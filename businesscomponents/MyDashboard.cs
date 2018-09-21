using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using CRAFT.BusinessComponents;
using CRAFT.SupportLibraries;
using CRAFT.Uimap;
using Framework_Reporting;
using NPOI.HSSF.Record.Formula.Functions;
using NPOI.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace CRAFT.businesscomponents
{

    /**
     * Class for storing general purpose business components
     * 
     * @author Cognizant
     */

    internal class MyDashboard : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;
        public MyDashboard(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
            common = new CommonComponents(ScriptHelper);
        }

        //**********************************************
        // Method NavigateToAdminDashboard()
        // Method Description : This method will navigate the user to Admin Dashboard page
        // Created On: 01/24/2017
        // Created By: GI offShore Team
        // *****************************************

        public void NavigateToAdminDashboard()
        {
            try
            {
                string NavigationUrl = DataTable.GetData("General_Data_" + Env, "NavigationURL");
                Driver.Navigate().GoToUrl(NavigationUrl);
                Report.UpdateTestLog("NavigateToAdminDashboardFinalStep", "Navigate to " + NavigationUrl, Status.PASS);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToAdminDashboard", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateAdminDashboard()
        // Method Description : This method will validate My Dashboard link on Admin Dashboard page
        // Created On: 01/25/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateAdminDashboard()
        {
            try
            {               
                if (common.CheckElement(MyDashboardOR.oMyDashboard_xpath)==true)
                {
                    Report.UpdateTestLog("ValidateAdminDashboardFinalStep",
                        "Successfully validated that User is navigated to the Admin Dashboard", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateAdminDashboard",
                          "User failed to navigate to the Admin Dashboard", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAdminDashboard", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAdminDashboard", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method NavigateToMyDashboard()
        // Method Description : This method will Navigate the user to My Dashboard page
        // Created On: 01/25/2017
        // Created By: GI offShore Team
        // *****************************************

        public void NavigateToMyDashboard()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyDashboardOR.oMyDashboard_xpath);
                string stext = elm.Text;
                if (elm.Displayed)
                {
                    elm.Click();
                    Report.UpdateTestLog("NavigateToMyDashboard", "Successfully clicked on " + stext, Status.PASS);
                    common.CallMeWait(2000);
                    IWebElement elm1 = Driver.FindElement(MyDashboardOR.oMyDashboardonMyDashboardPage_xpath);
                    if (elm1.Displayed)
                    {
                        Report.UpdateTestLog("NavigateToMyDashboardFinalStep",
                            "Successfully validated that User is navigated to the My Dashboard", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("NavigateToMyDashboard",
                             "User failed to navigate to the My Dashboard", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("NavigateToMyDashboard",
                               "My Dashboard link is not present on Admin Dashboard page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigateToMyDashboard", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToMyDashboard", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateAdministerCommentsTabVisibility()
        // Method Description : This method will Validate Administer comments tab visibility on My Dashboard page
        // Created On: 01/25/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateAdministerCommentsTabVisibility()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyDashboardOR.oAdministerComments_xpath);
                if (elm.Displayed)
                {
                    Report.UpdateTestLog("ValidateAdministerCommentsTabVisibilityFinalStep",
                        " Successfully validated that Administer Comments tab is present on My Dashboard page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateAdministerCommentsTabVisibility",
                          " Administer comments tab is not present on My Dashboard page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAdministerCommentsTabVisibility", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAdministerCommentsTabVisibility", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickOnAdministerComments()
        // Method Description : This method will Validate Administer comments tab visibility on My Dashboard page
        // Created On: 01/25/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnAdministerComments()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyDashboardOR.oAdministerComments_xpath);
                string stext = elm.Text;
                if (elm.Displayed)
                {
                    elm.Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("ClickOnAdministerCommentsFinalStep",
                        " Successfully clicked on " + stext, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnAdministerComments",
                          " Administer comments tab is not present on My Dashboard page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnAdministerComments", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnAdministerComments", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method VerifyDefaultDate()
        // Method Description : This method will Validate default date in Administer comments tab 
        // Created On: 01/25/2017
        // Created By: GI offShore Team
        // *****************************************

        public void VerifyDefaultDate()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyDashboardOR.o30days_xpath);
                string stext = elm.GetAttribute("class");
                if (stext.Contains("active"))
                {
                    Report.UpdateTestLog("VerifyDefaultDateFinalStep",
                        " Successfully validated that Administer Comments defaulted to 30 days ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyDefaultDate",
                          " Failed to validate that Administer Comments defaulted to 30 days ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyDefaultDate", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyDefaultDate", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method CreateNewArticleUnderAmericas()
        // Method Description : This method will create new article under Americas site 
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void CreateNewArticleUnderAmericas()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oContentAuthAmericanSite_xpath) == true)
                {
                    Report.UpdateTestLog("CreateNewArticleUnderAmericas", " Content Authoring for Americas Site (en-US) is present", Status.PASS);
                    Driver.FindElement(MyDashboardOR.oContentAuthAmericanSite_xpath).Click();
                    Report.UpdateTestLog("CreateNewArticleUnderAmericas", " Clicked on Content Authoring for Americas Site (en-US) ", Status.DONE);
                    if (common.CheckElement(MyDashboardOR.oCreateArticle_xpath) == true)
                    {
                        Report.UpdateTestLog("CreateNewArticleUnderAmericas", " Create Article is present Under Create New Content", Status.PASS);
                        Driver.FindElement(MyDashboardOR.oCreateArticle_xpath).Click();
                        Report.UpdateTestLog("CreateNewArticleUnderAmericasFinalStep", " Clicked on Create Article link Under Create New Content", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("CreateNewArticleUnderAmericas", " Create Article is not present Under Create New Content", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("CreateNewArticleUnderAmericas", " Content Authoring for Americas Site (en-US) is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateNewArticleUnderAmericas", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateNewArticleUnderAmericas", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method CreateNewsPage()
        // Method Description : This method will create News Page under Americas site 
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void CreateNewsPage()
        {
            try
            {
                string PageTitle1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string PageTitle = PageTitle1 + "_" + ArticleDate;
                string Description = PageTitle + "_Description";
                if (common.CheckElement(MyDashboardOR.oCreatePageTitle_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oCreatePageTitle_id).Click();
                    Driver.FindElement(MyDashboardOR.oCreatePageTitle_id).SendKeys(PageTitle);
                    Report.UpdateTestLog("CreateNewsPage", " Entered News Page Title", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNewsPage", " Page Title field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                 if (common.CheckElement(MyDashboardOR.oCreatePageDesc_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oCreatePageDesc_id).Click();
                    Driver.FindElement(MyDashboardOR.oCreatePageDesc_id).SendKeys(Description);
                    Report.UpdateTestLog("CreateNewsPage", " Entered News Page Description", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNewsPage", " Page Description field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //select the page layout
                 bool flag = false;
                 string Layout = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();
                 ReadOnlyCollection<IWebElement> Layouts = Driver.FindElements(MyDashboardOR.oNewsPageLayouts_xpath);
                 for (int i = 0; i < Layouts.Count; i++)
                 {
                     if (Layouts[i].Text.Trim().Contains(Layout))
                     {
                         Layouts[i].Click();
                         Report.UpdateTestLog("CreateNewsPage", " Selected Page Layout as : " + Layout, Status.DONE);
                         flag = true;
                         break;
                     }
                 }
                 if (flag == false)
                 {
                     Report.UpdateTestLog("CreateNewsPage", " Page Layout '" + Layout+"' is not present", Status.FAIL);
                     CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                 }
                     ///////////
                     if (common.CheckElement(MyDashboardOR.oCreateButton_id) == true)
                     {
                         Driver.FindElement(MyDashboardOR.oCreateButton_id).Click();
                         Report.UpdateTestLog("CreateNewsPageFinalStep", " Clicked on Create button", Status.PASS);
                         common.CallMeWait(4000);
                     }
                     else
                     {
                         Report.UpdateTestLog("CreateNewsPage", " Create button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                     }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateNewsPage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateNewsPage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method EnterDetailsOnNewsPage()
        // Method Description : This method will enter details on News Page 
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void EnterDetailsOnNewsPage()
        {
            try
            {
                string PageTitle = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string Author = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string Topic = PageTitle + "_Topic";               
                DateTime today = DateTime.Today;
                string ArticleDate = today.ToString("MM/dd/yyyy");
                string PageContent = PageTitle + "_Content";
                string SubHeadline = PageTitle + "_SubHeadline";
                DateTime Futureday = today.AddDays(60);
                string PublishEndDate = Futureday.ToString("MM/dd/yyyy");
                string TargetGeography = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string LocationGroup = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                string TargetService = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                // Enter Article Topic
                if (common.CheckElement(MyDashboardOR.oNewsDetail_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oNewsDetail_id).Click();
                    Driver.FindElement(MyDashboardOR.oNewsDetail_id).SendKeys(Topic);
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Entered Article Topic", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Article Topic is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Article Author
                if (common.CheckElement(MyDashboardOR.oArticleAuthor_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oArticleAuthor_id).Click();
                    Driver.FindElement(MyDashboardOR.oArticleAuthor_id).SendKeys(Author);
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Entered Article Author", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Article Author is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Article Date
                if (common.CheckElement(MyDashboardOR.oArticleDate_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oArticleDate_id).Click();
                    Driver.FindElement(MyDashboardOR.oArticleDate_id).SendKeys(ArticleDate);
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Entered Article Date", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Article Date is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Article Page Content
                if (common.CheckElement(MyDashboardOR.oPageContentField_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oPageContentField_id).Click();
                    Driver.FindElement(MyDashboardOR.oPageContent_id).SendKeys(PageContent);
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Entered Article Content", Status.DONE);
                    common.CallMeWait(4000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Article Content is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Article Sub Headline
                if (common.CheckElement(MyDashboardOR.oArticleSubHeadLine_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oArticleSubHeadLine_id).Click();
                    Driver.FindElement(MyDashboardOR.oArticleSubHeadLine_id).SendKeys(SubHeadline);
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Entered Article Sub Headline", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Article Sub Headline is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Publish Start Date
                if (common.CheckElement(MyDashboardOR.oPublishStartDate_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oPublishStartDate_id).Click();
                    Driver.FindElement(MyDashboardOR.oPublishStartDate_id).SendKeys(ArticleDate);
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Entered Article Publish Start Date", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Article Publish Start Date is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Publish End Date
                if (common.CheckElement(MyDashboardOR.oPublishEndDate_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oPublishEndDate_id).Click();
                    Driver.FindElement(MyDashboardOR.oPublishEndDate_id).SendKeys(PublishEndDate);
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Entered Article Publish End Date", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Article Publish End Date is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Expiration Date
                if (common.CheckElement(MyDashboardOR.oPageExpirationDate_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oPageExpirationDate_id).Click();
                    Driver.FindElement(MyDashboardOR.oPageExpirationDate_id).SendKeys(PublishEndDate);
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Entered Article Expiration Date", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Article Publish Expiration date is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                /*// Enter Target Geography
                if (common.CheckElement(MyDashboardOR.oTargetGeography_id) == true)
                {
                    Driver.FindElement(common.CheckElement(MyDashboardOR.oTargetGeography_id)).Click();
                    Driver.FindElement(common.CheckElement(MyDashboardOR.oTargetGeography_id)).SendKeys(TargetGeography);
                    Report.UpdateTestLog("CreateNewsPage", " Entered Target Geography", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNewsPage", " Target Geography is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Location Group
                if (common.CheckElement(MyDashboardOR.oLocationGroup_id) == true)
                {
                    Driver.FindElement(common.CheckElement(MyDashboardOR.oLocationGroup_id)).Click();
                    Driver.FindElement(common.CheckElement(MyDashboardOR.oLocationGroup_id)).SendKeys(LocationGroup);
                    Report.UpdateTestLog("CreateNewsPage", " Entered Location Group", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNewsPage", " Location Group is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Target Service
                if (common.CheckElement(MyDashboardOR.oTargetService_id) == true)
                {
                    Driver.FindElement(common.CheckElement(MyDashboardOR.oTargetService_id)).Click();
                    Driver.FindElement(common.CheckElement(MyDashboardOR.oTargetService_id)).SendKeys(TargetService);
                    Report.UpdateTestLog("CreateNewsPage", " Entered Target Service", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNewsPage", " Target Service is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }*/
                // Check Priority Checkbox
                if (common.CheckElement(MyDashboardOR.oPriorityCheckbox_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oPriorityCheckbox_id).Click();
                    Report.UpdateTestLog("EnterDetailsOnNewsPageFinalStep", " Checked Priority Checkbox", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("EnterDetailsOnNewsPage", " Priority Checkbox is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterDetailsOnNewsPage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterDetailsOnNewsPage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickOnAllowCommentCheckbox()
        // Method Description : This method will check the Allow Commenting checkbox
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnAllowCommentCheckbox()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oAllowCommentCheckbox_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oAllowCommentCheckbox_id).Click();                    
                    if (Driver.FindElement(MyDashboardOR.oAllowCommentCheckbox_id).Selected == true)
                    {
                        Report.UpdateTestLog("ClickOnAllowCommentCheckboxFinalStep", " Checked Allow Commenting checkbox", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ClickOnAllowCommentCheckbox", " Unable to check Allow Commenting checkbox", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ClickOnAllowCommentCheckbox", " Allow Commenting checkbox is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnAllowCommentCheckbox", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnAllowCommentCheckbox", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickCheckItIn()
        // Method Description : This method will check in from News Detail Page
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickCheckItIn()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oCheckItIn_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oCheckItIn_id).Click();
                    Report.UpdateTestLog("ClickCheckItIn", " Clicked on Check It in link ", Status.DONE);
                    if (common.CheckElement(MyDashboardOR.oCommentCheckinPopUp_id) == true)
                    {
                        Driver.FindElement(MyDashboardOR.oCommentCheckinPopUp_id).Click();
                        Driver.FindElement(MyDashboardOR.oCommentCheckinPopUp_id).SendKeys("Check-in");
                        Report.UpdateTestLog("ClickCheckItIn", " Entered comment in check-in pop-up ", Status.DONE);
                        if (common.CheckElement(MyDashboardOR.oCheckinPopUpContinueButton_id) == true)
                        {
                            Driver.FindElement(MyDashboardOR.oCheckinPopUpContinueButton_id).Click();
                            Report.UpdateTestLog("ClickCheckItInFinalStep", " Clicked Continue button in check-in pop-up ", Status.PASS);
                            common.CallMeWait(2000);
                        }
                        else
                        {
                            Report.UpdateTestLog("ClickCheckItIn", " Continue button is not present in check-in pop-up ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ClickCheckItIn", " Comment box is not present in check-in pop-up ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("ClickCheckItIn", " Check It in link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickCheckItIn", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickCheckItIn", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method Publish()
        // Method Description : This method will publish the article
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void Publish()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oPublishIt_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oPublishIt_id).Click();
                    Report.UpdateTestLog("Publish", " Clicked on Publish It link ", Status.DONE);
                    if (common.CheckElement(MyDashboardOR.oStart_id) == true)
                    {
                        Driver.FindElement(MyDashboardOR.oStart_id).Click();
                        Report.UpdateTestLog("PublishFinalStep", " Clicked on Start button ", Status.PASS);
                        common.CallMeWait(3000);
                    }
                    else
                    {
                        Report.UpdateTestLog("Publish", " Start button not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("Publish", " Publish link not found", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Publish", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Publish", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method Approve()
        // Method Description : This method will approve the article
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void Approve()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oApproveIt_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oApproveIt_id).Click();
                    Report.UpdateTestLog("Approve", " Clicked on Approve It link ", Status.DONE);
                    if (common.CheckElement(MyDashboardOR.oCommentCheckinPopUp_id) == true)
                    {
                        Driver.FindElement(MyDashboardOR.oCommentCheckinPopUp_id).Click();
                        Driver.FindElement(MyDashboardOR.oCommentCheckinPopUp_id).SendKeys("Approve");
                        Report.UpdateTestLog("Approve", " Entered comment in Approve pop-up ", Status.DONE);
                        if (common.CheckElement(MyDashboardOR.oCheckinPopUpContinueButton_id) == true)
                        {
                            Driver.FindElement(MyDashboardOR.oCheckinPopUpContinueButton_id).Click();
                            Report.UpdateTestLog("Approve", " Clicked Continue button in approve pop-up ", Status.DONE);
                            common.CallMeWait(3000);
                            if (common.CheckElement(MyDashboardOR.oStart_id) == true)
                            {
                                Driver.FindElement(MyDashboardOR.oStart_id).Click();
                                Report.UpdateTestLog("ApproveFinalStep", " Clicked on Approve button ", Status.PASS);
                                common.CallMeWait(5000);
                                if (common.CheckElement(MyDashboardOR.oApproveIt_id) == true)
                                {
                                    Driver.FindElement(MyDashboardOR.oApproveIt_id).Click();
                                    Report.UpdateTestLog("Approve", " Clicked on Approve It link ", Status.DONE);
                                    if (common.CheckElement(MyDashboardOR.oCommentCheckinPopUp_id) == true)
                                    {
                                        Driver.FindElement(MyDashboardOR.oCommentCheckinPopUp_id).Click();
                                        Driver.FindElement(MyDashboardOR.oCommentCheckinPopUp_id).SendKeys("Approve1");
                                        Report.UpdateTestLog("Approve", " Entered comment in Approve pop-up second time ", Status.DONE);
                                        if (common.CheckElement(MyDashboardOR.oCheckinPopUpContinueButton_id) == true)
                                        {
                                            Driver.FindElement(MyDashboardOR.oCheckinPopUpContinueButton_id).Click();
                                            Report.UpdateTestLog("Approve", " Clicked Continue button in approve pop-up ", Status.DONE);
                                            common.CallMeWait(5000);
                                        }
                                        else
                                        {
                                            Report.UpdateTestLog("Approve", " Continue button is not present in Approve pop-up ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                        }
                                    }
                                }
                                }
                                else
                                {
                                    Report.UpdateTestLog("Approve", " Start button is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                }
                            }
                            else
                            {
                                Report.UpdateTestLog("Approve", " Continue button not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                        }
                        else
                        {
                            Report.UpdateTestLog("Approve", " comment box is not present in Approve pop-up ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }               
                else
                {
                    Report.UpdateTestLog("Approve", " Approve It link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Approve", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Approve", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateCommentInArticle()
        // Method Description : This method will validate the comment flag
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateCommentInArticle()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oLike_XPath) == true)
                {
                    Report.UpdateTestLog("ValidateCommentInArticle", " Successfully validated that user can like on the article", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentInArticle", " User can't like on the article", Status.FAIL);
                }
                if (common.CheckElement(MyDashboardOR.oCommentFlag_XPath) == true)
                {
                    string comment = Driver.FindElement(MyDashboardOR.oCommentFlag_XPath).Text.Trim();
                    if (comment.Contains("Yes"))
                    {
                        Report.UpdateTestLog("ValidateCommentInArticleFinalStep", " Successfully validated that user can comment on the article", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateCommentInArticle", " User can't comment on the article", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentInArticle", " Comment field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCommentInArticle", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCommentInArticle", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeleteArticle()
        // Method Description : This method will delete the article
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteArticle()
        {
            try
            {
                bool flag = false;
                if (common.CheckElement(MyDashboardOR.oSettings_XPath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oSettings_XPath).Click();
                    if (common.CheckElement(By.XPath("//*[contains(text(),'Show Ribbon')]")) == true)
                    {
                        Driver.FindElement(By.XPath("//*[contains(text(),'Show Ribbon')]")).Click();
                        common.CallMeWait(3000);
                    }
                }
                if (common.CheckElement(MyDashboardOR.oPageTopNav_XPath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oPageTopNav_XPath).Click();
                    Report.UpdateTestLog("DeleteArticle", " Clicked on Page link on top left of the page" , Status.DONE);
                    common.CallMeWait(2000);
                    if (common.CheckElement(MyDashboardOR.oDeletePage_XPath) == true)
                    {
                        Driver.FindElement(MyDashboardOR.oDeletePage_XPath).Click();
                        common.CallMeWait(2000);
                        Driver.SwitchTo().Alert().Accept();
                        common.CallMeWait(1000);
                        flag = true;
                    }
                    else
                    {
                        Report.UpdateTestLog("DeleteArticle", " delete page not found" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("DeleteArticleFinalStep", " delete the Article ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("DeleteArticle", " Unable to delete Article ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("DeleteArticle", " Page link is not found on top left of the page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteArticle", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteArticle", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateCommentUnAvailable()
        // Method Description : This method will validate the unavailability of comment flag
        // Created On: 02/15/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateCommentUnAvailable()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oLike_XPath) == true)
                {
                    Report.UpdateTestLog("ValidateComment", " Successfully validated that user can like on the article", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateComment", " User can't like on the article", Status.PASS);
                }
                if (common.CheckElement(MyDashboardOR.oCommentFlag_XPath) == true)
                {
                    string comment = Driver.FindElement(MyDashboardOR.oCommentFlag_XPath).Text.Trim();
                    if (comment.Contains("No"))
                    {
                        Report.UpdateTestLog("ValidateCommentUnAvailableFinalStep", " Successfully validated that user can't comment on the article", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateCommentUnAvailable", " User can comment on the article", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentUnAvailable", " Comment field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCommentUnAvailable", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCommentUnAvailable", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ClickNavLinkUnderAmericas()
        // Method Description : This method will click on create new nav link  
        // Created On: 02/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickNavLinkUnderAmericas()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oContentAuthAmericanSite_xpath) == true)
                {
                    Report.UpdateTestLog("ClickNavLinkUnderAmericas", " Content Authoring for Americas Site (en-US) is present", Status.PASS);
                    Driver.FindElement(MyDashboardOR.oContentAuthAmericanSite_xpath).Click();
                    Report.UpdateTestLog("ClickNavLinkUnderAmericas", " Clicked on Content Authoring for Americas Site (en-US) ", Status.DONE);
                    if (common.CheckElement(MyDashboardOR.oCreateNavLink_xpath) == true)
                    {
                        Report.UpdateTestLog("ClickNavLinkUnderAmericas", " Create Nav Link is present Under Create New Content", Status.PASS);
                        Driver.FindElement(MyDashboardOR.oCreateNavLink_xpath).Click();
                        Report.UpdateTestLog("ClickNavLinkUnderAmericasFinalStep", " Clicked on Create Nav Link link Under Create New Content", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ClickNavLinkUnderAmericas", " Create Nav Link is not present Under Create New Content", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ClickNavLinkUnderAmericas", " Content Authoring for Americas Site (en-US) is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickNavLinkUnderAmericas", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickNavLinkUnderAmericas", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method CreateNavLink()
        // Method Description : This method will create  new nav link  
        // Created On: 02/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void CreateNavLink()
        {
            try
            {
                // Put Nav Link Title
                string NavlinkTitle1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string NavLinkTitle = NavlinkTitle1 + "_" + ArticleDate;
                if (common.CheckElement(MyDashboardOR.oNavLinkTitle_xpath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oNavLinkTitle_xpath).Click();
                    Driver.FindElement(MyDashboardOR.oNavLinkTitle_xpath).SendKeys(NavLinkTitle);
                    Report.UpdateTestLog("CreateNavLink", " Entered Nav Link Title :" + NavLinkTitle, Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNavLink", " Nav Link Title field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Put Nav Link URL
                string NavlinkURL = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (common.CheckElement(MyDashboardOR.oNavLinkURL_xpath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oNavLinkURL_xpath).Click();
                    Driver.FindElement(MyDashboardOR.oNavLinkURL_xpath).Clear();
                    Driver.FindElement(MyDashboardOR.oNavLinkURL_xpath).SendKeys(NavlinkURL);
                    Report.UpdateTestLog("CreateNavLink", " Entered Nav Link URL :" + NavlinkURL, Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNavLink", " Nav Link URL field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Check the Show In Navigation checkbox
                string Checkbox = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                if (Checkbox == "Navigation")
                {
                    if (common.CheckElement(MyDashboardOR.oShowInNavigationCheckbox_xpath) == true)
                    {
                        Driver.FindElement(MyDashboardOR.oShowInNavigationCheckbox_xpath).Click();
                        Report.UpdateTestLog("CreateNavLink", " Checked the Show In Navigation checkbox ", Status.DONE);
                    }
                    else
                    {
                        Report.UpdateTestLog("CreateNavLink", " Show In Navigation checkbox is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                // Enter Target Geography
                string TargetGeography = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                if (common.CheckElement(MyDashboardOR.oNavLinkTargetGeography_xpath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oNavLinkTargetGeography_xpath).Click();
                    Driver.FindElement(MyDashboardOR.oNavLinkTargetGeography_xpath).SendKeys(TargetGeography);
                    SendKeys.SendWait(@"{Tab}");
                    Report.UpdateTestLog("CreateNavLink", " Entered Target Geography :" + TargetGeography, Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNavLink", " Target Geography field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Select Link Type
                string LinkType = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                if (common.CheckElement(MyDashboardOR.oNavLinkType_xpath) == true)
                {
                    var selectLinkType = new SelectElement(Driver.FindElement(MyDashboardOR.oNavLinkType_xpath));
                    selectLinkType.SelectByText(LinkType);
                    Report.UpdateTestLog("CreateNavLink", " Selected link Type : " + LinkType, Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("CreateNavLink", " Link Type field is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Click on Save button
                ReadOnlyCollection<IWebElement> SaveButtonList = Driver.FindElements(MyDashboardOR.osaveButtonList_xpath);
                if(SaveButtonList.Count>0)
                {
                    IWebElement Save = SaveButtonList[1];
                    Save.Click();
                    Report.UpdateTestLog("CreateNavLinkFinalStep", " Clicked on Save Button ", Status.PASS);
                    common.CallMeWait(3000);
                }
                else
                {
                    Report.UpdateTestLog("CreateNavLink", " Save button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateNavLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateNavLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method FindAndClickOnNavLink()
        // Method Description : This method will find and click on newly created nav link  
        // Created On: 02/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void FindAndClickOnNavLink()
        {
            try
            {
                string NavlinkTitle = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                bool flag = true;
                if (common.CheckElement(MyDashboardOR.oNavLinkApprovalStatus_xpath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oNavLinkApprovalStatus_xpath).Click();
                    common.CallMeWait(1000);
                    Driver.FindElement(MyDashboardOR.oNavLinkApprovalStatus_xpath).Click();
                    common.CallMeWait(1000);
                    ReadOnlyCollection<IWebElement> NavLinkList = Driver.FindElements(MyDashboardOR.oNavLinkList_xpath);
                    for (int i = 0; i < NavLinkList.Count; i++)
                    {
                        string NavLink = NavLinkList[i].Text.Trim();
                        if(NavLink.Contains(NavlinkTitle))
                        {
                            NavLinkList[i].Click();
                            Report.UpdateTestLog("FindAndClickOnNavLinkFinalStep", " Clicked on Nav Link ", Status.PASS);
                            common.CallMeWait(3000);
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("FindAndClickOnNavLink", " Newly created Nav link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("FindAndClickOnNavLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindAndClickOnNavLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ApproveNavLink()
        // Method Description : This method will approve the newly created nav link  
        // Created On: 02/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ApproveNavLink()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oApproveRejectNavLink_xpath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oApproveRejectNavLink_xpath).Click();
                    Report.UpdateTestLog("ApproveNavLink", " Clicked on Approve/Reject link ", Status.PASS);
                    common.CallMeWait(2000);
                    if (common.CheckElement(MyDashboardOR.oApproveRadioButton_xpath) == true)
                    {
                        Driver.FindElement(MyDashboardOR.oApproveRadioButton_xpath).Click();
                        Report.UpdateTestLog("ApproveNavLink", " Clicked on Approve radio button ", Status.PASS);
                        if (common.CheckElement(MyDashboardOR.oOKButton_xpath) == true)
                        {
                            Driver.FindElement(MyDashboardOR.oOKButton_xpath).Click();
                            Report.UpdateTestLog("ApproveNavLinkFinalStep", " Clicked on OK button ", Status.PASS);
                            common.CallMeWait(3000);
                        }
                        else
                        {
                            Report.UpdateTestLog("ApproveNavLink", " OK button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ApproveNavLink", " Approve radio button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ApproveNavLink", " Approve/Reject link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ApproveNavLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ApproveNavLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method NavigateToAdminDashboard()
        // Method Description : This method will navigate to Admin Dashboard
        // Created On: 02/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void NavigateToAdminDashboardPage()
        {
            try
            {
                String url = DataTable.GetData("General_Data_" + Env, "URL");
                Driver.Navigate().GoToUrl(url);
                Report.UpdateTestLog("NavigateToAdminDashboardPageFinalStep", "Navigate to " + url, Status.PASS);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToAdminDashboardPage", "Error in MaximizeBrowsers " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method NavigateToViewNavLink()
        // Method Description : This method will Find Existing NavLink
        // Created On: 02/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void NavigateToViewNavLink()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oContentAuthAmericanSite_xpath) == true)
                {                  
                    Driver.FindElement(MyDashboardOR.oContentAuthAmericanSite_xpath).Click();
                    Report.UpdateTestLog("NavigateToViewNavLink", " Clicked on Content Authoring for Americas Site (en-US) ", Status.DONE);
                    if (common.CheckElement(MyDashboardOR.oViewNavLink_xpath) == true)
                    {
                        Driver.FindElement(MyDashboardOR.oViewNavLink_xpath).Click();
                        Report.UpdateTestLog("NavigateToViewNavLinkFinalStep", " Clicked on View Nav Link) ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("NavigateToViewNavLink", " View Nav Link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("NavigateToViewNavLink", " Content Authoring for Americas Site (en-US) is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigateToViewNavLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToViewNavLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method FindandClickExistingNavLink()
        // Method Description : This method will Find Existing NavLink and click
        // Created On: 02/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void FindandClickExistingNavLink()
        {
            try
            {
                string NavlinkTitle = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                bool flag = true;
                if (common.CheckElement(MyDashboardOR.oTitleSort_xpath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oTitleSort_xpath).Click();
                    common.CallMeWait(2000);
                    ReadOnlyCollection<IWebElement> NavLinkList = Driver.FindElements(MyDashboardOR.oNavLinkList_xpath);
                    for (int i = 0; i < NavLinkList.Count; i++)
                    {
                        string NavLink = NavLinkList[i].Text.Trim();
                        if (NavLink.Contains(NavlinkTitle))
                        {
                            NavLinkList[i].Click();
                            Report.UpdateTestLog("FindandClickExistingNavLinkFinalStep", " Clicked on Nav Link ", Status.PASS);
                            common.CallMeWait(3000);
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("FindandClickExistingNavLink", " Newly created Nav link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("FindandClickExistingNavLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindandClickExistingNavLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeleteNavLink()
        // Method Description : This method will delete the newly created nav link  
        // Created On: 02/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteNavLink()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oDeleteItem_xpath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oDeleteItem_xpath).Click();
                    Report.UpdateTestLog("DeleteNavLink", " Clicked on Delete Item ", Status.DONE);
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeleteNavLinkFinalStep", " Successfully deleted the Nav Link ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("DeleteNavLink", "  Delete Item is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteNavLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteNavLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ReplyCommentAsAuthor()
        // Method Description : This method will reply to a comment   
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ReplyCommentAsAuthor()
        {
            try
            {
                ReadOnlyCollection<IWebElement> CommentAuthors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> Replylinks = Driver.FindElements(MyDashboardOR.oCommentReply_xpath);
                ReadOnlyCollection<IWebElement> CommentTextFields = Driver.FindElements(MyDashboardOR.oCommentArea_xpath);
                ReadOnlyCollection<IWebElement> PostReplyButtons = Driver.FindElements(MyDashboardOR.oPostReplyButton_xpath);
                int iCommentCount = 0;
                if (common.CheckElement(MyDashboardOR.oCommentCount_class) == true)
                {
                    string scommentcounttext = Driver.FindElement(MyDashboardOR.oCommentCount_class).Text.Trim();
                    string scount = scommentcounttext.Substring(0, 2);
                    iCommentCount = Convert.ToInt32(scount);
                    Report.UpdateTestLog("ReplyCommentAsAuthor", " Before posting any reply to comment the comment count is = " + iCommentCount, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ReplyCommentAsAuthor", " No Comment count field is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if(common.CheckElement(MyDashboardOR.oCommentAuthor_xpath)== true)
                {
                    for (int i = 0; i < CommentAuthors.Count; i++)
                    {
                        string CommentAuthor = CommentAuthors[i].Text.Trim();
                        if (CommentAuthor != "Intranet Author")
                        {
                            Replylinks[i].Click();
                            Report.UpdateTestLog("ReplyCommentAsAuthor", " Clicked on Reply link", Status.DONE);
                            common.CallMeWait(2000);
                            if (common.CheckElement(MyDashboardOR.oCommentArea_xpath) == true)
                            {
                                CommentTextFields[i].Click();
                                Report.UpdateTestLog("ReplyCommentAsAuthor", " Clicked on Reply comment text field", Status.DONE);
                                common.CallMeWait(2000);
                                CommentTextFields[i].SendKeys("Replied as author First Time");
                                Report.UpdateTestLog("ReplyCommentAsAuthor", " Entered text on Reply comment text field", Status.DONE);
                                common.CallMeWait(2000);
                                if (common.CheckElement(MyDashboardOR.oPostReplyButton_xpath) == true)
                                {
                                    PostReplyButtons[i].Click();
                                    Report.UpdateTestLog("ReplyCommentAsAuthor", " Clicked the post comment button", Status.PASS);
                                    common.CallMeWait(2000);
                                }
                                else
                                {
                                    Report.UpdateTestLog("ReplyCommentAsAuthor", " No Post Comment button is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                }                               
                            }
                            else
                            {
                                Report.UpdateTestLog("ReplyCommentAsAuthor", " No Comment text field is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                            break;
                        }                       
                    }
                    if (common.CheckElement(MyDashboardOR.oCommentCount_class) == true)
                    {
                        string scommentcounttext = Driver.FindElement(MyDashboardOR.oCommentCount_class).Text.Trim();
                        string scount = scommentcounttext.Substring(0, 2);
                       int iCommentCountupdate = Convert.ToInt32(scount);
                       if (iCommentCount + 1 == iCommentCountupdate)
                       {
                           Report.UpdateTestLog("ReplyCommentAsAuthorFinalStep", " After posting reply to comment the comment count is increased by 1, the count is now = " + iCommentCountupdate, Status.PASS);
                       }
                       else
                       {
                           Report.UpdateTestLog("ReplyCommentAsAuthor", " After posting reply to comment the comment count is not increased by 1, the count is now = " + iCommentCountupdate, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                       }
                    }
                    else
                    {
                        Report.UpdateTestLog("ReplyCommentAsAuthor", " No Comment count field is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ReplyCommentAsAuthor", " No Comment is present" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ReplyCommentAsAuthor", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ReplyCommentAsAuthor", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateDeleteAndReportLink()
        // Method Description : This method will validate the delete and report link beside the comments   
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateDeleteAndReportLink()
        {
            try
            {
                ReadOnlyCollection<IWebElement> CommentAuthors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> Deletelinks = Driver.FindElements(MyDashboardOR.oCommentDelete_xpath);
                ReadOnlyCollection<IWebElement> ReportLinks = Driver.FindElements(MyDashboardOR.oCommentReport_xpath);
                 for (int i = 0; i < CommentAuthors.Count; i++)
                    {
                        string CommentAuthor = CommentAuthors[i].Text.Trim();
                        if (CommentAuthor == "Intranet Author")
                        {
                            if (Deletelinks[i].Text.Trim() == "Delete")
                            {
                                Report.UpdateTestLog("ValidateDeleteAndReportLink", " Successfully validated the delete link", Status.PASS);
                            }
                            else
                            {
                                Report.UpdateTestLog("ValidateDeleteAndReportLink", " Delete link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                            if (ReportLinks[i].Text.Trim() == "Report")
                            {
                                Report.UpdateTestLog("ValidateDeleteAndReportLinkFinalStep", " Successfully validated the Report link", Status.PASS);
                            }
                            else
                            {
                                Report.UpdateTestLog("ValidateDeleteAndReportLink", " report link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                            break;
                        }                        
                        }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDeleteAndReportLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDeleteAndReportLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

  /*      //**********************************************
        // Method SignOutAndCloseBrowser()
        // Method Description : This method will signout and close the browser   
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void SignOutAndCloseBrowser()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oSignOut_id) == true)
                {
                    Driver.FindElement(MyDashboardOR.oSignOut_id).Click();
                    Report.UpdateTestLog("SignOutAndCloseBrowser", " Clicked on Sign-out link ", Status.PASS);
                    common.CallMeWait(2000);
                   // Driver.Close();
                   // Report.UpdateTestLog("SignOutAndCloseBrowserFinalStep", " Successfully Close the browser ", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("SignOutAndCloseBrowser", " Sign-out link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SignOutAndCloseBrowser", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SignOutAndCloseBrowser", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method LoginAsContentOwner()
        // Method Description : This method will login as content owner  
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void LoginAsContentOwner()
        {
            try
            {
                String url = DataTable.GetData("General_Data_" + Env, "NavigationURL");
                Driver.Url = url;
                Report.UpdateTestLog("LoginAsContentOwner", " Open URL " + url + " in browser", Status.PASS);
                Driver.Manage().Window.Maximize();
                Report.UpdateTestLog("LoginAsContentOwnerFinalStep", " Successfully maximize the browser", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("LoginAsContentOwner", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("LoginAsContentOwner", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }*/

        //**********************************************
        // Method ReplyCommentSecondTime()
        // Method Description : This method will reply to a comment second time  
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ReplyCommentSecondTime()
        {
            try
            {
                ReadOnlyCollection<IWebElement> CommentAuthors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> Replylinks = Driver.FindElements(MyDashboardOR.oCommentReply_xpath);
                ReadOnlyCollection<IWebElement> CommentTextFields = Driver.FindElements(MyDashboardOR.oCommentArea_xpath);
                ReadOnlyCollection<IWebElement> PostReplyButtons = Driver.FindElements(MyDashboardOR.oPostReplyButton_xpath);
                if (common.CheckElement(MyDashboardOR.oCommentAuthor_xpath) == true)
                {
                    for (int i = 0; i < CommentAuthors.Count; i++)
                    {
                        string CommentAuthor = CommentAuthors[i].Text.Trim();
                        if (CommentAuthor == "Intranet Author")
                        {
                            Replylinks[i].Click();
                            Report.UpdateTestLog("ReplyCommentSecondTime", " Clicked on Reply link", Status.DONE);
                            common.CallMeWait(2000);
                            CommentTextFields[i].Click();
                            Report.UpdateTestLog("ReplyCommentSecondTime", " Clicked on Reply comment text field", Status.DONE);
                            common.CallMeWait(2000);
                            CommentTextFields[i].SendKeys("Replied as author second time");
                            Report.UpdateTestLog("ReplyCommentSecondTime", " Entered text on Reply comment text field second time", Status.DONE);
                            common.CallMeWait(2000);                            
                            PostReplyButtons[i].Click();
                            Report.UpdateTestLog("ReplyCommentSecondTimeFinalStep", " Clicked the post comment button", Status.PASS);
                            common.CallMeWait(2000);
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ReplyCommentSecondTime", " No Comment is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ReplyCommentSecondTime", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ReplyCommentSecondTime", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ReplyCommentThirdTime()
        // Method Description : This method will reply to a comment third time  
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ReplyCommentThirdTime()
        {
            try
            {
                ReadOnlyCollection<IWebElement> Comments = Driver.FindElements(MyDashboardOR.oComments_xpath);
                ReadOnlyCollection<IWebElement> Replylinks = Driver.FindElements(MyDashboardOR.oCommentReply_xpath);
                ReadOnlyCollection<IWebElement> CommentTextFields = Driver.FindElements(MyDashboardOR.oCommentArea_xpath);
                ReadOnlyCollection<IWebElement> PostReplyButtons = Driver.FindElements(MyDashboardOR.oPostReplyButton_xpath);
                if (common.CheckElement(MyDashboardOR.oComments_xpath) == true)
                {
                    for (int i = 0; i < Comments.Count; i++)
                    {
                        string Comment = Comments[i].Text.Trim();
                        if (Comment.Contains("Replied as author second time"))
                        {
                            Replylinks[i].Click();
                            Report.UpdateTestLog("ReplyCommentThirdTime", " Clicked on Reply link", Status.DONE);
                            common.CallMeWait(2000);
                            CommentTextFields[i].Click();
                            Report.UpdateTestLog("ReplyCommentThirdTime", " Clicked on Reply comment text field", Status.DONE);
                            common.CallMeWait(2000);
                            CommentTextFields[i].SendKeys("Replied as author third time");
                            Report.UpdateTestLog("ReplyCommentThirdTime", " Entered text on Reply comment text field third time", Status.DONE);
                            common.CallMeWait(2000);
                            PostReplyButtons[i].Click();
                            Report.UpdateTestLog("ReplyCommentThirdTimeFinalStep", " Clicked the post comment button", Status.PASS);
                            common.CallMeWait(2000);
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ReplyCommentThirdTime", " No Comment is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ReplyCommentThirdTime", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ReplyCommentThirdTime", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateNoReply()
        // Method Description : This method will validate reply link should not present  
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateNoReply()
        {
            try
            {
                 ReadOnlyCollection<IWebElement> Comments = Driver.FindElements(MyDashboardOR.oComments_xpath);
                 ReadOnlyCollection<IWebElement> links = Driver.FindElements(MyDashboardOR.olinks_xpath);
                 bool flag = false;
                 if (common.CheckElement(MyDashboardOR.oComments_xpath) == true)
                 {
                     for (int i = 0; i < Comments.Count; i++)
                     {
                         string Comment = Comments[i].Text.Trim();
                         if (Comment.Contains("Replied as author third time"))
                         {
                             if (links[i].Text.Trim().Contains("Reply"))
                             {
                                 flag = true;
                             }
                             break;
                         }
                     }
                     if (flag == false)
                     {
                         Report.UpdateTestLog("ValidateNoReplyFinalStep", " User is not able to reply to third level replies", Status.PASS);
                     }
                     else
                     {
                         Report.UpdateTestLog("ValidateNoReply", " User is able to reply to third level replies" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                     }
                 }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNoReply", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNoReply", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeleteReplyComments()
        // Method Description : This method will delete reply comments
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteReplyComments()
        {
            try
            {
                ReadOnlyCollection<IWebElement> CommentAuthors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> Deletelinks = Driver.FindElements(MyDashboardOR.oCommentDelete_xpath);
                ReadOnlyCollection<IWebElement> ReportLinks = Driver.FindElements(MyDashboardOR.oCommentReport_xpath);
                for (int i = 0; i < CommentAuthors.Count; i++)
                {
                    string CommentAuthor = CommentAuthors[i].Text.Trim();
                    if (CommentAuthor == "Intranet Author")
                    {
                        if (Deletelinks[i].Text.Trim() == "Delete")
                        {
                            Deletelinks[i].Click();
                            Report.UpdateTestLog("DeleteReplyComments", " Successfully clicked the delete link", Status.PASS);
                            common.CallMeWait(2000);
                            if (common.CheckElement(MyDashboardOR.odialogBox_class) == true)
                            {
                                if (common.CheckElement(MyDashboardOR.oYes_xpath) == true)
                                {
                                    Driver.FindElement(MyDashboardOR.oYes_xpath).Click();
                                    Report.UpdateTestLog("DeleteReplyCommentsFinalStep", " Clicked Yes button and deleted the comments", Status.PASS);
                                    common.CallMeWait(2000);
                                }
                                else
                                {
                                    Report.UpdateTestLog("DeleteReplyComments", " Yes button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                }
                            }
                            else
                            {
                                Report.UpdateTestLog("DeleteReplyComments", " Dialog Box is not populated", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                        }
                        else
                        {
                            Report.UpdateTestLog("DeleteReplyComments", " Delete link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                        break;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteReplyComments", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteReplyComments", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////////

        //**********************************************
        // Method ReplyCommentAsContentOwner()
        // Method Description : This method will reply to a comment   
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ReplyCommentAsContentOwner()
        {
            try
            {
                ReadOnlyCollection<IWebElement> CommentAuthors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> Replylinks = Driver.FindElements(MyDashboardOR.oCommentReply_xpath);
                ReadOnlyCollection<IWebElement> CommentTextFields = Driver.FindElements(MyDashboardOR.oCommentArea_xpath);
                ReadOnlyCollection<IWebElement> PostReplyButtons = Driver.FindElements(MyDashboardOR.oPostReplyButton_xpath);
                int iCommentCount = 0;
                if (common.CheckElement(MyDashboardOR.oCommentCount_class) == true)
                {
                    string scommentcounttext = Driver.FindElement(MyDashboardOR.oCommentCount_class).Text.Trim();
                    string scount = scommentcounttext.Substring(0, 2);
                    iCommentCount = Convert.ToInt32(scount);
                    Report.UpdateTestLog("ReplyCommentAsContentOwner", " Before posting any reply to comment the comment count is = " + iCommentCount, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ReplyCommentAsContentOwner", " No Comment count field is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(MyDashboardOR.oCommentAuthor_xpath) == true)
                {
                    for (int i = 0; i < CommentAuthors.Count; i++)
                    {
                        string CommentAuthor = CommentAuthors[i].Text.Trim();
                        if (CommentAuthor != "Intranet Content Owner")
                        {
                            Replylinks[i].Click();
                            Report.UpdateTestLog("ReplyCommentAsContentOwner", " Clicked on Reply link", Status.DONE);
                            common.CallMeWait(2000);
                            if (common.CheckElement(MyDashboardOR.oCommentArea_xpath) == true)
                            {
                                CommentTextFields[i].Click();
                                Report.UpdateTestLog("ReplyCommentAsContentOwner", " Clicked on Reply comment text field", Status.DONE);
                                common.CallMeWait(2000);
                                CommentTextFields[i].SendKeys("Replied as content owner First Time");
                                Report.UpdateTestLog("ReplyCommentAsContentOwner", " Entered text on Reply comment text field", Status.DONE);
                                common.CallMeWait(2000);
                                if (common.CheckElement(MyDashboardOR.oPostReplyButton_xpath) == true)
                                {
                                    PostReplyButtons[i].Click();
                                    Report.UpdateTestLog("ReplyCommentAsContentOwner", " Clicked the post comment button", Status.PASS);
                                    common.CallMeWait(2000);
                                }
                                else
                                {
                                    Report.UpdateTestLog("ReplyCommentAsContentOwner", " No Post Comment button is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                }
                            }
                            else
                            {
                                Report.UpdateTestLog("ReplyCommentAsContentOwner", " No Comment text field is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                            break;
                        }
                    }
                    if (common.CheckElement(MyDashboardOR.oCommentCount_class) == true)
                    {
                        string scommentcounttext = Driver.FindElement(MyDashboardOR.oCommentCount_class).Text.Trim();
                        string scount = scommentcounttext.Substring(0, 2);
                        int iCommentCountupdate = Convert.ToInt32(scount);
                        if (iCommentCount + 1 == iCommentCountupdate)
                        {
                            Report.UpdateTestLog("ReplyCommentAsContentOwnerFinalStep", " After posting reply to comment the comment count is increased by 1, the count is now = " + iCommentCountupdate, Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ReplyCommentAsContentOwner", " After posting reply to comment the comment count is not increased by 1, the count is now = " + iCommentCountupdate, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ReplyCommentAsContentOwner", " No Comment count field is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ReplyCommentAsContentOwner", " No Comment is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ReplyCommentAsContentOwner", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ReplyCommentAsContentOwner", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateReplyAndReportLink()
        // Method Description : This method will validate the Reply and report link beside the comments   
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateReplyAndReportLink()
        {
            try
            {
                ReadOnlyCollection<IWebElement> CommentAuthors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> Replylinks = Driver.FindElements(MyDashboardOR.oCommentReply_xpath);
                ReadOnlyCollection<IWebElement> ReportLinks = Driver.FindElements(MyDashboardOR.oCommentReport_xpath);
                for (int i = 0; i < CommentAuthors.Count; i++)
                {
                    string CommentAuthor = CommentAuthors[i].Text.Trim();
                    if (CommentAuthor != "Intranet Content Owner")
                    {
                        if (Replylinks[i].Text.Trim() == "Reply")
                        {
                            Report.UpdateTestLog("ValidateReplyAndReportLink", " Successfully validated the Reply link", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateReplyAndReportLink", " Delete link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                        if (ReportLinks[i].Text.Trim() == "Report")
                        {
                            Report.UpdateTestLog("ValidateReplyAndReportLinkFinalStep", " Successfully validated the Report link", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateReplyAndReportLink", " report link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                        break;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateReplyAndReportLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateReplyAndReportLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ReplyCommentSecondTimeAsContentOwner()
        // Method Description : This method will reply to a comment second time  
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ReplyCommentSecondTimeAsContentOwner()
        {
            try
            {
                ReadOnlyCollection<IWebElement> CommentAuthors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> Replylinks = Driver.FindElements(MyDashboardOR.oCommentReply_xpath);
                ReadOnlyCollection<IWebElement> CommentTextFields = Driver.FindElements(MyDashboardOR.oCommentArea_xpath);
                ReadOnlyCollection<IWebElement> PostReplyButtons = Driver.FindElements(MyDashboardOR.oPostReplyButton_xpath);
                if (common.CheckElement(MyDashboardOR.oCommentAuthor_xpath) == true)
                {
                    for (int i = 0; i < CommentAuthors.Count; i++)
                    {
                        string CommentAuthor = CommentAuthors[i].Text.Trim();
                        if (CommentAuthor == "Intranet Content Owner")
                        {
                            Replylinks[i].Click();
                            Report.UpdateTestLog("ReplyCommentSecondTimeAsContentOwner", " Clicked on Reply link", Status.DONE);
                            common.CallMeWait(2000);
                            CommentTextFields[i].Click();
                            Report.UpdateTestLog("ReplyCommentSecondTimeAsContentOwner", " Clicked on Reply comment text field", Status.DONE);
                            common.CallMeWait(2000);
                            CommentTextFields[i].SendKeys("Replied as content owner second time");
                            Report.UpdateTestLog("ReplyCommentSecondTimeAsContentOwner", " Entered text on Reply comment text field second time", Status.DONE);
                            common.CallMeWait(2000);
                            PostReplyButtons[i].Click();
                            Report.UpdateTestLog("ReplyCommentSecondTimeAsContentOwnerFinalStep", " Clicked the post comment button", Status.PASS);
                            common.CallMeWait(2000);
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ReplyCommentSecondTimeAsContentOwner", " No Comment is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ReplyCommentSecondTimeAsContentOwner", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ReplyCommentSecondTimeAsContentOwner", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ReplyCommentThirdTimeAsContentOwner()
        // Method Description : This method will reply to a comment third time  
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ReplyCommentThirdTimeAsContentOwner()
        {
            try
            {
                ReadOnlyCollection<IWebElement> Comments = Driver.FindElements(MyDashboardOR.oComments_xpath);
                ReadOnlyCollection<IWebElement> Replylinks = Driver.FindElements(MyDashboardOR.oCommentReply_xpath);
                ReadOnlyCollection<IWebElement> CommentTextFields = Driver.FindElements(MyDashboardOR.oCommentArea_xpath);
                ReadOnlyCollection<IWebElement> PostReplyButtons = Driver.FindElements(MyDashboardOR.oPostReplyButton_xpath);
                if (common.CheckElement(MyDashboardOR.oComments_xpath) == true)
                {
                    for (int i = 0; i < Comments.Count; i++)
                    {
                        string Comment = Comments[i].Text.Trim();
                        if (Comment.Contains("Replied as content owner second time"))
                        {
                            Replylinks[i].Click();
                            Report.UpdateTestLog("ReplyCommentThirdTimeAsContentOwner", " Clicked on Reply link", Status.DONE);
                            common.CallMeWait(2000);
                            CommentTextFields[i].Click();
                            Report.UpdateTestLog("ReplyCommentThirdTimeAsContentOwner", " Clicked on Reply comment text field", Status.DONE);
                            common.CallMeWait(2000);
                            CommentTextFields[i].SendKeys("Replied as content owner third time");
                            Report.UpdateTestLog("ReplyCommentThirdTimeAsContentOwner", " Entered text on Reply comment text field third time", Status.DONE);
                            common.CallMeWait(2000);
                            PostReplyButtons[i].Click();
                            Report.UpdateTestLog("ReplyCommentThirdTimeAsContentOwnerFinalStep", " Clicked the post comment button", Status.PASS);
                            common.CallMeWait(2000);
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ReplyCommentThirdTimeAsContentOwner", " No Comment is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ReplyCommentThirdTimeAsContentOwner", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ReplyCommentThirdTimeAsContentOwner", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateNoReplyAsContentOwner()
        // Method Description : This method will validate reply link should not present  
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateNoReplyAsContentOwner()
        {
            try
            {
                ReadOnlyCollection<IWebElement> Comments = Driver.FindElements(MyDashboardOR.oComments_xpath);
                ReadOnlyCollection<IWebElement> links = Driver.FindElements(MyDashboardOR.olinks_xpath);
                bool flag = false;
                if (common.CheckElement(MyDashboardOR.oComments_xpath) == true)
                {
                    for (int i = 0; i < Comments.Count; i++)
                    {
                        string Comment = Comments[i].Text.Trim();
                        if (Comment.Contains("Replied as content owner third time"))
                        {
                            if (links[i].Text.Trim().Contains("Reply"))
                            {
                                flag = true;
                            }
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateNoReplyAsContentOwnerFinalStep", " Content owner is not able to reply to third level replies", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNoReplyAsContentOwner", " Content owner is able to reply to third level replies", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNoReplyAsContentOwner", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNoReplyAsContentOwner", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeleteReplyCommentsAsContentOwner()
        // Method Description : This method will delete reply comments
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteReplyCommentsAsContentOwner()
        {
            try
            {
                ReadOnlyCollection<IWebElement> CommentAuthors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> Deletelinks = Driver.FindElements(MyDashboardOR.oCommentDelete_xpath);
                ReadOnlyCollection<IWebElement> ReportLinks = Driver.FindElements(MyDashboardOR.oCommentReport_xpath);
                for (int i = 0; i < CommentAuthors.Count; i++)
                {
                    string CommentAuthor = CommentAuthors[i].Text.Trim();
                    if (CommentAuthor == "Intranet Content Owner")
                    {
                        if (Deletelinks[i].Text.Trim() == "Delete")
                        {
                            Deletelinks[i].Click();
                            Report.UpdateTestLog("DeleteReplyCommentsAsContentOwner", " Successfully clicked the delete link", Status.PASS);
                            common.CallMeWait(2000);
                            if (common.CheckElement(MyDashboardOR.odialogBox_class) == true)
                            {
                                if (common.CheckElement(MyDashboardOR.oYes_xpath) == true)
                                {
                                    Driver.FindElement(MyDashboardOR.oYes_xpath).Click();
                                    Report.UpdateTestLog("DeleteReplyCommentsAsContentOwnerFinalStep", " Clicked Yes button and deleted the comments", Status.PASS);
                                    common.CallMeWait(2000);
                                }
                                else
                                {
                                    Report.UpdateTestLog("DeleteReplyCommentsAsContentOwner", " Yes button is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                }
                            }
                            else
                            {
                                Report.UpdateTestLog("DeleteReplyCommentsAsContentOwner", " Dialog Box is not populated", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                        }
                        else
                        {
                            Report.UpdateTestLog("DeleteReplyCommentsAsContentOwner", " Delete link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                        break;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteReplyCommentsAsContentOwner", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteReplyCommentsAsContentOwner", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }


        //**********************************************
        // Method ValidateLinks()
        // Method Description : This method will validate reply,delete and report links should not present  
        // Created On: 03/28/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateLinks()
        {
            try
            {
                ReadOnlyCollection<IWebElement> authors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> links = Driver.FindElements(MyDashboardOR.olinks_xpath);
                bool report = false;
                bool Delete = false;
                bool Reply = false;
                if (common.CheckElement(MyDashboardOR.oCommentAuthor_xpath) == true)
                {
                    for (int i = 0; i < authors.Count; i++)
                    {
                        string Author = authors[i].Text.Trim();
                        if (Author !="Intranet News Author")
                        {
                            for (int j = 0; j < links.Count; j++)
                            {
                                if (links[j].Text.Trim().Contains("Report"))
                                {
                                    Report.UpdateTestLog("ValidateLinks", " Report link is present beside the other comment", Status.PASS);
                                    report = true;
                                }
                                if (links[j].Text.Trim().Contains("Delete"))
                                {
                                    Report.UpdateTestLog("ValidateLinks", " Delete link is present beside the other comment", Status.PASS);
                                    Delete = true;
                                }
                                if (links[j].Text.Trim().Contains("Reply"))
                                {
                                    Report.UpdateTestLog("ValidateLinksFinalStep", " Reply link is present beside the other comment", Status.PASS);
                                    Reply = true;
                                }
                            }
                            break;
                        }
                    }
                    if (report == false)
                    {
                        Report.UpdateTestLog("ValidateLinks", " Report link is not present beside other comment", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (Delete == false)
                    {
                        Report.UpdateTestLog("ValidateLinks", " Delete link is not present beside other comment", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (Reply == false)
                    {
                        Report.UpdateTestLog("ValidateLinks", " Reply link is not present beside other comment", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLinks", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLinks", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateDeleteComments()
        // Method Description : This method will validate if top level comment is deleted then the replied comments also get deleted  
        // Created On: 03/29/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateDeleteComments()
        {
            try
            {
                ReadOnlyCollection<IWebElement> Comments = Driver.FindElements(MyDashboardOR.oComments_xpath);
                bool flag1 = true;
                bool flag2 = true;
                if (common.CheckElement(MyDashboardOR.oComments_xpath) == true)
                {
                    for (int i = 0; i < Comments.Count; i++)
                    {
                        string Comment = Comments[i].Text.Trim();
                        if (Comment.Contains("Replied as author second time"))
                        {
                            flag1 = false;
                        }
                        if (Comment.Contains("Replied as author third time"))
                        {
                            flag2 = false;
                        }
                    }
                    if (flag1 == true && flag2 == true)
                    {
                        Report.UpdateTestLog("ValidateDeleteCommentsFinalStep", " Successfully validated that if a top level comment is deleted, others comments below it are removed as well", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateDeleteComments", " Failed to validate that if a top level comment is deleted, others comments below it are removed as well", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateDeleteComments", " No Comment is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDeleteComments", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDeleteComments", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method ValidateDeleteCommentsAsCO()
        // Method Description : This method will validate if top level comment is deleted then the replied comments also get deleted  
        // Created On: 03/29/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateDeleteCommentsAsCO()
        {
            try
            {
                ReadOnlyCollection<IWebElement> Comments = Driver.FindElements(MyDashboardOR.oComments_xpath);
                bool flag1 = true;
                bool flag2 = true;
                if (common.CheckElement(MyDashboardOR.oComments_xpath) == true)
                {
                    for (int i = 0; i < Comments.Count; i++)
                    {
                        string Comment = Comments[i].Text.Trim();
                        if (Comment.Contains("Replied as content owner second time"))
                        {
                            flag1 = false;
                        }
                        if (Comment.Contains("Replied as content owner third time"))
                        {
                            flag2 = false;
                        }
                    }
                    if (flag1 == true && flag2 == true)
                    {
                        Report.UpdateTestLog("ValidateDeleteCommentsAsCOFinalStep", " Successfully validated that if a top level comment is deleted, others comments below it are removed as well", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateDeleteCommentsAsCO", " Failed to validate that if a top level comment is deleted, others comments below it are removed as well", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateDeleteCommentsAsCO", " No Comment is present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDeleteCommentsAsCO", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDeleteCommentsAsCO", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateAlternateLink()
        // Method Description : This method validate the alternate link
        // Created On: 04/17/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateAlternateLink()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oAlternateLink_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateAlternateLinkFinalStep", " Alternate link is present in Global spot news", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateAlternateLink", " Alternate link is not present in Global spot news", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAlternateLink", "Element not found" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAlternateLink", "Error in method" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method DeleteDraftNews()
        // Method Description : This method deletes the article
        // Created On: 04/17/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteDraftNews()
        {
            try
            {
                bool flag = false;
                common.WaitForElement(SiteContentOR.oSaveRibbon_xpath);
                Driver.FindElement(SiteContentOR.oSaveRibbon_xpath).Click();
                common.CallMeWait(1000);
                if (common.CheckElement(SiteContentOR.odeletepage_xpath)==true)
                {
                    Driver.FindElement(SiteContentOR.odeletepage_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    //common.CallMeWait(1000);
                    flag = true;
                }

                if (flag == true)
                {
                    Report.UpdateTestLog("DeleteDraftNewsFinalStep", "Page is deleted ",
                        Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("DeleteDraftNews", "Unable to delete the page",
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteDraftNews", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteDraftNews", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateAlternateType()
        // Method Description : This method validate the alternate Type field
        // Created On: 04/19/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateAlternateType()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oAlternateType_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateAlternateTypeFinalStep", " Alternate Type is present in Global spot news", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateAlternateType", " Alternate Type is not present in Global spot news", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAlternateType", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAlternateType", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickOnIconBesideLocations()
        // Method Description : This method clicks on the icon beside location to open
        // Created On: 05/18/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnIconBesideLocations()
        {
            try
            {
               
                if (common.CheckElement(MyDashboardOR.oLocationSelect_xpath) == true)
                {
                    IWebElement element = Driver.FindElement(MyDashboardOR.oLocationSelect_xpath);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;                   
                    //js.ExecuteScript("arguments[0].scrollIntoView();", element); 
                    js.ExecuteScript("window.scrollBy(0,-250)", "");
                    Driver.FindElement(MyDashboardOR.oLocationSelect_xpath).Click();
                    Report.UpdateTestLog("ClickOnIconBesideLocationsFinalStep", " Clicked on the icon to open the locations", Status.PASS);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnIconBesideLocations", " Icon not found beside location", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnIconBesideLocations", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnIconBesideLocations", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateLocationGroupValues()
        // Method Description : This method validates the location group values
        // Created On: 05/18/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateLocationGroupValues()
        {
            try
            {
                ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(SiteContentOR.Oselectframe_id);
                Driver.SwitchTo().Frame(framecoll[0]);
                if (common.CheckElement(MyDashboardOR.oAmerica_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateLocationGroupValues", " Americas option is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateLocationGroupValues", " Americas option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(MyDashboardOR.oAsiaPacific_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateLocationGroupValues", " Asia Pacific option is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateLocationGroupValues", " Asia pacific option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(MyDashboardOR.oEMEA_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateLocationGroupValues", " EMEA option is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateLocationGroupValues", " EMEA option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLocationGroupValues", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLocationGroupValues", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ClickOnCancel()
        // Method Description : This method clicks on the Cancel button
        // Created On: 05/18/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnCancel()
        {
            try
            {
                if (common.CheckElement(MyDashboardOR.oCancelButton_xpath) == true)
                {
                    Driver.FindElement(MyDashboardOR.oCancelButton_xpath).Click();
                    Report.UpdateTestLog("ClickOnCancel", " Clicked on cancel button ", Status.PASS);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnCancel", " cancel button is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnCancel", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnCancel", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateRemovedLinks()
        // Method Description : This method will validate reply,delete and report links should not present  
        // Created On: 06/8/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateRemovedLinks()
        {
            try
            {
                ReadOnlyCollection<IWebElement> authors = Driver.FindElements(MyDashboardOR.oCommentAuthor_xpath);
                ReadOnlyCollection<IWebElement> links = Driver.FindElements(MyDashboardOR.olinks_xpath);
                bool report = false;
                bool Delete = false;
                bool Reply = false;
                if (common.CheckElement(MyDashboardOR.oCommentAuthor_xpath) == true)
                {
                    for (int i = 0; i < authors.Count; i++)
                    {
                        string Author = authors[i].Text.Trim();
                        if (Author != "Intranet News Author")
                        {
                            for (int j = 0; j < links.Count; j++)
                            {
                                if (links[j].Text.Trim().Contains("Report"))
                                {
                                    Report.UpdateTestLog("ValidateRemovedLinks", " Report link is present beside the other comment", Status.PASS);
                                    report = true;
                                }
                                if (links[j].Text.Trim().Contains("Delete"))
                                {
                                    Report.UpdateTestLog("ValidateRemovedLinks", " Delete link is present beside the other comment", Status.PASS);
                                    Delete = true;
                                }
                                if (links[j].Text.Trim().Contains("Reply"))
                                {
                                    Report.UpdateTestLog("ValidateRemovedLinksFinalStep", " Reply link is present beside the other comment", Status.PASS);
                                    Reply = true;
                                }
                            }
                            break;
                        }
                    }
                    if (report == false)
                    {
                        Report.UpdateTestLog("ValidateRemovedLinks", " Report link is not present beside other comment", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (Delete == false)
                    {
                        Report.UpdateTestLog("ValidateRemovedLinks", " Delete link is not present beside other comment", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (Reply == false)
                    {
                        Report.UpdateTestLog("ValidateRemovedLinks", " Reply link is not present beside other comment", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateRemovedLinks", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateRemovedLinks", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
    
    
    }
}
