using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CRAFT.SupportLibraries;
using CRAFT.Uimap;
using Framework_Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;


namespace CRAFT.BusinessComponents
{

    /// <summary>
    /// Business Component Library template

    /// </summary>
    public class VisitorProfile : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;
        /// <summary>
        /// Constructor to initialize the business component library
        /// </summary>
        /// <param name="scriptHelper"> The ScriptHelper object passed from the DriverScript</param>
        public VisitorProfile(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
            common = new CommonComponents(ScriptHelper);
        }


        //******************************************************
        // Method Name: VerifySomeOneElseProfile()
        // Method Decs: This method will verify Edit botton is not display in some one else profile 
        // Created on: 13th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void VerifySomeOneElseProfile()
        {
            try
            {
                //String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
                //Driver.Navigate().GoToUrl(url);
                //common.CallMeWait(3000);
                if (Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement((VisitorProfileOR.Osomeoneelslink_xpath));
                    Report.UpdateTestLog("VerifySomeOneElseProfile", "My Profile link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySomeOneElseProfile", "My Profile link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.Osomeoneelslink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Osomeoneelslink_xpath).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("VerifySomeOneElseProfile", "clicked to some one Else profile ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySomeOneElseProfile", "Someone else profile is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (Driver.FindElement(VisitorProfileOR.Oeditlink_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifySomeOneElseProfileFinalStep", "Edit link is present on someone else profile page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("VerifySomeOneElseProfile", "Edit link is not present on someone else profile page ", Status.PASS);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySomeOneElseProfile", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("VerifySomeOneElseProfile", " Error occured", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false; ;
            }
        }


        //******************************************************
        // Method Name: VerifyPrifileEditlink()
        // Method Decs: This method will verify Edit botton is not display in User's profile 
        // Created on: 13th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void VerifyPrifileEditlink()
        {
            try
            {
                //String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
                //Driver.Navigate().GoToUrl(url);
                //common.CallMeWait(1000);
                if (common.CheckElement(VisitorProfileOR.Omyprofilelink_xpath)==true)
                {
                    Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement((VisitorProfileOR.Oeditlink_xpath));
                    Report.UpdateTestLog("VerifyPrifileEditlink", "My Profile link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPrifileEditlink", "My Profile link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.Oeditlink_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyPrifileEditlinkFinalStep", "Edit link is present on User's profile page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPrifileEditlink", "Edit link is not present on User's profile page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySomeOneElseProfile", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("VerifySomeOneElseProfile", " Error occured", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false; ;
            }
        }

        //******************************************************
        // Method Name: VerifyWorkScheduleFieldsOnMyPrifile()
        // Method Decs: This method will verify all Work scheduel filed on visitor profile 
        // Created on: 16th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifyWorkScheduleFieldsOnMyPrifile()
        {
            try
            {
                //String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
               // Driver.Navigate().GoToUrl(url);
                //common.CallMeWait(3000);
                if (Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement((VisitorProfileOR.OworkScheduleeditlink_xpath));
                    Report.UpdateTestLog("VerifySomeOneElseProfile", "My Profile link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySomeOneElseProfile", "My Profile link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.OworkScheduleeditlink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.OworkScheduleeditlink_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Work Shedule edit link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Work Shedule edit link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.Oweekrow1_xpath).Displayed)
                {
                    ReadOnlyCollection<IWebElement> elems1 = Driver.FindElements(VisitorProfileOR.Oweekrow1_xpath);
                    ReadOnlyCollection<IWebElement> elems2 = Driver.FindElements(VisitorProfileOR.Oweekrow2_xpath);
                    int totalweekday = elems1.Count + elems2.Count;
                    if (totalweekday <= 7)
                    {
                        Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Actual number of week day present is " + totalweekday, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Actual number of week day present is " + totalweekday, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "No week day is present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.Ostarttimelabel_xpath).Displayed)
                {
                    string Starttimelabel = Driver.FindElement(VisitorProfileOR.Ostarttimelabel_xpath).Text;
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Start time label is present as : " + Starttimelabel, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Start time label is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                //Start time Drop down verification
                SelectElement starttimevalues = new SelectElement(Driver.FindElement(VisitorProfileOR.Ostarttimedropdownvalues_xpath));
                IList<IWebElement> starttimevaluescount = starttimevalues.Options;
                if (starttimevaluescount.Any())
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Time Zone Drop Down is present",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Time Zone Drop Down is not present",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.Oendtimelabel_xpath).Displayed)
                {
                    string Endtimelabel = Driver.FindElement(VisitorProfileOR.Oendtimelabel_xpath).Text;
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "End time label is present as : " + Endtimelabel, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "End time label is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // End  Time Drop down verification
                SelectElement endtimevalues = new SelectElement(Driver.FindElement(VisitorProfileOR.Oendtimedropdownvalues_xpath));
                IList<IWebElement> endtimevaluescount = endtimevalues.Options;
                if (endtimevaluescount.Any())
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Time Zone Drop Down is present",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Time Zone Drop Down is not present",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                //Time zone label
                if (Driver.FindElement(VisitorProfileOR.Otimezonelabel_xpath).Displayed)
                {
                    string Timezonelabel = Driver.FindElement(VisitorProfileOR.Otimezonelabel_xpath).Text;
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Time Zone label is present as : "
                        + Timezonelabel, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Time Zone label is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //time zone drop down
                SelectElement oSelect = new SelectElement(Driver.FindElement(VisitorProfileOR.Otimezonedropdownvalue_xpath));
                IList<IWebElement> elementCount = oSelect.Options;
                if (elementCount.Any())
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifileFinalStep", "Time Zone Drop Down is present",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Time Zone Drop Down is not present",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySomeOneElseProfile", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("VerifySomeOneElseProfile", " Error occured", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyMyOfficeLocation()
        // Method Decs: This method will verify location fields on visitor profile 
        // Created on: 16th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifyMyOfficeLocation()
        {
            try
            {
                //String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
                //Driver.Navigate().GoToUrl(url);
                //common.CallMeWait(3000);
                if (Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(VisitorProfileOR.Olocationeditlink_xpath);

                    Report.UpdateTestLog("VerifySomeOneElseProfile", "My Profile link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySomeOneElseProfile", "My Profile link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.Olocationeditlink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Olocationeditlink_xpath).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("VerifyMyOfficeLocation", "Location edit link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMyOfficeLocation", "Location edit link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                //Location code verification
                if (Driver.FindElement(VisitorProfileOR.Olocatiocodevalue_xpath).Displayed)
                {
                    string locationcode = Driver.FindElement(VisitorProfileOR.Olocatiocodevalue_xpath).Text;
                    string locationcodelabel = Driver.FindElement(VisitorProfileOR.Olocatiocodelabel_xpath).Text;

                    Report.UpdateTestLog("VerifyMyOfficeLocation", "Location label is displayed as :" + locationcodelabel, Status.PASS);
                    Report.UpdateTestLog("VerifyMyOfficeLocation", "Location Code is displayed as :" + locationcode, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMyOfficeLocation", "Location code is not available", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                //address 
                if (Driver.FindElement(VisitorProfileOR.Oaddress_xpath).Displayed)
                {
                    string address = Driver.FindElement(VisitorProfileOR.Oaddress_xpath).Text;
                    if (address != null)
                    {
                        Report.UpdateTestLog("VerifyMyOfficeLocation", "Address is present: " + address, Status.PASS);
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyMyOfficeLocation", "Address is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


                //floor editable field
                if (Driver.FindElement(VisitorProfileOR.Ofloortextarea_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Ofloortextarea_xpath).Clear();
                    Driver.FindElement(VisitorProfileOR.Ofloortextarea_xpath).SendKeys("20");
                    Report.UpdateTestLog("VerifyMyOfficeLocation", "Floor option is editable", Status.PASS);
                    Driver.FindElement(VisitorProfileOR.OSavelocation_xpath).Click();
                    Report.UpdateTestLog("VerifyMyOfficeLocationFinalStep", "Save button is clicked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMyOfficeLocation", "Floor option is not editable", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyMyOfficeLocation", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("VerifyMyOfficeLocation", " Error occured", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyWorkScheduleWithDataUnavailable()
        // Method Decs: This method will verify view in case Data is unavailable for Work Schedule
        // Created on: 16th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifyWorkScheduleWithDataUnavailable()
        {
            try
            {
               // String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
               // Driver.Navigate().GoToUrl(url);
                //common.CallMeWait(1000);
                if (Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(VisitorProfileOR.OworkScheduleeditlink_xpath);
                    Report.UpdateTestLog("VerifyWorkScheduleWithDataUnavailable", "My Profile link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleWithDataUnavailable", "My Profile link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.OworkScheduleeditlink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.OworkScheduleeditlink_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("VerifyWorkScheduleWithDataUnavailable", "Work Shedule edit link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleWithDataUnavailable", "Work Shedule edit link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                //Week days 
                if (Driver.FindElement(VisitorProfileOR.Oweekrow1_xpath).Displayed)
                {
                    ReadOnlyCollection<IWebElement> elems1 = Driver.FindElements(VisitorProfileOR.Oweekrow1_xpath);
                    ReadOnlyCollection<IWebElement> elems2 = Driver.FindElements(VisitorProfileOR.Oweekrow2_xpath);
                    for (int i = 1; i <= elems1.Count; i++)
                    {
                        string tempxpath = "//*[@id='workSchedule']/div/div[3]/div/div[1]/div/div[1]/div[" + i +
                                           "]/label/input";
                        if (Driver.FindElement(By.XPath(tempxpath)).Selected)
                        {
                            Driver.FindElement(By.XPath(tempxpath)).Click();
                        }


                    }
                    for (int i = 1; i <= elems2.Count; i++)
                    {
                        string tempxpath = "//*[@id='workSchedule']/div/div[3]/div/div[1]/div/div[2]/div[" + i + "]/label/input";
                        if (Driver.FindElement(By.XPath(tempxpath)).Selected)
                        {
                            Driver.FindElement(By.XPath(tempxpath)).Click();
                        }
                    }
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "All week are deselected ", Status.PASS);
                    Driver.FindElement(VisitorProfileOR.Oworkshedulesavelink_xpath).Click();
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "Sabe button is clicked  ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "No week day is present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // Blank week day verification
                common.CallMeWait(1000);
                string dash = Driver.FindElement(VisitorProfileOR.Oblankworkingday_xpath).Text.Trim();
                if (dash.Equals("–"))
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifileFinalStep", "No day is scheduled for work ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWorkScheduleFieldsOnMyPrifile", "still day is present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyWorkScheduleWithDataUnavailable", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("VerifyWorkScheduleWithDataUnavailable", " Error occured", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ModifyWorkSchedule()
        // Method Decs: This method will modify  Work Schedule
        // Created on: 16th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void ModifyWorkSchedule()
        {
            try
            {
               // String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
                //Driver.Navigate().GoToUrl(url);
                //common.CallMeWait(3000);
               
                if (Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Omyprofilelink_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(VisitorProfileOR.OworkScheduleeditlink_xpath);
                    Report.UpdateTestLog("ModifyWorkSchedule", "My Profile link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ModifyWorkSchedule", "My Profile link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (Driver.FindElement(VisitorProfileOR.OworkScheduleeditlink_xpath).Displayed)
                {
                   
                    Driver.FindElement(VisitorProfileOR.OworkScheduleeditlink_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ModifyWorkSchedule", "Work Shedule edit link in clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ModifyWorkSchedule", "Work Shedule edit link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                //Week days selection during modification
                if (Driver.FindElement(VisitorProfileOR.Oweekrow1_xpath).Displayed)
                {
                    ReadOnlyCollection<IWebElement> elems1 = Driver.FindElements(VisitorProfileOR.Oweekrow1_xpath);
                    ReadOnlyCollection<IWebElement> elems2 = Driver.FindElements(VisitorProfileOR.Oweekrow2_xpath);
                    for (int i = 1; i <= elems1.Count; i++)
                    {
                        string tempxpath = "//*[@id='workSchedule']/div/div[3]/div/div[1]/div/div[1]/div[" + i +
                                           "]/label/input";
                        Driver.FindElement(By.XPath(tempxpath)).Click();
                    }
                    for (int i = 1; i <= elems2.Count; i++)
                    {
                        string tempxpath = "//*[@id='workSchedule']/div/div[3]/div/div[1]/div/div[2]/div[" + i + "]/label/input";
                        Driver.FindElement(By.XPath(tempxpath)).Click();
                    }

                }
                else
                {
                    Report.UpdateTestLog("ModifyWorkSchedule", "No week element are present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // Start  Time Drop down selection
                SelectElement starttimevalues = new SelectElement(Driver.FindElement(VisitorProfileOR.Ostarttimedropdownvalues_xpath));
                IList<IWebElement> starttimevaluescount = starttimevalues.Options;
                if (starttimevaluescount.Any())
                {
                    /*IWebElement startime= starttimevaluescount.ElementAt(3);
                    startime.Click();*/
                    string st = DataTable.GetData("General_Data_" + Env, "RequestType2");
                    starttimevalues.SelectByText(st);
                    Report.UpdateTestLog("ModifyWorkSchedule", "start time is selected: " + st,
                      Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ModifyWorkSchedule", "Unable to select Start time",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // End  Time Drop down verification
                SelectElement endtimevalues = new SelectElement(Driver.FindElement(VisitorProfileOR.Oendtimedropdownvalues_xpath));
                IList<IWebElement> endtimevaluescount = endtimevalues.Options;
                if (endtimevaluescount.Any())
                {
                    /*IWebElement endtime = endtimevaluescount.ElementAt(6);
                    endtime.Click();*/
                    string et = DataTable.GetData("General_Data_" + Env, "RequestType3");
                    starttimevalues.SelectByText(et);
                    endtimevalues.SelectByText(et);
                    Report.UpdateTestLog("ModifyWorkSchedule", "selected start time is selected: " + et,
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ModifyWorkSchedule", "Unable to select End time",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                //time zone drop down
                SelectElement locatiovalues = new SelectElement(Driver.FindElement(VisitorProfileOR.Otimezonedropdownvalue_xpath));
                IList<IWebElement> picklocation = locatiovalues.Options;
                if (picklocation.Any())
                {
                    IWebElement selectedlocation = picklocation.ElementAt(10);
                    selectedlocation.Click();
                    string sl = selectedlocation.Text;
                    Report.UpdateTestLog("ModifyWorkSchedule", "Selected location is :" + sl,
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ModifyWorkSchedule", "Unable to select location ",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //click to save option 
                if (Driver.FindElement(VisitorProfileOR.Oworkshedulesavelink_xpath).Displayed)
                {
                    Driver.FindElement(VisitorProfileOR.Oworkshedulesavelink_xpath).Click();
                    Report.UpdateTestLog("ModifyWorkScheduleFinalStep", "Save option is clicked :",
                       Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ModifyWorkSchedule", "Save button is unavialble : ",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ModifyWorkSchedule", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                Report.UpdateTestLog("ModifyWorkSchedule", " Error occured", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: VerifyHaveQuestionslinks()
        // Method Decs: This method will Verify HaveQuestions links on visitor profile
        // Created on: 18th Jan 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyHaveQuestionslinks()
        {
            try
            {
                /* String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
                 Driver.Navigate().GoToUrl(url);
                 common.CallMeWait(3000);*/
                common.WaitForElement(VisitorProfileOR.Ohavequestion_xpath);
                string haveqes = Driver.FindElement(VisitorProfileOR.Ohavequestion_xpath).Text.Trim();
                if (haveqes.Contains("Can't find what you are looking for?"))
                {
                    Report.UpdateTestLog("VerifyHaveQuestionslinks", "Have a question Text is present as : " + haveqes,
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyHaveQuestionslinks", " Have a question Text is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


                common.WaitForElement(VisitorProfileOR.Ohavequestionlinksvalue_xpath);
                ReadOnlyCollection<IWebElement> elems1 = Driver.FindElements(VisitorProfileOR.Ohavequestionlinksvalue_xpath);
                if (elems1.Count > 0)
                {
                    for (int i = 1; i <= elems1.Count; i++)
                    {
                        String emailadd = elems1[i - 1].GetAttribute("href").Trim();

                        Report.UpdateTestLog("VerifyHaveQuestionslinksFinalStep", "Required links are present (" + i + ")  :" + emailadd,
                       Status.PASS);
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyHaveQuestionslinks", "Required links are not  present ",
                         Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyHaveQuestionslinks", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                Report.UpdateTestLog("VerifyHaveQuestionslinks", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: VerifyCanNotFindSomethingLink()
        // Method Decs: This method will Verify Ca'Find Something link on visitor profile
        // Created on: 18th Jan 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyCanNotFindSomethingLink()
        {
            try
            {
                String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
                Driver.Navigate().GoToUrl(url);
                common.CallMeWait(3000);
                common.WaitForElement(VisitorProfileOR.Ocannotfinlink);
                //  string haveqes = Driver.FindElement(VisitorProfileOR.Ohavequestion_xpath).Text.Trim();
                ReadOnlyCollection<IWebElement> elems1 = Driver.FindElements(VisitorProfileOR.Ocannotfinlink);
                if (elems1.Count > 0)
                {
                    for (int i = 1; i <= elems1.Count; i++)
                    {
                        String link = elems1[i].Text.Trim();
                        if (link.Equals("Can't Find Something?"))
                        {
                            Report.UpdateTestLog("VerifyCanNotFindSomethingLinkFinalStep", "Can't find link is present as :" + link,
                       Status.PASS);
                            break;
                        }

                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyCanNotFindSomethingLink", "Can't find link is not present  ",
                         Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCanNotFindSomethingLink", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                Report.UpdateTestLog("VerifyCanNotFindSomethingLink", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: VerifyStatusOfVideo()
        // Method Decs: This method will Verify 
        // Created on: 19th Jan 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyStatusOfVideo()
        {

            try
            {

                if (Driver.FindElement(VisitorProfileOR.Opageheadlineheader_xpath).Displayed)
                {
                    string pageheadlineheader = Driver.FindElement(VisitorProfileOR.Opageheadlineheader_xpath).Text;
                    Report.UpdateTestLog("VerifyStatusOfVideo", "visitor page is launched", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyStatusOfVideo", "visitor page is not launched", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ReadOnlyCollection<IWebElement> detailFrame = Driver.FindElements(By.XPath("//iframe"));
                Driver.SwitchTo().Frame(detailFrame[0]);
                ReadOnlyCollection<IWebElement> elems1 = Driver.FindElements(VisitorProfileOR.Ovideotitlle_xpath);
                if (elems1.Count > 0)
                {
                    string videoheader = elems1[0].Text;
                    if (videoheader != null)
                    {
                        Report.UpdateTestLog("VerifyStatusOfVideoFinalStep", "video header is present as :" + videoheader, Status.PASS);
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyStatusOfVideo", "video header not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                Driver.SwitchTo().DefaultContent();
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyStatusOfVideo", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("VerifyStatusOfVideo", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyGlobalIntranetDefaultpage()
        // Method Decs: This method will Verify 
        // Created on: 19th Jan 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyGlobalIntranetDefaultpage()
        {
            try
            {
                ReadOnlyCollection<IWebElement> cbreheader = Driver.FindElements(VisitorProfileOR.Ocbreheader_xpath);
                if (cbreheader.Count > 0)
                {
                    cbreheader[0].Click();
                    Report.UpdateTestLog("VerifyGlobalIntranetDefaultpage", "CBRE Header Logo is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyGlobalIntranetDefaultpage", "CBRE Header Logo is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                string geturl = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string currenturl = Driver.Url.Trim();
                if (geturl.Equals(currenturl))
                {
                    Report.UpdateTestLog("VerifyGlobalIntranetDefaultpageFinalStep", "Navigated to Default CBRE page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyGlobalIntranetDefaultpage", " Default CBRE page not loaded ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyGlobalIntranetDefaultpage", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyGlobalIntranetDefaultpage", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: EditExperienceServices()
        // Method Decs: This method will Verify  and edit Experience and Services
        // Created on: 19th Jan 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void EditExperienceServices()
        {
            try
            {
                String skills = DataTable.GetData("Profile", "Skills");
                common.WaitForElement(VisitorProfileOR.oexperienceServiceseditlink_xpath);
                if (common.CheckElement(VisitorProfileOR.oexperienceServiceseditlink_xpath) == true)
                {
                    Report.UpdateTestLog("EditExperienceServices", "Edit link Present beside 'Experience & Services' " , Status.PASS);
                    Driver.FindElement(VisitorProfileOR.oexperienceServiceseditlink_xpath).Click();
                    Report.UpdateTestLog("EditExperienceServices", "Clicked on Edit link ", Status.PASS);
                    Driver.FindElement(VisitorProfileOR.oexperienceServicesskillremove_xpath).Click();
                    Driver.FindElement(VisitorProfileOR.oexperienceServicesskill_xpath).SendKeys(skills);
                    Report.UpdateTestLog("EditExperienceServices", "Entered value in skill field is  " + skills, Status.PASS);
                    Driver.FindElement((By.XPath("//*[@class='suggestion-list']/li[1]"))).Click();
                    Driver.FindElement(VisitorProfileOR.oexperienceServicessavebtn_xpath).Click();
                    if (Driver.FindElement(VisitorProfileOR.oexperienceServicesskilltext_xpath).Text.Equals(skills))

                    {
                        Report.UpdateTestLog("EditExperienceServicesFinalStep", "Profile skill is updated with new skill ," + skills, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("EditExperienceServices", "Profile skill is not updated with new skill ," + skills, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("EditExperienceServices", "Edit link NOT Present beside 'Experience & Services' ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EditExperienceServices", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EditExperienceServices", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyWhatisNew()
        // Method Decs: This method will Verify  the functionality of the "What's New" web part
        // Created on: 31st Jan 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyWhatisNew()
        {
            try
            {
                common.WaitForElement((VisitorProfileOR.Owhatisnew_xpath));
                if (Driver.FindElement(VisitorProfileOR.Owhatisnew_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyWhatisNew", "What's New Section is present ", Status.PASS);
                    ReadOnlyCollection<IWebElement> whatisnewoption = Driver.FindElements(VisitorProfileOR.Owhatisnewoption_xpath);
                    if (whatisnewoption.Count > 0)
                    {
                        IWebElement firstlink = whatisnewoption[0];
                        string firstlinktext = firstlink.Text.Trim();
                        Report.UpdateTestLog("VerifyWhatisNew", "first link is present as " + firstlinktext, Status.PASS);
                        firstlink.Click();
                        Report.UpdateTestLog("VerifyWhatisNewFinalStep", firstlinktext + "link is clicked", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyWhatisNew", "No link is present under What's New Section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyWhatisNew", "What's New Section is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyWhatisNew", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyWhatisNew", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyQuicklinks()
        // Method Decs: This method will Verify  the functionality of the "What's New" web part
        // Created on: 31st Jan 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyQuicklinks()
        {
            try
            {
                common.WaitForElement((VisitorProfileOR.Oquicklinks_xpath));
                if (Driver.FindElement(VisitorProfileOR.Oquicklinks_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyQuicklinks", "Quick Link  Section is present ", Status.PASS);
                    ReadOnlyCollection<IWebElement> quicklinksoption = Driver.FindElements(VisitorProfileOR.Oquicklinksoption_xpath);
                    if (quicklinksoption.Count > 0)
                    {

                        IWebElement firstlink =
                            Driver.FindElement(By.XPath("//*[text()='Quick Links']/parent::*/table/tbody/tr[1]/td[1]/a"));
                        string firstlinktext = firstlink.GetAttribute("innerText").Trim();
                        Report.UpdateTestLog("VerifyQuicklinks", "first link is present as " + firstlinktext, Status.PASS);
                        firstlink.Click();
                        Report.UpdateTestLog("VerifyQuicklinksFinalStep", firstlinktext + "link is clicked", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyQuicklinks", "No link is present under Quick Link  Section ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyQuicklinks", "What's New Section is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyQuicklinks", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyQuicklinks", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyPopularLinks()
        // Method Decs: This method will Verify  the functionality of the PopularLinks web part
        // Created on: 7th Feb 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyPopularLinks()
        {
            try
            {
                int x = 1;

                common.WaitForElement((VisitorProfileOR.Opopular_text));
                ReadOnlyCollection<IWebElement> elmsElements = Driver.FindElements(VisitorProfileOR.Opopular_text);
                int flag = 0;
                if (elmsElements.Count > 0)
                {
                    flag = 1;
                    Report.UpdateTestLog("VerifyPopularLinks", "PopularLinks web part is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPopularLinks", "PopularLinks web part is Not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    string path = "//h4[text()='Popular Items']/parent::*/table/tbody/tr/td[2]/a";
                    // string path2 = "//h4[text()='Popular Items']/parent::*/table/tbody/tr/td[2]/a/span";

                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(By.XPath(path));
                    if (elmsElements1.Count > 2)
                    {
                        x = 2;
                    }
                    for (int i = 0; i < x; i++)
                    {
                        elmsElements1 = Driver.FindElements(By.XPath(path));

                        string linkname = elmsElements1[i].Text.Trim();
                        string linkvalue = elmsElements1[i].GetAttribute("href").Trim();
                        elmsElements1[i].Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("VerifyPopularLinks", "clicked on " + linkname, Status.DONE);
                        string newurl = Driver.Url.Trim();
                        if (newurl.Equals(linkvalue))
                        {
                            Report.UpdateTestLog("VerifyPopularLinksFinalStep", "Successfully Navigated to the " + newurl, Status.PASS);
                            Driver.Navigate().Back();
                            common.CallMeWait(3000);
                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyPopularLinks", "Unable to Navigate to " + newurl, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }

                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPopularLinks", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPopularLinks", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyDocumentLinks()
        // Method Decs: This method will Verify  the functionality of the DocumentLinks web part
        // Created on: 7th Feb 2017
        // Created By: GI offShore Team		
        //****************************************************

        public void VerifyDocumentLinks()
        {
            try
            {
                int x = 1;
                common.WaitForElement((VisitorProfileOR.Oducuments_text));
                ReadOnlyCollection<IWebElement> elmsElements = Driver.FindElements(VisitorProfileOR.Oducuments_text);
                int flag = 0;
                if (elmsElements.Count > 0)
                {
                    flag = 1;
                    Report.UpdateTestLog("VerifyDocumentLinks", "DocumentLinks web part is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyDocumentLinks", "DocumentLinks web part is Not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    string path = "//*[contains(@id, 'onetidDoclibView')]/tbody/tr/td[3]/div/a";
                    // string path2 = "//h4[text()='Popular Items']/parent::*/table/tbody/tr/td[2]/a/span";

                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(By.XPath(path));
                    if (elmsElements1.Count > 2)
                    {
                        x = 2;
                    }
                    for (int i = 0; i < x; i++)
                    {
                        elmsElements1 = Driver.FindElements(By.XPath(path));

                        string linkname = elmsElements1[i].Text.Trim();
                        string linkvalue = elmsElements1[i].GetAttribute("href").Trim();
                        elmsElements1[i].Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("VerifyDocumentLinks", "clicked on " + linkname, Status.DONE);
                        string newurl = Driver.Url.Trim();
                        if (newurl.Contains(linkvalue))
                        {
                            Report.UpdateTestLog("VerifyDocumentLinksFinalStep", "Successfully Navigated to the " + newurl, Status.PASS);
                            Driver.Navigate().Back();
                            common.CallMeWait(3000);
                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyDocumentLinks", "Unable to Navigate to " + newurl, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyDocumentLinks", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyDocumentLinks", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method VerifyPageAuthorForVisitor()
        // Method Description : This method verifies the page auhor and last updated date for visitor
        // Created On: 17th March
        // Created By: GI offShore Team
        // *****************************************
        public void VerifyPageAuthorForVisitor()
        {
            try
            {
                if (common.CheckElement(LinksOR.opublishedInfo) == true)
                {
                    string pblishdate = Driver.FindElement(LinksOR.opublishedInfo).Text.Trim();
                    Report.UpdateTestLog("VerifyPageAuthorForVisitor", "Publish Date is :" + pblishdate, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageAuthorForVisitor", "Publish Date is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (common.CheckElement(LinksOR.opublishedAuthor) == false)
                {
                    //string author = Driver.FindElement(LinksOR.opublishedAuthor).Text.Trim();
                    Report.UpdateTestLog("VerifyPageAuthorForVisitorFinalStep", "Published By is not displayed for visitor", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageAuthorForVisitor", "Published By is displayed for visitor", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPageAuthorForVisitor", "Error in method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: Verifyfootertextcolor()
        // Method Decs: This method will Verify color for text Can't find what you are looking for? Click here for help and its background
        // Created on: 17th March 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void Verifyfootertextcolor()
        {
            try
            {

                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                if (common.CheckElement(VisitorProfileOR.Ohavequestion_xpath) == true)
                {
                    string c = Driver.FindElement(VisitorProfileOR.Ohavequestion_xpath).GetCssValue("color").Trim();
                    if (c.Contains(req1))
                    {
                        Report.UpdateTestLog("Verifyfootertextcolor", "Can't find what you are looking for Text color matched",
                             Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("Verifyfootertextcolor", "Can't find what you are looking for Text color not matched",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("Verifyfootertextcolor", " Can't find what you are looking for Text is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


                if (common.CheckElement(VisitorProfileOR.Ohavequestionlinksvalue_xpath) == true)
                {
                    string c2 = Driver.FindElement(VisitorProfileOR.Ohavequestionlinksvalue_xpath).GetCssValue("color").Trim();
                    if (c2.Contains(req2))
                    {
                        Report.UpdateTestLog("Verifyfootertextcolor", "Click here for help  Text color matched",
                             Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("Verifyfootertextcolor", "Click here for help  Text color not matched",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("Verifyfootertextcolor", " Click here for help link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (common.CheckElement(VisitorProfileOR.Ofooter_id) == true)
                {
                    string c3 = Driver.FindElement(VisitorProfileOR.Ofooter_id).GetCssValue("background-color").Trim();
                    if (c3.Contains(req3))
                    {
                        Report.UpdateTestLog("VerifyfootertextcolorFinalStep", "Back ground color matched",
                             Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("Verifyfootertextcolor", "Back ground color not matched",
                       Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("Verifyfootertextcolor", " Back ground  not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Verifyfootertextcolor", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                //string s = e.ToString();
                Report.UpdateTestLog("Verifyfootertextcolor", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyJapaneseCharacters()
        // Method Decs: This method verify japanese character when site is open in japanes location
        // Created on: 22th March 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyJapaneseCharacters()
        {
            try
            {

                string text = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string path = "//a[text()='" + text + "']";
                By xpath = By.XPath(path);
                if (common.CheckElement(xpath) == true)
                {
                    Report.UpdateTestLog("VerifyJapaneseCharactersFinalStep", "japanes text is present " + text, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyJapaneseCharacters", "japanes text is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyJapaneseCharacters", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyJapaneseCharacters", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickAndVerifyDocumentLinks()
        // Method Decs: This method will Verify  the functionality of the DocumentLinks web part
        // Created on: 9th June 2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickAndVerifyDocumentLinks()
        {
            try
            {
                int x = 1;
                common.WaitForElement((VisitorProfileOR.Oducuments_text));
                ReadOnlyCollection<IWebElement> elmsElements = Driver.FindElements(VisitorProfileOR.Oducuments_text);
                int flag = 0;
                if (elmsElements.Count > 0)
                {
                    flag = 1;
                    Report.UpdateTestLog("ClickAndVerifyDocumentLinks", "DocumentLinks web part is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickAndVerifyDocumentLinks", "DocumentLinks web part is Not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    string path = "//*[contains(@id, 'onetidDoclibView')]/tbody/tr/td[3]/div/a";
                    // string path2 = "//h4[text()='Popular Items']/parent::*/table/tbody/tr/td[2]/a/span";

                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(By.XPath(path));
                    if (elmsElements1.Count > 2)
                    {
                        x = 2;
                    }
                    for (int i = 0; i < x; i++)
                    {
                        elmsElements1 = Driver.FindElements(By.XPath(path));

                        string linkname = elmsElements1[i].Text.Trim();
                        string linkvalue = elmsElements1[i].GetAttribute("href").Trim();
                        elmsElements1[i].Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("ClickAndVerifyDocumentLinks", "clicked on " + linkname, Status.DONE);
                        string newurl = Driver.Url.Trim();
                        if (newurl.Contains(linkvalue))
                        {
                            Report.UpdateTestLog("ClickAndVerifyDocumentLinksFinalStep", "Successfully Navigated to the " + newurl, Status.PASS);
                            Driver.Navigate().Back();
                            common.CallMeWait(3000);
                        }
                        else
                        {
                            Report.UpdateTestLog("ClickAndVerifyDocumentLinks", "Unable to Navigate to " + newurl, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickAndVerifyDocumentLinks", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickAndVerifyDocumentLinks", " Error occured" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
    
    }
}
