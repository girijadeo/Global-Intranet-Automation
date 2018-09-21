using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework_Reporting;
using OpenQA.Selenium;
using CRAFT.SupportLibraries;
using System.Configuration;

namespace CRAFT.BusinessComponents
{
    /// <summary>
    ///Functional Components class
    /// </summary>
    public class FunctionalComponents : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        /// <summary>
        ///  Constructor to initialize the component library
        /// </summary>
        /// <param name="scriptHelper">The ScriptHelper object passed from the DriverScript</param>
        public FunctionalComponents(ScriptHelper scriptHelper) : base(scriptHelper)
        {

        }
    }



}
