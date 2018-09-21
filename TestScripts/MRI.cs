using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRAFT.SupportLibraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework_Core;

namespace CRAFT.TestScripts
{
    class MRI_Automation:TestCase
    {
        [TestMethod]
        [TestCategory("MRI")]

        public void TC_001()
        {
            testParameters.CurrentTestDescription = "Click the Commercial Management link";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
    }
}
