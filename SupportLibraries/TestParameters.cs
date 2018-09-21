using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework_Core;
using OpenQA.Selenium;

namespace CRAFT.SupportLibraries
{
    /// <summary>
    ///   Class to encapsulate various input parameters required for each test script
    /// </summary>
    public class SeleniumTestParameters : TestParameters
    {
        public SeleniumTestParameters(string currentScenario, string currentTestcase)
            : base(currentScenario, currentTestcase)
        {

        }

        /// <summary>
        ///  The browser for a specific test
        /// </summary>
        public Browser Browser { get; set; }

        /// <summary>
        ///  Function to get the browserVersion for a specific test
        /// </summary>
        public String BrowserVersion { get; set; }

        /// <summary>
        ///  Function to get the platform for a specific test
        /// </summary>
        public Platform Platform { get; set; }

        /// <summary>
        ///  Function to get the platform for a specific test
        /// </summary>
        public int TestCaseNo { get; set; }

    }
}
