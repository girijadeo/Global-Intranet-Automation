using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Framework_Core;
using Framework_DataTable;
using Framework_Reporting;
using Framework_Utilities;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace CRAFT.SupportLibraries
{

    /// <summary>
    ///  Driver script class which encapsulates the core logic of the CRAFT framework
    /// </summary>
    public class DriverScript
    {
        private List<String> _businessFlowData;
        private int _currentIteration, _currentSubIteration;
        private string _startTime, _endTime;
        private String _timeStamp;
        private String reportPath;

        private ReportSettings _reportSettings;
        
        private RemoteWebDriver _driver;


        private String _gridMode;
        private string _testStatus;

        public string TestStatus
        {
            get { return _testStatus; }
            set { _testStatus = value; }
        }

        /// <summary>
        /// The DataTable object
        /// </summary> 
        protected CraftDataTable dataTable;

        /// <summary>
        /// The Report object
        /// </summary> 
        protected SeleniumReport report;

        /// <summary>
        /// The ScriptHelper object
        /// </summary> 
        protected ScriptHelper scriptHelper;

        private FrameworkParameters _frameworkParameters = FrameworkParameters.Instance;

        /// <summary>
        ///  The TestParameters object
        /// </summary>
        protected SeleniumTestParameters testParameters;


        /// <summary>
        ///  Constructor to initialize the DriverScript
        /// </summary>
        public DriverScript(SeleniumTestParameters testParameters)
        {
            this.testParameters = testParameters;
        }

        private void SetRelativePath()
        {

            String relativePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (relativePath.Contains("bin"))
            {
                relativePath = relativePath.Substring(0, relativePath.IndexOf("bin"));
            }
            else
            {
                relativePath = relativePath.Substring(0, relativePath.IndexOf("TestResults"));
            }
            if (relativePath.Contains("allocator"))
            {
                relativePath = Directory.GetParent(relativePath).ToString();
            }
            _frameworkParameters.RelativePath = relativePath;
        }

        private void SetDefaultTestParameters()
        {

            string browser = ConfigurationManager.AppSettings["Browser"].ToLower();
            testParameters.Browser = (Browser)Enum.Parse(typeof(Browser), browser);
            testParameters.BrowserVersion = ConfigurationManager.AppSettings["DefaultBrowserVersion"];

            if (testParameters.IterationMode == null)

            {
                testParameters.IterationMode = IterationOptions.RunAllIterations;
            }
            //if (testParameters.Browser!=null)
            //{
            //    string browser = ConfigurationManager.AppSettings["Browser"].ToLower();
            //    testParameters.Browser = (Browser)Enum.Parse(typeof(Browser), browser);
            //    testParameters.BrowserVersion = ConfigurationManager.AppSettings["DefaultBrowserVersion"];
            //}
            if (testParameters.Platform == null)
            {
                testParameters.Platform = PlatformFactory.GetPlatform(ConfigurationManager.AppSettings["DefaultPlatform"]);
            }
        }

        /// <summary>
        /// Function which drives the test case execution (core logic of the framework)
        /// </summary>
        public void DriveTestExecution()
        {
            StartUp();
            InitializeWebDriver();
            InitializeTestIterations();
            InitializeTestReport();
            InitializeDatatable();
            InitializeTestScript();
            SetUp();
            try
            {
                ExecuteTestIterations();
            }
            catch (FrameworkException fx)
            {
                report.TestStatus = "Failed";
                ExceptionHandler(fx, fx.errorName);
            }
            catch (TargetInvocationException ix)
            {
                report.TestStatus = "Failed";
                ExceptionHandler((Exception) ix.InnerException, "Error");
            }
            catch (Exception ex)
            {
                report.TestStatus = "Failed";
                ExceptionHandler(ex, "Error");
            }
            finally
            {
                QuitWebDriver();
                WrapUp();
            }
        }

        /// <summary>
        /// Function that calls the basic start up functions  required
        /// </summary>
        private void StartUp()
        {
            _startTime = Util.GetCurrentTime();
            SetRelativePath();
            _frameworkParameters = FrameworkParameters.Instance;
            SetDefaultTestParameters();
        }

        private void InitializeWebDriver()
        {
            _startTime = Util.GetCurrentTime();

            _gridMode = ConfigurationManager.AppSettings["GridMode"];

            if (_gridMode.Equals("on", StringComparison.CurrentCultureIgnoreCase))
            {
                DesiredCapabilities desiredCapabilities = new DesiredCapabilities(testParameters.Browser.ToString(), testParameters.BrowserVersion, testParameters.Platform);

                Uri gridHubUrl;
                try
                {
                    gridHubUrl = new Uri(ConfigurationManager.AppSettings["GridHubUrl"]);
                }
                catch (Exception e)
                {

                    throw new FrameworkException("The specified Selenium Grid Hub URL is malformed");
                }

                _driver = new RemoteWebDriver(gridHubUrl, desiredCapabilities);
            }
            else
            {
                _driver = WebDriverFactory.GetDriver(testParameters.Browser);
            }
        }

        private void InitializeTestReport()
        {
            _frameworkParameters.RunConfiguration = ConfigurationManager.AppSettings["RunConfiguration"];
            _timeStamp = TimeStamp.GetInstance();

            InitializeReportSettings();

            string theme = ConfigurationManager.AppSettings["ReportTheme"];
            ReportTheme reportTheme =
                    ReportThemeFactory.GetReportsTheme((Framework_Reporting.ReportThemeFactory.Theme)Enum.Parse(typeof(Framework_Reporting.ReportThemeFactory.Theme), theme));

            report = new SeleniumReport(_reportSettings, reportTheme);

            report.InitializeReportTypes();
            report.Driver = _driver;

            report.InitializeTestLog();
            report.AddTestLogHeading(_reportSettings.ProjectName +
                                        " - " + _reportSettings.ReportName +
                                        " Automation Execution Results");
            report.AddTestLogSubHeading("Date & Time",
                                            ": " + Util.GetCurrentFormattedTime(ConfigurationManager.AppSettings["DateFormatString"]),
                                            "Iteration Mode", ": " + testParameters.IterationMode);
            report.AddTestLogSubHeading("Start Iteration", ": " + testParameters.StartIteration,
                                        "End Iteration", ": " + testParameters.EndIteration);

            if (_gridMode.Equals("on", StringComparison.CurrentCultureIgnoreCase))
            {
                report.AddTestLogSubHeading("Browser", ": " + testParameters.Browser,
                                                "Version", ": " + testParameters.BrowserVersion);
                report.AddTestLogSubHeading("Platform", ": " + testParameters.Platform.ToString(),
                                            "Application URL", ": " + ConfigurationManager.AppSettings["ApplicationUrl"]);
                

            }
            else
            {
                report.AddTestLogSubHeading("Browser", ": " + testParameters.Browser,
                                                "Application URL", ": " + ConfigurationManager.AppSettings["ApplicationUrl"]);
            }

            report.AddTestLogTableHeadings();
        }

        private void InitializeReportSettings()
        {
            reportPath = _frameworkParameters.RelativePath +
                                    Util.GetFileSeparator() + "Results" +
                                    Util.GetFileSeparator() + _timeStamp;

            _reportSettings = new ReportSettings(reportPath,
                                                    testParameters.CurrentScenario +
                                                    "_" + testParameters.CurrentTestcase);

            _reportSettings.DateFormatString = ConfigurationManager.AppSettings["DateFormatString"];
            _reportSettings.LogLevel = Convert.ToInt32(ConfigurationManager.AppSettings["LogLevel"]);
            _reportSettings.ProjectName = ConfigurationManager.AppSettings["ProjectName"];
            _reportSettings.GenerateExcelReports =
                    Boolean.Parse(ConfigurationManager.AppSettings["ExcelReport"]);
            _reportSettings.GenerateHtmlReports =
                    Boolean.Parse(ConfigurationManager.AppSettings["HtmlReport"]);
            _reportSettings.IncludeTestDataInReport =
                    Boolean.Parse(ConfigurationManager.AppSettings["IncludeTestDataInReport"]);
            _reportSettings.TakeScreenshotFailedStep =
                    Boolean.Parse(ConfigurationManager.AppSettings["TakeScreenshotFailedStep"]);
            _reportSettings.TakeScreenshotPassedStep =
                    Boolean.Parse(ConfigurationManager.AppSettings["TakeScreenshotPassedStep"]);
        }

        private void InitializeDatatable()
        {
            String datatablePath = _frameworkParameters.RelativePath +
                                        Util.GetFileSeparator() + "Datatables";

            String runTimeDatatablePath;
            if (_reportSettings.IncludeTestDataInReport)
            {
                runTimeDatatablePath = reportPath + Util.GetFileSeparator() + "Datatables";
                if (!File.Exists(runTimeDatatablePath + Util.GetFileSeparator() + testParameters.CurrentScenario + ".xls"))
                {
                    try
                    {
                        File.Copy(datatablePath + Util.GetFileSeparator() + testParameters.CurrentScenario + ".xls", runTimeDatatablePath + Util.GetFileSeparator() + testParameters.CurrentScenario + ".xls");
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.StackTrace);
                        throw new FrameworkException("Error in creating run-time datatable: Copying the datatable failed...");
                    }
                }

                if (!File.Exists(runTimeDatatablePath + Util.GetFileSeparator() + "Common Testdata.xls"))
                {
                    try
                    {
                        File.Copy(datatablePath + Util.GetFileSeparator() + "Common Testdata.xls", runTimeDatatablePath + Util.GetFileSeparator() + "Common Testdata.xls");
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.StackTrace);

                        throw new FrameworkException("Error in creating run-time datatable: Copying the common datatable failed...");
                    }
                }
            }
            else
            {
                runTimeDatatablePath = datatablePath;
            }

            dataTable = new CraftDataTable(runTimeDatatablePath, testParameters.CurrentScenario);
        }

        private void InitializeTestScript()
        {
            report.TestCaseNo = testParameters.TestCaseNo;
            report.TestEnvironment = ConfigurationManager.AppSettings["Environment"];
            report.WorkItemUrl = ConfigurationManager.AppSettings["WorkItemURL"];
            report.TfsUrl = ConfigurationManager.AppSettings["TfsUrl"];
            report.TfsProj = ConfigurationManager.AppSettings["TfsProj"];
            report.ManageBugs = ConfigurationManager.AppSettings["Managebug"];
            report.UpdateTotalScenariosCount();
            scriptHelper = new ScriptHelper(dataTable, report, _driver);

            _businessFlowData = GetBusinessFlow();
        }

        private List<String> GetBusinessFlow()
        {
            ExcelDataAccess businessFlowAccess =
                    new ExcelDataAccess(_frameworkParameters.RelativePath +
                                            Util.GetFileSeparator() + "Datatables",
                                            testParameters.CurrentScenario);
            businessFlowAccess.DatasheetName = "Business_Flow";

            int rowNum = businessFlowAccess.GetRowNum(testParameters.CurrentTestcase, 0);
            if (rowNum == -1)
            {
                throw new FrameworkException("The test case \"" + testParameters.CurrentTestcase + "\" is not found in the Business Flow sheet!");
            }

            String dataValue;
            List<String> businessFlowData = new List<String>();
            int currentColumnNum = 1;
            while (true)
            {
                dataValue = businessFlowAccess.GetValue(rowNum, currentColumnNum);
                if (dataValue.Equals(""))
                {
                    break;
                }
                businessFlowData.Add(dataValue);
                currentColumnNum++;
            }

            if (businessFlowData.Count() == 0)
            {
                throw new FrameworkException("No business flow found against the test case \"" + testParameters.CurrentTestcase + "\"");
            }

            return businessFlowData;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void InitializeTestIterations()
        {
            int nTestcaseRows = 1;
            int nSubIterations = 1;

            switch (testParameters.IterationMode)
            {
                case IterationOptions.RunAllIterations:

                    String datatablePath = _frameworkParameters.RelativePath +
                                            Util.GetFileSeparator() + "Datatables";
                    ExcelDataAccess testDataAccess =
                            new ExcelDataAccess(datatablePath, testParameters.CurrentScenario);
                    testDataAccess.DatasheetName = ConfigurationManager.AppSettings["DefaultDataSheet"];

                    int startRowNum = testDataAccess.GetRowNum(testParameters.CurrentTestcase, 0);
                    nTestcaseRows = testDataAccess.GetRowCount(testParameters.CurrentTestcase, 0, startRowNum);
                    nSubIterations = testDataAccess.GetRowCount("1", 1, startRowNum);	// Assumption: Every test case will have at least one iteration
                    int nIterations = nTestcaseRows / nSubIterations;
                    testParameters.EndIteration = nIterations;
                    _currentIteration = 1;
                    break;


                case IterationOptions.RunOneIterationOnly:
                    _currentIteration = 1;
                    break;

                case IterationOptions.RunRangeOfIterations:
                    if (testParameters.StartIteration > testParameters.EndIteration)
                    {
                        throw new FrameworkException("Error", "StartIteration cannot be greater than EndIteration!");
                    }
                    _currentIteration = testParameters.StartIteration;
                    break;
            }
        }
        /// <summary>
        ///  Function to do required setup activities before starting the test execution
        /// </summary>
        protected void SetUp()
        {
            _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
           // _driver.Url = ConfigurationManager.AppSettings["ApplicationUrl"];
        }

        private void ExecuteTestIterations()
        {
            while (_currentIteration <= testParameters.EndIteration)
            {
                report.AddTestLogSection("Iteration: " + _currentIteration.ToString());

                try
                {
                    ExecuteTestcase(_businessFlowData);
                }
                catch (FrameworkException fx)
                {
                    ExceptionHandler(fx, fx.errorName);
                }
                catch (Exception ix)
                {
                    ExceptionHandler(ix, "Error");
                } //catch (Exception ex) {
                //    ExceptionHandler(ex, "Error");
                //} 

                _currentIteration++;
            }
        }
        // Previous Method with dictionary

    /*    private void ExecuteTestcase(List<String> businessFlowData)
        {
            Dictionary<String, int> keywordDirectory = new Dictionary<String, int>();

            for (int currentKeywordNum = 0; currentKeywordNum < businessFlowData.Count(); currentKeywordNum++)
            {
                String[] currentFlowData = businessFlowData[currentKeywordNum].Split(",".ToCharArray());
                String currentKeyword = currentFlowData[0];

                int nKeywordIterations;
                if (currentFlowData.Length > 1)
                {
                    nKeywordIterations = Convert.ToInt32(currentFlowData[1]);
                }
                else
                {
                    nKeywordIterations = 1;
                }

                for (int currentKeywordIteration = 0; currentKeywordIteration < nKeywordIterations; currentKeywordIteration++)
                {
                    if (keywordDirectory.ContainsKey(currentKeyword))
                    {
                        keywordDirectory.Add(currentKeyword, keywordDirectory[currentKeyword] + 1);
                    }
                    else
                    {
                        keywordDirectory.Add(currentKeyword, 1);
                    }
                    _currentSubIteration = keywordDirectory[currentKeyword];

                    dataTable.SetCurrentRow(testParameters.CurrentTestcase, _currentIteration, _currentSubIteration);

                    if (_currentSubIteration > 1)
                    {
                        report.AddTestLogSubSection(currentKeyword + " (Sub-Iteration: " + _currentSubIteration + ")");
                    }
                    else
                    {
                        report.AddTestLogSubSection(currentKeyword);
                    }

                    // check the quite status of driver
                    bool f = CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus;
                    if (f == true)
                    {
                        InvokeBusinessComponent(currentKeyword);
                    }

                }
            }
        }*/

     // Updated Method with List

        private void ExecuteTestcase(List<String> businessFlowData)
        {
            var keywordList = new List<string>();
            for (int currentKeywordNum = 0; currentKeywordNum < businessFlowData.Count(); currentKeywordNum++)
            {
                var isIterate = false;
                String[] currentFlowData = businessFlowData[currentKeywordNum].Split(",".ToCharArray());
                String currentKeyword = currentFlowData[0];
                int nKeywordIterations;
                if (currentFlowData.Length > 1)
                {
                    nKeywordIterations = Convert.ToInt32(currentFlowData[1]);
                }
                else
                {
                    nKeywordIterations = 1;
                }
                for (int currentKeywordIteration = 0; currentKeywordIteration < nKeywordIterations; currentKeywordIteration++)
                {
                    keywordList.Add(currentKeyword);
                    _currentSubIteration = 1;

                    dataTable.SetCurrentRow(testParameters.CurrentTestcase, _currentIteration, _currentSubIteration);
                    report.AddTestLogSubSection(currentKeyword);
                    // check the quite status of driver
                    bool f = CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus;
                    if (f == true)
                    {
                        InvokeBusinessComponent(currentKeyword);
                    }

                }
            }
        }
        
        private void InvokeBusinessComponent(String currentKeyword)
        {
            bool methodFound = false;
            Assembly asm = Assembly.GetExecutingAssembly();

            foreach (Type type in asm.GetTypes())
            {
                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    if (method.Name.ToLower().Equals(currentKeyword.ToLower()))
                    {
                        methodFound = true;
                        Type[] types = new Type[1];
                        types[0] = typeof(ScriptHelper);


                        ConstructorInfo ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null,
                                        CallingConventions.HasThis, types, null);
                        if (ctor != null)
                        {
                            object[] argVals = new object[] { scriptHelper };
                            object instance = ctor.Invoke(argVals);

                            MethodInfo methodInfo = method;
                            object[] parameters = new object[] { };
                            methodInfo.Invoke(instance, parameters);

                        }
                    }
                    if (methodFound) break;
                }
                if (methodFound) break;
            }

            if (!methodFound)
            {
                //Error reporting
                throw new FrameworkException("Keyword " + currentKeyword + " not found within any class inside the businesscomponents");
            }
        }


        private void ExceptionHandler(Exception ex, String exceptionName)
        {
            // Error reporting
            String exceptionDescription = ex.Message;
            if (exceptionDescription == null)
            {
                exceptionDescription = ex.ToString();
            }

            if (ex.Source != null)
            {
                report.UpdateTestLog(exceptionName, exceptionDescription + " <b>Caused by: </b>" +
                                                                            ex.Source, Status.FAIL);
            }
            else
            {
                report.UpdateTestLog(exceptionName, exceptionDescription, Status.FAIL);
            }
            Console.WriteLine(ex.StackTrace);

            // Error response
            if (_frameworkParameters.StopExecution)
            {
                report.UpdateTestLog("CRAFT Info",
                        "Test execution terminated by user! All subsequent tests aborted...",
                        Status.DONE);
            }
            else
            {
                string obj = ConfigurationManager.AppSettings["OnError"];
                OnError onError = (OnError)Enum.Parse(typeof(OnError), obj);
                switch (onError)
                {
                    case OnError.NextIteration:
                        report.UpdateTestLog("CRAFT Info",
                                "Test case iteration terminated by user! Proceeding to next iteration (if applicable)...",
                                Status.DONE);
                        _currentIteration++;
                        ExecuteTestIterations();
                        break;

                    case OnError.NextTestCase:
                        report.UpdateTestLog("CRAFT Info",
                                "Test case terminated by user! Proceeding to next test case (if applicable)...",
                                Status.DONE);
                        break;

                    case OnError.Stop:
                        _frameworkParameters.StopExecution = true;
                        report.UpdateTestLog("CRAFT Info",
                                "Test execution terminated by user! All subsequent tests aborted...",
                                Status.DONE);
                        break;
                }
            }

            // Wrap up execution
            QuitWebDriver();
            WrapUp();
        }

        /// <summary>
        /// Function to do required teardown activities at the end of the test execution
        /// </summary>
        protected void QuitWebDriver()
        {
            _driver.Quit();
        }

        private void WrapUp()
        {
            _endTime = Util.GetCurrentTime();
            CloseTestReport();
            _testStatus = report.TestStatus;
            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = true;
            if (report.TestStatus.Equals("Failed", StringComparison.CurrentCultureIgnoreCase))
            {
                Assert.Fail(report.FailureDescription);
            }
            
        }

        private void CloseTestReport()
        {
            string executionTime = Util.GetTimeDifference(Convert.ToDateTime(_startTime), Convert.ToDateTime(_endTime));
            report.AddTestLogFooter(executionTime);
        }
    }




}





