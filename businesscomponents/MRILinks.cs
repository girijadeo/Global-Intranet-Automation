using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRAFT.SupportLibraries;
using System.Configuration;
using CRAFT.Uimap;
using Framework_Reporting;

namespace CRAFT.BusinessComponents
{
    /// <summary>
    /// Business Component Library template

    /// </summary>
    public class MRILinks : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;
        /// <summary>
        /// Constructor to initialize the business component library
        /// </summary>
        /// <param name="scriptHelper"> The ScriptHelper object passed from the DriverScript</param>
        public MRILinks(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
            common = new CommonComponents(ScriptHelper);
        }

        // *****************************************
        // Method ClickCommercialManagementLinkOnMainMenuItems()
        // Created On: 01/22/2018
        // Method Description : This method click on the 'Commercial Management' link option
        // Created By: Girija Deo
        // *****************************************
        public void ClickCommercialManagementLinkOnMainMenuItems()
        {
            try
            {
                if (common.CheckElement(MRImainMenuItemsOR.oCommercialManagement_xpath))
                {
                    Driver.FindElement(MRImainMenuItemsOR.oCommercialManagement_xpath).Click();
                    Report.UpdateTestLog("ClickCommercialManagementLinkOnMainMenuItems", "Commercial Management option is clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickCommercialManagementLinkOnMainMenuItems", "unable to find Commercial Management option ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickCommercialManagementLinkOnMainMenuItems", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        public void LaunchMRIURL()
        {
            try
            {
                string MRIURL = DataTable.GetData("General_Data_MRI", "URL");
                Driver.Navigate().GoToUrl(MRIURL);
                Report.UpdateTestLog("LaunchMRIURL", "Navigate to " + MRIURL, Status.PASS);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("LaunchMRIURL", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
    }
}
