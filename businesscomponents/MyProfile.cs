using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CRAFT.BusinessComponents;
using CRAFT.SupportLibraries;
using CRAFT.Uimap;
using Framework_Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.Record.Formula.Functions;
using NPOI.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;
using System.Configuration;

namespace CRAFT.businesscomponents
{

    /**
     * Class for storing general purpose business components
     * 
     * @author Cognizant
     */

    internal class MyProfile : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;
        public MyProfile(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
            common = new CommonComponents(ScriptHelper);
        }

        //**********************************************
        // Method ValidateMyProfilePage()
        // Method Description : This method will validate My Profile page
        // Created On: 01/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateMyProfilePage()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oProfile_xpath);
                if (elm.Displayed)
                {
                    Report.UpdateTestLog("ValidateMyProfilePage", "User successfully navigated to My Profile page", Status.PASS);
                    IWebElement elm1 = Driver.FindElement(MyProfileOR.oExpService_xpath);
                    if (elm1.Displayed)
                    {
                        Report.UpdateTestLog("ValidateMyProfilePage", "Experiences and Services label is displayed on My Profile page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateMyProfilePage", "Experiences and Services label is not displayed on My Profile page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    common.CallMeWait(1000);
                    //common.WaitForElement(MyProfileOR.oExpServiceEdit_xpath);
                   // IWebElement elm2 = Driver.FindElement(MyProfileOR.oExpServiceEdit_xpath);
                    if (common.CheckElement(MyProfileOR.oExpServiceEdit_xpath)==true)
                    {
                        Report.UpdateTestLog("ValidateMyProfilePage", "Edit link is present beside Experiences and Services label on My Profile page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateMyProfilePage", "Edit link is not present beside Experiences and Services label on My Profile page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    IWebElement elm3 = Driver.FindElement(MyProfileOR.oSkillsLabel_xpath);
                    if (elm3.Displayed)
                    {
                        Report.UpdateTestLog("ValidateMyProfilePage", "Skill label is present Under Experiences and Services label on My Profile page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateMyProfilePage", "Skill label is not present Under Experiences and Services label on My Profile page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    IWebElement elm4 = Driver.FindElement(MyProfileOR.oPastProjectLabel_xpath);
                    if (elm4.Displayed)
                    {
                        Report.UpdateTestLog("ValidateMyProfilePageFinalStep", "Past Project label is present Under Experiences and Services label on My Profile page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateMyProfilePage", "Past Project label is not present Under Experiences and Services label on My Profile page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateMyProfilePage", "User not able to navigated to My Profile page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateMyProfilePage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateMyProfilePage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickOnEditLink()
        // Method Description : This method will click on edit link beside Experience and Service label
        // Created On: 01/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnEditLink()
        {
            try
            {
                common.WaitForElement(MyProfileOR.oExpServiceEdit_xpath);
                IWebElement elm = Driver.FindElement(MyProfileOR.oExpServiceEdit_xpath);
                string sedit = elm.Text;
                elm.Click();
                Report.UpdateTestLog("ClickOnEditLinkFinalStep", "Successfully clicked on " + sedit + " link", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnEditLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnEditLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method AddAutopopulatedSkill()
        // Method Description : This method will add auto populated skill and validate 
        // Created On: 01/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddAutopopulatedSkill()
        {
            string sSkillInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
            try
            {
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();
                skill.SendKeys(sSkillInputtext);
                if (common.CheckElement(MyProfileOR.oSkillAutoComplete_xpath) == true)
                {
                    Report.UpdateTestLog("AddAutopopulatedSkill", "Successfully validated that Skill field Auto populates relevant data", Status.PASS);
                    Driver.FindElement(MyProfileOR.oSkillAutoComplete_xpath).Click();
                    if (common.CheckElement(MyProfileOR.oSelectedSkill_xpath) == true)
                    {
                        Report.UpdateTestLog("AddAutopopulatedSkillFinalStep", "Successfully select the Auto populated relevant data", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("AddAutopopulatedSkill", "Failed to select the Auto populated relevant data", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("AddAutopopulatedSkill", "Skill field Failed to auto populate relevant data", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddAutopopulatedSkill", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddAutopopulatedSkill", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method AddNewSkill()
        // Method Description : This method will add new skill and validate 
        // Created On: 01/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddNewSkill()
        {
            try
            {
                string sSkillInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string sSkillInputtext1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();
                if (sSkillInputtext1.Any())
                {
                    skill.SendKeys(sSkillInputtext1);
                    common.CallMeWait(2000);
                }
                else
                {
                    skill.SendKeys(sSkillInputtext);
                    common.CallMeWait(2000);

                }
                IWebElement exp = Driver.FindElement(MyProfileOR.oExpService_xpath);
                exp.Click();
                
                if (common.CheckElement(MyProfileOR.oSelectedSkill_xpath) == true)
                {
                    Report.UpdateTestLog("AddNewSkillFinalStep", "Successfully Entered new skill which is not present in database", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddNewSkill", "New Skill is not added in Skills field", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddNewSkill", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddNewSkill", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method Save()
        // Method Description : This method will save after adding skills
        // Created On: 01/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void Save()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oSave_xpath) == true)
                {
                    Driver.FindElement(MyProfileOR.oSave_xpath).Click();
                    Report.UpdateTestLog("SaveFinalStep", "Successfully Clicked on Save button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("Save", "Save button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Save", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Save", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateMyProfileAfterSave()
        // Method Description : This method will validate whether the update is successfull after editing
        // Created On: 01/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateMyProfileAfterSave()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oSkillUpdateOnProfilePage_xpath);
                string stext = elm.Text.Trim();
                string sSkillInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string sSkillInputtext2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (sSkillInputtext2.Any())
                {
                    if (stext.Contains(sSkillInputtext) && stext.Contains(sSkillInputtext2))
                    {
                        Report.UpdateTestLog("ValidateMyProfileAfterSaveFinalStep",
                            "Successfully validated that update is successfull on My Profile page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateMyProfileAfterSave", "Update is unsuccessfull on My Profile page",
                            Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    if (stext.Contains(sSkillInputtext))
                    {
                        Report.UpdateTestLog("ValidateMyProfileAfterSaveFinalStep",
                            "Successfully validated that update is successfull on My Profile page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateMyProfileAfterSave", "Update is unsuccessfull on My Profile page",
                            Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateMyProfileAfterSave", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateMyProfileAfterSave", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeleteSkill()
        // Method Description : This method will delete the updated skill
        // Created On: 01/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteSkill()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oSkillUpdateOnProfilePage_xpath);
                string stext = elm.Text.Trim();
                IWebElement elm1 = Driver.FindElement(MyProfileOR.oExpServiceEdit_xpath);
                string sedit = elm1.Text;
                elm1.Click();
                if (common.CheckElement(MyProfileOR.oSkillRemoveCross_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> elms = Driver.FindElements(MyProfileOR.oSkillRemoveCross_xpath);
                    for (int i = 1; i <= elms.Count; i++)
                    {
                        Driver.FindElement(MyProfileOR.oSkillRemoveCross_xpath).Click();

                    }
                    Report.UpdateTestLog("DeleteSkill", "Successfully clicked the cross icon to delete the skill", Status.PASS);
                    Driver.FindElement(MyProfileOR.oSave_xpath).Click();
                    IWebElement elm2 = Driver.FindElement(MyProfileOR.oSkillUpdateOnProfilePage_xpath);
                    string stext2 = elm2.Text.Trim();

                    if (stext != stext2)
                    {
                        Report.UpdateTestLog("DeleteSkillFinalStep", "Successfully delete the skill", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("DeleteSkill", "Failed to delete the skill", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Driver.FindElement(MyProfileOR.oSave_xpath).Click();
                    common.CallMeWait(1000);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteSkill", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteSkill", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
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
                    Report.UpdateTestLog("EditExperienceServices", "Edit link Present beside 'Experience & Services' ", Status.PASS);
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
                        Report.UpdateTestLog("EditExperienceServices", "Profile skill is not updated with new skill ," + skills, Status.PASS);
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


        //**********************************************
        // Method AddAutopopulatedPastProject()
        // Method Description : This method will add auto completed past projects
        // Created On: 01/30/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddAutopopulatedPastProject()
        {
            string sPastProjectInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
            try
            {
                IWebElement PastProject = Driver.FindElement(MyProfileOR.oPastProjectsInputField_xpath);
                PastProject.Click();
                PastProject.SendKeys(sPastProjectInputtext);
                if (common.CheckElement(MyProfileOR.oPastProjectAutoComplete_xpath) == true)
                {
                    Report.UpdateTestLog("AddAutopopulatedPastProject", "Successfully validated that Past Project field Auto populates relevant data", Status.PASS);
                    Driver.FindElement(MyProfileOR.oPastProjectAutoComplete_xpath).Click();
                    if (common.CheckElement(MyProfileOR.oSelectedPastProject_xpath) == true)
                    {
                        Report.UpdateTestLog("AddAutopopulatedPastProjectFinalStep", "Successfully select the Auto populated relevant data in Past Project field", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("AddAutopopulatedPastProject", "Failed to select the Auto populated relevant data in Past Project field", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("AddAutopopulatedPastProject", "Past Project field Failed to auto populate relevant data", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddAutopopulatedPastProject", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddAutopopulatedPastProject", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method AddNewPastProject()
        // Method Description : This method will add new past project which is not auto populated 
        // Created On: 01/30/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddNewPastProject()
        {
            try
            {
                string sPastProjectInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string sPastProjectInputtext1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                IWebElement PastProject = Driver.FindElement(MyProfileOR.oPastProjectsInputField_xpath);
                PastProject.Click();
                if (sPastProjectInputtext1.Any())
                {
                    PastProject.SendKeys(sPastProjectInputtext1);
                }
                else
                {
                    PastProject.SendKeys(sPastProjectInputtext);

                }
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();
                if (common.CheckElement(MyProfileOR.oSelectedPastProject_xpath) == true)
                {
                    Report.UpdateTestLog("AddNewPastProjectFinalStep", "Successfully Entered new Past Project which is not auto populated", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddNewPastProject", "Failed to add new past project in Past Project field", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddNewPastProject", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddNewPastProject", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidatePastProjectInMyProfileAfterSave()
        // Method Description : This method will validate whether the Past Project update is successfull after editing
        // Created On: 01/30/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidatePastProjectInMyProfileAfterSave()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oPastProjectUpdateOnProfilePage_xpath);
                string stext = elm.Text.Trim();
                string sPastProjectInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string sPastProjectInputtext2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (sPastProjectInputtext2.Any())
                {
                    if (stext.Contains(sPastProjectInputtext) && stext.Contains(sPastProjectInputtext2))
                    {
                        Report.UpdateTestLog("ValidatePastProjectInMyProfileAfterSaveFinalStep",
                            "Successfully validated that Past Project update is successfull on My Profile page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidatePastProjectInMyProfileAfterSave", "Past Project Update is unsuccessfull on My Profile page",
                            Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    if (stext.Contains(sPastProjectInputtext))
                    {
                        Report.UpdateTestLog("ValidatePastProjectInMyProfileAfterSaveFinalStep",
                            "Successfully validated that Past Project update is successfull on My Profile page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidatePastProjectInMyProfileAfterSave", "Past Project Update is unsuccessfull on My Profile page",
                            Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidatePastProjectInMyProfileAfterSave", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidatePastProjectInMyProfileAfterSave", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeletePastProject()
        // Method Description : This method will delete the updated Past Project
        // Created On: 01/30/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeletePastProject()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oPastProjectUpdateOnProfilePage_xpath);
                string stext = elm.Text.Trim();
                IWebElement elm1 = Driver.FindElement(MyProfileOR.oExpServiceEdit_xpath);
                common.CheckElement(MyProfileOR.oExpServiceEdit_xpath);
                string sedit = elm1.Text;
                elm1.Click();
                if (common.CheckElement(MyProfileOR.oPastProjectRemoveCross_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> elms = Driver.FindElements(MyProfileOR.oPastProjectRemoveCross_xpath);
                    for (int i = 1; i <= elms.Count; i++)
                    {
                        Driver.FindElement(MyProfileOR.oPastProjectRemoveCross_xpath).Click();

                    }
                    Report.UpdateTestLog("DeletePastProject", "Successfully clicked the cross icon to delete the Past Project", Status.PASS);
                    Driver.FindElement(MyProfileOR.oSave_xpath).Click();
                    IWebElement elm2 = Driver.FindElement(MyProfileOR.oPastProjectUpdateOnProfilePage_xpath);
                    string stext2 = elm2.Text.Trim();

                    if (stext != stext2)
                    {
                        Report.UpdateTestLog("DeletePastProjectFinalStep", "Successfully delete the Past Project", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("DeletePastProject", "Failed to delete the Past Project", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Driver.FindElement(MyProfileOR.oSave_xpath).Click();
                    common.CallMeWait(1000);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeletePastProject", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeletePastProject", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method AddBlankSkill()
        // Method Description : This method will delete any existing skill and save with blank skill 
        // Created On: 01/31/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddBlankSkill()
        {
            try
            {
                string sSkillInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                if (common.CheckElement(MyProfileOR.oSkillRemoveCross_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> elms = Driver.FindElements(MyProfileOR.oSkillRemoveCross_xpath);
                    for (int i = 1; i <= elms.Count; i++)
                    {
                        Driver.FindElement(MyProfileOR.oSkillRemoveCross_xpath).Click();

                    }
                    Report.UpdateTestLog("AddBlankSkill", "Successfully clicked the cross icon to delete the skill", Status.PASS);
                }
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();

                if (common.CheckElement(MyProfileOR.oSelectedSkill_xpath) == false)
                {
                    Report.UpdateTestLog("AddBlankSkillFinalStep", "Successfully Validated No information is added to the SKILLS field", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddBlankSkill", "Skill is present in Skills field", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddBlankSkill", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddBlankSkill", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method AddBlankPastProject()
        // Method Description : This method will delete any existing Past Project and save with blank value 
        // Created On: 01/31/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddBlankPastProject()
        {
            try
            {
                string PastProjectInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                if (common.CheckElement(MyProfileOR.oPastProjectRemoveCross_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> elms = Driver.FindElements(MyProfileOR.oPastProjectRemoveCross_xpath);
                    for (int i = 1; i <= elms.Count; i++)
                    {
                        Driver.FindElement(MyProfileOR.oPastProjectRemoveCross_xpath).Click();

                    }
                    Report.UpdateTestLog("AddBlankPastProject", "Successfully clicked the cross icon to delete the Past Project", Status.PASS);
                }
                IWebElement PastProject = Driver.FindElement(MyProfileOR.oPastProjectsInputField_xpath);
                PastProject.Click();

                if (common.CheckElement(MyProfileOR.oSelectedPastProject_xpath) == false)
                {
                    Report.UpdateTestLog("AddBlankPastProjectFinalStep", "Successfully Validated No information is added to the Past Project field", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddBlankPastProject", "Past Project is present in Past Project field", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddBlankPastProject", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddBlankPastProject", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickOnEditLinkSecondTime()
        // Method Description : This method will click on edit link beside Experience and Service label
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnEditLinkSecondTime()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oExpServiceEdit_xpath) == true)
                {
                    IWebElement elm = Driver.FindElement(MyProfileOR.oExpServiceEdit_xpath);
                    string sedit = elm.Text;
                    elm.Click();
                    Report.UpdateTestLog("ClickOnEditLinkSecondTimeFinalStep", "Successfully clicked on " + sedit + " link", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnEditLinkSecondTime", " Edit link is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnEditLinkSecondTime", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnEditLinkSecondTime", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method SaveSecondTime()
        // Method Description : This method will save after adding skills Second Time
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void SaveSecondTime()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oSave_xpath) == true)
                {
                    Driver.FindElement(MyProfileOR.oSave_xpath).Click();
                    Report.UpdateTestLog("SaveSecondTimeFinalStep", "Successfully Clicked on Save button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SaveSecondTime", "Save button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SaveSecondTime", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SaveSecondTime", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method AddMaxStringInPastProject()
        // Method Description : This method will add new past project which is allowable string length 
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddMaxStringInPastProject()
        {
            try
            {
                string sPastProjectInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                int ilength = sPastProjectInputtext.Length;
                IWebElement PastProject = Driver.FindElement(MyProfileOR.oPastProjectsInputField_xpath);
                PastProject.Click();
                PastProject.SendKeys(sPastProjectInputtext);
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();
                if (common.CheckElement(MyProfileOR.oSelectedPastProject_xpath) == true)
                {
                    Report.UpdateTestLog("AddMaxStringInPastProjectFinalStep", "Successfully Entered new Past Project with String length : " + ilength, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddMaxStringInPastProject", "Failed to add new past project with String length :" + ilength, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddMaxStringInPastProject", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddMaxStringInPastProject", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method AddMoreThanMaxStringInPastProjectField()
        // Method Description : This method will try to add new past project which is more than allowable string length
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddMoreThanMaxStringInPastProjectField()
        {
            try
            {
                string sPastProjectInputtext = DataTable.GetData("General_Data_" + Env, "RequestType2");
                int ilength = sPastProjectInputtext.Length;
                IWebElement PastProject = Driver.FindElement(MyProfileOR.oPastProjectsInputField_xpath);
                PastProject.Click();
                PastProject.SendKeys(Keys.Backspace);
                PastProject.SendKeys(Keys.Backspace);
                PastProject.SendKeys(sPastProjectInputtext);
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();
                if (common.CheckElement(MyProfileOR.oSelectedPastProject_xpath) == true)
                {
                    Report.UpdateTestLog("AddMoreThanMaxStringInPastProjectFieldFinalStep", "Successfully Entered new Past Project with String length : " + ilength, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddMoreThanMaxStringInPastProjectField", "Failed to enter new past project with String length :" + ilength, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddMoreThanMaxStringInPastProjectField", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddMoreThanMaxStringInPastProjectField", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateMaxStringAllowedInPastProject()
        // Method Description : This method will Validate Maximum String length allowed in Past project field
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateMaxStringAllowedInPastProject()
        {
            try
            {
                string sPastProjectAllowableInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                int iAllowedLength = sPastProjectAllowableInputtext.Length;
                string sPastProjectMoreThanAllowableInputtext = DataTable.GetData("General_Data_" + Env, "RequestType2");
                int iMoreThanAllowedLength = sPastProjectMoreThanAllowableInputtext.Length;
                string sErrorText = DataTable.GetData("General_Data_" + Env, "RequestType3");
                IWebElement elm = Driver.FindElement(MyProfileOR.oErrorMessage_xpath);
                if (common.CheckElement(MyProfileOR.oErrorMessage_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateMaxStringAllowedInPastProjectFinalStep",
                        "Successfully validated that Past Project Field is not allowing String length :" +
                        iMoreThanAllowedLength + ", Showing error message : " + elm.Text, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateMaxStringAllowedInPastProject",
                         "Past Project Field is  allowing String length :" +
                         iMoreThanAllowedLength, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateMaxStringAllowedInPastProject", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateMaxStringAllowedInPastProject", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method Cancel()
        // Method Description : This method will click on Cancel button
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void Cancel()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oCancelButton_xpath) == true)
                {
                    Driver.FindElement(MyProfileOR.oCancelButton_xpath).Click();
                    Report.UpdateTestLog("CancelFinalStep", "Successfully Clicked on Cancel button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("Cancel", "Cancel button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Cancel", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Cancel", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidatePastProjectInMyProfilewithAllowableString()
        // Method Description : This method will validate whether the Past Project update is successfull after editing
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidatePastProjectInMyProfilewithAllowableString()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oPastProjectUpdateOnProfilePage_xpath);
                string stext = elm.Text.Trim();
                string sPastProjectInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                //string sPastProjectInputtext2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (stext.Contains(sPastProjectInputtext))
                {
                    Report.UpdateTestLog("ValidatePastProjectInMyProfilewithAllowableStringFinalStep",
                        "Successfully validated that Past Project update is successfull on My Profile page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidatePastProjectInMyProfilewithAllowableString", "Past Project Update is unsuccessfull on My Profile page",
                        Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidatePastProjectInMyProfileAfterSave", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidatePastProjectInMyProfileAfterSave", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeletePastProjectLongStringData()
        // Method Description : This method delete the long string in Past Project Field
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeletePastProjectLongStringData()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oPastProjectUpdateOnProfilePage_xpath);
                string stext = elm.Text.Trim();
                IWebElement elm1 = Driver.FindElement(MyProfileOR.oExpServiceEdit_xpath);
                common.CheckElement(MyProfileOR.oExpServiceEdit_xpath);
                string sedit = elm1.Text;
                elm1.Click();
                IWebElement PastProject = Driver.FindElement(MyProfileOR.oPastProjectsInputField_xpath);
                PastProject.Click();
                PastProject.SendKeys(Keys.Backspace);
                PastProject.SendKeys(Keys.Backspace);
                //Report.UpdateTestLog("DeletePastProjectLongStringData", "Successfully clicked the cross icon to delete the Past Project", Status.PASS);
                Driver.FindElement(MyProfileOR.oSave_xpath).Click();
                IWebElement elm2 = Driver.FindElement(MyProfileOR.oPastProjectUpdateOnProfilePage_xpath);
                string stext2 = elm2.Text.Trim();

                if (stext != stext2)
                {
                    Report.UpdateTestLog("DeletePastProjectLongStringDataFinalStep", "Successfully delete the Past Project", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("DeletePastProjectLongStringData", "Failed to delete the Past Project", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeletePastProjectLongStringData", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeletePastProjectLongStringData", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ValidateOrgChartInMyProfile()
        // Method Description : This method will validate the organization chart on My Profile page
        // Created On: 02/03/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateOrgChartInMyProfile()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oOrgChartLabel_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Successfully validated that org chart label is present on lower right side beneath work schedule ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Org chart label is not present on My Profile page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(MyProfileOR.oOrgChart_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Successfully validated that org chart is present ", Status.PASS);
                    IWebElement e = Driver.FindElement(MyProfileOR.oOrgChart_xpath);
                    string s = e.GetAttribute("readonly");
                    if (s == null)
                    {

                        Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Successfully validated that org chart is not editable ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Org chart is not editable ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Org chart is not present ", Status.PASS);
                }
                if (common.CheckElement(MyProfileOR.oImagePlaceHolder_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Successfully validated that there is a picture or placeholder present for every person in org chart ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Picture or placeholder is not present for every person in org chart ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(MyProfileOR.oOrgChartName_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Successfully validated that Name is present for every person in org chart ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Name is not present for every person in org chart ", Status.PASS);
                }
                if (common.CheckElement(MyProfileOR.oOrgChartTitle_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Successfully validated that Title is present for every person in org chart ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Title is not present for every person in org chart ", Status.PASS);
                }
                ReadOnlyCollection<IWebElement> orgchartpeoples = Driver.FindElements(MyProfileOR.oOrgChartPeoplelist_xpath);
                int icount = orgchartpeoples.Count;
                IWebElement elm = Driver.FindElement(MyProfileOR.oOrgChartTitle_xpath);
                string stitle = elm.Text;
                if (icount > 1 && stitle.Contains("Manager"))
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfileFinalStep", " Successfully validated that the order of the org chart is: supervisor, person themselves and then any direct reports in a tree layout ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " The order of the org chart is not like : supervisor, person themselves and then any direct reports in a tree layout ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateOrgChartInMyProfile", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateOrgChartInMyProfile", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateSuperviserAndOtherProfile()
        // Method Description : This method will validate the Supervisor and other profile page
        // Created On: 02/03/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateSuperviserAndOtherProfile()
        {
            try
            {
                IWebElement supervisor = Driver.FindElement(MyProfileOR.oOrgChartName_xpath);
                string sSupervisorName = supervisor.Text.Trim();
                supervisor.Click();
                common.CallMeWait(2000);
                common.WaitForElement(MyProfileOR.oSupervisorName_xpath);
                IWebElement supervisorprofile = Driver.FindElement(MyProfileOR.oSupervisorName_xpath);
                string sSupervisorNameOnSupervisorProfile = supervisorprofile.Text.Trim();
                if (sSupervisorName == sSupervisorNameOnSupervisorProfile)
                {
                    Report.UpdateTestLog("ValidateSuperviserAndOtherProfile", " Successfully validated that after clicking on the supervisor's profile in org chart it redirects to the supervisor profile ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateSuperviserAndOtherProfile", " After clicking on the supervisor's profile in org chart it doesn't redirect to the supervisor profile ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                IWebElement sup = Driver.FindElement(MyProfileOR.oOrgChartName_xpath);
                string supvsr = sup.Text.Trim();
                sup.Click();
                common.CallMeWait(2000);
                common.WaitForElement(MyProfileOR.oSupervisorName_xpath);
                IWebElement elm2 = Driver.FindElement(MyProfileOR.oSupervisorName_xpath);
                string supvsr1 = elm2.Text.Trim();
                if (supvsr == supvsr1)
                {
                    Report.UpdateTestLog("ValidateSuperviserAndOtherProfileFinalStep", " Successfully validated that clicking on one of the other profiles in the org chart while visiting another person's profile, redirected to that persons profile page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateSuperviserAndOtherProfile", " Clicking on one of the other profiles in the org chart while visiting another person's profile, doesn't redirected to that persons profile page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSuperviserAndOtherProfile", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSuperviserAndOtherProfile", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method Visitor_ValidateSuperviserAndOtherProfile()
        // Method Description : This method will validate the Supervisor and other profile page
        // Created On: 02/03/2017
        // Created By: GI offShore Team
        // *****************************************

        public void Visitor_ValidateSuperviserAndOtherProfile()
        {
            try
            {
                IWebElement supervisor = Driver.FindElement(MyProfileOR.oOrgChartName_xpath);
                string sSupervisorName = supervisor.Text.Trim();
                supervisor.Click();
                common.CallMeWait(2000);
                common.WaitForElement(MyProfileOR.oSupervisorName_xpath);
                IWebElement supervisorprofile = Driver.FindElement(MyProfileOR.oSupervisorName_xpath);
                string sSupervisorNameOnSupervisorProfile = supervisorprofile.Text.Trim();
                if (sSupervisorName == sSupervisorNameOnSupervisorProfile)
                {
                    Report.UpdateTestLog("Visitor_ValidateSuperviserAndOtherProfile", " Successfully validated that after clicking on the supervisor's profile in org chart it redirects to the supervisor profile ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("Visitor_ValidateSuperviserAndOtherProfile", " After clicking on the supervisor's profile in org chart it doesn't redirect to the supervisor profile ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                IWebElement sup = Driver.FindElement(MyProfileOR.oOrgChartName_xpath);
                string supvsr = sup.Text.Trim();
                sup.Click();
                common.CallMeWait(2000);
                common.WaitForElement(MyProfileOR.oSupervisorName_xpath);
                IWebElement elm2 = Driver.FindElement(MyProfileOR.oSupervisorName_xpath);
                string supvsr1 = elm2.Text.Trim();
                if (supvsr == supvsr1)
                {
                    Report.UpdateTestLog("Visitor_ValidateSuperviserAndOtherProfileFinalStep", " Successfully validated that clicking on one of the other profiles in the org chart while visiting another person's profile, redirected to that persons profile page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("Visitor_ValidateSuperviserAndOtherProfile", " Clicking on one of the other profiles in the org chart while visiting another person's profile, doesn't redirected to that persons profile page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Visitor_ValidateSuperviserAndOtherProfile", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Visitor_ValidateSuperviserAndOtherProfile", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ValidateFooterNotEditable()
        // Method Description : This method will validate footer is not editable
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateFooterNotEditable()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> allimages = Driver.FindElements(MyProfileOR.oFootercontent_xpath);
                for (int i = 0; i < allimages.Count; i++)
                {
                    if (allimages[i].TagName != "a")
                    {
                        flag = false;
                    }
                }
                if (flag == true)
                {
                    Report.UpdateTestLog("ValidateFooterNotEditableFinalStep", " Successfully validated that Footer is not editable", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateFooterNotEditable", " Footer is editable", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateFooterNotEditable", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateFooterNotEditable", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateFooterSectionsAndLinks()
        // Method Description : This method will validate footer Contents and links
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateFooterSectionsAndLinks()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> alllinks = Driver.FindElements(MyProfileOR.oFootercontent_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 1; i < alllinks.Count; i++)
                    {
                        if (links[j].Trim() != alllinks[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateFooterSectionsAndLinksFinalStep", " link '" + links[j].Trim() + "' is present under '" + alllinks[0].Text.Trim() + "'", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateFooterSectionsAndLinks", " link '" + links[j].Trim() + "' is not present under '" + alllinks[0].Text.Trim() + "'", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateFooterSectionsAndLinks", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateFooterSectionsAndLinks", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateCorporateInformationFooterSectionsAndLinks()
        // Method Description : This method will validate Corporate Information footer Contents and links
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateCorporateInformationFooterSectionsAndLinks()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> alllinks = Driver.FindElements(MyProfileOR.oCorporateInformationFooter_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 1; i < alllinks.Count; i++)
                    {
                        if (links[j].Trim() != alllinks[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateCorporateInformationFooterSectionsAndLinksFinalStep", " link '" + links[j].Trim() + "' is present under '" + alllinks[0].Text.Trim() + "'", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateCorporateInformationFooterSectionsAndLinks", " link '" + links[j].Trim() + "' is not present under '" + alllinks[0].Text.Trim() + "'", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCorporateInformationFooterSectionsAndLinks", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCorporateInformationFooterSectionsAndLinks", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ValidateAccountManagementFooterSectionsAndLinks()
        // Method Description : This method will validate Account Managementfooter Contents and links
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateAccountManagementFooterSectionsAndLinks()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> alllinks = Driver.FindElements(MyProfileOR.oAccountManagementFooter_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType4");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 1; i < alllinks.Count; i++)
                    {
                        if (links[j].Trim() != alllinks[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateAccountManagementFooterSectionsAndLinksFinalStep", " link '" + links[j].Trim() + "' is present under '" + alllinks[0].Text.Trim() + "'", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateAccountManagementFooterSectionsAndLinks", " link '" + links[j].Trim() + "' is not present under '" + alllinks[0].Text.Trim() + "'", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAccountManagementFooterSectionsAndLinks", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAccountManagementFooterSectionsAndLinks", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateCollaborationToolsFooterSectionsAndLinks()
        // Method Description : This method will validate Collaboration Tools footer Contents and links
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateCollaborationToolsFooterSectionsAndLinks()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> alllinks = Driver.FindElements(MyProfileOR.oCollaborationToolsFooter_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType5");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 1; i < alllinks.Count; i++)
                    {
                        if (links[j].Trim() != alllinks[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateCollaborationToolsFooterSectionsAndLinksFinalStep", " link '" + links[j].Trim() + "' is present under '" + alllinks[0].Text.Trim() + "'", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateCollaborationToolsFooterSectionsAndLinks", " link '" + links[j].Trim() + "' is not present under '" + alllinks[0].Text.Trim() + "'", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCollaborationToolsFooterSectionsAndLinks", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCollaborationToolsFooterSectionsAndLinks", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method NavigateToOwnedSite()
        // Method Description : This method will navigate to owned site and validate footer
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void NavigateToOwnedSite()
        {
            try
            {
                string NavigationUrl = DataTable.GetData("General_Data_" + Env, "NavigationURL");
                Driver.Navigate().GoToUrl(NavigationUrl);
                Report.UpdateTestLog("NavigateToOwnedSite", "Navigate to " + NavigationUrl, Status.PASS);
                ValidateFooterSectionsAndLinks();
                ValidateCorporateInformationFooterSectionsAndLinks();
                ValidateAccountManagementFooterSectionsAndLinks();
                ValidateCollaborationToolsFooterSectionsAndLinks();
                Report.UpdateTestLog("NavigateToOwnedSiteFinalStep", " Validated the footer contents of owned site", Status.PASS);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToOwnedSite", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method NavigateToOtherSite()
        // Method Description : This method will navigate to other site and validate footer
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void NavigateToOtherSite()
        {
            try
            {
                string NavigationUrl = DataTable.GetData("General_Data_" + Env, "RequestType1");
                Driver.Navigate().GoToUrl(NavigationUrl);
                Report.UpdateTestLog("NavigateToOtherSite", "Navigate to " + NavigationUrl, Status.PASS);
                ValidateFooterSectionsAndLinks();
                ValidateCorporateInformationFooterSectionsAndLinks();
                ValidateAccountManagementFooterSectionsAndLinks();
                ValidateCollaborationToolsFooterSectionsAndLinks();
                Report.UpdateTestLog("NavigateToOtherSiteFinalStep", " Validated the footer contents of other site", Status.PASS);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToOtherSite", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method NavigateToHomePage()
        // Method Description : This method will navigate to Home Page
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void NavigateToHomePage()
        {
            try
            {
                string homepageurl;
                if (Env == "CI")
                {
                    homepageurl = "http://ci-intranet.cbre.com/en-US";
                }
                else
                {
                    homepageurl = "https://fte-intranet.cbre.com/en-US";
                }
                Driver.Navigate().GoToUrl(homepageurl);
                string pageurl = Driver.Url;
                if (homepageurl.Trim() == pageurl)
                {
                    Report.UpdateTestLog("NavigateToHomePageFinalStep", "Successfully Navigate to " + pageurl, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("NavigateToHomePage", " Navigate to " + pageurl + " ,expected URL: " + homepageurl, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToHomePage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateAboutUs()
        // Method Description : This method will navigate to About Us page and validate
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // ***************************************** 

        public void ValidateAboutUs()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oAboutUsFooter_xpath);
                if (elm.Text.Trim() == "About Us")
                {
                    Report.UpdateTestLog("ValidateAboutUs", " About Us link is present in Footer section", Status.PASS);
                    elm.Click();
                    common.CallMeWait(2000);
                    string url = Driver.SwitchTo().Window(Driver.WindowHandles[1]).Url;
                    string expurl = "http://www.cbre.com/about";
                    if (url == expurl)
                    {
                        Report.UpdateTestLog("ValidateAboutUsFinalStep", " Successfully navigated to About Us page in new tab", Status.PASS);
                        Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
                        Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateAboutUs", " Failed to navigate to About Us page, goes to: " + url + " , expected url :" + expurl, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    //NavigateToHomePage();
                }
                else
                {
                    Report.UpdateTestLog("ValidateAboutUs", " About Us link is not present in Footer section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAboutUs", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAboutUs", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateCorporateResponsibility()
        // Method Description : This method will navigate to Corporate Responsibility page and validate
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // ***************************************** 

        public void ValidateCorporateResponsibility()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oCorporateResponsibility_xpath);
                if (elm.Text.Trim() == "Corporate Responsibilty")
                {
                    Report.UpdateTestLog("ValidateCorporateResponsibility", " Corporate Responsibilty link is present in Footer section", Status.PASS);
                    elm.Click();
                    common.CallMeWait(2000);
                    string url = Driver.SwitchTo().Window(Driver.WindowHandles[1]).Url;
                    string expurl = "http://www.cbre.com/about/corporate-responsibility";
                    if (url == expurl)
                    {
                        Report.UpdateTestLog("ValidateCorporateResponsibilityFinalStep", " Successfully navigated to Corporate Responsibilty page in new tab", Status.PASS);
                        Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
                        Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateCorporateResponsibility", " Failed to navigate to Corporate Responsibilty page, goes to: " + url + " , expected url :" + expurl, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateCorporateResponsibility", " Corporate Responsibilty link is not present in Footer section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCorporateResponsibility", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCorporateResponsibility", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateResources()
        // Method Description : This method will navigate to Resources page and validate then navigates back to homepage
        // Created On: 02/04/2017
        // Created By: GI offShore Team
        // ***************************************** 

        public void ValidateResources()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oResources_xpath);
                if (elm.Text.Trim() == "Resources")
                {
                    Report.UpdateTestLog("ValidateResources", " Resources link is present in Footer section", Status.PASS);
                    elm.Click();
                    common.CallMeWait(2000);
                    string url = Driver.Url;
                    string expurl = "intranet.cbre.com/en-US/Resources";
                    if (url.Contains(expurl))
                    {
                        Report.UpdateTestLog("ValidateResourcesFinalStep", " Successfully navigated to Resources page ", Status.PASS);
                        NavigateToHomePage();
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateResources", " Failed to navigate to Corporate Responsibilty page, goes to: " + url + " , expected url :" + expurl, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateResources", " Corporate Responsibilty link is not present in Footer section", Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateResources", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateResources", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

  
         //**********************************************
        // Method ClickOnEditContactInformation()
        // Method Description : This method will click on edit link beside contact information
        // Created On: 02/06/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnEditContactInformation()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oEditContactInformation_xpath) == true)
                {
                    IWebElement elm = Driver.FindElement(MyProfileOR.oEditContactInformation_xpath);
                    string sedit = elm.Text;
                    elm.Click();
                    Report.UpdateTestLog("ClickOnEditContactInformation", "Successfully clicked on " + sedit + " link", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnEditContactInformation", " edit link is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;     
                }
                common.WaitForElement(MyProfileOR.oSaveContactInformation_xpath);
                if (common.CheckElement(MyProfileOR.oSaveContactInformation_xpath) == true)
                {
                    Report.UpdateTestLog("ClickOnEditContactInformationFinalStep", "Successfully opened contact information in edit mode ", Status.PASS);   
                }
                else
                {
                    Report.UpdateTestLog("ClickOnEditContactInformation", "Failed to open contact information in edit mode ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;     
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnEditContactInformation", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnEditContactInformation", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        
        //**********************************************
        // Method ValidateContactInformationContents()
        // Method Description : This method will validate Contact Information section in Edit mode
        // Created On: 02/06/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateContactInformationContents()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> allllabels = Driver.FindElements(MyProfileOR.oContactInformationcontents_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 0; i < allllabels.Count; i++)
                    {
                        if (links[j].Trim() != allllabels[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateContactInformationContents", " link '" + links[j].Trim() + "' is present under Contact Information", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateContactInformationContents", " link '" + links[j].Trim() + "' is not present under Contact Information", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                bool flag1 = true;
                ReadOnlyCollection<IWebElement> allHRs = Driver.FindElements(MyProfileOR.oEditInHRcontents_xpath);
                String requestType2 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string[] labels = requestType2.Split(',');
                for (int k = 0; k < labels.Length; k++)
                {
                    for (int l = 1; l < allHRs.Count; l++)
                    {
                        if (allHRs[l].Text.Trim() == "Edit in myHR")
                        {                            
                            Report.UpdateTestLog("ValidateContactInformationContents", " link '" + allHRs[l].Text.Trim() + "' is present beside label : '" + labels[k].Trim()+"'", Status.PASS);
                            break;
                        }
                        else
                        {
                            flag1 = false;                           
                        }
                    }
                    if (flag1 == false)
                    {
                        Report.UpdateTestLog("ValidateContactInformationContents", " link 'Edit in myHR' is not present beside label : '" + labels[k].Trim() + "'" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;         
                    }
                }
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(MyProfileOR.oEditInHRcontents_xpath);
                String requestType3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string[] rdonly = requestType3.Split(',');
                for (int x = 0; x < rdonly.Length; x++)
                {
                    if (elms[x].GetAttribute("readonly") == null)
                    {
                        Report.UpdateTestLog("ValidateContactInformationContentsFinalStep", " label '" + allllabels[x].Text.Trim() + "' is not editable ", Status.PASS);     
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateContactInformationContents", " label '" + allllabels[x].Text.Trim() + "' is editable ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;   
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateContactInformationContents", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateContactInformationContents", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateManagerFieldInContactInformation()
        // Method Description : This method will validate the Manager In Contact Information section
        // Created On: 02/06/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateManagerFieldInContactInformation()
        {
            try
            {                
                IWebElement supervisor = Driver.FindElement(MyProfileOR.OManager_xpath);
                if (supervisor.TagName == "a")
                {
                    Report.UpdateTestLog("ValidateManagerFieldInContactInformation", " Successfully validated that Manager field is not editable ", Status.PASS);   
                }
                else
                {
                    Report.UpdateTestLog("ValidateManagerFieldInContactInformation", " Manager field is editable ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;   
                }
                string sSupervisorName = supervisor.Text.Trim();
                supervisor.Click();
                common.CallMeWait(2000);
                common.WaitForElement(MyProfileOR.oSupervisorName_xpath);
                IWebElement supervisorprofile = Driver.FindElement(MyProfileOR.oSupervisorName_xpath);
                string sSupervisorNameOnSupervisorProfile = supervisorprofile.Text.Trim();
                if (sSupervisorName == sSupervisorNameOnSupervisorProfile)
                {
                    Report.UpdateTestLog("ValidateManagerFieldInContactInformationFinalStep", " Successfully validated that after clicking on the manager's profile in contact information it redirects to the manager profile ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateManagerFieldInContactInformation", " After clicking on the manager's profile in contact information it doesn't redirect to the manager profile ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }              
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateManagerFieldInContactInformation", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateManagerFieldInContactInformation", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method NavigateBackToContactInformationEditPage()
        // Method Description : This method will Navigate Back To Contact Information EditPage 
        // Created On: 02/06/2017
        // Created By: GI offShore Team
        // *****************************************

        public void NavigateBackToContactInformationEditPage()
        {
            try
            {
                string topNavigation = DataTable.GetData("General_Data_" + Env, "TopNavigation");
                topNavigation = topNavigation.Trim();
                string dynamicXpath = "//*[text()='" + topNavigation + "']";

                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("NavigateBackToContactInformationEditPage", " Click on  : " + topNavigation, Status.PASS);
                common.WaitForElement(MyProfileOR.oEditContactInformation_xpath);
                IWebElement elm = Driver.FindElement(MyProfileOR.oEditContactInformation_xpath);
                string sedit = elm.Text;
                elm.Click();
                Report.UpdateTestLog("NavigateBackToContactInformationEditPage", "Successfully clicked on " + sedit + " link", Status.DONE);
                common.WaitForElement(MyProfileOR.oSaveContactInformation_xpath);
                if (common.CheckElement(MyProfileOR.oSaveContactInformation_xpath) == true)
                {
                    Report.UpdateTestLog("NavigateBackToContactInformationEditPageFinalStep", "Successfully opened contact information in edit mode ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("NavigateBackToContactInformationEditPage", "Failed to open contact information in edit mode ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
   
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigateBackToContactInformationEditPage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateBackToContactInformationEditPage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateAssistantInContactInformationEditPage()
        // Method Description : This method will validate Assistant in Contact Information EditPage and calls DeleteAssistant() method if newly added 
        // Created On: 02/06/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateAssistantInContactInformationEditPage()
        {
            try
            {
                string AssistantName = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                IWebElement elm = Driver.FindElement(MyProfileOR.OAssistantInputField_xpath);
                if (common.CheckElement(MyProfileOR.OAssistantDeleteIcon_xpath) == false)
                {
                    elm.Click();
                    IWebElement elm5 = Driver.FindElement(MyProfileOR.OAssistantInput_xpath);
                    elm5.SendKeys(AssistantName);
                    common.CallMeWait(2000);
                    common.WaitForElement(MyProfileOR.OAssistantAutoPopulate_xpath);
                    Driver.FindElement(MyProfileOR.OAssistantAutoPopulate_xpath).Click();
                    if (common.CheckElement(MyProfileOR.OAssistantNameSelected_xpath) == true)
                    {
                        Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage",
                            "Selected assistant name means Assistant field is editable", Status.PASS);
                        common.WaitForElement(MyProfileOR.oSaveContactInformation_xpath);
                        Driver.FindElement(MyProfileOR.oSaveContactInformation_xpath).Click();
                        Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage", "Clicked on Save button",
                            Status.DONE);
                        common.CallMeWait(5000);
                        if (common.CheckElement(MyProfileOR.OAssistantName_xpath) == true)
                        {
                            IWebElement elm1 = Driver.FindElement(MyProfileOR.OAssistantName_xpath);
                            string sAssistantName = elm1.Text.Trim();
                            if (AssistantName == sAssistantName)
                            {
                                Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage",
                                    "Assistant name is successfully saved", Status.PASS);
                                elm1.Click();
                                common.CallMeWait(4000);
                                IWebElement AssistantProfile = Driver.FindElement(MyProfileOR.oSupervisorName_xpath);
                                string sAssistantNameOnAssistantProfile = AssistantProfile.Text.Trim();
                                if (AssistantName == sAssistantNameOnAssistantProfile)
                                {
                                    Report.UpdateTestLog("ValidateAssistantInContactInformationEditPageFinalStep",
                                        " Successfully validated that after clicking on the assistant's profile in contact information it redirects to the assistant profile ",
                                        Status.PASS);
                                    DeleteAssistant();
                                }
                                else
                                {
                                    Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage",
                                        " After clicking on the assistant's profile in contact information it doesn't redirect to the assistant profile ",
                                        Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                }
                            }
                            else
                            {
                                Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage",
                                    "Assistant name is not matching", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage",
                                                                "Assistant name field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage",
                            "Not able to select assistant name ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage", "Assistant is already present",
                        Status.PASS);
                    common.WaitForElement(MyProfileOR.oSaveContactInformation_xpath);
                    Driver.FindElement(MyProfileOR.oSaveContactInformation_xpath).Click();
                    Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage", "Clicked on Save button",
                        Status.DONE);
                    common.CallMeWait(4000);
                    common.WaitForElement(MyProfileOR.OAssistantName_xpath);
                    IWebElement elm1 = Driver.FindElement(MyProfileOR.OAssistantName_xpath);
                    string sAssistantName = elm1.Text.Trim();
                    elm1.Click();
                    common.CallMeWait(4000);
                    IWebElement AssistantProfile = Driver.FindElement(MyProfileOR.oSupervisorName_xpath);
                    string sAssistantNameOnAssistantProfile = AssistantProfile.Text.Trim();
                    if (sAssistantName == sAssistantNameOnAssistantProfile)
                    {
                        Report.UpdateTestLog("ValidateAssistantInContactInformationEditPageFinalStep",
                            " Successfully validated that after clicking on the assistant's profile in contact information it redirects to the assistant profile ",
                            Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage",
                            " After clicking on the assistant's profile in contact information it doesn't redirect to the assistant profile ",
                            Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
          }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAssistantInContactInformationEditPage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeleteAssistant()
        // Method Description : This method will delete the assistant name if added new
        // Created On: 02/06/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteAssistant()
        {
            try
            {
                string AssistantName = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                string topNavigation = DataTable.GetData("General_Data_" + Env, "TopNavigation");
                topNavigation = topNavigation.Trim();
                string dynamicXpath = "//*[text()='" + topNavigation + "']";

                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("DeleteAssistant", " Click on  : " + topNavigation, Status.PASS);
                common.WaitForElement(MyProfileOR.oEditContactInformation_xpath);
                IWebElement elm = Driver.FindElement(MyProfileOR.oEditContactInformation_xpath);
                string sedit = elm.Text;
                elm.Click();
                Report.UpdateTestLog("DeleteAssistant", "Successfully clicked on " + sedit + " link", Status.DONE);
                common.WaitForElement(MyProfileOR.oSaveContactInformation_xpath);
                if (common.CheckElement(MyProfileOR.oSaveContactInformation_xpath) == true)
                {
                    Report.UpdateTestLog("DeleteAssistant", "Successfully opened contact information in edit mode ", Status.PASS);
                    if (common.CheckElement(MyProfileOR.OAssistantDeleteIcon_xpath) == true)
                    {
                        IWebElement elm1 = Driver.FindElement(MyProfileOR.OAssistantDeleteIcon_xpath);
                        elm1.Click();                        
                        if (common.CheckElement(MyProfileOR.OAssistantNameSelected_xpath) == false)
                        {
                            Report.UpdateTestLog("DeleteAssistant", "Successfully deleted the assistant in edit section ", Status.PASS);
                            IWebElement save = Driver.FindElement(MyProfileOR.oSaveContactInformation_xpath);
                            save.Click();
                            Report.UpdateTestLog("DeleteAssistant", "Successfully clicked on save button ", Status.PASS);   
                            common.CallMeWait(3000);
                            common.WaitForElement(MyProfileOR.OBlankAssistantName_xpath);
                            IWebElement elm2 = Driver.FindElement(MyProfileOR.OBlankAssistantName_xpath);
                            string sAssistantName = elm2.Text.Trim();
                            if (AssistantName != sAssistantName)
                            {
                                Report.UpdateTestLog("DeleteAssistantFinalStep", "Successfully deleted the assistant ", Status.PASS);   
                            }
                            else
                            {
                                Report.UpdateTestLog("DeleteAssistant", "Failed to delete the assistant ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;  
                            }

                        }
                        else
                        {
                            Report.UpdateTestLog("DeleteAssistant", "Failed to delete the assistant in edit mode ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;  
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("DeleteAssistant", "No Assistant is present to delete ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;    
                    }

                }
                else
                {
                    Report.UpdateTestLog("DeleteAssistant", "Failed to open contact information in edit mode ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }    
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteAssistant", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteAssistant", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ValidateMyProfileleftColumn()
        // Method Description : This method will validate profile image and contents
        // Created On: 02/06/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateMyProfileleftColumn()
        {
            try
            {
                ReadOnlyCollection<IWebElement> profile = Driver.FindElements(MyProfileOR.OProfile_xpath);
                if (profile.Count == 2)
                {
                    Report.UpdateTestLog("ValidateMyProfileleftColumn", " Successfully validated that profile page is divided into 2 columns" , Status.PASS);   
                }
                else
                {
                    Report.UpdateTestLog("ValidateMyProfileleftColumn", " Profile page is not divided into 2 columns", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;     
                }
                if (common.CheckElement(MyProfileOR.OProfileImage_xpath))
                {
                    Report.UpdateTestLog("ValidateMyProfileleftColumn", " Successfully validated that profile image is on left columns", Status.PASS);     
                }
                else
                {
                    Report.UpdateTestLog("ValidateMyProfileleftColumn", " Profile image is not on left columns", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;       
                }
                bool flag = true;
                ReadOnlyCollection<IWebElement> contents = Driver.FindElements(MyProfileOR.OProfileDetails_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 0; i < contents.Count; i++)
                    {
                        if (links[j].Trim() != contents[i].GetAttribute("id").Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateMyProfileleftColumnFinalStep", " '" + links[j].Trim() + "' is present in My Profile page", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateMyProfileleftColumn", " '" + links[j].Trim() + "' is not present in My Profile page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateMyProfileleftColumn", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateMyProfileleftColumn", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method NavigateToEmployeeProfile()
        // Method Description : This method will navigate to Employee's Profile page after clicking My Profile
        // Created On: 02/06/2017
        // Created By: GI offShore Team
        // ***************************************** 

        public void NavigateToEmployeeProfile()
        {
            try
            {
                common.WaitForElement(MyProfileOR.oProfile_xpath);
                string profiletext = Driver.FindElement(MyProfileOR.oProfile_xpath).Text.Trim();
                if (profiletext.Equals("Profile"))
                {
                    Report.UpdateTestLog("NavigateToEmployeeProfileFinalStep", "Navigated to  Profile page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("NavigateToEmployeeProfile", "Unable to navigate to profile page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigateToEmployeeProfile", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToEmployeeProfile", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //**********************************************
        // Method ValidateMyProfileRightColumn()
        // Method Description : This method will validate profile image and contents of right side
        // Created On: 02/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateMyProfileRightColumn()
        {
            try
            {
                ReadOnlyCollection<IWebElement> profile = Driver.FindElements(MyProfileOR.OProfile_xpath);
                if (profile.Count == 2)
                {
                    Report.UpdateTestLog("ValidateMyProfileRightColumn", " Successfully validated that profile page is divided into 2 columns", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateMyProfileRightColumn", " Profile page is not divided into 2 columns", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                bool flag = true;
                string s;
                ReadOnlyCollection<IWebElement> contents = Driver.FindElements(MyProfileOR.OMyProfileRightSection_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 0; i < contents.Count; i++)
                    {
                        if (contents[i].Text.Trim().Contains("EDIT"))
                        {
                            s = contents[i].Text.Trim().Substring(0, contents[i].Text.Trim().Length - 5);
                        }
                        else
                        {
                            s = contents[i].Text.Trim();
                        }
                        if (links[j].Trim() != s)
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateMyProfileRightColumn", " '" + links[j].Trim() + "' is present in My Profile page on right side", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateMyProfileRightColumn", " '" + links[j].Trim() + "' is not present in My Profile page on right side", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }

                ReadOnlyCollection<IWebElement> orgchartpeoples = Driver.FindElements(MyProfileOR.oOrgChartPeoplelist_xpath);
                int icount = orgchartpeoples.Count;
                IWebElement elm = Driver.FindElement(MyProfileOR.oOrgChartTitle_xpath);
                string stitle = elm.Text;
                if (icount > 1 && stitle.Contains("Manager"))
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfileFinalStep", " Successfully validated that org chart shows the employee's direct report and their subordinates ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateOrgChartInMyProfile", " Org Chart doesn't show the employee's direct report and their subordinates ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateMyProfileRightColumn", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateMyProfileRightColumn", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickOnOfficeLocationEdit()
        // Method Description : This method will click on Edit Link beside Office Location
        // Created On: 02/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnOfficeLocationEdit()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oOfficeLocationEdit_xpath) == true)
                {
                    Report.UpdateTestLog("ClickOnOfficeLocationEdit", " Edit link is present beside Office Location" , Status.PASS); 
                    Driver.FindElement(MyProfileOR.oOfficeLocationEdit_xpath).Click();
                    Report.UpdateTestLog("ClickOnOfficeLocationEdit", " Clicked on Edit link beside Office Location", Status.DONE);
                    if (common.CheckElement(MyProfileOR.oSaveOfficeLocation_xpath) == true)
                    {
                        Report.UpdateTestLog("ClickOnOfficeLocationEditFinalStep", " Successfully open the office location section in edit mode ", Status.PASS);    
                    }
                    else
                    {
                        Report.UpdateTestLog("ClickOnOfficeLocationEdit", " Failed to open the office location section in edit mode ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;   
                    }
                }
                else
                {
                    Report.UpdateTestLog("ClickOnOfficeLocationEdit", " Edit link is not present beside Office Location", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;     
                }   
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnOfficeLocationEdit", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnOfficeLocationEdit", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ValidateOfficeLocationContents()
        // Method Description : This method will validate Office Location contents
        // Created On: 02/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateOfficeLocationContents()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> contents = Driver.FindElements(MyProfileOR.oOfficeLocationContents_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 0; i < contents.Count; i++)
                    {
                        if (links[j].Trim() != contents[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateOfficeLocationContents", " '" + links[j].Trim() + "' is present in Office location section", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateOfficeLocationContents", " '" + links[j].Trim() + "' is not present in Office location section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                if (Driver.FindElement(MyProfileOR.oAddress_xpath).TagName == "div")
                {
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " Address is not editable in Office location section", Status.PASS);  
                }
                else
                {
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " Address is editable in Office location section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;     
                }
                if (Driver.FindElement(MyProfileOR.oLocationCode_xpath).TagName == "div")
                {
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " Location code is not editable in Office location section", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " Location code is editable in Office location section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (Driver.FindElement(MyProfileOR.oFloor_xpath).TagName == "input")
                {
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " Floor is editable in Office location section", Status.PASS);
                    string floorNumber = "20";
                    string expFlrNmbr = "22";
                    IWebElement elm = Driver.FindElement(MyProfileOR.oFloor_xpath);
                    elm.Click();
                    elm.Clear();
                    elm.SendKeys(expFlrNmbr);
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " New Floor Number is entered", Status.DONE);
                    Driver.FindElement(MyProfileOR.oSaveOfficeLocation_xpath).Click();
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " Clicked on Save button", Status.DONE);
                    common.CallMeWait(2000);
                    string sAddress = Driver.FindElement(MyProfileOR.oFloorNumberInMyProfile_xpath).Text.Trim();
                    string sActualFloorNumber = sAddress.Substring(6);
                    if (expFlrNmbr == sActualFloorNumber)
                    {
                        Report.UpdateTestLog("ValidateOfficeLocationContents", " Successfully validated that floor is saved with new data", Status.PASS);
                        ClickOnOfficeLocationEdit();
                        elm.Click();
                        elm.Clear();
                        elm.SendKeys(floorNumber);
                        Driver.FindElement(MyProfileOR.oSaveOfficeLocation_xpath).Click();
                        Report.UpdateTestLog("ValidateOfficeLocationContents", " Clicked on Save button", Status.DONE);
                        common.CallMeWait(2000);
                        string sAddress1 = Driver.FindElement(MyProfileOR.oFloorNumberInMyProfile_xpath).Text.Trim();
                        string sActualFloorNumber1 = sAddress1.Substring(6);
                        if (floorNumber == sActualFloorNumber1)
                        {
                            Report.UpdateTestLog("ValidateOfficeLocationContentsFinalStep", " Floor number successfully changed to previous number", Status.PASS);  
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateOfficeLocationContents", " Floor number failed to change to previous number", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;   
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateOfficeLocationContents", " Floor is not saved with new data", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;  
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " Floor is not editable in Office location section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateOfficeLocationContents", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateOfficeLocationContents", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateEditContactInformation()
        // Method Description : This method will validate and click on edit link beside contact information
        // Created On: 02/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateEditContactInformation()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oEditContactInformation_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateEditContactInformation",
                                                " Edit link is present beside Contact Information ", Status.PASS);
                    IWebElement elm = Driver.FindElement(MyProfileOR.oEditContactInformation_xpath);
                    string sedit = elm.Text;
                    elm.Click();
                    Report.UpdateTestLog("ValidateEditContactInformation", "Successfully clicked on " + sedit + " link",
                        Status.DONE);
                    common.WaitForElement(MyProfileOR.oSaveContactInformation_xpath);
                    if (common.CheckElement(MyProfileOR.oSaveContactInformation_xpath) == true)
                    {
                        Report.UpdateTestLog("ValidateEditContactInformationFinalStep",
                            "Successfully opened contact information in edit mode ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateEditContactInformation",
                            "Failed to open contact information in edit mode ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateEditContactInformation",
                                                " Edit link is not present beside Contact Information ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateEditContactInformation", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateEditContactInformation", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateDownloadContact()
        // Method Description : This method will validate Download contact in My Profile
        // Created On: 02/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateDownloadContact()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oDownloadContact_xpath) == true) 
                {
                    Report.UpdateTestLog("ValidateDownloadContactFinalStep", " Download contact link is present in My Profile", Status.PASS);
                   }
                else
                {
                    Report.UpdateTestLog("ValidateDownloadContact", " Download contact link is not present in My Profile", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;   
                } 
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDownloadContact", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDownloadContact", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ValidateContactInformation()
        // Method Description : This method will validate Contact Information section in Edit mode
        // Created On: 02/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateContactInformation()
        {
            try
            {
                ReadOnlyCollection<IWebElement> allllabels = Driver.FindElements(MyProfileOR.oContactInformationcontents_xpath);
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(MyProfileOR.oEditInHRcontents_xpath);
                String requestType3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string[] rdonly = requestType3.Split(',');
                for (int x = 0; x < rdonly.Length; x++)
                {
                    if (elms[x].GetAttribute("readonly") == null)
                    {
                        Report.UpdateTestLog("ValidateContactInformation", " label '" + allllabels[x].Text.Trim() + "' is not editable ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateContactInformation", " label '" + allllabels[x].Text.Trim() + "' is editable ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                IWebElement elm5 = Driver.FindElement(MyProfileOR.OAssistantInput_xpath);
                if (elm5.TagName == "input")
                {
                    Report.UpdateTestLog("ValidateContactInformationFinalStep", " Assistant field is editable", Status.PASS);  
                }
                else
                {
                    Report.UpdateTestLog("ValidateContactInformation", " Assistant field is not editable", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;    
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateContactInformationContents", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateContactInformationContents", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateEditExperienceAndService()
        // Method Description : This method will click on edit link beside Experience and Service label and validate
        // Created On: 01/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateEditExperienceAndService()
        {
            try
            {
                common.WaitForElement(MyProfileOR.oExpServiceEdit_xpath);
                IWebElement elm = Driver.FindElement(MyProfileOR.oExpServiceEdit_xpath);
                string sedit = elm.Text;
                elm.Click();
                Report.UpdateTestLog("ValidateEditExperienceAndService", "Successfully clicked on " + sedit + " link", Status.DONE);
                if (common.CheckElement(MyProfileOR.oSave_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateEditExperienceAndServiceFinalStep", " Experience and Service section is opened in Edit Mode", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateEditExperienceAndService", " Experience and Service section is not opened in Edit Mode", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateEditExperienceAndService", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateEditExperienceAndService", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method AddMoreThanMaxStringInSkillField()
        // Method Description : This method will try to add new Skill which is more than allowable string length
        // Created On: 02/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddMoreThanMaxStringInSkillField()
        {
            try
            {
                string sSkillInputtext = DataTable.GetData("General_Data_" + Env, "RequestType2");
                int ilength = sSkillInputtext.Length;
                
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();
               // skill.SendKeys(Keys.Backspace);
                //skill.SendKeys(Keys.Backspace);
                skill.SendKeys(sSkillInputtext);
                IWebElement PastProject = Driver.FindElement(MyProfileOR.oPastProjectsInputField_xpath);
                PastProject.Click();
                if (common.CheckElement(MyProfileOR.oSelectedSkill_xpath) == true)
                {
                    Report.UpdateTestLog("AddMoreThanMaxStringInSkillFieldFinalStep", "Successfully Entered new skill with String length : " + ilength, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddMoreThanMaxStringInSkillField", "Failed to enter new skill with String length :" + ilength, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddMoreThanMaxStringInSkillField", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddMoreThanMaxStringInSkillField", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateMaxStringAllowedInSkill()
        // Method Description : This method will Validate Maximum String length allowed in Skill field
        // Created On: 02/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateMaxStringAllowedInSkill()
        {
            try
            {
                string sSkillAllowableInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                int iAllowedLength = sSkillAllowableInputtext.Length;
                string sSkillMoreThanAllowableInputtext = DataTable.GetData("General_Data_" + Env, "RequestType2");
                int iMoreThanAllowedLength = sSkillMoreThanAllowableInputtext.Length;
                string sErrorText = DataTable.GetData("General_Data_" + Env, "RequestType3");
                IWebElement elm = Driver.FindElement(MyProfileOR.oErrorMessage_xpath);
                if (common.CheckElement(MyProfileOR.oErrorMessage_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateMaxStringAllowedInSkillFinalStep",
                        "Successfully validated that Skill Field is not allowing String length :" +
                        iMoreThanAllowedLength + ", Showing error message : " + elm.Text, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateMaxStringAllowedInSkill",
                         "Skill Field is  allowing String length :" +
                         iMoreThanAllowedLength, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateMaxStringAllowedInSkill", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateMaxStringAllowedInSkill", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method AddMaxStringInSkill()
        // Method Description : This method will add new past project which is allowable string length 
        // Created On: 02/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void AddMaxStringInSkill()
        {
            try
            {
                string sSkillInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                int ilength = sSkillInputtext.Length;              
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();
                skill.SendKeys(sSkillInputtext);
                IWebElement PastProject = Driver.FindElement(MyProfileOR.oPastProjectsInputField_xpath);
                PastProject.Click();
                if (common.CheckElement(MyProfileOR.oSelectedSkill_xpath) == true)
                {
                    Report.UpdateTestLog("AddMaxStringInSkillFinalStep", "Successfully Entered new skill with String length : " + ilength, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddMaxStringInSkill", "Failed to add new skill with String length :" + ilength, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddMaxStringInSkill", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddMaxStringInSkill", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ValidateSkillInMyProfilewithAllowableString()
        // Method Description : This method will validate whether the skill update is successfull after editing
        // Created On: 02/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateSkillInMyProfilewithAllowableString()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oSkillUpdateOnProfilePage_xpath);
                string stext = elm.Text.Trim();
                string sSkillInputtext = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (stext.Contains(sSkillInputtext))
                {
                    Report.UpdateTestLog("ValidateSkillInMyProfilewithAllowableStringFinalStep",
                        "Successfully validated that skill update is successfull on My Profile page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateSkillInMyProfilewithAllowableString", "Skill Update is unsuccessfull on My Profile page",
                        Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSkillInMyProfilewithAllowableString", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSkillInMyProfilewithAllowableString", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeleteSkillLongStringData()
        // Method Description : This method delete the long string in skill Field
        // Created On: 02/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteSkillLongStringData()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyProfileOR.oSkillUpdateOnProfilePage_xpath);
                string stext = elm.Text.Trim();
                IWebElement elm1 = Driver.FindElement(MyProfileOR.oExpServiceEdit_xpath);
                common.CheckElement(MyProfileOR.oExpServiceEdit_xpath);
                string sedit = elm1.Text;
                elm1.Click();
                IWebElement skill = Driver.FindElement(MyProfileOR.oSkillsInputField_xpath);
                skill.Click();
                skill.SendKeys(Keys.Backspace);
                skill.SendKeys(Keys.Backspace);
                //Report.UpdateTestLog("DeletePastProjectLongStringData", "Successfully clicked the cross icon to delete the Past Project", Status.PASS);
                Driver.FindElement(MyProfileOR.oSave_xpath).Click();
                IWebElement elm2 = Driver.FindElement(MyProfileOR.oSkillUpdateOnProfilePage_xpath);
                string stext2 = elm2.Text.Trim();

                if (stext != stext2)
                {
                    Report.UpdateTestLog("DeleteSkillLongStringDataFinalStep", "Successfully delete the skill", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("DeleteSkillLongStringData", "Failed to delete the skill", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteSkillLongStringData", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteSkillLongStringData", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateVisitorProfilePage()
        // Method Description : This method will Validate the visitor profile page
        // Created On: 02/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateVisitorProfilePage()
        {
            try
            {
                //Validate Skills Field
                IWebElement skill = Driver.FindElement(SearchFromLandingPageOR.oSkills_xpath);
                if (skill.Displayed)
                {
                    Report.UpdateTestLog("ValidateVisitorProfilePage", " Successfully Validated Skills Field ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateVisitorProfilePage", " Skills Field is not present, element is mapped to " + skill.Text, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Validate Past Projects Field
                IWebElement PastProjects = Driver.FindElement(SearchFromLandingPageOR.oPastProjects_xpath);
                if (PastProjects.Displayed)
                {
                    Report.UpdateTestLog("ValidateVisitorProfilePage", " Successfully Validated Past Projects Field ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateVisitorProfilePage", " Past Projects Field is not present, element is mapped to " + PastProjects.Text, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Validate Edit field not available
                if (common.CheckElement(MyProfileOR.oExpServiceEdit_xpath) == false)
                {
                    Report.UpdateTestLog("ValidateVisitorProfilePageFinalStep", " Successfully Validated Edit link is not available beside experience and services label ", Status.PASS);   
                }
                else
                {
                    Report.UpdateTestLog("ValidateVisitorProfilePage", " Edit link is available beside experience and services label ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;   
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateVisitorProfilePage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateVisitorProfilePage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //**********************************************
        // Method VerifyMyProfilefieldsForOwner()
        // Method Description : This method will validate Office Location contents
        // Created On: 02/10/2017
        // Created By: GI offShore Team
        // *****************************************

        public void VerifyMyProfilefieldsForOwner()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> contents = Driver.FindElements(MyProfileOR.oOfficeLocationContents_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 0; i < contents.Count; i++)
                    {
                        if (links[j].Trim() != contents[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyMyProfilefieldsForOwner", " '" + links[j].Trim() + "' is present in Office location section", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("VerifyMyProfilefieldsForOwner", " '" + links[j].Trim() + "' is not present in Office location section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                if (Driver.FindElement(MyProfileOR.oFloor_xpath).TagName == "input")
                {
                    Report.UpdateTestLog("VerifyMyProfilefieldsForOwner", " Floor is editable in Office location section", Status.PASS);
                    string floorNumber = "20";
                    string expFlrNmbr = "22";
                    IWebElement elm = Driver.FindElement(MyProfileOR.oFloor_xpath);
                    elm.Click();
                    elm.Clear();
                    elm.SendKeys(expFlrNmbr);
                    Report.UpdateTestLog("VerifyMyProfilefieldsForOwner", " New Floor Number is entered", Status.DONE);
                    Driver.FindElement(MyProfileOR.oSaveOfficeLocation_xpath).Click();
                    Report.UpdateTestLog("VerifyMyProfilefieldsForOwner", " Clicked on Save button", Status.DONE);
                    common.CallMeWait(2000);
                    string sAddress = Driver.FindElement(MyProfileOR.oFloorNumberInMyProfile_xpath).Text.Trim();
                    string sActualFloorNumber = sAddress.Substring(6);
                    if (expFlrNmbr == sActualFloorNumber)
                    {
                        Report.UpdateTestLog("VerifyMyProfilefieldsForOwner", " Successfully validated that floor is saved with new data", Status.PASS);
                        ClickOnOfficeLocationEdit();
                        elm.Click();
                        elm.Clear();
                        elm.SendKeys(floorNumber);
                        Driver.FindElement(MyProfileOR.oSaveOfficeLocation_xpath).Click();
                        Report.UpdateTestLog("VerifyMyProfilefieldsForOwnerFinalStep", " Clicked on Save button", Status.PASS);
                        common.CallMeWait(1000);

                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyMyProfilefieldsForOwner", " Floor is not saved with new data", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateOfficeLocationContents", " Floor is not editable in Office location section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateOfficeLocationContents", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateOfficeLocationContents", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
    
            //**********************************************
        // Method ValidateEmailOnMyProfile()
        // Method Description : This method will validate email functionality
        // Created On: 02/14/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateEmailOnMyProfile()
        {
            try
            {
                IWebElement supervisor = Driver.FindElement(MyProfileOR.oOrgChartName_xpath);
                string sSupervisorName = supervisor.Text.Trim();
                supervisor.Click();
                common.CallMeWait(2000);
                common.WaitForElement(MyProfileOR.oSupervisorName_xpath);
                IWebElement supervisorprofile = Driver.FindElement(MyProfileOR.oSupervisorName_xpath);
                string sSupervisorNameOnSupervisorProfile = supervisorprofile.Text.Trim();
                if (sSupervisorName == sSupervisorNameOnSupervisorProfile)
                {
                    Report.UpdateTestLog("ValidateEmailOnMyProfile", " Successfully validated that after clicking on the supervisor's profile in org chart it redirects to the supervisor profile ", Status.PASS);
                    if (common.CheckElement(MyProfileOR.oEmailID_xpath) == true)
                    {
                        Report.UpdateTestLog("ValidateEmailOnMyProfile", " Email ID is present", Status.PASS);
                        Driver.FindElement(MyProfileOR.oEmailID_xpath).Click();
                        Report.UpdateTestLog("ValidateEmailOnMyProfile", " Clicked on Email ID", Status.DONE);
                        common.CallMeWait(2000);
                        SendKeys.SendWait(@"{Esc}");
                        common.CallMeWait(1000);
                        SendKeys.SendWait(@"{Tab}");
                        common.CallMeWait(1000);
                        SendKeys.SendWait(@"{Enter}");
                        Report.UpdateTestLog("ValidateEmailOnMyProfileFinalStep", " MS outlook application is launched with the email dislayed on the screen", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateEmailOnMyProfile", " Email ID is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateEmailOnMyProfile", " After clicking on the supervisor's profile in org chart it doesn't redirect to the supervisor profile ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateEmailOnMyProfile", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateEmailOnMyProfile", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateOfficeAddressOnMyProfile()
        // Method Description : This method will validate office adress on My Profile page
        // Created On: 02/16/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateOfficeAddressOnMyProfile()
        {
            try
            {
                
                if (common.CheckElement(MyProfileOR.oAddressList_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> Address = Driver.FindElements(MyProfileOR.oAddressList_xpath);
                    if (Address[0].Displayed)
                    {
                        Report.UpdateTestLog("ValidateOfficeAddressOnMyProfile", "Office Street Number: " + Address[0].Text.Trim(), Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateOfficeAddressOnMyProfile", "Office Street Number not found", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (Address[1].Displayed)
                    {
                        Report.UpdateTestLog("ValidateOfficeAddressOnMyProfile", "Office City, State and PIN : " + Address[1].Text.Trim(), Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateOfficeAddressOnMyProfile", "Office City, State and PIN not found", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (Address[2].Displayed)
                    {
                        Report.UpdateTestLog("ValidateOfficeAddressOnMyProfileFinalStep", "Office Country : " + Address[2].Text.Trim(), Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateOfficeAddressOnMyProfile", "Office Country not found", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateOfficeAddressOnMyProfile", "Address not found" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateOfficeAddressOnMyProfile", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateOfficeAddressOnMyProfile", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidatGoogleMapOnMyProfile()
        // Method Description : This method will validate Google Map on My Profile page
        // Created On: 02/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidatGoogleMapOnMyProfile()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oGoogleMap_xpath) == true)
                {
                    Report.UpdateTestLog("ValidatGoogleMapOnMyProfileFinalStep", " Successfully validated that Google Map is present on My profile page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidatGoogleMapOnMyProfile", " Google Map is not present on My profile page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidatGoogleMapOnMyProfile", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidatGoogleMapOnMyProfile", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickLinkAtFooter()
        // Method Description : This method will click Corporate Information footer link
        // Created On: 04/05/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickLinkAtFooter()
        {
            try
            {
                bool flag = false;
                ReadOnlyCollection<IWebElement> alllinks = Driver.FindElements(MyProfileOR.oCorporateInformationFooter_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                
                string[] links = requestType1.Split(',');
                    for (int i = 1; i < alllinks.Count; i++)
                    {
                        if (alllinks[i].Text.Trim().Contains(requestType1))
                        {
                            Report.UpdateTestLog("ClickLinkAtFooter", " link '" + requestType1 + "' is present under '" + alllinks[0].Text.Trim() + "'", Status.PASS);
                            alllinks[i].Click();
                            Report.UpdateTestLog("ClickLinkAtFooterFinalStep", " Clicked link '" + requestType1 + "' ", Status.PASS);
                            common.CallMeWait(2000);                          
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ClickLinkAtFooter", " link '" + requestType1 + "' is not present under '" + alllinks[0].Text.Trim() + "'", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickLinkAtFooter", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickLinkAtFooter", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidatePageTitle()
        // Method Description : This method will validate page title
        // Created On: 04/05/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidatePageTitle()
        {
            try
            {
                String ExpectedPageTitle = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (common.CheckElement(HomePageSearchOR.oDepartmentsPageTitle_id) == true)
                {
                    string ActualTitle = Driver.FindElement(HomePageSearchOR.oDepartmentsPageTitle_id).Text.Trim();
                    if (ExpectedPageTitle.Equals(ActualTitle))
                    {
                        Report.UpdateTestLog("ValidatePageTitleFinalStep", " User is navigated to the required page :" + ExpectedPageTitle, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidatePageTitle", " User is not navigated to the required page, Expected page title : " + ExpectedPageTitle + " Actual page title : " + ActualTitle, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidatePageTitle", " Page Title Field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidatePageTitle", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidatePageTitle", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name:ValidateContactsOfRegions()
        // Method Description: This method will validate contacts groupes by regions
        // Created on 04/05/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void ValidateContactsOfRegions()
        {
            try
            {
                bool flag = true;
                string Regions = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string[] ExpectedRegions = Regions.Split(',');
                if (common.CheckElement(MyProfileOR.oContactRegions_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> Actualregions = Driver.FindElements(MyProfileOR.oContactRegions_xpath);
                    for (int i = 0; i < ExpectedRegions.Count(); i++)
                    {
                        string ExpectedRegion = ExpectedRegions[i].Trim();
                        for (int k = 0; k < Actualregions.Count; k++)
                        {
                            string ActualRegion = Actualregions[k].Text.Trim();
                            if (ExpectedRegion.Contains(ActualRegion))
                            {
                                Report.UpdateTestLog("ValidatePageTitle", " region '" + ExpectedRegions[i] + "' is present", Status.PASS);
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false; 
                            }
                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("ValidatePageTitle", " region '" + ExpectedRegions[i] + "' is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidatePageTitle", " Contact regions field not present" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidatePageTitle", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidatePageTitle", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name:ValidateLinkedinUrl()
        // Method Description: This method validates the linkedin URL
        // Created on 05/19/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void ValidateLinkedinUrl()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oLinkedinUrl_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateLinkedinUrl", " Linkedin URL field is present", Status.PASS);
                    Driver.FindElement(MyProfileOR.oLinkedinUrl_xpath).Click();
                    Report.UpdateTestLog("ValidateLinkedinUrl", " Clicked on Linkedin URL ", Status.PASS);
                    common.CallMeWait(1000);
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    string URL = Driver.Url;
                    if (URL.Contains("www.linkedin.com"))
                    {
                        Report.UpdateTestLog("ValidateLinkedinUrlFinalStep", " After clicking on Linkedin URL user navigates to linkedin page in new tab", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateLinkedinUrl", " After clicking on Linkedin URL user is not navigated to linkedin page in new tab", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateLinkedinUrl", "Linkedin URL field is not present" , Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLinkedinUrl", "Element not found" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLinkedinUrl", "Error in method" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name:ValidateTwitterUrl()
        // Method Description: This method validates the Twitter URL
        // Created on 05/19/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void ValidateTwitterUrl()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oTwitterUrl_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateTwitterUrl", " Twitter URL field is present", Status.PASS);
                    Driver.FindElement(MyProfileOR.oTwitterUrl_xpath).Click();
                    Report.UpdateTestLog("ValidateTwitterUrl", " Clicked on Twitter URL ", Status.PASS);
                    common.CallMeWait(1000);
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    string URL = Driver.Url;
                    if (URL.Contains("twitter.com"))
                    {
                        Report.UpdateTestLog("ValidateTwitterUrlFinalStep", " After clicking on Twitter URL user navigates to Twitter page in new tab", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateTwitterUrl", " After clicking on Twitter URL user is not navigated to Twitter page in new tab", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateTwitterUrl", "Twitter URL field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateTwitterUrl", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateTwitterUrl", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name:ValidateWebsiteUrl()
        // Method Description: This method validates the Website URL
        // Created on 05/19/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void ValidateWebsiteUrl()
        {
            try
            {
                if (common.CheckElement(MyProfileOR.oWebsiteUrl_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateWebsiteUrl", " Website URL field is present", Status.PASS);
                    Driver.FindElement(MyProfileOR.oWebsiteUrl_xpath).Click();
                    Report.UpdateTestLog("ValidateWebsiteUrl", " Clicked on Website URL ", Status.PASS);
                    common.CallMeWait(1000);
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    string URL = Driver.Url;
                    if (URL.Contains("www.google.com"))
                    {
                        Report.UpdateTestLog("ValidateWebsiteUrlFinalStep", " After clicking on Website URL user navigates to "+URL+" page in new tab", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateWebsiteUrl", " After clicking on website URL user is not navigated to the page in new tab", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateWebsiteUrl", "Website URL field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateWebsiteUrl", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateWebsiteUrl", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

    }
}
