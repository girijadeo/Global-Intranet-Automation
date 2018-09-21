using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Framework_Utilities;
using Framework_Core;
using System.Runtime;
using System.Threading;
using System.Reflection;
using Framework_Reporting;
using CRAFT.SupportLibraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRAFT.Allocator
{

    /// <summary>
    ///  Class to facilitate parallel execution of test scripts
    /// </summary>
    public class ParallelRunner
    {
        private FrameworkParameters _frameworkParameters = FrameworkParameters.Instance;
        private SeleniumTestParameters _testParameters;
        private DateTime _startTime, _endTime;
        private String _testStatus;

        private SeleniumReport _report;


        /// <summary>
        /// Constructor to initialize the details of the test case to be executed
        /// </summary>
        /// <param name="testParameters">The TestParameters object (passed from the Allocator)</param>
        /// <param name="report">The SeleniumReport object (passed from the Allocator)</param>
        public ParallelRunner(SeleniumTestParameters testParameters, SeleniumReport report)
        {
            _testParameters = testParameters;
            _report = report;
        }


        public void Run()
        {
            _startTime = Convert.ToDateTime(Util.GetCurrentTime());
            _testStatus = InvokeTestScript(_testParameters);
            _endTime = Convert.ToDateTime(Util.GetCurrentTime());
            String executionTime = Util.GetTimeDifference(_startTime, _endTime);
            _report.UpdateResultSummary(_testParameters.CurrentScenario,
                                        _testParameters.CurrentTestcase,
                                        _testParameters.CurrentTestDescription,
                                        executionTime, _testStatus);
        }

        private String InvokeTestScript(SeleniumTestParameters testParameters)
        {
            string testStatus;
            FrameworkParameters frameworkParameters = FrameworkParameters.Instance;

            if (frameworkParameters.StopExecution)
            {
                testStatus = "Test Execution Aborted";
            }
            else
            {
                DriverScript driverScript = new DriverScript(testParameters);
                try
                {
                    driverScript.DriveTestExecution();
                }
                catch (AssertFailedException ex)
                {
                    testStatus = "Failed";
                }
                testStatus = driverScript.TestStatus;
            }

            return testStatus;

        }

        public void ThreadPoolCallBack(Object doneEvent)
        {
            try
            {
                //Calling thread execution method
                Run();

                //Setting the thread execution completion
                ManualResetEvent _doneEvent = (ManualResetEvent)doneEvent;
                _doneEvent.Set();
            }
            catch (Exception ex)
            {
                throw new FrameworkException("Error occured while executing a thread");
            }
        }
    }
}






