using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CRAFT.SupportLibraries;
using Framework_Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutoItX3Lib;
using System.Configuration;


namespace CRAFT.BusinessComponents
{

    /// <summary>
    /// Business Component Library template
    
    /// </summary>
    public class CommonComponents : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        // this flag check the status of the connected driver. 
        
        /// <summary>
        /// Constructor to initialize the business component library
        /// </summary>
        /// <param name="scriptHelper"> The ScriptHelper object passed from the DriverScript</param>
        public CommonComponents(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {

        }

        // *****************************************
        // Method CheckElement()
        // Method Description : This method will Click web element visible or not
        // Created On: 01/11/2017
        // Created By: GI offShore Team
        // *****************************************

        public bool CheckElement(By by)
        {
            try
            {
                if (Driver.FindElement(by).Displayed == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        // *****************************************
        // Method MaximizeBrowsers()
        // Method Description : This method will maximize the browser
        // Created On: 01/11/2017
        // Created By: GI offShore Team
        // *****************************************
        public void MaximizeBrowsers()
        {
            try
            {
                //CRAFT.BusinessComponents.CommonComponents.driverquitestatus = true;
                String url = DataTable.GetData("General_Data_" + Env, "URL");
                Driver.Url = url;
                CallMeWait(1000);
                var AutoIT = new AutoItX3();
                AutoIT.WinActivate("Authentication Required");
                AutoIT.Send(DataTable.GetData("General_Data_" + Env, "UserName"));
                AutoIT.Send("{TAB}");
                AutoIT.Send(DataTable.GetData("General_Data_" + Env, "Password"));
                AutoIT.Send("{ENTER}");
                Report.UpdateTestLog("MaximizeBrowsers", " Open URL " + url+ " in browser", Status.PASS);
                Driver.Manage().Window.Maximize();
                CallMeWait(1000);
                Report.UpdateTestLog("MaximizeBrowsersFinalStep", " Successfully maximize the browser", Status.PASS);
               // popup();
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("MaximizeBrowsers", "Error in MaximizeBrowsers "+e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method CallMeWait()
        // Method Description : This method will go delay the execution
        // Created On: 01/11/2017
        // Created By: GI offShore Team
        // *****************************************
        public void CallMeWait(int time)
        {
            Thread.Sleep(time);
        }

        // *****************************************
        // Method WaitForElement()
        // Method Description : This method will wait for maximum 1 min for an element.
        // Created On: 01/11/2017
        // Created By: GI offShore Team
        // *****************************************

        public void WaitForElement(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
                wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("WaitForElement", " Element is not appeared in 60 seconds " , Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method UploadeFile()
        // Method Description : This method will upload a file
        // Created On: 01/13/2017
        // Created By: GI offShore Team
        // Note: Please import  System.Windows.Forms;
        // *****************************************
        public void UploadeFile(string temppath)
        {
            try
            {
                SendKeys.SendWait(temppath);
                CallMeWait(2000);
                SendKeys.SendWait(@"{Enter}");
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("UploadeFile", e.ToString(), Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: popup()
        // Method Decs:  This method will  handle profile update window
        // Created on: 04/07/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void popup()
        {
            try
            {
                //common.WaitForElement(By.XPath("//input[@value='OK']"));
                if (CheckElement(By.XPath("//input[@value='OK']")) == true)
                {
                    Driver.FindElement(By.XPath("//input[@value='OK']")).Click();
                    Report.UpdateTestLog("popup", "clicked ok ", Status.PASS);
                    CallMeWait(2000);
                }
                if (CheckElement(By.XPath("//input[@value='ACCEPT']")) == true)
                {
                    Driver.FindElement(By.XPath("//input[@value='ACCEPT']")).Click();
                    Report.UpdateTestLog("popup", "clicked accept", Status.PASS);
                    CallMeWait(2000);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("popup", "unable to handlw pop up :  " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("popup", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


    }
}
