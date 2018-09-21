using System;
using System.Collections.Generic;
using System.Security;
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
using System.Text;


namespace CRAFT.SupportLibraries
{

    /// <summary>
    /// Abstract base class for all the test cases to be automated
    /// Author: Cognizant
    /// </summary>
    [TestClass]
    public abstract class TestCase : ResultSummaryManager
    {
        /// <summary>
        /// The SeleniumTestParameters object to be used to specify the test parameters
        /// </summary>
        protected static SeleniumTestParameters testParameters;

        /// <summary>
        /// The DriverScript object to be used to execute the required test case
        /// </summary>
        protected DriverScript driverScript;

        private string _startTime, _endTime;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            SetRelativePath();
            InitializeTestBatch();
            InitializeSummaryReport();
            try
            {
                SetupErrorLog();
            }
            catch (FileNotFoundException e)
            {
                throw new FrameworkException("Error while setting up the Error log!");
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            if (frameworkParameters.StopExecution)
            {
                AssemblyCleanup();
                //throw new SkipException("Aborting all subsequent tests!");
            }
            _startTime = Util.GetCurrentTime();
            string currentScenario = this.GetType().Name;
            string currentTestcase = testContextInstance.TestName;
            testParameters = new SeleniumTestParameters(currentScenario, currentTestcase);
            string[] tcName = Regex.Split(currentTestcase, "_");
            if (tcName.Length == 2)
            {
                int testCase = 0;
                if (int.TryParse(tcName[1], out testCase))
                {
                    testParameters.TestCaseNo = testCase;
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            string testStatus = driverScript.TestStatus;
            _endTime = Util.GetCurrentTime();
            string executionTime = Util.GetTimeDifference(Convert.ToDateTime(_startTime), Convert.ToDateTime(_endTime));
            report.UpdateResultSummary(testParameters.CurrentScenario,
                                        testParameters.CurrentTestcase,
                                        testParameters.CurrentTestDescription,
                                        executionTime, testStatus);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            WrapUp();
            LaunchResultSummary();
        }
    }
}