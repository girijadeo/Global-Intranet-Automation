using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Framework_Core;
using Framework_Reporting;
using Framework_Utilities;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using CRAFT.SupportLibraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRAFT.Allocator
{
    /// <summary>
    /// Class to manage the batch execution of test scripts within the framework
    /// </summary>
    [TestClass]
    
    public class Allocator : ResultSummaryManager
    {
        private static List<SeleniumTestParameters> _testInstancesToRun;

        [TestMethod]
        public void DriveBatchExecution()
        {
            int nThreads = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfThreads"]);
            //ExecutorService parallelExecutor = Executors.newFixedThreadPool(nThreads);
            //ThreadPool.SetMaxThreads(nThreads, 0);
            InitializeTestBatch();
            ManualResetEvent[] doneEvents = new ManualResetEvent[nThreads];
            int i = 0;
            for (int currentTestInstance = 0; currentTestInstance < _testInstancesToRun.Count(); currentTestInstance++)
            {
                if (i < nThreads)
                {
                    doneEvents[i] = new ManualResetEvent(false);
                    ParallelRunner testRunner = new ParallelRunner(_testInstancesToRun[currentTestInstance], report);
                    ThreadPool.QueueUserWorkItem(testRunner.ThreadPoolCallBack, (object)doneEvents[i]);
                    //parallelExecutor.execute(testRunner);

                    if (frameworkParameters.StopExecution)
                    {
                        break;
                    }
                    i++;
                }
                //If the thread count reaches the ini thread count then wait for completion of any one thread
                if (i == nThreads && nThreads > 1)
                {
                    WaitHandle.WaitAny(doneEvents);
                    i--;
                }
                else if (nThreads == 1)
                {
                    WaitHandle.WaitAll(doneEvents);
                    i--;
                }
            }
            //Wait for all threads to complete their execution before proceeding to next step
            WaitHandle.WaitAll(doneEvents);
        }

        private static void InitializeTestBatch()
        {
            _testInstancesToRun = GetRunInfo(ConfigurationManager.AppSettings["RunConfiguration"]);
        }

        private static List<SeleniumTestParameters> GetRunInfo(String sheetName)
        {
            ExcelDataAccess runManagerAccess = new ExcelDataAccess(frameworkParameters.RelativePath, "Run Manager");
            runManagerAccess.DatasheetName = sheetName;

            int nTestInstances = runManagerAccess.GetLastRowNum();
            List<SeleniumTestParameters> testInstancesToRun = new List<SeleniumTestParameters>();

            for (int currentTestInstance = 1; currentTestInstance <= nTestInstances; currentTestInstance++)
            {
                String executeFlag = runManagerAccess.GetValue(currentTestInstance, "Execute");
                //Manik
                //string Env = ConfigurationManager.AppSettings["Environment"];
                //
                if (executeFlag.Equals("Yes", StringComparison.CurrentCultureIgnoreCase))
                {

                    string currentScenario = runManagerAccess.GetValue(currentTestInstance, "Test_Scenario");
                   //Manik
                    //string currentScenario = currentScenario1 + Env;
                    //Manik
                    string currentTestcase = runManagerAccess.GetValue(currentTestInstance, "Test_Case");
                    SeleniumTestParameters testParameters = new SeleniumTestParameters(currentScenario, currentTestcase);

                    testParameters.CurrentTestDescription = runManagerAccess.GetValue(currentTestInstance, "Description");

                    testParameters.IterationMode = (IterationOptions)Enum.Parse(typeof(IterationOptions), runManagerAccess.GetValue(currentTestInstance, "Iteration_Mode"));
                    String startIteration = runManagerAccess.GetValue(currentTestInstance, "Start_Iteration");
                    if (!startIteration.Equals(""))
                    {
                        testParameters.StartIteration = Convert.ToInt32(startIteration);
                    }
                    String endIteration = runManagerAccess.GetValue(currentTestInstance, "End_Iteration");
                    if (!endIteration.Equals(""))
                    {
                        testParameters.EndIteration = Convert.ToInt32(endIteration);
                    }

                    String browser = runManagerAccess.GetValue(currentTestInstance, "Browser");
                    if (!browser.Equals(""))
                    {
                        testParameters.Browser = (Browser)Enum.Parse(typeof(Browser), browser);
                    }
                    String browserVersion = runManagerAccess.GetValue(currentTestInstance, "Browser_Version");
                    if (!browserVersion.Equals(""))
                    {
                        testParameters.BrowserVersion = browserVersion;
                    }
                    String platform = runManagerAccess.GetValue(currentTestInstance, "Platform");
                    if (!platform.Equals(""))
                    {
                        testParameters.Platform = PlatformFactory.GetPlatform(platform);
                    }

                    testInstancesToRun.Add(testParameters);
                }
            }

            return testInstancesToRun;
        }

    }
}






