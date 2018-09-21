using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRAFT.SupportLibraries;
using System.IO;
using System.Data;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Data.OleDb;
using System.Reflection;
using Framework_Core;
using Framework_Reporting;
using Framework_Utilities;
using System.Configuration;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;




/// <summary>
/// Abstract class that manages the result summary creation during a batch execution
/// author Cognizant
/// </summary>
public abstract class ResultSummaryManager
{
    protected static SeleniumReport report;
    private static ReportSettings _reportSettings;

    private static string _overallStartTime, _overallEndTime;
    private static string _timeStamp;
    private static string _reportPath;

    protected static FrameworkParameters frameworkParameters =
                            FrameworkParameters.Instance;


    protected static void SetRelativePath()
    {
        string relativePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (relativePath.Contains("bin"))
        {
            relativePath = relativePath.Substring(0, relativePath.IndexOf("bin"));
        }
        else
        {
            relativePath = relativePath.Substring(0, relativePath.IndexOf("TestResults"));
        }
        frameworkParameters.RelativePath = relativePath;
    }

    protected static void InitializeTestBatch()
    {
        _overallStartTime = Util.GetCurrentTime();
    }

    protected static void InitializeSummaryReport()
    {
        frameworkParameters.RunConfiguration = ConfigurationManager.AppSettings["RunConfiguration"];
        _timeStamp = TimeStamp.GetInstance();
        InitializeReportSettings();
        ReportTheme reportTheme =
                ReportThemeFactory.GetReportsTheme((Framework_Reporting.ReportThemeFactory.Theme)Enum.Parse(typeof(Framework_Reporting.ReportThemeFactory.Theme), ConfigurationManager.AppSettings["ReportTheme"]));
        report = new SeleniumReport(_reportSettings, reportTheme);
        report.InitializeReportTypes();
        report.InitializeResultSummary();
        report.WorkItemUrl = ConfigurationManager.AppSettings["WorkItemURL"];
        CreateResultSummaryHeader();
    }

    protected static void InitializeReportSettings()
    {
        _reportPath = Path.Combine(frameworkParameters.RelativePath, "Results", _timeStamp);
        _reportSettings = new ReportSettings(_reportPath, "");

        _reportSettings.DateFormatString = (ConfigurationManager.AppSettings["DateFormatString"]);
        _reportSettings.ProjectName = (ConfigurationManager.AppSettings["ProjectName"]);
        _reportSettings.GenerateExcelReports = Convert.ToBoolean(ConfigurationManager.AppSettings["ExcelReport"]);
        _reportSettings.GenerateHtmlReports = Convert.ToBoolean(ConfigurationManager.AppSettings["HtmlReport"]);
        _reportSettings.LinkTestLogsToSummary = true;
        
    }

    protected static void CreateResultSummaryHeader()
    {
        report.AddResultSummaryHeading(_reportSettings.ProjectName +
                                            " - " + " Automation Execution Result Summary");
        report.AddResultSummarySubHeading("Application",
                                ": " + ConfigurationManager.AppSettings["ProjectName"],
                                "OnError", ": " + ConfigurationManager.AppSettings["OnError"]);
        report.AddResultSummarySubHeading("Run Configuration",
                                ": " + ConfigurationManager.AppSettings["RunConfiguration"],
                                "No. of threads", ": " + ConfigurationManager.AppSettings["NumberOfThreads"]);
        report.AddResultSummarySubHeading("Environment",
                                ": " + ConfigurationManager.AppSettings["Environment"],
                                "Browser", ": " + ConfigurationManager.AppSettings["Browser"]);
        report.AddResultSummarySubHeading("VDI",
                                ": " + ConfigurationManager.AppSettings["VDI"],
                                "Run Mode", ": " + ConfigurationManager.AppSettings["RunMode"]);


        report.AddResultSummarySubHeading("Types Of Test",
                                ": " + ConfigurationManager.AppSettings["TypeOfTest"],
                                "Module(s)", ": " + ConfigurationManager.AppSettings["Module"]);
        report.AddResultSummarySubHeading("App Version",
                                ": " + ConfigurationManager.AppSettings["AppVersion"],
                                "Sprint/Release", ": " + ConfigurationManager.AppSettings["SprintRelease"]);
        report.AddResultSummarySubHeading("Environment",
                                ": " + ConfigurationManager.AppSettings["Environment"],
                                "OS Version", ": " + Environment.OSVersion.Version + "|" + Environment.OSVersion.Platform );// ConfigurationManager.AppSettings["OSVersion"]); // can be may be dynamic
        report.AddResultSummarySubHeading("Cycle Session ID", ": " + DateTime.Now.ToString("yyMMddHHmmssff"),"","");
        report.AddResultSummaryTableHeadings();
    }


    protected static void SetupErrorLog()
    {
        String errorLogFile = _reportPath + Util.GetFileSeparator() + "ErrorLog.txt";
        if (!File.Exists(errorLogFile))
            File.Create(errorLogFile);
    }

    protected static void WrapUp()
    {
        _overallEndTime = Util.GetCurrentTime();
        TimeSpan span;
        DateTime End = Convert.ToDateTime(_overallEndTime);
        DateTime Start = Convert.ToDateTime(_overallStartTime);
        if (End > Start)
        {
            span = End - Start;
        }
        else
        {
            End = End.AddDays(1);
            span = End - Start;
        }
        string totalExecutionTime = String.Format("{0} hrs, {1} mins, {2} secs", span.Hours, span.Minutes, span.Seconds);
        //Dictionary<String, int> dataDict = report.AddResultSummaryFooter(totalExecutionTime);
        _overallStartTime = Start.ToString("dd-MMM-yyyy hh:mm:ss tt");
        _overallEndTime = End.ToString("dd-MMM-yyyy hh:mm:ss tt");
        Dictionary<String, int> dataDict = report.UpdateFinalReport(_overallStartTime,_overallEndTime,totalExecutionTime);
        //Console.WriteLine("Starttime :" + dataDict["Passed"]);

        
        if (ConfigurationManager.AppSettings["PostDataToDevops"] == "Yes")
        {
            PostData(dataDict);
            
        }
     
       
        
    }

   protected static void PostData(Dictionary<String, int> dataDict)
    {
        // Creating Json data
        try
        {
            dynamic jsondata1 = new JObject();
            jsondata1.ApplicationId = 13;
            jsondata1.AutomationProcessId = 14;
            jsondata1.AutomationToolId = 19;
            jsondata1.Version = 4.0;
            jsondata1.Cycle = "2.5.2.1";
            jsondata1.Description = "Regression";
            jsondata1.Passed = dataDict["Passed"];
            jsondata1.Failed = dataDict["Failed"];
            jsondata1.Blocked = 0;
            jsondata1.StartDateTime = Convert.ToDateTime(_overallStartTime).GetDateTimeFormats('s')[0];
            jsondata1.EndDateTime = Convert.ToDateTime(_overallEndTime).GetDateTimeFormats('s')[0];
            jsondata1.Metadata = "";

            //Initializing the client
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://devopsmetricsservice.azurewebsites.net/api/metrics/");
            //Creating the content
            var content = new StringContent(jsondata1.ToString(), Encoding.UTF8, "application/json");

            StreamWriter file2 = new StreamWriter("c:\\ResponseFile2.txt");
            file2.WriteLine(jsondata1);
            file2.Close();


            //Posting the data to database
            var response = client.PostAsync("submit", content).Result;
            // StreamWriter file1 = new StreamWriter("c:\\ResponseFile.txt");
            //file1.WriteLine(response);
            //file1.Close();
        }
        catch (Exception e)
        {
            StreamWriter file1 = new StreamWriter("c:\\ResponseFile.txt");
            file1.WriteLine(e.StackTrace);
            file1.Close();
            Console.WriteLine(e.StackTrace);
        }
    }

    protected static void LaunchResultSummary()
    {
        
       
        if (_reportSettings.GenerateHtmlReports)
        {
            try
            {
                Process.Start("RunDLL32.EXE",
                    "shell32.dll,ShellExec_RunDLL " + _reportPath + "\\HTML Results\\SummaryMail.html");

                if (ConfigurationManager.AppSettings["SendMail"] == "Yes") 
                    Email();
            }
            catch (IOException e)
            {
                throw new FrameworkException("Error opening Result file");
            }
        }
        else if (_reportSettings.GenerateExcelReports)
        {
            try
            {
                Process.Start("RunDLL32.EXE",
                              "shell32.dll,ShellExec_RunDLL " + _reportPath + "\\Excel Results\\Summary.xls");
                if (ConfigurationManager.AppSettings["SendMail"] == "Yes") 
                    Email();
            }
            catch (IOException e)
            {
                throw new FrameworkException("Error opening Result file");
            }
        }
    }


    public static void Email()
    {
        try
        {

            string recepientEmail;
            string subject;
            string body;
            int port = int.Parse(ConfigurationManager.AppSettings["MailPort"]);
            string host = ConfigurationManager.AppSettings["MailHost"];
            string mailFrom = ConfigurationManager.AppSettings["MailFrom"];
            string mailTo1 = ConfigurationManager.AppSettings["MailTo1"];
            string mailTo2 = ConfigurationManager.AppSettings["MailTo2"];
            string mailTo3 = ConfigurationManager.AppSettings["MailTo3"];
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    string resultLink = _reportPath + "\\HTML Results\\Summary.html";
                    using (StreamReader reader = new StreamReader(resultLink)) 
                    {
                        body = reader.ReadToEnd();
                    }
                    mailMessage.From = new MailAddress(mailFrom);
                    mailMessage.Subject = "AUTOMATED EXECUTION SUMMARY -GLOBAL INTRANET";
                    mailMessage.Body = body;
                    
                    mailMessage.IsBodyHtml = true;
                    String[] email = mailTo1.Split(';');
                    foreach (var eachmail in email)
                    {
                        mailMessage.To.Add(new MailAddress(eachmail));
                    }
                    
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = host;
                    smtp.UseDefaultCredentials = true;
                    smtp.Port = port; 
                    smtp.Send(mailMessage);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in Email method" +e);
        }
    }

    protected static void UploadTestResultsToTFS(string testCaseResultFileName)
    {
        //Write the path of HTML result file to Registry
        RegistryKey regKey = null;
        regKey = Registry.CurrentUser;
        regKey = regKey.CreateSubKey("Software\\Craft-VSTS\\Config");
        if (_reportSettings.GenerateHtmlReports)
        {
            try
            {
                regKey.SetValue("ResultPath", _reportPath + "\\HTML Results\\" + testCaseResultFileName + ".html");
            }
            catch (Exception ex)
            {
                throw new FrameworkException("Error writing into registry. Access Denied");
            }
        }
        else if (_reportSettings.GenerateExcelReports)
        {
            try
            {
                regKey.SetValue("ResultPath", _reportPath + "\\Excel Results\\" + testCaseResultFileName + ".xls");
            }
            catch (Exception ex)
            {
                throw new FrameworkException("Error writing into registry. Access Denied");
            }
        }
    }
}