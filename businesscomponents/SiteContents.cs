using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CRAFT.SupportLibraries;
using CRAFT.Uimap;
using Framework_Reporting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AutoItX3Lib;
using System.Configuration;


namespace CRAFT.BusinessComponents
{

    /// <summary>
    /// Business Component Library template

    /// </summary>
    public class SiteContents : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;
        /// <summary>
        /// Constructor to initialize the business component library
        /// </summary>
        /// <param name="scriptHelper"> The ScriptHelper object passed from the DriverScript</param>
        public SiteContents(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
            common = new CommonComponents(ScriptHelper);
        }


        //******************************************************
        // Method Name: ClickOnTopNavigationItem()
        // Method Decs: This Metion will click on text from top navigation menu 
        // Created on:  10th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ClickOnTopNavigationItem()
        {
            try
            {
                string topNavigation = DataTable.GetData("General_Data_" + Env, "TopNavigation");
                topNavigation = topNavigation.Trim();
                string dynamicXpath = "//*[text()='" + topNavigation + "']";
                if (common.CheckElement(By.XPath(dynamicXpath)) == true)
                {
                    Driver.FindElement(By.XPath(dynamicXpath)).Click();
                    Report.UpdateTestLog("ClickOnTopNavigationItemFinalStep", " Clicked on  : " + topNavigation, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("ClickOnTopNavigationItem", topNavigation +" is not present on top ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnTopNavigationItem", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnTopNavigationItem", " Error on ClickOnTopNavigationItem method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnSubMenuTopNavigationItem()
        // Method Decs: This method will click on sub menu from top navigation menu 
        // Created on:  10th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void ClickOnSubMenuTopNavigationItem()
        {
            try
            {
                string subMenuTopNavigation = DataTable.GetData("General_Data_" + Env, "SubMenuTopNavigation");
                subMenuTopNavigation = subMenuTopNavigation.Trim();
                string dynamicXpath = "//*[text()='" + subMenuTopNavigation + "']";
                if(common.CheckElement(By.XPath(dynamicXpath)) == true)
                {
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("ClickOnTopNavigationItemFinalStep", " Clicked on  : " + subMenuTopNavigation, Status.PASS);
                common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnTopNavigationItem",  subMenuTopNavigation +" is not present in submenu", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnTopNavigationItem", " Error on ClickOnTopNavigationItem method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: clickOnSiteContentsItem()
        // Method Decs: This method will click on Site Contents item 
        // Created on:  10th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void ClickOnSiteContentsItem()
        {           
            try
            {
                int flag = 0;
                string pagecontentvalue = DataTable.GetData("General_Data_" + Env, "Pagecontentvalue");
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                for (int i = 2; i <= elms.Count; i++)
                {
                  //  string innerValue =Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text;
                    string innerValue = Driver.FindElement(By.XPath("//*[@id='applist']/div[" + i + "]/div[2]/div/div")).Text;

                    if (innerValue.Contains(pagecontentvalue))
                    {
                        Driver.FindElement(By.XPath("//*[@id='applist']/div[" + i + "]/div[1]")).Click();
                        flag = 1;
                        common.CallMeWait(5000);
                        break;
                    }
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("ClickOnSiteContentsItem", " Not able to find Pages : ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("ClickOnSiteContentsItemFinalStep", " Clicked on Item  Pages : " + pagecontentvalue, Status.PASS);
                    
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnSiteContentsItem", " Error on ClickOnSiteContentsItem method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: FindPage()
        // Method Decs: This method will click on page 
        // Created on:  10th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void FindPage()
        {
            try
            {
                string pageName = DataTable.GetData("General_Data_" + Env, "PageName");
                int flag = 0;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                ReadOnlyCollection<IWebElement> elms =
                    Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                for (int i = 1; i < elms.Count; i++)
                {
                    string pageValue = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]/div/a")).Text;

                    if (pageValue.Contains(pageName))
                    {
                        Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]/div/a")).Click();
                        flag = 1;
                        common.CallMeWait(1000);
                        break;

                    }

                }
                if (flag == 1)
                {
                    Report.UpdateTestLog("FindPageFinalStep", " Clicked on Item : " + pageName, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("FindPage", " Unable to Click on Item : " + pageName, Status.FAIL);
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Verification Failed", " There is problem in ClickOnSiteContentsItem Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateLandingPage()
        // Method Decs: This method will validate landing page 
        // Created on:  20th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ValidateLandingPage()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oLeftNav_id) == true)
                {
                    Report.UpdateTestLog("ValidateLandingPageFinalStep", " Successfully validated that Left Nav is present in landing page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateLandingPage", " Left Nav is not present in landing page", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLandingPage", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLandingPage", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: EditPage()
        // Method Decs: This method will click on Site Contents item 
        // Created on:  10th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void EditPage()
        {
            try
            {
                string webPartCategories = DataTable.GetData("General_Data_" + Env, "WebPartCategories");
                string webParts = DataTable.GetData("General_Data_" + Env, "WebParts");
                string videoSource = DataTable.GetData("AddWebPartInfo", "VideoSource");
                string CheckVideoStatus = DataTable.GetData("AddWebPartInfo", "CheckVideoStatus");
                IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
               
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("EditPage", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(5000);
                IWebElement addwebpart = Driver.FindElement(By.XPath("//*[@id='MSOZone']/div[1]"));
                js.ExecuteScript("CoreInvoke('ShowWebPartAdder', 'MainZone');");
                
                Report.UpdateTestLog("EditPage", " Click on Add a Web Part element  ", Status.PASS);
                ClickOnWebpartCategory(webPartCategories);
                ClickOnWebPart(webParts);
               
                IWebElement addBtn = Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath);
               
                addBtn.Click();
               
                //js.ExecuteScript("arguments[0].style.border='2px groove green'", addBtn);
                //Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath).Click();
                Report.UpdateTestLog("EditPage", " Click on Add button  ", Status.PASS);
                Driver.FindElement(SiteContentOR.oaddwebpartwebelementsavebtn_xpath).Click();
                common.CallMeWait(5000);
                Report.UpdateTestLog("EditPage", " Click on Save button  ", Status.PASS);
                common.CallMeWait(5000);
                if (videoSource.Count() > 0)
                {
                    AddYouTubeInfo();
                }
               
                //Verification
                int count = Driver.FindElements(SiteContentOR.owebpartcountwebelemets_xpath).Count;
                if (Driver.FindElements(SiteContentOR.owebpartcountwebelemets_xpath).Count >= 1)
                {
                    Report.UpdateTestLog("EditPageFinalStep", " Number of web part: " + count + " Available in the page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EditPage", " Number of web part: " + count + " Available in the page but expected is 1 ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (CheckVideoStatus.Count() > 0)
                {
                    CheckVideoPlayStatus();
                }
               
               
                DeleteWebPart();

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EditPage", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EditPage", " There is a problem in EditPage Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }


        }
        //******************************************************
        // Method Name: ClickOnWebpartCategory()
        // Method Decs: This method will click on Site Contents item 
        // Created on:  10th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ClickOnWebpartCategory(string category)
        {
            try
            {
                Driver.FindElement(By.XPath("//*[@title='" + category + "']")).Click();
                Report.UpdateTestLog("ClickOnWebpartCategoryFinalStep", " Click on Add a Web Part element : " + category, Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnWebpartCategory", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("ClickOnWebpartCategory", " There is a problem in ClickOnWebpartCategory Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }


        }
        //******************************************************
        // Method Name: ClickOnWebPart()
        // Method Decs: This method will click on Site Contents item 
        // Created on:  10th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ClickOnWebPart(string part)
        {
            try
            {
                // common.WaitForElement();
                //Driver.FindElement(By.XPath("//*[@title='" + part + "']")).Click();
                Driver.FindElement(By.XPath("//*[@title=\"" + part + "\"]")).Click();
                Report.UpdateTestLog("ClickOnWebPartFinalStep", " Click on Add  sub Web Part element : " + part, Status.PASS);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnWebPart", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnWebPart", " There is a problem in ClickOnWebpartCategory Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }


        }
        //******************************************************
        // Method Name: DeleteWebPart()
        // Method Decs: This method will delete the existing web part
        // Created on:  10th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void DeleteWebPart()
        {
            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
               // Report.UpdateTestLog("EditPage", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(5000);
                Driver.FindElement(By.XPath("//*[@class='main-wp-zone-sm']/child::*[2]/div[2]/child::*/child::*[1]/child::*[2]/div/a")).Click();
                
                Driver.FindElement(By.XPath("//*[text()='Delete']")).Click();
                common.CallMeWait(5000);
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Accept();
                common.CallMeWait(5000);
                Driver.FindElement(SiteContentOR.oaddwebpartwebelementsavebtn_xpath).Click();
                Report.UpdateTestLog("DeleteWebPartFinalStep", " Web part Deleted successfully   ", Status.PASS);
              }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteWebPart", " Web Element not found :"+e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteWebPart", " Problem in DeleteWebPart Method: "+e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            

        }
        //******************************************************
        // Method Name: AddYouTubeInfo()
        // Method Decs: This method will add youtube infomation
        // Created on:  12th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void AddYouTubeInfo()
        {
            try
            {
                string videoSource = DataTable.GetData("AddWebPartInfo", "VideoSource");
                string link = DataTable.GetData("AddWebPartInfo", "Link");
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("AddYouTubeInfo", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(5000);


                Driver.FindElement(By.XPath("//*[@class='main-wp-zone-sm']/child::*[2]/div[2]/child::*/child::*[1]/child::*[2]/div/a")).Click();

                Driver.FindElement(By.XPath("//*[text()='Edit Web Part']")).Click();
                common.CallMeWait(5000);
                
                //select the youtube 
                var selectElement    = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                selectElement.SelectByText(videoSource);
                // set you tube link
                Report.UpdateTestLog("AddYouTubeInfo", " Select video source as  " + videoSource, Status.DONE);
                Driver.FindElement(SiteContentOR.ovideowebpartlinktextbox_id).SendKeys(link);
                Report.UpdateTestLog("AddYouTubeInfo", " Select video source link as  " + link, Status.DONE);
                // click on apply button
                Driver.FindElement(SiteContentOR.ovideowebpartapplybtn_xpath).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("AddYouTubeInfo", " Click on Apply button  " , Status.DONE);
                //click on Ok button
                Driver.FindElement(SiteContentOR.ovideowebpartokbtn_xpath).Click();
                common.CallMeWait(3000);
                Report.UpdateTestLog("AddYouTubeInfo", " Click on OK button  " , Status.DONE);
                //click on save button
                Driver.FindElement(SiteContentOR.oaddwebpartwebelementsavebtn_xpath).Click();
                Report.UpdateTestLog("AddYouTubeInfoFinalStep", " Click on Save button  ", Status.PASS);
                common.CallMeWait(2000);
                
            }catch(NoSuchElementException e)
            {
                Report.UpdateTestLog("AddYouTubeInfo", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddYouTubeInfo", " Problem in AddYouTubeInfo Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            
        }
        //******************************************************
        // Method Name: CheckVideoPlayStatus()
        // Method Decs: This method will check youtube video is running or pause
        // Created on:  13th  Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void CheckVideoPlayStatus()
        {
            try
            {
                ReadOnlyCollection <IWebElement> detailFrame = Driver.FindElements(By.XPath("//iframe"));
                Driver.SwitchTo().Frame(detailFrame[0]);
                ReadOnlyCollection<IWebElement> play= Driver.FindElements((SiteContentOR.oyoutubeplaybtn_xpath));    
                play[0].Click();
                string youtybestatus =
                    Driver.FindElement(SiteContentOR.oyoutubestatuscheck_xpath).GetAttribute("aria-label");
                if (youtybestatus.Equals("Pause"))
                {
                    Report.UpdateTestLog("CheckVideoPlayStatus", " youtube Video is Play status " , Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CheckVideoPlayStatus", " youtube Video is Pause status ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                
                common.CallMeWait(3000);
                
                ReadOnlyCollection<IWebElement> playpause    =  Driver.FindElements(SiteContentOR.oyoutubestatuscheck_xpath);
                playpause[0].Click();
                youtybestatus =playpause[0].GetAttribute("aria-label");
                if (youtybestatus.Equals("Play"))
                {
                    Report.UpdateTestLog("CheckVideoPlayStatusFinalStep", " youtube Video is Pause status ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CheckVideoPlayStatus", " youtube Video is Play status ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                Driver.SwitchTo().DefaultContent();
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CheckVideoPlayStatus", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("CheckVideoPlayStatus", " Error occured in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyShowMoreAndUserProfile()
        // Method Decs: This method will verify user profile and show more button present on page 
        // Created on:  13th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void VerifyShowMoreAndUserProfile()
        {
            try
            {
                //String url = DataTable.GetData("General_Data_" + Env, "RequestType1");
                //Driver.Navigate().GoToUrl(url);
                //common.CallMeWait(300);
                ReadOnlyCollection<IWebElement> elms;
                if (Driver.FindElement(SiteContentOR.Opeoplelistlabel_xpath).Displayed)
                {
                    string labelname = Driver.FindElement(SiteContentOR.Opeoplelistlabel_xpath).Text;
                    Report.UpdateTestLog("VerifyShowMoreAndUserProfile ", " People label is present as " + labelname,
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyShowMoreAndUserProfile", " People label is Not present as ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

                }

                if (Driver.FindElement(SiteContentOR.Opeoplelistcontainer_xpath).Displayed)
                {

                    elms =
                        new ReadOnlyCollection<IWebElement>(Driver.FindElements(SiteContentOR.Opeoplelistcontainer_xpath));
                    int count = elms.Count;
                    Report.UpdateTestLog("VerifyShowMoreAndUserProfile ", " Total People present are " + count,
                        Status.PASS);

                    if (count >= 12)
                    {
                        if (Driver.FindElement(SiteContentOR.OshowMorePeopleLink_xpath).Displayed)
                        {
                            Report.UpdateTestLog("VerifyShowMoreAndUserProfile ", " Show More link is displayed ",
                                Status.PASS);
                            Driver.FindElement(SiteContentOR.OshowMorePeopleLink_xpath).Click();
                            Report.UpdateTestLog("VerifyShowMoreAndUserProfile ", " Show More link is clicked ",
                                Status.PASS);

                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyShowMoreAndUserProfile ", " Show More link is not present ",
                                Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }


                    }

                    elms[0].Click();
                    common.CallMeWait(2000);
                    ReadOnlyCollection<string> allwindow = Driver.WindowHandles;
                    if (allwindow.Count > 1)
                    {
                        Report.UpdateTestLog("VerifyShowMoreAndUserProfileFinalStep", " Profile page is opened in new Tab ",
                                Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyShowMoreAndUserProfile", " Profile window not opened ",
                                Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyShowMoreAndUserProfile", " People label is Not present as ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyShowMoreAndUserProfile", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {

                Report.UpdateTestLog("VerifyShowMoreAndUserProfile", " Error occured", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: EditVideoLayoutPage()
        // Method Decs: This method will edir video payout page 
        // Created on:  13th Jan 2017		
        // Created by:  GI offshore Team
        //****************************************************

        public void EditVideoLayoutPage()
        {
            try
            {
                String videoText = DataTable.GetData("AddWebPartInfo", "VideoText");
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("EditVideoLayoutPage", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(5000);
                AddYouTubeInfoAtVedioLayout();

                ReadOnlyCollection<IWebElement> detailFrame = Driver.FindElements(By.XPath("//iframe"));
                Driver.SwitchTo().Frame(detailFrame[0]);
                if (common.CheckElement(By.XPath("//*[text()='" + videoText + "']")) == true)
                {
                    Report.UpdateTestLog("EditVideoLayoutPageFinalStep", "Video is present with name:  " + videoText, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EditVideoLayoutPage", "Video is not present with name:  " + videoText, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                Driver.SwitchTo().DefaultContent();
                ClearVideoLinkFromVideoLayout();


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EditVideoLayoutPage", " Element not found   "+e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EditVideoLayoutPage", " Problem in current method  " +e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            
        }

        //******************************************************
        // Method Name: AddYouTubeInfo()
        // Method Decs: This method will add youtube infomation
        // Created on:  12th Jan 2017
		// Created by:  GI offshore Team		
        //****************************************************
        public void AddYouTubeInfoAtVedioLayout()
        {
            try
            {
                string videoSource = DataTable.GetData("AddWebPartInfo", "VideoSource");
                string link = DataTable.GetData("AddWebPartInfo", "Link");

                Driver.FindElement(By.XPath("//*[@class='ms-webpart-menuArrowSpan']")).Click();
                Driver.FindElement(By.XPath("//*[text()='Edit Web Part']")).Click();
                common.CallMeWait(5000);

                //select the youtube 
                var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                selectElement.SelectByText("Brightcove");
                common.CallMeWait(1000);                
                selectElement.SelectByText(videoSource);
                // set you tube link
                Report.UpdateTestLog("AddYouTubeInfo", " Select video source as  " + videoSource, Status.DONE);
                Driver.FindElement(SiteContentOR.ovideowebpartlinktextbox_id).Clear();
                Driver.FindElement(SiteContentOR.ovideowebpartlinktextbox_id).SendKeys(link);
                Report.UpdateTestLog("AddYouTubeInfo", " Select video source link as  " + link, Status.DONE);
                // click on apply button
                Driver.FindElement(SiteContentOR.ovideowebpartapplybtn_xpath).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("AddYouTubeInfo", " Click on Apply button  ", Status.DONE);
                //click on Ok button
                Driver.FindElement(SiteContentOR.ovideowebpartokbtn_xpath).Click();
                common.CallMeWait(3000);
                Report.UpdateTestLog("AddYouTubeInfo", " Click on OK button  ", Status.DONE);
                //click on checkin button
                ReadOnlyCollection<IWebElement> ribbonlist =Driver.FindElements(SiteContentOR.osavenewcheckinribbon_xpath);
                ribbonlist[2].Click();
                Report.UpdateTestLog("AddYouTubeInfo", " Click on check out button  ", Status.DONE);
                common.CallMeWait(2000);
                Driver.FindElement(SiteContentOR.ochecincontinuebtn_xpath).Click();
                Report.UpdateTestLog("AddYouTubeInfoFinalStep", " Click on CONTUNUE button  ", Status.PASS);
                common.CallMeWait(2000);
                

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddYouTubeInfo", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddYouTubeInfo", " Problem in AddYouTubeInfo Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClearVideoLinkFromVideoLayout()
        // Method Decs: This method will clean youtube video lik from video layou tpage
        // Created on:  12th Jan 2017	
		// Created by:  GI offshore Team	
        //****************************************************
        public void ClearVideoLinkFromVideoLayout()
        {
            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("EditPage", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(3000);
                Driver.FindElement(By.XPath("//*[@class='ms-webpart-menuArrowSpan']")).Click();
                Driver.FindElement(By.XPath("//*[text()='Edit Web Part']")).Click();
                common.CallMeWait(5000);

                
                Driver.FindElement(SiteContentOR.ovideowebpartlinktextbox_id).Clear();
                
                // click on apply button
                Driver.FindElement(SiteContentOR.ovideowebpartapplybtn_xpath).Click();
                common.CallMeWait(2000);
               
                //click on Ok button
                Driver.FindElement(SiteContentOR.ovideowebpartokbtn_xpath).Click();
                common.CallMeWait(3000);
                
                //click on checkin button
                ReadOnlyCollection<IWebElement> ribbonlist = Driver.FindElements(SiteContentOR.osavenewcheckinribbon_xpath);
                ribbonlist[2].Click();
                
                common.CallMeWait(2000);
                Driver.FindElement(SiteContentOR.ochecincontinuebtn_xpath).Click();
                
                common.CallMeWait(2000);
                Report.UpdateTestLog("ClearVideoLinkFromVideoLayoutFinalStep", " Video Link cleaned successfully ", Status.PASS);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClearVideoLinkFromVideoLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClearVideoLinkFromVideoLayout", " Problem in AddYouTubeInfo Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyIntranetCategory()
        // Method Decs: This method will verify Intranet Category field
        // Created on:  24th Jan 2017
		// Created by:  GI offshore Team
        //****************************************************
        public void VerifyIntranetCategory()
        {
            try
            {
                int flag = 0;
                common.WaitForElement(SiteContentOR.oeditlink_xpath);
                Driver.FindElement(SiteContentOR.oeditlink_xpath).Click();
                common.WaitForElement(SiteContentOR.ointernetcatagorywebelement_xpath);
                string dynamicLink = "//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr[1]/th";
                ReadOnlyCollection<IWebElement> elems =Driver.FindElements(SiteContentOR.ointernetcatagorywebelement_xpath);
                int listCount = elems.Count;
                for (int i = 1; i <= listCount; i++)
                {
                    dynamicLink ="//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr[1]/th["+i+"]";
                    string value = Driver.FindElement(By.XPath(dynamicLink)).GetAttribute("title");
                    if (value.Equals("Intranet Category"))
                    {
                        Report.UpdateTestLog("VerifyIntranetCategoryFinalStep", "Intranet Category Present in the header  ", Status.PASS);
                        flag = 1;
                        break;
                    }
                    
                }
               
                if (flag ==0)
                {
                    Report.UpdateTestLog("VerifyIntranetCategory", "Intranet Category Not Present in the header", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyIntranetCategory", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyIntranetCategory", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EditIntranetCategory()
        // Method Decs: This method will verify editing Intranet Category field
        // Created on: 12th Jan 2017
        // Created by: GI offshore Team
        //****************************************************
        public void EditIntranetCategory()
        {
            try
            {
                int flag = 0;
                common.WaitForElement(SiteContentOR.oeditlink_xpath);
                Driver.FindElement(SiteContentOR.oeditlink_xpath).Click();
                common.WaitForElement(SiteContentOR.ointernetcatagorywebelement_xpath);
                string dynamicLink = "//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr[1]/th";
                ReadOnlyCollection<IWebElement> elems = Driver.FindElements(SiteContentOR.ointernetcatagorywebelement_xpath);
                int listCount = elems.Count;
                string suggetiontext = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string sug = null;
                for (int i = 1; i <= listCount; i++)
                {
                    dynamicLink = "//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr[1]/th[" + i + "]";
                    string value = Driver.FindElement(By.XPath(dynamicLink)).GetAttribute("title");
                    if (value.Equals("Intranet Category"))
                    {

                        IWebElement e = Driver.FindElement(By.XPath("//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr[2]/td[" + i + "]"));
                        e.Click();
                        e.Click();
                        Driver.FindElement(By.XPath("//*[@id='jsgrid_taxonomygridcontrol_$containereditableRegion']")).Clear();
                        Driver.FindElement(By.XPath("//*[@id='jsgrid_taxonomygridcontrol_$containereditableRegion']")).SendKeys(suggetiontext);
                        common.CallMeWait(2000);
                        sug =
                            Driver.FindElement(
                                By.XPath(
                                    "//*[@id='jsgrid_taxonomygridcontrol_$containersuggestionsContainerGroup0Title']"))
                                .Text;

                        flag = 1;
                        Report.UpdateTestLog("EditIntranetCategoryFinalStep", "User is able to edit ", Status.PASS);
                        break;
                    }

                }

                if (sug.Equals("Suggestions"))
                {
                    Report.UpdateTestLog("EditIntranetCategory", "Suggestion list are displayed for Intranet Category", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EditIntranetCategory", "Suggestion list are not displayed for Intranet Category", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (flag == 0)
                {
                    Report.UpdateTestLog("EditIntranetCategory", "Intranet Category Not Present in the header", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EditIntranetCategory", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EditIntranetCategory", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreatePageWithVideoLayout()
        // Method Decs: This method will create a page with video lauout and add video web part 
        // Created on:  25th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void CreatePageWithVideoLayout()
        {
            try
            {
                int flag = 0;
                string pagename1 = DataTable.GetData("General_Data_" + Env, "PageName");
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string pagename = pagename1 + "_" + ArticleDate;
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(3000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                common.WaitForElement(SiteContentOR.ocreatecbreintrapage_xpath);
                Driver.FindElement(SiteContentOR.ocreatecbreintrapage_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.otitleTextBox_xpath);
                Driver.FindElement(SiteContentOR.otitleTextBox_xpath).SendKeys(pagename);
                common.WaitForElement(SiteContentOR.ovideolayout_xpath);
                Driver.FindElement(SiteContentOR.ovideolayout_xpath).Click();
                common.WaitForElement(SiteContentOR.ocreatepage_xpath);
                Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (common.CheckElement((SiteContentOR.ofilelink_xpath)) == true)
                {
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("CreatePageWithVideoLayoutFinalStep", "Page is cretaed with name :" + pagename,
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreatePageWithVideoLayout", "Unable to create page" + pagename,
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreatePageWithVideoLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreatePageWithVideoLayout", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: Deletepage()
        // Method Decs: This method will find a page and delete the click on page 
        // Created on:  25th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void Deletepage()
        {
            bool flag = false;
            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                common.CallMeWait(1000);
                //common.WaitForElement(SiteContentOR.odeletepage_xpath);
                //Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (common.CheckElement(SiteContentOR.odeletepage_xpath)==true)
                {
                    Driver.FindElement(SiteContentOR.odeletepage_xpath).Click();
                    common.CallMeWait(1000);
                    Driver.SwitchTo().Alert().Accept();                    
                    flag = true;
                }

                if (flag)
                {
                    Report.UpdateTestLog("DeletepageFinalStep", "Page is deleted ",
                        Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("Deletepage", "Unable to delete the page",
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Deletepage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Deletepage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyUploadImage()
        // Method Decs: This method will upload the image in site comtent->image folder 
        // Created on:  11th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyUploadImage()
        {
            int flag = 0;

            try
            {
                common.WaitForElement(SiteContentOR.oadminlink_xapth);
                Driver.FindElement(SiteContentOR.oadminlink_xapth).Click();
                Report.UpdateTestLog("verifyUploadImage", " Admin link is clicked ", Status.PASS);

                common.WaitForElement(SiteContentOR.oclickingtositecontent);
                Driver.FindElement(SiteContentOR.oclickingtositecontent).Click();
                Report.UpdateTestLog("verifyUploadImage", " site content link is clicked ", Status.PASS);

                common.WaitForElement(SiteContentOR.oclicktoimagefolder_xpath);
                Driver.FindElement(SiteContentOR.oclicktoimagefolder_xpath).Click();
                Report.UpdateTestLog("verifyUploadImage", " image folder link is clicked ", Status.PASS);
                common.CallMeWait(3000);

                //delete existing image 
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");

                ReadOnlyCollection<IWebElement> allimages = Driver.FindElements(By.XPath("//*[@id='onetidDoclibViewTbl0']/tbody/tr/td/child::*[1]/child::*"));

                for (int k = 0; k < allimages.Count; k++)
                {
                    string imagetext = allimages[k].Text.Trim();
                    if (requestType1.Contains(imagetext))
                    {
                        Actions a = new Actions(Driver);
                        a.ClickAndHold(allimages[k]);
                        a.Perform();
                        allimages[k].Click();
                        common.CallMeWait(3000);
                        Driver.FindElement(
                            By.XPath("//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")).Click();
                        common.CallMeWait(2000);
                        Driver.SwitchTo().Alert().Accept();
                        common.CallMeWait(5000);
                        break;
                    }
                }

                try
                {
                    common.WaitForElement(SiteContentOR.oclicktonewitem_xpath);
                    Driver.FindElement(SiteContentOR.oclicktonewitem_xpath).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("verifyUploadImage", " New item link is clicked ", Status.PASS);
                    ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(SiteContentOR.Oselectframe_id);
                    Driver.SwitchTo().Frame(framecoll[0]);
                    //common.WaitForElement(SiteContentOR.oclicktonewitem_xpath);
                    Driver.FindElement(SiteContentOR.oclicktoupload_xpath).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("verifyUploadImage", " Image upload window is opened ", Status.PASS);
                }
                catch (NoSuchFrameException e)
                {
                    Report.UpdateTestLog("verifyUploadImage", " Image upload window is not found", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                //sending the image loacation to upload a image

                common.UploadeFile(requestType1);
                Driver.FindElement(SiteContentOR.oclickokbutton_xpath).Click();
                common.CallMeWait(4000);
                Report.UpdateTestLog("verifyUploadImage", " image path is selected ", Status.PASS);
                Driver.FindElement(SiteContentOR.Oclicktosave_xpath).Click();
                Report.UpdateTestLog("verifyUploadImage", " Image save button is clicked ", Status.PASS);
                common.CallMeWait(2000);
                Driver.SwitchTo().DefaultContent();

                // under image folder

                string findxpath =
                    "//*[@id='onetidDoclibViewTbl0']/tbody/tr/td/child::*[1]/child::*[last()]/div/child::*[2]/a[2]";
                Actions builder = new Actions(Driver);
                builder.ClickAndHold(Driver.FindElement(By.XPath("//*[@id='onetidDoclibViewTbl0']/tbody/tr/td/child::*[1]/child::*[last()]/div/div")));
                builder.Perform();
                common.CallMeWait(6000);
                Driver.FindElement(By.XPath(findxpath)).Click();
                common.CallMeWait(5000);

                IWebElement wbe = Driver.FindElement(By.XPath("//*[contains(@id, '_callout-content')]"));
                ReadOnlyCollection<IWebElement> links = wbe.FindElements(By.TagName("a"));
                foreach (IWebElement link in links)
                {
                    String href = link.GetAttribute("href");
                    if (href.Contains("checkout"))
                    {
                        flag = 1;
                        break;

                    }
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("verifyUploadImageFinalStep", " Check out link is not present ", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("verifyUploadImage", " Check out link is present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }

            catch (Exception e)
            {
                Report.UpdateTestLog("verifyUploadImage", " Error in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        

        //******************************************************
        // Method Name: VerifySiteContentTypes()
        // Method Decs: This method will verify site content type under site content 
        // Created on:  25th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifySiteContentTypes()
        {

            //string pagecontentvalue = DataTable.GetData("General_Data_" + Env, "Pagecontentvalue");
            try
            {

                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                if (elms.Count > 0)
                {
                    //RequestType1
                    string sitetypevalue = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                    int flag = 0;
                    for (int i = 2; i <= elms.Count; i++)
                    {
                        string innerValue =
                            Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text.Trim();
                        if (innerValue.Contains(sitetypevalue))
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    //RequestType2
                    sitetypevalue = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                    flag = 0;
                    for (int i = 2; i <= elms.Count; i++)
                    {
                        string innerValue =
                            Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text.Trim();
                        if (innerValue.Contains(sitetypevalue))
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    //RequestType3
                    sitetypevalue = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                    flag = 0;
                    for (int i = 2; i <= elms.Count; i++)
                    {
                        string innerValue =
                            Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text.Trim();
                        if (innerValue.Contains(sitetypevalue))
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    //RequestType4
                    sitetypevalue = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                    flag = 0;
                    for (int i = 2; i <= elms.Count; i++)
                    {
                        string innerValue =
                            Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text.Trim();
                        if (innerValue.Contains(sitetypevalue))
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    //RequestType5
                    sitetypevalue = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                    flag = 0;
                    for (int i = 2; i <= elms.Count; i++)
                    {
                        string innerValue =
                            Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text.Trim();
                        if (innerValue.Contains(sitetypevalue))
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    //RequestType6
                    sitetypevalue = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                    flag = 0;
                    for (int i = 2; i <= elms.Count; i++)
                    {
                        string innerValue =
                            Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text.Trim();
                        if (innerValue.Contains(sitetypevalue))
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    //RequestType7
                    sitetypevalue = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                    flag = 0;
                    for (int i = 2; i <= elms.Count; i++)
                    {
                        string innerValue =
                            Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text.Trim();
                        if (innerValue.Contains(sitetypevalue))
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        Report.UpdateTestLog("VerifySiteContentTypesFinalStep", sitetypevalue + "  is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySiteContentTypes", sitetypevalue + "  is not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifySiteContentTypes", " No siste content item present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySiteContentTypes", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySiteContentTypes", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyAddImageCarousel()
        // Method Decs: This method will add image gallery Web Part in page
        // Created on:  27th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifyAddImageCarousel()
        {

            try
            {
                string webPartCategories = DataTable.GetData("General_Data_" + Env, "WebPartCategories");
                string webParts = DataTable.GetData("General_Data_" + Env, "WebParts");
                IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
                IWebElement addwebpart = Driver.FindElement(By.XPath("//*[@id='MSOZone']/div[1]"));
                js.ExecuteScript("CoreInvoke('ShowWebPartAdder', 'MainZone');");
                Report.UpdateTestLog("EditPage", " Click on Add a Web Part element  ", Status.PASS);
                ClickOnWebpartCategory(webPartCategories);
                ClickOnWebPart(webParts);
                IWebElement addBtn = Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath);
                addBtn.Click();
                Report.UpdateTestLog("VerifyAddImageCarousel", " Click on OK button  ", Status.DONE);
                common.CallMeWait(3000);
                Actions builder = new Actions(Driver);
                builder.MoveToElement(Driver.FindElement(By.XPath("//span[contains(text(),'Image Gallery')]")))
                .Click().Build().Perform();
                common.CallMeWait(2000);
                Driver.FindElement(SiteContentOR.oclicktoeditgallerywebpart).Click();
                Driver.FindElement(By.XPath("//*[text()='Edit Web Part']")).Click();
                Report.UpdateTestLog("VerifyAddImageCarousel", " Edit Button is Clicked  ", Status.PASS);
                common.CallMeWait(3000);
                Driver.FindElement(SiteContentOR.oselectafolderlocation).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.oselectimageoption).Click();
                Driver.FindElement(SiteContentOR.ocloseoption).Click();

                // click on apply button
                Driver.FindElement(SiteContentOR.ovideowebpartapplybtn_xpath).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("VerifyAddImageCarousel", " Click on Apply button  ", Status.PASS);
                //click on Ok button
                Driver.FindElement(SiteContentOR.ovideowebpartokbtn_xpath).Click();
                common.CallMeWait(3000);
                Report.UpdateTestLog("VerifyAddImageCarousel", " Click on OK button  ", Status.PASS);
                if (Driver.FindElement(By.XPath("//span[contains(text(),'Image Gallery')]")).Displayed)
                {
                    Report.UpdateTestLog("VerifyAddImageCarouselFinalStep", "Image Carousel is uploaded ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyAddImageCarousel", "Unable to upload Image Carousel ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //going to deleted added image Gallery Web part
                // DeleteAddedImageCarousel();

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyAddImageCarousel", " Web Element not found " + e, Status.FAIL);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyAddImageCarousel", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: DeleteAddedImageCarousel()
        // Method Decs: This method delete the  added image gallery Web Part from page
        // Created on:  27th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void DeleteAddedImageCarousel()
        {
            try
            {
                Actions builder = new Actions(Driver);
                builder.MoveToElement(Driver.FindElement(By.XPath("//span[contains(text(),'Image Gallery')]")))
                    .Click().Build().Perform();
                common.CallMeWait(2000);
                Driver.FindElement(SiteContentOR.oclicktoeditgallerywebpart).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.odeletegallerywebpart).Click();
                common.CallMeWait(1000);

                Driver.SwitchTo().Alert().Accept();
                Driver.SwitchTo().DefaultContent();
                common.CallMeWait(3000);
                Report.UpdateTestLog("DeleteAddedImageCarouselFinalStep", " Image Web part is deleted ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteAddedImageCarousel", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteAddedImageCarousel", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ConfigureGalleryWebPart()
        // Method Decs: This method configure carousel and grid with 6,9,12 image layout.
        // Created on:  27th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void ConfigureGalleryWebPart()
        {
            try
            {
                //uploading images in Image Gallery Web part in carousel lay out
                VerifyAddImageCarousel();
                Driver.FindElement(SiteContentOR.oclicktoeditgallerywebpart).Click();
                Driver.FindElement(By.XPath("//*[text()='Edit Web Part']")).Click();
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Edit Button is Clicked  ", Status.PASS);
                common.CallMeWait(3000);

                common.WaitForElement(SiteContentOR.ogridrediobutton);
                if (Driver.FindElement(SiteContentOR.ogridrediobutton).Displayed)
                {
                    Driver.FindElement(SiteContentOR.ogridrediobutton).Click();
                    Report.UpdateTestLog("ConfigureGalleryWebPart", " Grid option is selected ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ConfigureGalleryWebPart", " unable to select Grid option ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Selecting Nine image per grid is clicked
                Driver.FindElement(SiteContentOR.opergridimagenine).Click();
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Nine image per grid is clicked  ", Status.PASS);
                // click on apply button
                Driver.FindElement(SiteContentOR.ovideowebpartapplybtn_xpath).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Click on Apply button  ", Status.DONE);
                //click on Ok button
                Driver.FindElement(SiteContentOR.ovideowebpartokbtn_xpath).Click();
                common.CallMeWait(4000);
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Click on OK button  ", Status.DONE);
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Nine image per grid is displayed ", Status.DONE);

                //opening the Web part in Edit mode
                Driver.FindElement(SiteContentOR.oclicktoeditgallerywebpart).Click();
                Driver.FindElement(By.XPath("//*[text()='Edit Web Part']")).Click();
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Edit Button is Clicked  ", Status.PASS);
                common.CallMeWait(3000);

                //Selecting Twelve image per grid is clicked
                Driver.FindElement(SiteContentOR.opergridimagetwelve).Click();
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Twelve image per grid is clicked  ", Status.PASS);
                // click on apply button
                Driver.FindElement(SiteContentOR.ovideowebpartapplybtn_xpath).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Click on Apply button  ", Status.DONE);
                //click on Ok button
                Driver.FindElement(SiteContentOR.ovideowebpartokbtn_xpath).Click();
                common.CallMeWait(4000);
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Click on OK button  ", Status.DONE);
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Twelve image per grid is displayed ", Status.DONE);

                //opening the Web part in Edit mode
                Driver.FindElement(SiteContentOR.oclicktoeditgallerywebpart).Click();
                Driver.FindElement(By.XPath("//*[text()='Edit Web Part']")).Click();
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Edit Button is Clicked  ", Status.PASS);
                common.CallMeWait(3000);

                //Selecting Six image per grid is clicked
                Driver.FindElement(SiteContentOR.opergridimagesix).Click();
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Twelve image per grid is clicked  ", Status.PASS);
                // click on apply button
                Driver.FindElement(SiteContentOR.ovideowebpartapplybtn_xpath).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Click on Apply button  ", Status.DONE);
                //click on Ok button
                Driver.FindElement(SiteContentOR.ovideowebpartokbtn_xpath).Click();
                common.CallMeWait(4000);
                Report.UpdateTestLog("ConfigureGalleryWebPart", " Click on OK button  ", Status.DONE);
                Report.UpdateTestLog("ConfigureGalleryWebPartFinalStep", " Six image per grid is displayed ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteAddedImageCarousel", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteAddedImageCarousel", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: VerifyMyOfficeLinkAndResources()
        // Method Decs: This method validates the Myoffice in Global Navigation and Resources Link in MegaMenu.
        // Created on:  30th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void VerifyMyOfficeLinkAndResources()
        {
            try
            {
                string topNavigation = DataTable.GetData("General_Data_" + Env, "TopNavigation").Trim();
                string resourcetextdata = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string dynamicXpath = "//*[text()='" + topNavigation + "']";
                string myofficelinktext = Driver.FindElement(By.XPath(dynamicXpath)).Text;
                if (myofficelinktext.Equals(topNavigation))
                {
                    Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", topNavigation + " link is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", topNavigation + " link is Not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Driver.FindElement(By.XPath(SiteContentOR.oresourcelink));
                string resourcetext =
                    Driver.FindElement(SiteContentOR.oresourcetext).Text;
                if (resourcetextdata.Equals(resourcetext))
                {
                    Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", resourcetextdata + " link is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", resourcetextdata + " link is Not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
               // Actions builder = new Actions(Driver);
               // builder.MoveToElement(Driver.FindElement(SiteContentOR.oresourcetext)).Build().Perform();
               // common.CallMeWait(2000);
               // string globalintranettext = Driver.FindElement(By.XPath("//*[@id='mega-menu']/div/div[2]/div[1]/div/a[1]")).Text;

                ReadOnlyCollection<IWebElement> elms =
                      Driver.FindElements(SearchFromLandingPageOR.oserviceLinesTopNav_xpath);
               
                By sublinktext = By.XPath("//*[text()='Global Intranet']");
                Actions action = new Actions(Driver);
                string value = elms[0].Text;
                action.MoveToElement(elms[0]);
                action.Perform();
                common.CallMeWait(2000);
                
                   if (common.CheckElement(HomePageSearchOR.oafterhover_xpath) == true)
                    {
                    Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", "Lay out is appearing after mouse hover on Resources", Status.PASS);
                    if (common.CheckElement(sublinktext) == true)
                       {
                    Report.UpdateTestLog("VerifyMyOfficeLinkAndResourcesStep", " Global Intranet link is present", Status.PASS);
                    }
                    else
                    {
                    Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", " Global Intranet link is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                   else
                   {
                       Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", "Lay out is not appearing after mouse hover on Resources", Status.FAIL);
                       CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                   }               
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyMyOfficeLinkAndResources", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: CreatePageWithAccordionLayout()
        // Method Decs: This method will create a page with video lauout and add video web part 
        // Created on:  30th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void CreatePageWithAccordionLayout()
        {
            try
            {
                int flag = 0;
                string pagename1 = DataTable.GetData("General_Data_" + Env, "PageName");
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string pagename = pagename1 + "_" + ArticleDate;
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.ocreatecbreintrapage_xpath);
                Driver.FindElement(SiteContentOR.ocreatecbreintrapage_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.otitleTextBox_xpath);
                Driver.FindElement(SiteContentOR.otitleTextBox_xpath).SendKeys(pagename);
                common.WaitForElement(SiteContentOR.oaccordionpage_xpath);
                Driver.FindElement(SiteContentOR.oaccordionpage_xpath).Click();
                common.WaitForElement(SiteContentOR.ocreatepage_xpath);
                Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (common.CheckElement((SiteContentOR.ofilelink_xpath)) == true)
                {
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("CreatePageWithAccordionLayoutFinalStep", "Page is cretaed with name :" + pagename,
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreatePageWithAccordionLayout", "Unable to create page" + pagename,
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreatePageWithAccordionLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreatePageWithAccordionLayout", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyAnalyticsDashboard()
        // Method Decs: This method will Analyse the Analytics Dashboard page information
        // Created on:  30th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyAnalyticsDashboard()
        {
            try
            {
                string day_30 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string alltime = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string leastpopularheader = Driver.FindElement(SiteContentOR.oleastViewed).Text.Trim();
                ReadOnlyCollection<IWebElement> elms1 = Driver.FindElements(SiteContentOR.oleastViewedoption);
                string path1 = "//*[@id='leastViewed']/div/div[2]/div";
                DashboardDataAnalyser(day_30, elms1, leastpopularheader, path1);
                DashboardDataAnalyser(alltime, elms1, leastpopularheader, path1);

                string _7days = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string _14days = DataTable.GetData("General_Data_" + Env, "RequestType4");
                string _30days = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string alltime2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string mostpopularheader = Driver.FindElement(SiteContentOR.omostViewed).Text.Trim();
                ReadOnlyCollection<IWebElement> elms2 = Driver.FindElements(SiteContentOR.omostViewedoption);
                string path2 = "//*[@id='mostViewed']/div/div[2]/div";
                DashboardDataAnalyser(_7days, elms2, mostpopularheader, path2);
                DashboardDataAnalyser(_14days, elms2, mostpopularheader, path2);
                DashboardDataAnalyser(_30days, elms2, mostpopularheader, path2);
                DashboardDataAnalyser(alltime2, elms2, mostpopularheader, path2);

                string mostRecentlyModifiedheader = Driver.FindElement(SiteContentOR.omostRecentlyModified).Text.Trim();
                string path3 = "//*[@id='mostRecentlyModified']/div/div[2]/div";
                if (Driver.FindElement(SiteContentOR.omostRecentlyModified).Displayed)
                {

                    Report.UpdateTestLog("VerifyAnalyticsDashboard", mostRecentlyModifiedheader + "section is present", Status.PASS);
                    int c = Driver.FindElements(By.XPath(path3)).Count;
                    if (c > 0)
                    {
                        Report.UpdateTestLog("VerifyAnalyticsDashboard", c + " result present under " + mostRecentlyModifiedheader + " section", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyAnalyticsDashboard", "No result present under " + mostRecentlyModifiedheader + " section", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyAnalyticsDashboard", mostRecentlyModifiedheader + "section is Not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


                string leastRecentlyModifiedrheader = Driver.FindElement(SiteContentOR.oleastRecentlyModified).Text.Trim();
                string path4 = "//*[@id='leastRecentlyModified']/div/div[2]/div";

                if (Driver.FindElement(SiteContentOR.omostRecentlyModified).Displayed)
                {

                    Report.UpdateTestLog("VerifyAnalyticsDashboard", leastRecentlyModifiedrheader + "section is present", Status.PASS);
                    int c = Driver.FindElements(By.XPath(path4)).Count;
                    if (c > 0)
                    {
                        Report.UpdateTestLog("VerifyAnalyticsDashboardFinalStep", c + " result present under " + leastRecentlyModifiedrheader + " section", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyAnalyticsDashboard", "No result present under " + leastRecentlyModifiedrheader + " section", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyAnalyticsDashboard", leastRecentlyModifiedrheader + "section is Not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyAnalyticsDashboard", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyAnalyticsDashboard", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: DashboardDataAnalyser()
        // Method Decs: This method is called by VerifyAnalyticsDashboard 
        // Created on:  30th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void DashboardDataAnalyser(string days, ReadOnlyCollection<IWebElement> elms, string section, string path)
        {
            try
            {

                if (elms.Count > 0)
                {

                    for (int i = 0; i < elms.Count; i++)
                    {
                        IWebElement webelm = elms[i];
                        string value = elms[i].GetAttribute("innerText").Trim();
                        if (value.Equals(days))
                        {
                            elms[i].Click();
                            ReadOnlyCollection<IWebElement> elms2 = Driver.FindElements(By.XPath(path));
                            if (elms2.Count > 0)
                            {
                                Report.UpdateTestLog("DashboardDataAnalyserFinalStep", "System disaplay " + elms2.Count + " data under " + section + " in  " + value, Status.PASS);
                            }
                            else
                            {
                                Report.UpdateTestLog("DashboardDataAnalyser", "No data present under " + section + " in  " + value, Status.FAIL);
                                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }

                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("DashboardDataAnalyser", " No Days option is present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DashboardDataAnalyser", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DashboardDataAnalyser", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: CreatePageWithAccordionLayout()
        // Method Decs: This method will create a page with video lauout and add video web part 
        // Created on:  30th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void CreatePageWith3ColumnSecondaryLayout()
        {
            try
            {
                int flag = 0;
                string pagename1 = DataTable.GetData("General_Data_" + Env, "PageName");
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string pagename = pagename1 + "_" + ArticleDate;
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.ocreatecbreintrapage_xpath);
                Driver.FindElement(SiteContentOR.ocreatecbreintrapage_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.otitleTextBox_xpath);
                Driver.FindElement(SiteContentOR.otitleTextBox_xpath).SendKeys(pagename);
                common.WaitForElement(SiteContentOR.o3coloumn_xpath);
                Driver.FindElement(SiteContentOR.o3coloumn_xpath).Click();
                common.WaitForElement(SiteContentOR.ocreatepage_xpath);
                Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (common.CheckElement((SiteContentOR.ofilelink_xpath)) == true)
                {
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("CreatePageWith3ColumnSecondaryLayoutFinalStep", pagename + "  Page is cretaed",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreatePageWith3ColumnSecondaryLayout", "Unable to create page" + pagename,
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreatePageWith3ColumnSecondaryLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreatePageWith3ColumnSecondaryLayout", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeletePeople()
        // Method Decs: This method will Delete people from People List
        // Created on:  31th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void DeletePeople()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                int i = 1;
                int flags = 0;
                string dynamicPath = "//*[@class='ms-listviewtable']/tbody/tr[1]/td[2] ";
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[2]")).GetAttribute("innerText");
                    if (name.Contains(req1))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.oitemsheader_xpath);
                    IWebElement elm = Driver.FindElement(SiteContentOR.oitemsheader_xpath);
                    elm.Click();
                    //Driver.FindElement(SiteContentOR.oitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.odeleteitemsheader_xpath);
                    Driver.FindElement(SiteContentOR.odeleteitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    Driver.SwitchTo().DefaultContent();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeletePeopleFinalStep", " name '" + req1 + "' found and deleted", Status.PASS);
                    IWebElement header = Driver.FindElement(SiteContentOR.oheaderbrowse_xpath);
                    header.Click();
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("DeletePeople", " name '" + req1 + "' not found", Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeletePeople", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeletePeople", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: AddPeopleInPeopleList()
        // Method Decs: This method will add people in People List
        // Created on:  31th Jan 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void AddPeopleInPeopleList()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                common.WaitForElement(SiteContentOR.oaddnewpeopleplusbtn_xpath);
                if (Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Click();
                    Report.UpdateTestLog("AddPeopleInPeopleList", "clicked to add new item button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddPeopleInPeopleList", "new item button is not displayed", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (Driver.FindElement(By.XPath("//*[@class='sp-peoplepicker-topLevel']")).Displayed)
                {
                   // Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Click();
                    Driver.FindElement(By.XPath("//*[@class='sp-peoplepicker-topLevel']")).Click();
                    Driver.FindElement(By.XPath("//*[@title='Person']/input[2]")).SendKeys(req1);
                    Report.UpdateTestLog("AddPeopleInPeopleList", "name is entered as :" + req1, Status.PASS);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("AddPeopleInPeopleList", "Unable to enter name", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (Driver.FindElement((By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]"))).Displayed)
                {
                    Driver.FindElement((By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]"))).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("AddPeopleInPeopleListFinalStep", "clicked to save button", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("AddPeopleInPeopleList", "Unable to click save button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }              
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddPeopleInPeopleList", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddPeopleInPeopleList", " Problem in AddPeopleInPeopleList Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyEditQuicklinks()
        // Method Decs: This method will edit a quick link in site content and verify it 
        // Created on: 1st Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyEditQuicklinks()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                //string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                IWebElement reqStrng = Driver.FindElement(By.XPath("//td[5]"));
                string subStrng = reqStrng.Text;
                string req2 = subStrng.Split(';')[0];

                int flag = 0;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@summary='Quick Links']/tbody/tr/td[2]"));

                if (elms.Count > 0)
                {
                    for (int i = 0; i < elms.Count; i++)
                    {
                        IWebElement elm = elms[i];
                        string elementtext = elm.Text.Trim();
                        if (elementtext.Equals(req1))
                        {
                            elm.Click();
                            Report.UpdateTestLog("VerifyEditQuicklinks", req1 + " is selected  ", Status.PASS);
                            flag = 1;
                            break;
                        }

                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyEditQuicklinks", " No link is present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    common.WaitForElement(By.XPath("//*[@id='Hero-WPQ2']/tbody/tr/td/a[2]"));
                    if (Driver.FindElement(By.XPath("//*[@id='Hero-WPQ2']/tbody/tr/td/a[2]")).Displayed)
                    {
                        Driver.FindElement(By.XPath("//*[@id='Hero-WPQ2']/tbody/tr/td/a[2]")).Click();
                        Report.UpdateTestLog("VerifyEditQuicklinks", " Edit link is clicked", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEditQuicklinks", " Unable to click Edit link", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                    ReadOnlyCollection<IWebElement> elms2 =
                        Driver.FindElements(By.XPath("//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr"));
                    //*[@id="spgridcontainer_WPQ2_leftpane_mainTable"]/tbody/tr[6]/td[2]/span

                    for (int i = 2; i < elms2.Count; i++)
                    {
                        string dynamicpath1 = "//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr[" + i +
                                              "]/td[2]/span";
                        //ReadOnlyCollection<IWebElement> elms3 = Driver.FindElements(By.XPath(dynamicpath1));
                        if (Driver.FindElement(By.XPath(dynamicpath1)).Text.Trim().Equals(req1))
                        {

                            IWebElement elm4 =
                                Driver.FindElement(
                                    By.XPath("//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr[" + i +
                                             "]/td[5]"));

                            if (elm4.Displayed)
                            {
                                elm4.Click();
                                elm4.Click();
                                /*Driver.FindElement(
                                     By.XPath(
                                         "//*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']"))
                                     .Clear();*/
                                Driver.FindElement(
                                    By.XPath(
                                        "//*[@id='jsgrid_taxonomygridcontrol_$containereditableRegion']"))
                                    .Clear();

                                /*   Driver.FindElement(
                                       By.XPath(
                                           "//*[@id ='jsgrid_taxonomygridcontrol_$containereditableRegion']"))
                                       .SendKeys(req2);*/

                                common.CallMeWait(3500);

                                Driver.FindElement(
                                    By.XPath(
                                        "//*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']"))
                                    .SendKeys(req2);
                            }
                            IWebElement elm6 = Driver.FindElement(By.XPath("//*[@class='suggestion-match-text']"));
                            string suggestStrg = elm6.Text;
                            Assert.AreEqual(suggestStrg, req2);

                            if (elm6.Displayed)
                            {
                                Report.UpdateTestLog("VerifyEditQuicklinks", "Internet category suggestions validated",
                                    Status.PASS);
                            }
                            else
                            {
                                Report.UpdateTestLog("VerifyEditQuicklinks", "Suggestion not found", Status.FAIL);
                                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                            if (Driver.FindElement(By.XPath("//*[text()='Stop']")).Displayed)
                            {
                                Driver.FindElement(By.XPath("//*[text()='Stop']")).Click();
                                Report.UpdateTestLog("VerifyEditQuicklinksFinalStep", " Stopped editing", Status.PASS);
                            }
                            else
                            {
                                Report.UpdateTestLog("VerifyEditQuicklinks", " Unable to Stop editing", Status.FAIL);
                                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }

                        }

                    }
                    //*[text()='Quick Links - No Category']/parent::*/table/tbody/tr[2]/td[2]/a
                  


                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyEditQuicklinks", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyEditQuicklinks", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyPageLayout()
        // Method Decs: This method will validate different type of layout lay out of page
        // Created on:  1st Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyPageLayout()
        {
            try
            {

                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.ocreatecbreintrapage_xpath);
                Driver.FindElement(SiteContentOR.ocreatecbreintrapage_xpath).Click();
                common.CallMeWait(2000);
                common.WaitForElement(SiteContentOR.o3coloumn_xpath);
                if (Driver.FindElement(SiteContentOR.o3coloumn_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.o3coloumn_xpath).Click();
                    Report.UpdateTestLog("VerifyPageLayout", "PageLayouts with 3 Column option  is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageLayout", "PageLayouts with 3 Column option  is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.WaitForElement(SiteContentOR.o2coloumn_xpath);
                if (Driver.FindElement(SiteContentOR.o2coloumn_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.o2coloumn_xpath).Click();
                    Report.UpdateTestLog("VerifyPageLayout", "PageLayouts with 2 Column option  is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageLayout", "PageLayouts with 2 Column option  is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.WaitForElement(SiteContentOR.olandingpage_xpath);
                if (Driver.FindElement(SiteContentOR.olandingpage_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.olandingpage_xpath).Click();
                    Report.UpdateTestLog("VerifyPageLayoutFinalStep", "PageLayouts with landing page option is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageLayout", "PageLayouts with landing page option  is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPageLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPageLayout", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: AdjustTimeFrameforMostviewedandLeastviewed()
        // Method Decs: This method willadjust time frame for most viewed and least viewed
        // Created on:  2nd Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void AdjustTimeFrameforMostviewedandLeastviewed()
        {
            try
            {
                string day_30 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string alltime = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string leastpopularheader = Driver.FindElement(SiteContentOR.oleastViewed).Text.Trim();
                ReadOnlyCollection<IWebElement> elms1 = Driver.FindElements(SiteContentOR.oleastViewedoption);
                string path1 = "//*[@id='leastViewed']/div/div[2]/div";
                DashboardDataAnalyser(day_30, elms1, leastpopularheader, path1);
                DashboardDataAnalyser(alltime, elms1, leastpopularheader, path1);

                string _7days = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string _14days = DataTable.GetData("General_Data_" + Env, "RequestType4");
                string _30days = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string alltime2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string mostpopularheader = Driver.FindElement(SiteContentOR.omostViewed).Text.Trim();
                ReadOnlyCollection<IWebElement> elms2 = Driver.FindElements(SiteContentOR.omostViewedoption);
                string path2 = "//*[@id='mostViewed']/div/div[2]/div";
                DashboardDataAnalyser(_7days, elms2, mostpopularheader, path2);
                DashboardDataAnalyser(_14days, elms2, mostpopularheader, path2);
                DashboardDataAnalyser(_30days, elms2, mostpopularheader, path2);
                DashboardDataAnalyser(alltime2, elms2, mostpopularheader, path2);
                Report.UpdateTestLog("AdjustTimeFrameforMostviewedandLeastviewedFinalStep", " Successfully validated the date refiners", Status.PASS);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AdjustTimeFrameforMostviewedandLeastviewed", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AdjustTimeFrameforMostviewedandLeastviewed", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }  
    
     
        //******************************************************
        // Method Name: NavigatetoPageLibrary()
        // Method Decs: This method nanigates to Page Library Under Site Content
        // Created on:  3nd Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void NavigatetoPageLibrary()
        {
            try
            {
                int flag = 0;
                common.WaitForElement(SiteContentOR.ocbrehome_id);
                if (Driver.FindElement((SiteContentOR.ocbrehome_id)).Displayed)
                {
                    Driver.FindElement((SiteContentOR.ocbrehome_id)).Click();
                    common.CallMeWait(4000);
                    Driver.FindElement(By.XPath("//*[text()='Admin']")).Click();
                    common.CallMeWait(1000);
                    Driver.FindElement(By.XPath("//*[text()='Site contents']")).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("NavigatetoPageLibrary", " navigated to site Content  ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("NavigatetoPageLibrary", " Unable to navigate tosite Content", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                for (int i = 2; i <= elms.Count; i++)
                {
                    string innerValue =
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text;

                    if (innerValue.Contains("Pages"))
                    {
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[1]")).Click();
                        flag = 1;
                        common.CallMeWait(5000);
                        break;
                    }
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("NavigatetoPageLibrary", " Not able to find Pages : ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("NavigatetoPageLibraryFinalStep", " Clicked on Item  Pages  ", Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigatetoPageLibrary", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigatetoPageLibrary", " Problem in NavigatetoPageLibrary Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreatePageWith2ColumnSecondaryLayout()
        // Method Decs: This method will create a page with 2 Column Lay Out 
        // Created on:  3rd Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void CreatePageWith2ColumnSecondaryLayout()
        {
            try
            {
                int flag = 0;
                string pagename1 = DataTable.GetData("General_Data_" + Env, "PageName");
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string pagename = pagename1 + "_" + ArticleDate;
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.ocreatecbreintrapage_xpath);
                Driver.FindElement(SiteContentOR.ocreatecbreintrapage_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.otitleTextBox_xpath);
                Driver.FindElement(SiteContentOR.otitleTextBox_xpath).SendKeys(pagename);
                common.WaitForElement(SiteContentOR.o2coloumn_xpath);
                Driver.FindElement(SiteContentOR.o2coloumn_xpath).Click();
                common.WaitForElement(SiteContentOR.ocreatepage_xpath);
                Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (common.CheckElement((SiteContentOR.ofilelink_xpath)) == true)
                {
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("CreatePageWith2ColumnSecondaryLayoutFinalStep", "Page is cretaed with name :" + pagename,
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreatePageWith2ColumnSecondaryLayout", "Unable to create page" + pagename,
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreatePageWith2ColumnSecondaryLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreatePageWith2ColumnSecondaryLayout", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: AddwebPartinPage()
        // Method Decs: This method add web part in page
        // Created on:  3rd Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void AddwebPartinPage()
        {
            string webPartCategories = DataTable.GetData("General_Data_" + Env, "WebPartCategories");
            string webParts = DataTable.GetData("General_Data_" + Env, "WebParts");
            string videoSource = DataTable.GetData("AddWebPartInfo", "VideoSource");
            string CheckVideoStatus = DataTable.GetData("AddWebPartInfo", "CheckVideoStatus");
            try
            {
                IJavaScriptExecutor js = Driver as IJavaScriptExecutor;

                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("AddwebPartinPage", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(5000);
                IWebElement addwebpart = Driver.FindElement(By.XPath("//*[@id='MSOZone']/div[1]"));
                js.ExecuteScript("CoreInvoke('ShowWebPartAdder', 'MainZone');");

                Report.UpdateTestLog("AddwebPartinPage", " Click on Add a Web Part element  ", Status.PASS);
                ClickOnWebpartCategory(webPartCategories);
                ClickOnWebPart(webParts);

                IWebElement addBtn = Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath);

                addBtn.Click();

                //js.ExecuteScript("arguments[0].style.border='2px groove green'", addBtn);
                //Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath).Click();
                Report.UpdateTestLog("AddwebPartinPage", " Click on Add button  ", Status.PASS);
                Driver.FindElement(SiteContentOR.oaddwebpartwebelementsavebtn_xpath).Click();
                common.CallMeWait(5000);
                Report.UpdateTestLog("AddwebPartinPageFinalStep", " Click on Save button  ", Status.PASS);
                common.CallMeWait(5000);
                if (videoSource.Count() > 0)
                {
                    AddYouTubeInfo();
                }

                //Verification
               /* int count = Driver.FindElements(SiteContentOR.owebpartcountwebelemets_xpath).Count;
                if (Driver.FindElements(SiteContentOR.owebpartcountwebelemets_xpath).Count >= 1)
                {
                    Report.UpdateTestLog("AddwebPartin2Column", " Number of web part: " + count + " Available in the page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddwebPartin2Column", " Number of web part: " + count + " Available in the page but expected is 1 ", Status.FAIL);
                }
                if (CheckVideoStatus.Count() > 0)
                {
                    CheckVideoPlayStatus();
                } */
                
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddwebPartinPage", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddwebPartinPage", " There is a problem in  Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }


        }


        //******************************************************
        // Method Name: AddSecondwebPartinPage()
        // Method Decs: This method will add web part in 2 Column layout page
        // Created on:  3rd Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void AddSecondwebPartinPage()
        {
            string webPartCategories = DataTable.GetData("General_Data_" + Env, "WebPartCategories");
            string webParts = DataTable.GetData("General_Data_" + Env, "WebParts");
            string videoSource = DataTable.GetData("AddWebPartInfo", "VideoSource");
            string CheckVideoStatus = DataTable.GetData("AddWebPartInfo", "CheckVideoStatus");
            try
            {
                IJavaScriptExecutor js = Driver as IJavaScriptExecutor;

                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("AddSecondwebPartinPage", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(5000);
                IWebElement addwebpart = Driver.FindElement(By.XPath("//*[@id='MSOZone']/div[1]"));
                js.ExecuteScript("CoreInvoke('ShowWebPartAdder', 'MainZone');");

                Report.UpdateTestLog("AddSecondwebPartinPage", " Click on Add a Web Part element  ", Status.PASS);
                ClickOnWebpartCategory(webPartCategories);
                ClickOnWebPart(webParts);

                IWebElement addBtn = Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath);

                addBtn.Click();

                //js.ExecuteScript("arguments[0].style.border='2px groove green'", addBtn);
                //Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath).Click();
                Report.UpdateTestLog("AddSecondwebPartinPage", " Click on Add button  ", Status.PASS);
                Driver.FindElement(SiteContentOR.oaddwebpartwebelementsavebtn_xpath).Click();
                common.CallMeWait(5000);
                Report.UpdateTestLog("AAddSecondwebPartinPageFinalStep", " Click on Save button  ", Status.PASS);
                common.CallMeWait(5000);
                if (videoSource.Count() > 0)
                {
                    AddYouTubeInfo();
                }

                //Verification
                /* int count = Driver.FindElements(SiteContentOR.owebpartcountwebelemets_xpath).Count;
                 if (Driver.FindElements(SiteContentOR.owebpartcountwebelemets_xpath).Count >= 1)
                 {
                     Report.UpdateTestLog("AddwebPartin2Column", " Number of web part: " + count + " Available in the page", Status.PASS);
                 }
                 else
                 {
                     Report.UpdateTestLog("AddwebPartin2Column", " Number of web part: " + count + " Available in the page but expected is 1 ", Status.FAIL);
                 }
                 if (CheckVideoStatus.Count() > 0)
                 {
                     CheckVideoPlayStatus();
                 } */

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddSecondwebPartinPage", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddSecondwebPartinPage", " There is a problem in  Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }


        }

        //******************************************************
        // Method Name: CreateACustomLink()
        // Method Decs: This method creata a custion link after filling all required detial on the custom link form
        // Created on:  6th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void CreateACustomLink()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                common.WaitForElement(SiteContentOR.onewitemlink_xpath);
                common.CallMeWait(2000);
                if (Driver.FindElement(SiteContentOR.onewitemlink_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.onewitemlink_xpath).Click();
                    Report.UpdateTestLog("CreateACustomLink", "clicked on New Item link", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateACustomLink", "unable to click on new item link", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.otitle_xpath);
                Driver.FindElement(SiteContentOR.otitle_xpath).Clear();
                Driver.FindElement(SiteContentOR.otitle_xpath).SendKeys(req1);
                Report.UpdateTestLog("CreateACustomLink", "tittle is entered as :" + req1, Status.PASS);

                common.WaitForElement(SiteContentOR.ourl_xpath);
                Driver.FindElement(SiteContentOR.ourl_xpath).Clear();
                Driver.FindElement(SiteContentOR.ourl_xpath).SendKeys(req2);
                Report.UpdateTestLog("CreateACustomLink", "Link is entered as :" + req2, Status.PASS);

                common.WaitForElement(SiteContentOR.oIntOrgCategory_xpath);
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).Clear();
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).SendKeys(req3);
                Report.UpdateTestLog("CreateACustomLink", "Intranet :" + req3, Status.PASS);

                common.WaitForElement(SiteContentOR.oribbonsaveoption_xpath);
                if (Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Click();
                    Report.UpdateTestLog("CreateACustomLinkFinalStep", "clicked on save" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateACustomLink", "Unable to click save data" + req3, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.CallMeWait(2000);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateACustomLink", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateACustomLink", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeleteCustomLink()
        // Method Decs: This method delete selected custom link
        // Created on:  6th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void DeleteCustomLink()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                int i = 1;
                int flags = 0;
                string dynamicPath = "//*[@class='ms-listviewtable']/tbody/tr[1]/td[2] ";
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[2]")).GetAttribute("innerText");
                    if (name.Contains(req1))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.oitemsheader_xpath);
                    IWebElement elm = Driver.FindElement(SiteContentOR.oitemsheader_xpath);
                    elm.Click();
                    //Driver.FindElement(SiteContentOR.oitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.odeleteitemsheader_xpath);
                    Driver.FindElement(SiteContentOR.odeleteitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    Driver.SwitchTo().DefaultContent();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeleteCustomLinkFinalStep", " link " + req1 + "' found and deleted", Status.PASS);
                    IWebElement header = Driver.FindElement(SiteContentOR.oheaderbrowse_xpath);
                    header.Click();
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("DeleteCustomLink", " name '" + req1 + "' not found", Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteCustomLink", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteCustomLink", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: VerifyEditCustomlinks()
        // Method Decs: This method edits a Custom link in site content and verify it 
        // Created on: 6th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyEditCustomlinks()
        {
            try
            {
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string req4 = DataTable.GetData("General_Data_" + Env, "RequestType4");
                int Flag = 0;
                common.WaitForElement(SiteContentOR.oeditlink_xpath);
                if (Driver.FindElement(SiteContentOR.oeditlink_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oeditlink_xpath).Click();
                    Report.UpdateTestLog("VerifyEditCustomlinks", "edit button is clicked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyEditCustomlinks", "Unable to clicked edit button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                ReadOnlyCollection<IWebElement> intranetelm = Driver.FindElements(By.XPath("//td[5]"));

                for (int i = 0; i < intranetelm.Count; i++)
                {
                    string str = intranetelm[i].GetAttribute("innerText").Trim();
                    if (str.Contains(req3))
                    {
                        intranetelm[i].Click();
                        intranetelm[i].Click();
                        //*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']
                        Driver.FindElement(By.XPath("//*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']")).Clear();
                        Driver.FindElement(By.XPath("//*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']")).SendKeys(req4);
                        Report.UpdateTestLog("VerifyEditCustomlinks", "text is clreared and reentered as: " + req4,
                       Status.PASS);
                        Flag = 1;
                        break;
                    }
                }
                if (Flag == 1)
                {
                    IWebElement elm6 = Driver.FindElement(By.XPath("//*[@class='suggestion-match-text']"));
                    string suggestStrg = elm6.Text;
                    //  Assert.AreEqual(suggestStrg, req4);

                    if (suggestStrg.Contains(req4))
                    {
                        Report.UpdateTestLog("VerifyEditCustomlinks", "Internet category suggestions validated",
                            Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEditCustomlinks", "Suggestion not found", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyEditCustomlinks", "unable to find edit intrant link", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.WaitForElement(SiteContentOR.ostopedit_xpath);
                if (Driver.FindElement(SiteContentOR.ostopedit_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.ostopedit_xpath).Click();
                    Report.UpdateTestLog("VerifyEditQuicklinksFinalStep", " Stopped editing", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyEditQuicklinks", " Unable to Stop editing", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyEditCustomlinks", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyEditCustomlinks", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: FindItem()
        // Method Decs: This method will find items under Site Contet Library Custom link in site content and click on it 
        // Created on: 6th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void FindItem()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                int i = 1;
                int flags = 0;
                string dynamicPath = "//*[@class='ms-listviewtable']/tbody/tr[1]/td[2] ";
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[2]")).GetAttribute("innerText");
                    if (name.Contains(req1))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("FindItemFinalStep", " Clicked on Element ", Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("FindItem", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindItem", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreatePeopleIntranetCategory()
        // Method Decs: This method will add people in People List
        // Created on:  6th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void CreatePeopleIntranetCategory()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                common.WaitForElement(SiteContentOR.oaddnewpeopleplusbtn_xpath);
                if (Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Click();
                    Report.UpdateTestLog("CreatePeopleIntranetCategory", "clicked to add new item button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreatePeopleIntranetCategory", "new item button is not displayed", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (Driver.FindElement(By.XPath("//*[@class='sp-peoplepicker-topLevel']")).Displayed)
                {
                    // Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Click();
                    Driver.FindElement(By.XPath("//*[@class='sp-peoplepicker-topLevel']")).Click();
                    Driver.FindElement(By.XPath("//*[@title='Person']/input[2]")).SendKeys(req1);
                    Report.UpdateTestLog("CreatePeopleIntranetCategory", "name is entered as :" + req1, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreatePeopleIntranetCategory", "Unable to enter name", Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.oIntOrgCategory_xpath);
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).Clear();
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).SendKeys(req3);
                Report.UpdateTestLog("CreateACustomLink", "Intranet :" + req3, Status.PASS);

                if (Driver.FindElement((By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]"))).Displayed)
                {
                    Driver.FindElement((By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]"))).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("CreatePeopleIntranetCategoryFinalStep", "clicked to save button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreatePeopleIntranetCategory", "Unable to click save button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreatePeopleIntranetCategory", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreatePeopleIntranetCategory", " Problem in AddPeopleInPeopleList Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyPeopleIntranetCategory()
        // Method Decs: This method will Verify  Intranet category for people list 
        // Created on: 6th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyPeopleIntranetCategory()
        {
            try
            {
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string req4 = DataTable.GetData("General_Data_" + Env, "RequestType4");
                int Flag = 0;
                common.WaitForElement(SiteContentOR.oeditlink_xpath);
                if (Driver.FindElement(SiteContentOR.oeditlink_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oeditlink_xpath).Click();
                    Report.UpdateTestLog("VerifyPeopleIntranetCategory", "edit button is clicked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPeopleIntranetCategory", "Unable to clicked edit button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                ReadOnlyCollection<IWebElement> intranetelm = Driver.FindElements(By.XPath("//td[3]"));

                for (int i = 0; i < intranetelm.Count; i++)
                {
                    string str = intranetelm[i].GetAttribute("innerText").Trim();
                    if (str.Contains(req3))
                    {
                        intranetelm[i].Click();
                        intranetelm[i].Click();
                        //*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']
                        Driver.FindElement(By.XPath("//*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']")).Clear();
                        Driver.FindElement(By.XPath("//*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']")).SendKeys(req4);
                        Report.UpdateTestLog("VerifyPeopleIntranetCategory", "text is clreared and rentered as: " + req4,
                       Status.PASS);
                        Flag = 1;
                        break;
                    }
                }
                if (Flag == 1)
                {
                    IWebElement elm6 = Driver.FindElement(By.XPath("//*[@class='suggestion-match-text']"));
                    string suggestStrg = elm6.Text;
                    //  Assert.AreEqual(suggestStrg, req4);

                    if (suggestStrg.Contains(req4))
                    {
                        Report.UpdateTestLog("VerifyPeopleIntranetCategory", "Internet category suggestions validated",
                            Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyPeopleIntranetCategory", "Suggestion not found", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyPeopleIntranetCategory", "unable to find edit intrant link", Status.FAIL);

                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.WaitForElement(SiteContentOR.ostopedit_xpath);
                if (Driver.FindElement(SiteContentOR.ostopedit_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.ostopedit_xpath).Click();
                    Report.UpdateTestLog("VerifyPeopleIntranetCategoryFinalStep", " Stopped editing", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPeopleIntranetCategory", " Unable to Stop editing", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPeopleIntranetCategory", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPeopleIntranetCategory", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeleteQuickLink()
        // Method Decs: This method will Delete QuickLink from QuickLink List
        // Created on:  7th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void DeleteQuickLink()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                int i = 1;
                int flags = 0;
                string dynamicPath = "//*[@class='ms-listviewtable']/tbody/tr[1]/td[2] ";
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[2]")).GetAttribute("innerText");
                    if (name.Contains(req1))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.oitemsheader_xpath);
                    IWebElement elm = Driver.FindElement(SiteContentOR.oitemsheader_xpath);
                    elm.Click();
                    //Driver.FindElement(SiteContentOR.oitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.odeleteitemsheader_xpath);
                    Driver.FindElement(SiteContentOR.odeleteitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    Driver.SwitchTo().DefaultContent();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeleteQuickLinkFinalStep", " link " + req1 + "' found and deleted", Status.PASS);
                    IWebElement header = Driver.FindElement(SiteContentOR.oheaderbrowse_xpath);
                    header.Click();
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("DeleteQuickLink", " name '" + req1 + "' not found", Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteQuickLink", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteQuickLink", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreateQuicklinkIntranetCategory()
        // Method Decs: This method will create a quick link in Quick link Library inder Site Content
        // Created on:  7th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void CreateQuicklinkIntranetCategory()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                common.WaitForElement(SiteContentOR.onewitemlink_xpath);
                common.CallMeWait(2000);
                if (Driver.FindElement(SiteContentOR.onewitemlink_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.onewitemlink_xpath).Click();
                    Report.UpdateTestLog("CreateQuicklinkIntranetCategory", "clicked on New Item link", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateQuicklinkIntranetCategory", "unable to click on new item link", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.otitle_xpath);
                Driver.FindElement(SiteContentOR.otitle_xpath).Clear();
                Driver.FindElement(SiteContentOR.otitle_xpath).SendKeys(req1);
                Report.UpdateTestLog("CreateQuicklinkIntranetCategory", "tittle is entered as :" + req1, Status.PASS);

                common.WaitForElement(SiteContentOR.opicture_xpath);
                Driver.FindElement(SiteContentOR.opicture_xpath).Clear();
                Driver.FindElement(SiteContentOR.opicture_xpath).SendKeys(req2);
                Report.UpdateTestLog("CreateQuicklinkIntranetCategory", "Picture Link is entered as :" + req2, Status.PASS);

                common.WaitForElement(SiteContentOR.ourl_xpath);
                Driver.FindElement(SiteContentOR.ourl_xpath).Clear();
                Driver.FindElement(SiteContentOR.ourl_xpath).SendKeys(req2);
                Report.UpdateTestLog("CreateQuicklinkIntranetCategory", "Url Link is entered as :" + req2, Status.PASS);

                common.WaitForElement(SiteContentOR.oIntOrgCategory_xpath);
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).Clear();
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).SendKeys(req3);
                Report.UpdateTestLog("CreateQuicklinkIntranetCategory", "Intranet :" + req3, Status.PASS);

                common.WaitForElement(SiteContentOR.oribbonsaveoption_xpath);
                if (Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Click();
                    Report.UpdateTestLog("CreateQuicklinkIntranetCategoryFinalStep", "clicked on save" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateQuicklinkIntranetCategory", "Unable to click save data" + req3, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.CallMeWait(2000);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateQuicklinkIntranetCategory", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateQuicklinkIntranetCategory", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyQuicklinkIntranetCategory()
        // Method Decs: This method will edit a Quick link Intranet Category and verify it 
        // Created on: 7th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyQuicklinkIntranetCategory()
        {
            try
            {
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string req4 = DataTable.GetData("General_Data_" + Env, "RequestType4");
                int Flag = 0;
                common.WaitForElement(SiteContentOR.oeditlink_xpath);
                if (Driver.FindElement(SiteContentOR.oeditlink_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oeditlink_xpath).Click();
                    Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", "edit button is clicked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", "Unable to clicked edit button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                ReadOnlyCollection<IWebElement> intranetelm = Driver.FindElements(By.XPath("//td[5]"));

                for (int i = 0; i < intranetelm.Count; i++)
                {
                    string str = intranetelm[i].GetAttribute("innerText").Trim();
                    if (str.Contains(req3))
                    {
                        intranetelm[i].Click();
                        intranetelm[i].Click();
                        //*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']
                        Driver.FindElement(By.XPath("//*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']")).Clear();
                        common.CallMeWait(2000);
                        Driver.FindElement(By.XPath("//*[@class='ms-rtestate-write ms-taxonomy-writeableregion ms-inputBox ms-inputBoxActive']")).SendKeys(req4);
                        Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", "text is clreared and reentered as: " + req4,
                       Status.PASS);
                        common.CallMeWait(2000);
                        Flag = 1;
                        break;
                    }
                }
                if (Flag == 1)
                {
                    IWebElement elm6 = Driver.FindElement(By.XPath("//*[@class='suggestion-match-text']"));
                    string suggestStrg = elm6.Text;
                    //  Assert.AreEqual(suggestStrg, req4);

                    if (suggestStrg.Contains(req4))
                    {
                        Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", "Internet category suggestions validated",
                            Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", "Suggestion not found", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", "unable to find edit intrant link", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.WaitForElement(SiteContentOR.ostopedit_xpath);
                if (Driver.FindElement(SiteContentOR.ostopedit_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.ostopedit_xpath).Click();
                    Report.UpdateTestLog("VerifyQuicklinkIntranetCategoryFinalStep", " Stopped editing", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", " Unable to Stop editing", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyMyOfficePage()
        // Method Decs: This method verify the My Office page
        // Created on: 8th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyMyOfficePage()
        {
            string myofficeurl = DataTable.GetData("General_Data_" + Env, "RequestType1");
            string newurl = Driver.Url.Trim();
            if (myofficeurl.Equals(newurl))
            {
                Report.UpdateTestLog("VerifyQuicklinkIntranetCategoryFinalStep", "Successfuly Navigated to My Office page", Status.PASS);
            }
            else
            {
                Report.UpdateTestLog("VerifyQuicklinkIntranetCategory", "Unable to  Navigat on My Office page", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: CreateLandingPage()
        // Method Decs: This method will create a page with LandingPage lauout 
        // Created on:  8th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void CreateLandingPage()
        {
            try
            {
                int flag = 0;
                string pagename1 = DataTable.GetData("General_Data_" + Env, "PageName");
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string pagename = pagename1 + "_" + ArticleDate;
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                Report.UpdateTestLog("CreateLandingPage", "Clicked on File option", Status.DONE);
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                Report.UpdateTestLog("CreateLandingPage", "Clicked on Document option", Status.DONE);
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.ocreatecbreintrapage_xpath);
                Driver.FindElement(SiteContentOR.ocreatecbreintrapage_xpath).Click();
                Report.UpdateTestLog("CreateLandingPage", "Create CBRE Intranet option is selected", Status.DONE);
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.otitleTextBox_xpath);
                Driver.FindElement(SiteContentOR.otitleTextBox_xpath).SendKeys(pagename);
                Report.UpdateTestLog("CreateLandingPage", "page title is " + pagename, Status.PASS);
                common.WaitForElement(SiteContentOR.olandingpage_xpath);
                Driver.FindElement(SiteContentOR.olandingpage_xpath).Click();
                Report.UpdateTestLog("CreateLandingPage", "Page type Selected", Status.PASS);
                common.WaitForElement(SiteContentOR.ocreatepage_xpath);
                Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                Report.UpdateTestLog("CreateLandingPage", "Clicked on Create option", Status.PASS);
                if (common.CheckElement((SiteContentOR.ofilelink_xpath)) == true)
                {
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("CreateLandingPageFinalStep", pagename + "  Page is cretaed",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateLandingPage", "Unable to create page" + pagename,
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateLandingPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateLandingPage", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: clickOnSiteContentsItemAsSiteOwner()
        // Method Decs: This method will click on Site Contents item as site owner
        // Created on:  8th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void clickOnSiteContentsItemAsSiteOwner()
        {
            int flag = 0;
            string pagecontentvalue = DataTable.GetData("General_Data_" + Env, "Pagecontentvalue");
            try
            {
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                for (int i = 3; i <= elms.Count; i++)
                {
                    string innerValue =
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text;

                    if (innerValue.Contains(pagecontentvalue))
                    {
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[1]")).Click();
                        flag = 1;
                        common.CallMeWait(5000);
                        break;
                    }
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("clickOnSiteContentsItemAsSiteOwner", " Not able to find Pages : ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("clickOnSiteContentsItemAsSiteOwnerFinalStep", " Clicked on Item  Pages : " + pagecontentvalue, Status.PASS);
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("clickOnSiteContentsItemAsSiteOwner", " Error on ClickOnSiteContentsItem method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: ChangePageLayOut()
        // Method Decs: This method change the layout og page
        // Created on:  8th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void ChangePageLayOut()
        {

            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                common.CallMeWait(1000);
                string layoutname = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                common.WaitForElement(SiteContentOR.opagelayout_xpath);
                if (Driver.FindElement(SiteContentOR.opagelayout_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.opagelayout_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ChangePageLayOut", "Clicked on Layout option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ChangePageLayOut", " Unable to click on Layout option", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                string dynamicpath = "//*[text()='" + layoutname + "']";
                common.WaitForElement(By.XPath(dynamicpath));
                if (Driver.FindElement(By.XPath(dynamicpath)).Displayed)
                {
                    Driver.FindElement(By.XPath(dynamicpath)).Click();
                    common.CallMeWait(3000);
                    Report.UpdateTestLog("ChangePageLayOut", "Lay Out Changed to " + layoutname, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ChangePageLayOut", " Unable to change Layout ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.osave_xpath);
                if (Driver.FindElement(SiteContentOR.osave_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.osave_xpath).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("ChangePageLayOutFinalStep", "Click on save option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ChangePageLayOut", " Unable to click on save option ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }



            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ChangePageLayOut", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ChangePageLayOut", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyAccordionTabVideoLayOut()
        // Method Decs: This method verify the lay out type 
        // Created on:  9th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifyAccordionTabVideoLayOut()
        {

            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                common.CallMeWait(1000);
                string layout1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string layout2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string layout3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string dynamicpath1, dynamicpath2, dynamicpath3;
                int f1, f2, f3;
                common.WaitForElement(SiteContentOR.opagelayout_xpath);
                if (Driver.FindElement(SiteContentOR.opagelayout_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.opagelayout_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "Clicked on Layout option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", " Unable to click on Layout option", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                dynamicpath1 = "//*[text()='" + layout1 + "']";
                common.WaitForElement(By.XPath(dynamicpath1));
                if (Driver.FindElement(By.XPath(dynamicpath1)).Displayed)
                {

                    f1 = 1;
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "Layout is present with name : " + layout1, Status.PASS);
                }
                else
                {
                    f1 = 0;
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "No Layour is present with name : " + layout1, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                dynamicpath2 = "//*[text()='" + layout2 + "']";
                common.WaitForElement(By.XPath(dynamicpath2));
                if (Driver.FindElement(By.XPath(dynamicpath2)).Displayed)
                {
                    f2 = 1;
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "Layout is present with name : " + layout2, Status.PASS);
                }
                else
                {
                    f2 = 0;
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "No Layour is present with name : " + layout2, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                dynamicpath3 = "//*[text()='" + layout3 + "']";
                common.WaitForElement(By.XPath(dynamicpath3));
                if (Driver.FindElement(By.XPath(dynamicpath3)).Displayed)
                {
                    f3 = 1;
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "Layout is present with name : " + layout3, Status.PASS);
                }
                else
                {
                    f3 = 0;
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "No Layout is present with name : " + layout3, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (f1 == 1)
                {
                    Driver.FindElement(By.XPath(dynamicpath1)).Click();
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "Clicked on :" + layout1, Status.DONE);
                    common.CallMeWait(3000);

                }
                else if (f2 == 1)
                {
                    Driver.FindElement(By.XPath(dynamicpath2)).Click();
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "Clicked on :" + layout2, Status.DONE);
                    common.CallMeWait(3000);
                }
                else if (f3 == 1)
                {
                    Driver.FindElement(By.XPath(dynamicpath3)).Click();
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "Clicked on :" + layout3, Status.DONE);
                    common.CallMeWait(3000);
                }
                else
                {
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", "Unable to Click on Layout option", Status.DONE);
                }
                // Actions a = new Actions(Driver);
                // a.SendKeys(OpenQA.Selenium.Keys.Escape);
                common.WaitForElement(SiteContentOR.osave_xpath);
                if (Driver.FindElement(SiteContentOR.osave_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.osave_xpath).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOutFinalStep", "Click on save option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", " Unable to click on save option ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyAccordionTabVideoLayOut", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: OpenPagetoEdit()
        // Method Decs: This method opens page in edit mode
        // Created on:  9th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void OpenPagetoEdit()
        {
            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("OpenPagetoEditFinalStep", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(3000);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("OpenPagetoEdit", " Error on ClickOnTopNavigationItem method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: Savepage()
        // Method Decs: This method click to save option to save page.
        // Created on:  9th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void Savepage()
        {
            try
            {
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.osave_xpath);
                if (Driver.FindElement(SiteContentOR.osave_xpath).Displayed)
                {

                    Driver.FindElement(SiteContentOR.osave_xpath).Click();
                    common.CallMeWait(3000);
                    Report.UpdateTestLog("SavepageFinalStep", "Click on save option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("Savepage", " Unable to click on save option ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Savepage", " Error on ClickOnTopNavigationItem method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyOrgChartSelection()
        // Method Decs: This method verifies Org Chart Selection during edit a page
        // Created on:  9th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyOrgChartSelection()
        {
            try
            {
                common.WaitForElement(SiteContentOR.oorgchart_xpath);
                if (Driver.FindElement(SiteContentOR.oorgchart_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyOrgChartSelectionFinalStep", "Org Chart Selection is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyOrgChartSelection", " Org Chart Selection is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyOrgChartSelection", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyOrgChartSelection", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: VerifyLandingPage()
        // Method Decs: This method verifies lay out of landing page
        // Created on:  10th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyLandingPage()
        {
            try
            {
                common.WaitForElement(SiteContentOR.oleftContentColumn_id);
                if (Driver.FindElement(SiteContentOR.oleftContentColumn_id).Displayed)
                {
                    Report.UpdateTestLog("VerifyLandingPage", "Left Content Column is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyLandingPage", " Left Content Column is not present  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.omainContentColumn_id);
                if (Driver.FindElement(SiteContentOR.omainContentColumn_id).Displayed)
                {
                    Report.UpdateTestLog("VerifyLandingPage", "Main Content Column is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyLandingPage", " Main Content Column is not present  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.orightContentColumn_id);
                if (Driver.FindElement(SiteContentOR.orightContentColumn_id).Displayed)
                {
                    Report.UpdateTestLog("VerifyLandingPageFinalStep", "Right Content Column is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyLandingPage", "Right Content Column is not present  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyLandingPage", "Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyLandingPage", "Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: OpenWebpartinEditMode()
        // Method Decs: This method verifies Org Chart Selection during edit a pageopen any added web part in Edit Mode
        // Created on:  10th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void OpenWebpartinEditMode()
        {
            try
            {
                common.WaitForElement(SiteContentOR.owebpartmenuArrow_class);

                Driver.FindElement(SiteContentOR.owebpartmenuArrow_class).Click();
                common.CallMeWait(1000);
                Driver.FindElement(By.XPath("//*[text()='Edit Web Part']")).Click();
                common.CallMeWait(3000);
                Report.UpdateTestLog("OpenWebpartinEditModeFinalStep", "Web part opened in edit mode ", Status.PASS);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("OpenWebpartinEditMode", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("OpenWebpartinEditMode", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyCustomLinkTileFormate()
        // Method Decs: This method verify custom link tile option in the web part of custom link
        // Created on:  10th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyCustomLinkTileFormate()
        {
            try
            {
                common.WaitForElement(SiteContentOR.odisplaytype_id);
                if (Driver.FindElement(SiteContentOR.odisplaytype_id).Displayed)
                {
                    Driver.FindElement(SiteContentOR.odisplaytype_id).Click();
                    Report.UpdateTestLog("VerifyCustomLinkTileFormate", " Click on Display Type ", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("VerifyCustomLinkTileFormate", "Unable to lick on Display Type ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.otile_xpath);
                if (Driver.FindElement(SiteContentOR.otile_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.otile_xpath).Click();
                    Report.UpdateTestLog("VerifyCustomLinkTileFormateFinalStep", " Tile option selected", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyCustomLinkTileFormate", "Unable to select tile option", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCustomLinkTileFormate", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyCustomLinkTileFormate", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyLocationInWebPart()
        // Method Decs: This method verifies CBRE ALL Location in What's New Web Part
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyLocationInWebPart()
        {
            try
            {
                common.WaitForElement(SiteContentOR.olocation_id);
                string cbreall = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string locationvalue = Driver.FindElement(SiteContentOR.olocation_id).GetAttribute("value").Trim();

                if (cbreall.Equals(locationvalue))
                {
                    Report.UpdateTestLog("VerifyLocationInWebPartFinalStep", "CBRE ALL as Location is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyLocationInWebPart", "CBRE ALL as Location is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyLocationInWhatisNewWebPart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyLocationInWhatisNewWebPart", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SetLcationInWebPart()
        // Method Decs: This method changes the default location in Web part
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void SetLcationInWebPart()
        {
            try
            {
                string location = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();

                common.WaitForElement(SiteContentOR.olocation_id);
                if (Driver.FindElement(SiteContentOR.olocation_id).Displayed)
                {
                    Driver.FindElement(SiteContentOR.olocation_id).Clear();
                    Driver.FindElement(SiteContentOR.olocation_id).SendKeys(location);
                    Report.UpdateTestLog("SetLcationInWebPartFinalStep", "location is Set as :" + location, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SetLcationInWebPart", "Unable to set location ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SetLcationInWebPart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SetLcationInWebPart", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SetPrimaryServicesInWebPart()
        // Method Decs: This method changes the default PrimaryServices in Web part
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void SetPrimaryServicesInWebPart()
        {
            try
            {
                string primaryservices = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                common.WaitForElement(SiteContentOR.oprimaryService_id);
                if (Driver.FindElement(SiteContentOR.oprimaryService_id).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oprimaryService_id).Clear();
                    Driver.FindElement(SiteContentOR.oprimaryService_id).SendKeys(primaryservices);
                    Report.UpdateTestLog("SetPrimaryServicesInWebPartFinalStep", "Primary Services is Set as :" + primaryservices, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SetPrimaryServicesInWebPart", "Unable to set primary Services ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SetPrimaryServicesInWebPart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SetPrimaryServicesInWebPart", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: ClickToApply()
        // Method Decs: This method click on the Apply Button
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void ClickToApply()
        {
            try
            {

                common.WaitForElement(SiteContentOR.ovideowebpartapplybtn_xpath);
                Driver.FindElement(SiteContentOR.ovideowebpartapplybtn_xpath).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("ClickToApplyFinalStep", " Click on Apply button  ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickToApply", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToApply", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickToOK()
        // Method Decs: This method click on the OK Button
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void ClickToOK()
        {
            try
            {
                //click on Ok button
                common.WaitForElement(SiteContentOR.ovideowebpartokbtn_xpath);
                Driver.FindElement(SiteContentOR.ovideowebpartokbtn_xpath).Click();
                common.CallMeWait(3000);
                Report.UpdateTestLog("ClickToOKFinalStep", " Click on OK button  ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickToOK", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToOK", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: ListitemPresenceInWebpart()
        // Method Decs: This method check the presence of list item in Web Part
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void ListitemPresenceInWebpart()
        {
            try
            {
                string token = DataTable.GetData("General_Data_" + Env, "WebParts").Trim();
                string xpath = "//h4[contains(text(),'" + token + "')]/parent::*/table/tbody/tr";
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath(xpath));
                if (elms.Count > 0)
                {
                    Report.UpdateTestLog("ChangeDefaultSelectionInWhatisNewFinalStep", "Total list items present : " + elms.Count, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ChangeDefaultSelectionInWhatisNew", "No list items present  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }



            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickToOK", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToOK", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyDocumentLinksAsAuthor()
        // Method Decs: This method will Verify  the functionality of the DocumentLinks web part login as Auhor
        // Created on: 13th Feb 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyDocumentLinksAsAuthor()
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
                    Report.UpdateTestLog("VerifyDocumentLinksAsAuthor", "DocumentLinks web part is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyDocumentLinksAsAuthor", "DocumentLinks web part is Not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    string path = "//h4[text()='Documents']/following-sibling::*/table/tbody/tr/td[2]/a";
                    // string path2 = "//h4[text()='Popular Items']/parent::*/table/tbody/tr/td[2]/a/span";

                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(By.XPath(path));
                    if (elmsElements1.Count > 2)
                    {
                        x = 2;
                    }
                    for (int i = 1; i < x; i++)
                    {
                        elmsElements1 = Driver.FindElements(By.XPath(path));

                        string linkname = elmsElements1[i].Text.Trim();
                        //string linkvalue = elmsElements1[i].GetAttribute("href").Trim();
                        elmsElements1[i].Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("VerifyDocumentLinksAsAuthor", "clicked on " + linkname, Status.DONE);
                        Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                        string newurl = Driver.Url.Trim();
                        if (newurl.Contains(".ppt") || newurl.Contains(".docx") || newurl.Contains(".jpg") || newurl.Contains(".JPG") || newurl.Contains(".xls") || newurl.Contains(".xlsx") || newurl.Contains(".png"))
                        {
                            Report.UpdateTestLog("VerifyDocumentLinksAsAuthorFinalStep", "Successfully Navigated to the " + newurl, Status.PASS);
                            Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
                            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                            common.CallMeWait(1000);
                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyDocumentLinksAsAuthor", "Unable to Navigate to " + newurl, Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }

                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyDocumentLinksAsAuthor", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyDocumentLinksAsAuthor", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnNewsTopNav()
        // Method Decs: This method will click on News link Top Navigation
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  

        public void ClickOnNewsTopNav()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oTopNavNews_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oTopNavNews_xpath).Click();
                    Report.UpdateTestLog("ClickOnNewsTopNavFinalStep", " Clicked on News link on Top Navigation ", Status.PASS);                    
                }
                else
                {
                    Report.UpdateTestLog("ClickOnNewsTopNav", " News link is not present on Top Navigation not found ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnNewsTopNav", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnNewsTopNav", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateNewsFeedPageTitle()
        // Method Decs: This method will validate the title of News Feed
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  

        public void ValidateNewsFeedPageTitle()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oNewsFeedPageTitle_id) == true)
                {
                    string sExpectedPageTitle = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                    string sActualPageTitle = Driver.FindElement(SiteContentOR.oNewsFeedPageTitle_id).Text.Trim();
                    if (sExpectedPageTitle == sActualPageTitle)
                    {
                        Report.UpdateTestLog("ValidateNewsFeedPageTitleFinalStep", " Successfully validated that user navigates to news feed page, Page title is : " + sActualPageTitle, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsFeedPageTitle", " User failed to navigate to news feed page. Expected Page title: " + sExpectedPageTitle + " Actual Page title: " + sActualPageTitle,Status.FAIL);
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageTitle", " News link is not present on Top Navigation not found ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNewsFeedPageTitle", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNewsFeedPageTitle", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateNewsFeedPageLayout()
        // Method Decs: This method will validate the Layout of News Feed page
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //**************************************************** 

        public void ValidateNewsFeedPageLayout()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oNavBar_id))
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Top Navigation is present in News feed page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Top Navigation is not present in News feed page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.oBodyContainer_id))
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Container is present in News feed page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Container is not present in News feed page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.oFooter_id))
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayoutFinalStep", " Footer is present in News feed page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Footer is not present in News feed page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateLoadMoreOnNewsFeedPage()
        // Method Decs: This method will validate News Article list and Load More button on News Feed page
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ValidateLoadMoreOnNewsFeedPage()
        {
            try
            {
                ReadOnlyCollection<IWebElement> list =
                                    Driver.FindElements(SiteContentOR.oNewsArticleList_XPath);
                int iCount = list.Count;
                if(iCount>0)
                {
                    Report.UpdateTestLog("ValidateLoadMoreOnNewsFeedPage", " News Articles are present in News Feed Page. Total count of articles are = " + iCount, Status.PASS);
                    if (common.CheckElement(SiteContentOR.oLoadMore_id) == true)
                    {
                        Driver.FindElement(SiteContentOR.oLoadMore_id).Click();
                        Report.UpdateTestLog("ValidateLoadMoreOnNewsFeedPage", " Clicked on 'Load More News' button", Status.DONE);
                        common.CallMeWait(2000);
                        ReadOnlyCollection<IWebElement> list1 =
                                    Driver.FindElements(SiteContentOR.oNewsArticleList_XPath);
                        int iCountLater = list1.Count;
                        if (iCountLater > iCount)
                        {
                            Report.UpdateTestLog("ValidateLoadMoreOnNewsFeedPageFinalStep", " After clicking on 'Load More News' button more news articles are populated. Total count of articles are = " + iCountLater, Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateLoadMoreOnNewsFeedPage", " After clicking on 'Load More News' button more news articles are not populated. Total count of articles before = " + iCount + " Total count of articles after = " + iCountLater, Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateLoadMoreOnNewsFeedPage", " 'Load More News' button is not present in News Feed Page.", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else 
                {
                    Report.UpdateTestLog("ValidateLoadMoreOnNewsFeedPage", " No News Article is present in News Feed Page." , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLoadMoreOnNewsFeedPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLoadMoreOnNewsFeedPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateViewAllOnNewsFeedPage()
        // Method Decs: This method will select the option All news from the dropdown and open a article from News Feed page
        // Created on:  13th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ValidateViewAllOnNewsFeedPage()
        {
            try
            {
                var dropdown = Driver.FindElement(SiteContentOR.oDropDown_id);
                var selectElement = new SelectElement(dropdown);
                common.CallMeWait(2000);
                selectElement.DeselectByText("All News");
                if (Driver.FindElement(SiteContentOR.oOption1_XPath).GetAttribute("selected") == "true")
                {
                    Report.UpdateTestLog("ValidateViewAllOnNewsFeedPage", " Selected All News from DropDown on News Feed Page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateViewAllOnNewsFeedPage", " Unable to select All News from DropDown on News Feed Page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ReadOnlyCollection<IWebElement> list =
                                    Driver.FindElements(SiteContentOR.oNewsArticleList_XPath);
                string sFirstArticleTitle = list[1].Text.Trim();
                list[1].Click();
                Report.UpdateTestLog("ValidateViewAllOnNewsFeedPage", " Clicked on First Article ", Status.DONE);
                Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                string spagetitle = Driver.FindElement(SiteContentOR.oArticlePageTitle_id).Text.Trim();
                if (sFirstArticleTitle == spagetitle)
                {
                    Report.UpdateTestLog("ValidateViewAllOnNewsFeedPageFinalStep", " After clicking on a news article it successfully navigates to the respective page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateViewAllOnNewsFeedPage", " After clicking on a news article it failed to navigate to the respective page. Expected page title: " + sFirstArticleTitle + " , Actual Page title: " + spagetitle, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateViewAllOnNewsFeedPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateViewAllOnNewsFeedPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateNewsArticlePageLayout()
        // Method Decs: This method will click on the READ MORE link and validate the Layout of News Article page
        // Created on:  14th Feb 2017	
        // Created by:  GI offshore Team	
        //**************************************************** 

        public void ValidateNewsArticlePageLayout()
        {
            try
            {
                ReadOnlyCollection<IWebElement> Articlelist = Driver.FindElements(SiteContentOR.oNewsArticleList_XPath);
                ReadOnlyCollection<IWebElement> ReadMorelist = Driver.FindElements(SiteContentOR.oReadMore_XPath);
                if (Articlelist.Count > 0 && ReadMorelist.Count > 0)
                {
                    string sFirstArticleTitle = Articlelist[1].Text.Trim();
                    ReadMorelist[1].Click();
                    Report.UpdateTestLog("ValidateNewsArticlePageLayout", " Clicked on READ MORE link of the first column of news feed page", Status.DONE);
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    string spagetitle = Driver.FindElement(SiteContentOR.oArticlePageTitle_id).Text.Trim();
                    if (sFirstArticleTitle == spagetitle)
                    {
                        Report.UpdateTestLog("ValidateNewsArticlePageLayout", " After clicking on a read more link it successfully navigates to the respective page ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsArticlePageLayout", " After clicking on a read more it failed to navigate to the respective page. Expected page title: " + sFirstArticleTitle + " , Actual Page title: " + spagetitle, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                
                if (common.CheckElement(SiteContentOR.oNavBar_id))
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Top Navigation is present in News Article page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Top Navigation is not present in News Article page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.oBodyContainer_id))
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Container is present in News Article page ", Status.PASS);
                    ReadOnlyCollection<IWebElement> Columnlist = Driver.FindElements(SiteContentOR.oBodyContainerColumns_id);
                    if (Columnlist.Count > 0)
                    {
                        Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Container has " + Columnlist.Count + " columns in News Article page ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Container has no column presemt in News Article page ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Container is not present in News Article page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.oFooter_id))
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayoutFinalStep", " Footer is present in News Article page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsFeedPageLayout", " Footer is not present in News Article page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsArticlePageLayout", " No Article or read more link is present on News feed page", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNewsArticlePageLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNewsArticlePageLayout", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateNewsDetailPage()
        // Method Decs: This method will click on the READ MORE link and validate share, like and comment functionality of News detail page
        // Created on:  14th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************     

        public void ValidateNewsDetailPage()
        {
            try
           {
                ReadOnlyCollection<IWebElement> Articlelist = Driver.FindElements(SiteContentOR.oNewsArticleList_XPath);
                ReadOnlyCollection<IWebElement> ReadMorelist = Driver.FindElements(SiteContentOR.oReadMore_XPath);
                if (Articlelist.Count > 0 && ReadMorelist.Count > 0)
                {
                    string sFirstArticleTitle = Articlelist[2].Text.Trim();
                    ReadMorelist[2].Click();
                    Report.UpdateTestLog("ValidateNewsDetailPage", " Clicked on READ MORE link beside " + sFirstArticleTitle, Status.DONE);
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    string spagetitle = Driver.FindElement(SiteContentOR.oArticlePageTitle_id).Text.Trim();
                    if (sFirstArticleTitle == spagetitle)
                    {
                        Report.UpdateTestLog("ValidateNewsDetailPage", " After clicking on a read more link it successfully navigates to the respective page ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsDetailPage", " After clicking on a read more it failed to navigate to the respective page. Expected page title: " + sFirstArticleTitle + " , Actual Page title: " + spagetitle, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    common.CallMeWait(5000);
                    if (common.CheckElement(SiteContentOR.oShare_id) == true)
                    {
                        Report.UpdateTestLog("ValidateNewsDetailPage", " Successfully validated that share link is present on News Detail page ", Status.PASS);
                        //Driver.FindElement(SiteContentOR.oShare_id).Click();
                       // Report.UpdateTestLog("ValidateNewsDetailPage", " Clicked on share link on News Detail page", Status.DONE);
                       // common.CallMeWait(2000);
                       // SendKeys.SendWait(@"{Esc}");
                       // common.CallMeWait(1000);
                      //  SendKeys.SendWait(@"{Tab}");
                      //  common.CallMeWait(1000);
                       // SendKeys.SendWait(@"{Enter}");
                        //Report.UpdateTestLog("ValidateNewsDetailPage", " Successfully validated that user is able to share the news article ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsDetailPage", " Share link is not present on News Detail page ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (common.CheckElement(SiteContentOR.oLikeButton_class) == true)
                    {
                        Driver.FindElement(SiteContentOR.oLikeButton_class).Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("ValidateNewsDetailPage", " Clicked the like button on News Detail page ", Status.DONE);
                        if (common.CheckElement(SiteContentOR.oLiked_class) == true)
                        {
                            Report.UpdateTestLog("ValidateNewsDetailPage", " Successfully liked the news article on News Detail page ", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateNewsDetailPage", " Unable to like the news article on News Detail page ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Driver.FindElement(SiteContentOR.oLiked_class).Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("ValidateNewsDetailPage", " Clicked the unlike button on News Detail page ", Status.DONE);
                        Driver.FindElement(SiteContentOR.oLikeButton_class).Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("ValidateNewsDetailPage", " Clicked the like button on News Detail page ", Status.DONE);
                        if (common.CheckElement(SiteContentOR.oLiked_class) == true)
                        {
                            Report.UpdateTestLog("ValidateNewsDetailPage", " Successfully liked the news article on News Detail page ", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateNewsDetailPage", " Unable to like the news article on News Detail page ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    string sExpectedcomment = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                    if (common.CheckElement(SiteContentOR.oCommentTextField_XPath) == true)
                    {
                        IWebElement elm = Driver.FindElement(SiteContentOR.oCommentTextField_XPath);
                        //ReadOnlyCollection<IWebElement> Commentlist = Driver.FindElements(SiteContentOR.oCommentsList_XPath);
                        bool flag = true;
                        elm.Click();
                        elm.SendKeys(sExpectedcomment);
                        Report.UpdateTestLog("ValidateNewsDetailPage", " Entered comment in comment box ", Status.DONE);
                        Driver.FindElement(SiteContentOR.oPostCommentButton_XPath).Click();
                        Report.UpdateTestLog("ValidateNewsDetailPage", " Clicked Post Comment button ", Status.DONE);
                        common.CallMeWait(2000);
                        ReadOnlyCollection<IWebElement> Commentlist = Driver.FindElements(SiteContentOR.oCommentsList_XPath);
                        for (int i = 0; i < Commentlist.Count; i++)
                        {
                            string sActualComment = Commentlist[i].Text.Trim();
                            if (sActualComment.Contains(sExpectedcomment))
                            {
                                Report.UpdateTestLog("ValidateNewsDetailPage", " Successfully put a comment on News Detail page ", Status.PASS);
                                break;
                            }
                            else
                            {
                                flag = false;
                            }                           
                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("ValidateNewsDetailPage", " Unable to put a comment on News Detail page ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                        if (flag == true)
                        {
                            if (common.CheckElement(SiteContentOR.oDeleteComment_XPath) == true)
                            {
                                Driver.FindElement(SiteContentOR.oDeleteComment_XPath).Click();
                                Report.UpdateTestLog("ValidateNewsDetailPage", " Clicked on delete comment link ", Status.DONE);
                                Driver.FindElement(SiteContentOR.oDeleteYes_XPath).Click();
                                Report.UpdateTestLog("ValidateNewsDetailPageFinalStep", " Clicked on YES on delete pop-up ", Status.PASS);
                            }
                            else
                            {
                                Report.UpdateTestLog("ValidateNewsDetailPage", " No Delete comment link is present on News Detail page", Status.FAIL);
                                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsDetailPage", " No comment box is present on News Detail page", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }    
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsDetailPage", " No Article or read more link is present on News Feed page", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNewsDetailPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNewsDetailPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickTonewItem()
        // Method Decs: This method click on the (+) new Item link under any modul of site content
        // Created on:  14th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ClickTonewItem()
        {
            try
            {
                common.WaitForElement(SiteContentOR.onewitem_xpath);
                if (Driver.FindElement(SiteContentOR.onewitem_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.onewitem_xpath).Click();
                    Report.UpdateTestLog("ClickTonewItemFinalStep", "Clicked on New item link ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickTonewItem", " Unable to click on New item link ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickTonewItem", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickTonewItem", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreateACustomLinkAgain()
        // Method Decs: This method create a link in Cutim Link library
        // Created on:  14th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void CreateACustomLinkAgain()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType4");
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType5");
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType6");
                common.WaitForElement(SiteContentOR.onewitemlink_xpath);
                common.CallMeWait(2000);
                if (Driver.FindElement(SiteContentOR.onewitemlink_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.onewitemlink_xpath).Click();
                    Report.UpdateTestLog("CreateACustomLinkAgain", "clicked on New Item link", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateACustomLinkAgain", "unable to click on new item link", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.otitle_xpath);
                Driver.FindElement(SiteContentOR.otitle_xpath).Clear();
                Driver.FindElement(SiteContentOR.otitle_xpath).SendKeys(req1);
                Report.UpdateTestLog("CreateACustomLinkAgain", "tittle is entered as :" + req1, Status.PASS);

                common.WaitForElement(SiteContentOR.ourl_xpath);
                Driver.FindElement(SiteContentOR.ourl_xpath).Clear();
                Driver.FindElement(SiteContentOR.ourl_xpath).SendKeys(req2);
                Report.UpdateTestLog("CreateACustomLinkAgain", "Link is entered as :" + req2, Status.PASS);

                common.WaitForElement(SiteContentOR.oIntOrgCategory_xpath);
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).Clear();
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).SendKeys(req3);
                Report.UpdateTestLog("CreateACustomLinkAgain", "Intranet :" + req3, Status.PASS);

                common.WaitForElement(SiteContentOR.oribbonsaveoption_xpath);
                if (Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Click();
                    Report.UpdateTestLog("CreateACustomLinkAgainFinalStep", "clicked on save" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateACustomLinkAgain", "Unable to click save data" + req3, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.CallMeWait(2000);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateACustomLinkAgain", " Element not found : " + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateACustomLinkAgain", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeleteCustomLinkAgain()
        // Method Decs: This method will Delete CustomLink from CustomLink List
        // Created on:  14th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void DeleteCustomLinkAgain()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType4");
                int i = 1;
                int flags = 0;
                string dynamicPath = "//*[@class='ms-listviewtable']/tbody/tr[1]/td[2] ";
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[2]")).GetAttribute("innerText");
                    if (name.Contains(req1))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.oitemsheader_xpath);
                    IWebElement elm = Driver.FindElement(SiteContentOR.oitemsheader_xpath);
                    elm.Click();
                    //Driver.FindElement(SiteContentOR.oitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.odeleteitemsheader_xpath);
                    Driver.FindElement(SiteContentOR.odeleteitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    Driver.SwitchTo().DefaultContent();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeleteCustomLinkAgainFinalStep", " link " + req1 + "' found and deleted", Status.PASS);
                    IWebElement header = Driver.FindElement(SiteContentOR.oheaderbrowse_xpath);
                    header.Click();
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("DeleteCustomLinkAgain", " name '" + req1 + "' not found", Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteCustomLinkAgain", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteCustomLinkAgain", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: SelectCategoryInEditWebpart()
        // Method Decs: This method select a Category in Web Part 
        // Created on:  14th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectCategoryInEditWebpart()
        {
            try
            {
                common.WaitForElement(SiteContentOR.oCategorydropdown_id);
                if (Driver.FindElement(SiteContentOR.oCategorydropdown_id).Displayed)
                {
                    Report.UpdateTestLog("SelectCategoryInEditWebpart", "Category Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oCategorydropdown_id));
                    IList<IWebElement> elmcount = oselect.Options;
                    for (int i = 0; i < elmcount.Count; i++)
                    {
                        string s = elmcount[i].Text.Trim();
                        if (s != "")
                        {
                            elmcount[i].Click();
                            Report.UpdateTestLog("SelectCategoryInEditWebpartFinalStep", "Selected Category is " + s, Status.PASS);
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("SelectCategoryInEditWebpart", "Category Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectCategoryInEditWebpart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectCategoryInEditWebpart", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyWebpartOnPage()
        // Method Decs: This method verifies presence og particular web part on the page
        // Created on:  14th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyWebpartOnPage()
        {
            try
            {
                string webpartname = DataTable.GetData("General_Data_" + Env, "WebParts");
                string dxpath = "//h4[text()=\"" + webpartname + "\"]";
                //*[text()="Quick Links"]
                common.WaitForElement(By.XPath(dxpath));
                if (Driver.FindElement(By.XPath(dxpath)).Displayed)
                {
                    Report.UpdateTestLog("VerifyWebpartOnPageFinalStep", webpartname + " web part is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWebpartOnPage", webpartname + " web part is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyWebpartOnPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyWebpartOnPage", " Problem in Method " + e, Status.FAIL);
            }
        }

        //******************************************************
        // Method Name: CreateMultiplelink()
        // Method Decs: This method will create a quick link in Quick link Library inder Site Content
        // Created on:  14th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void CreateMultiplelink(string c, int w)
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim() + c;
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                common.WaitForElement(SiteContentOR.onewitemlink_xpath);
                common.CallMeWait(1000);
                if (Driver.FindElement(SiteContentOR.onewitemlink_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.onewitemlink_xpath).Click();
                    Report.UpdateTestLog("CreateMultiplelink", "clicked on New Item link", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateMultiplelink", "unable to click on new item link", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.otitle_xpath);
                Driver.FindElement(SiteContentOR.otitle_xpath).Clear();
                Driver.FindElement(SiteContentOR.otitle_xpath).SendKeys(req1);
                Report.UpdateTestLog("CreateMultiplelink", "tittle is entered as :" + req1, Status.PASS);

                common.WaitForElement(SiteContentOR.opicture_xpath);
                Driver.FindElement(SiteContentOR.opicture_xpath).Clear();
                Driver.FindElement(SiteContentOR.opicture_xpath).SendKeys(req2);
                Report.UpdateTestLog("CreateMultiplelink", "Picture Link is entered as :" + req2, Status.PASS);

                common.WaitForElement(SiteContentOR.ourl_xpath);
                Driver.FindElement(SiteContentOR.ourl_xpath).Clear();
                Driver.FindElement(SiteContentOR.ourl_xpath).SendKeys(req2);
                Report.UpdateTestLog("CreateMultiplelink", "Url Link is entered as :" + req2, Status.PASS);

                common.WaitForElement(SiteContentOR.oIntOrgCategory_xpath);
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).Clear();
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).SendKeys(req3);
                Report.UpdateTestLog("CreateMultiplelink", "Intranet :" + req3, Status.PASS);

                common.WaitForElement(SiteContentOR.osortingweight_xpath);
                Driver.FindElement(SiteContentOR.osortingweight_xpath).Clear();
                Driver.FindElement(SiteContentOR.osortingweight_xpath).SendKeys(w.ToString());
                Report.UpdateTestLog("CreateMultiplelink", "Sorting Weight is entered as :" + w, Status.PASS);

                common.WaitForElement(SiteContentOR.oribbonsaveoption_xpath);
                if (Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Click();
                    Report.UpdateTestLog("CreateMultiplelinkFinalStep", "clicked on save" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateMultiplelink", "Unable to click save data" + req3, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.CallMeWait(2000);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateMultiplelink", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateMultiplelink", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreateManylinks()
        // Method Decs: This method call Create Multiple link in order to create multiple links
        // Created on:  14th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void CreateManylinks()
        {
            try
            {
                string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7");
                int n = Int32.Parse(req7);
                for (int i = 1; i <= n; i++)
                {
                    CreateMultiplelink(i.ToString(), i);
                    Report.UpdateTestLog("CreateManylinksFinalStep", "Quick link created :" + i, Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateManylinks", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateManylinks", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: VerifyShowMore()
        // Method Decs: This method verifies that after clicking the Show more remaining items are load for quick link web part
        // Created on:  14th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifyShowMore()
        {
            try
            {
                string dpath = "//h4[text()='Quick Links']/parent::*/table/tbody/tr/td[2]/a";
                ReadOnlyCollection<IWebElement> linkcount =
                                  Driver.FindElements(By.XPath(dpath));
                if (linkcount.Count > 0)
                {
                    Report.UpdateTestLog("VerifyShowMore", "Number of link present :" + linkcount.Count, Status.DONE);
                    if (linkcount.Count >= 10)
                    {
                        common.WaitForElement(SiteContentOR.oshowmore_xpath);
                        if (Driver.FindElement(SiteContentOR.oshowmore_xpath).Displayed)
                        {
                            Report.UpdateTestLog("VerifyShowMore", "SHOW MORE link is present", Status.PASS);
                            Driver.FindElement(SiteContentOR.oshowmore_xpath).Click();
                            Report.UpdateTestLog("VerifyShowMore", "SHOW MORE link is Clicked", Status.PASS);
                            ReadOnlyCollection<IWebElement> linkcount2 =
                                 Driver.FindElements(By.XPath(dpath));
                            Report.UpdateTestLog("VerifyShowMoreFinalStep", "Total link present after click are " + linkcount2.Count, Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyShowMore", "SHOW MORE link is not present", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        //common.WaitForElement(SiteContentOR.oshowmore_xpath);
                        //if (Driver.FindElement(SiteContentOR.oshowmore_xpath).Displayed)
                        //{
                            Report.UpdateTestLog("VerifyShowMore", "SHOW MORE link is not present as less than 10 links are present", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

                       // }
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyShowMore", "No Link is present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyShowMore", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyShowMore", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: NavigatetoQuiclLinksLibrary()
        // Method Decs: This method nanigates to Quick links Library Under Site Content
        // Created on:  14th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void NavigatetoLibrary()
        {
            try
            {
                bool flag = false;
                string SiteContentItem = DataTable.GetData("General_Data_" + Env, "SiteContentItem").Trim();
                common.WaitForElement(By.XPath("//*[text()='Admin']"));
                Driver.FindElement(By.XPath("//*[text()='Admin']")).Click();
                common.WaitForElement(By.XPath("//*[text()='Site contents']"));
                Driver.FindElement(By.XPath("//*[text()='Site contents']")).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("NavigatetoQuiclLinksLibrary", " navigated to site Content  ", Status.PASS);


                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                for (int i = 2; i <= elms.Count; i++)
                {
                    string innerValue =
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text.Trim();

                    if (innerValue.Contains(SiteContentItem))
                    {
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[1]")).Click();
                        flag = true;
                        common.CallMeWait(5000);
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("NavigatetoPageLibrary", " Not able to find " + SiteContentItem, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("NavigatetoPageLibraryFinalStep", " Clicked on Item : " + SiteContentItem, Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigatetoPageLibrary", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigatetoPageLibrary", " Problem in NavigatetoPageLibrary Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: Deletemultiplelink()
        // Method Decs: This method  Deletes delete links presnt in quick/custom links
        // Created on:  14th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void Deletemultiplelink(string c)
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim() + c;
                int i = 1;
                int flags = 0;
                string dynamicPath = "//*[@class='ms-listviewtable']/tbody/tr[1]/td[2] ";
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[2]")).GetAttribute("innerText").Trim();
                    if (name.Equals(req1))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.oitemsheader_xpath);
                    IWebElement elm = Driver.FindElement(SiteContentOR.oitemsheader_xpath);
                    elm.Click();
                    //Driver.FindElement(SiteContentOR.oitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.odeleteitemsheader_xpath);
                    Driver.FindElement(SiteContentOR.odeleteitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    Driver.SwitchTo().DefaultContent();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeletemultiplelinkFinalStep", " link " + req1 + "' found and deleted", Status.PASS);
                    IWebElement header = Driver.FindElement(SiteContentOR.oheaderbrowse_xpath);
                    header.Click();
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("Deletemultiplelink", " name '" + req1 + "' not found", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Deletemultiplelink", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Deletemultiplelink", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeleteManylinks()
        // Method Decs: This method call Deletemultiplelink in order to delete multiple links
        // Created on:  14th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void DeleteManylinks()
        {
            try
            {
                string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7");
                int n = Int32.Parse(req7);
                bool flag = false;
                for (int i = 1; i <= n; i++)
                {
                    Deletemultiplelink(i.ToString());
                    flag = true;
                    //  Report.UpdateTestLog("DeleteManylinks", " link deleted :" + i, Status.DONE);
                }
                if (flag == true)
                {
                    Report.UpdateTestLog("DeleteManylinksFinalStep", " links are deleted ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("DeleteManylinks", " links are not deleted ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteManylinks", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteManylinks", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: SelectCategoryByNameInEditWebpart()
        // Method Decs: This method select a Category in Web Part 
        // Created on:  15th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectCategoryByNameInEditWebpart()
        {
            try
            {
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                common.WaitForElement(SiteContentOR.oCategorydropdown_id);
                if (Driver.FindElement(SiteContentOR.oCategorydropdown_id).Displayed)
                {
                    Report.UpdateTestLog("SelectCategoryByNameInEditWebpart", "Category Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oCategorydropdown_id));
                    oselect.SelectByText(req3);
                    Report.UpdateTestLog("SelectCategoryByNameInEditWebpartFinalStep", "Category Drop is selected as :" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectCategoryByNameInEditWebpart", "Category Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectCategoryByNameInEditWebpart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectCategoryByNameInEditWebpart", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyShowMore()
        // Method Decs: This method verifies sorting order of the link by weight on a page
        // Created on:  15th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void VerifySortingOrderbyWeight()
        {
            try
            {
                int flag = 0;
                var map2 = new Dictionary<int, string>();
                var map1 = new Dictionary<int, string>();
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string dpath = "//h4[text()='Quick Links']/parent::*/table/tbody/tr/td[2]/a/span";
                ReadOnlyCollection<IWebElement> linkcount = Driver.FindElements(By.XPath(dpath));
                if (linkcount.Count > 0)
                {
                    Report.UpdateTestLog("VerifySortingOrderbyWeight", "Number of link present :" + linkcount.Count, Status.DONE);
                    for (int i = 1; i <= linkcount.Count; i++)
                    {
                        // CreateMultiplelink(i.ToString(), i);
                        string linkname = linkcount[i - 1].Text.Trim();
                        map1.Add(i, linkname);
                        string map2value = map1[i];
                        Report.UpdateTestLog("VerifySortingOrderbyWeight", "present link name is " + linkname, Status.DONE);
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifySortingOrderbyWeight", "No Link is present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Create Map For Link and Weight
                string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                int n = Int32.Parse(req7);
                for (int i = 1; i <= n; i++)
                {
                    // CreateMultiplelink(i.ToString(), i);

                    map2.Add(i, req1 + i.ToString());
                    string map1value = map2[i];
                    Report.UpdateTestLog("CreateMapForLinkandWeight", "Number of Data Stored into Map : " + i, Status.DONE);
                }
                //Validating both map here
                if (map1.Count == map2.Count)
                {
                    for (int i = 1; i <= map1.Count; i++)
                    {
                        // CreateMultiplelink(i.ToString(), i);
                        string m1 = (map1[i]);
                        string m2 = (map2[i]);
                        if (m1 != m2)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    Report.UpdateTestLog("VerifySortingOrderbyWeight", "Comparission  done", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("VerifySortingOrderbyWeight", "Comparission not done", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (flag == 0)
                {
                    Report.UpdateTestLog("VerifySortingOrderbyWeightFinalStep", "Sorting order is preserved", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySortingOrderbyWeight", "Sorting order is not preserved", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateManyQuicklinks", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateManyQuicklinks", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: Uploadfile()
        // Method Decs: This method upload a image in Image Folder under site content
        // Created on:  15th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void Uploadfile()
        {
            try
            {
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string Category = DataTable.GetData("General_Data_" + Env, "RequestType3");
                common.WaitForElement(SiteContentOR.Oselectframe_id);
                ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(SiteContentOR.Oselectframe_id);
                Driver.SwitchTo().Frame(framecoll[0]);
                Report.UpdateTestLog("Uploadfile", " File upload window is opened ", Status.PASS);
                //click on the Choose a file option
                common.WaitForElement(SiteContentOR.oclicktoupload_xpath);
                 Driver.FindElement(SiteContentOR.oclicktoupload_xpath).Click();
                //common.CallMeWait(100);
                Report.UpdateTestLog("Uploadfile", " Choose a file option is clicked ", Status.PASS);
                // enter image path                 
                AutoItX3 autoit = new AutoItX3();

                if (ConfigurationManager.AppSettings["Browser"] == "iexplore")
                { autoit.WinActivate("Choose File to Upload"); }
                else
              { autoit.WinActivate("Open"); }          
               
                common.CallMeWait(2000);
                autoit.Send(requestType1);
                common.CallMeWait(1000);
                autoit.Send("{ENTER}");                
                common.CallMeWait(1000);
                //click on Ok button
                common.WaitForElement(SiteContentOR.oclickokbutton_xpath);
                Driver.FindElement(SiteContentOR.oclickokbutton_xpath).Click();
                common.CallMeWait(2000);
                //select category
                if (Category.Any())
                {
                    if (common.CheckElement(SiteContentOR.oDocIntranetCategory_xpath) == true)
                    {
                        Driver.FindElement(SiteContentOR.oDocIntranetCategory_xpath).Click();
                        Report.UpdateTestLog("Uploadfile", " Clicked on Intranet Category text field ", Status.PASS);
                        Driver.FindElement(SiteContentOR.oDocIntranetCategory_xpath).SendKeys(Category);
                        Report.UpdateTestLog("Uploadfile", " Entered category in Intranet Category text field ", Status.PASS);
                        common.CallMeWait(1000);
                    }
                    else
                    {
                        Report.UpdateTestLog("Uploadfile", " Intranet Category text field is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                //Click on the save option 
                common.WaitForElement(SiteContentOR.Oclicktosave_xpath);
                Report.UpdateTestLog("Uploadfile", " file path is selected ", Status.PASS);
                Driver.FindElement(SiteContentOR.Oclicktosave_xpath).Click();
                Report.UpdateTestLog("UploadfileFinalStep", " file save button is clicked ", Status.PASS);
                common.CallMeWait(2000);
                Driver.SwitchTo().DefaultContent();
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Uploadfile", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Uploadfile", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeleteAImage()
        // Method Decs: This method delete a image in Image Folder under site content
        // Created on:  15th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void DeleteAImage()
        {
            try
            {
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");

                ReadOnlyCollection<IWebElement> allimages = Driver.FindElements(By.XPath("//*[@id='onetidDoclibViewTbl0']/tbody/tr/td/child::*[1]/child::*"));

                for (int k = 0; k < allimages.Count; k++)
                {
                    string imagetext = allimages[k].Text.Trim();
                    if (requestType1.Contains(imagetext))
                    {
                        // common.CallMeWait(2000);
                        Actions a = new Actions(Driver);
                        a.ClickAndHold(allimages[k]);
                        a.Perform();
                        allimages[k].Click();
                        common.CallMeWait(1000);
                        Driver.FindElement(
                            By.XPath("//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")).Click();
                        Driver.SwitchTo().Alert().Accept();
                        common.CallMeWait(1000);
                        Report.UpdateTestLog("DeleteAImageFinalStep", " Image is deleted ", Status.PASS);
                        break;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteAImage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteAImage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyCheckOutlink()
        // Method Decs: This method verifies the check out link is present or not in (...) option of image
        // Created on:  15th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyCheckOutlink()
        {
            try
            {
                int flag = 0;
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                ReadOnlyCollection<IWebElement> allimages = Driver.FindElements(By.XPath("//*[@id='onetidDoclibViewTbl0']/tbody/tr/td/child::*[1]/child::*"));

                for (int k = 0; k < allimages.Count; k++)
                {
                    string imagetext = allimages[k].Text.Trim();
                    if (requestType1.Contains(imagetext))
                    {
                        string findxpath =
                  "//*[@id='onetidDoclibViewTbl0']/tbody/tr/td/child::*[1]/child::*[last()]/div/child::*[2]/a[2]";
                        Actions builder = new Actions(Driver);
                        builder.ClickAndHold(Driver.FindElement(By.XPath("//*[@id='onetidDoclibViewTbl0']/tbody/tr/td/child::*[1]/child::*[last()]/div/div")));
                        builder.Perform();
                        common.CallMeWait(2000);
                        common.WaitForElement(By.XPath(findxpath));
                        Driver.FindElement(By.XPath(findxpath)).Click();
                        common.CallMeWait(2000);

                        IWebElement wbe = Driver.FindElement(By.XPath("//*[contains(@id, '_callout-content')]"));
                        ReadOnlyCollection<IWebElement> links = wbe.FindElements(By.TagName("a"));
                        foreach (IWebElement link in links)
                        {
                            String href = link.GetAttribute("href");
                            if (href.Contains("checkout"))
                            {
                                flag = 1;
                                break;

                            }
                        }
                    }
                }

                if (flag == 0)
                {
                    Report.UpdateTestLog("verifyUploadImageFinalStep", " Check out link is not present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("verifyUploadImage", " Check out link is present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCheckOutlink", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyCheckOutlink", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateBlogFolderInPages()
        // Method Decs: This method will click on page 
        // Created on:  10th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ValidateBlogFolderInPages()
        {
            try
            {
                bool flag = false;
                string pageName = DataTable.GetData("General_Data_" + Env, "PageName").Trim();
                ReadOnlyCollection<IWebElement> elms =
                    Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                for (int i = 1; i < elms.Count; i++)
                {
                    string pageValue = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]/div/a")).Text;
                    string folder = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[2]/a/img")).GetAttribute("src");
                    if (pageValue.Contains(pageName) && folder.Contains("folder.gif"))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    Report.UpdateTestLog("ValidateBlogFolderInPagesFinalStep", " Successfully validated that blog folder is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateBlogFolderInPages", " Blog folder is not present in Pages", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateBlogFolderInPages", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateBlogFolderInPages", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreatePageWithBlogLayout()
        // Method Decs: This method will create a page with blog lauout 
        // Created on:  02/21/2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void CreatePageWithBlogLayout()
        {
            try
            {
                int flag = 0;
                string pagename1 = DataTable.GetData("General_Data_" + Env, "PageName").Trim();
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string pagename = pagename1 + "_" + ArticleDate;
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.oCreateIntBlogPage_xpath);
                Driver.FindElement(SiteContentOR.oCreateIntBlogPage_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.otitleTextBox_xpath);
                Driver.FindElement(SiteContentOR.otitleTextBox_xpath).SendKeys(pagename);
                common.WaitForElement(SiteContentOR.oBlogLayout_xpath);
                Driver.FindElement(SiteContentOR.oBlogLayout_xpath).Click();
                common.WaitForElement(SiteContentOR.ocreatepage_xpath);
                Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (common.CheckElement((SiteContentOR.ofilelink_xpath)) == true)
                {
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("CreatePageWithBlogLayoutFinalStep", pagename + "  Page is cretaed",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreatePageWithBlogLayout", "Unable to create page" + pagename,
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreatePageWithBlogLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreatePageWithBlogLayout", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeleteBlogPage()
        // Method Decs: This method will find a page and delete the click on page 
        // Created on:  25th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void DeleteBlogPage()
        {
            int flag = 0;
            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                common.CallMeWait(2000);
                common.WaitForElement(SiteContentOR.oPageTab_xpath);
                Driver.FindElement(SiteContentOR.oPageTab_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.odeletepage_xpath);
                //Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (Driver.FindElement(SiteContentOR.odeletepage_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.odeletepage_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    common.CallMeWait(1000);
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("DeleteBlogPageFinalStep", "Page is deleted ",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("DeleteBlogPage", "Unable to delete the page",
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteBlogPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteBlogPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: Findfile()
        // Method Decs: This method select a file to be  operate
        // Created on:  16th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void Findfile()
        {
            try
            {
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                int i = 1;
                int flags = 0;
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]")).GetAttribute("innerText");
                    if (name.Contains(req2))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    Report.UpdateTestLog("FindfileFinalStep", "file is selected " + req2, Status.PASS);
                    common.CallMeWait(2000);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Findfile", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Findfile", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: Deletefile()
        // Method Decs: This method delete a doc file 
        // Created on:  16th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void Deletefile()
        {
            int flag = 0;
            try
            {
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.odeletedoc_xpath);
                if (Driver.FindElement(SiteContentOR.odeletedoc_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.odeletedoc_xpath).Click();
                    common.CallMeWait(1000);
                    Driver.SwitchTo().Alert().Accept();
                    common.CallMeWait(1000);
                    flag = 1;
                }
                if (flag == 1)
                {
                    Report.UpdateTestLog("DeletefileFinalStep", "File is deleted ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("Deletefile", "Unable to delete the File", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Deletefile", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Deletefile", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectShowNewsForm()
        // Method Decs: This method SelectsShow  NewssForm in Web Part 
        // Created on:  16th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectShowNewsForm()
        {
            try
            {
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                common.WaitForElement(SiteContentOR.oshownewsform_id);
                if (Driver.FindElement(SiteContentOR.oshownewsform_id).Displayed)
                {
                    Report.UpdateTestLog("SelectShowNewsForm", "Form Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oshownewsform_id));
                    oselect.SelectByText(req3);
                    Report.UpdateTestLog("SelectShowNewsFormFinalStep", "Form Drop is selected as :" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectShowNewsForm", "Form in Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectShowNewsForm", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectShowNewsForm", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyDisablefield()
        // Method Decs: This method verifies the primary Servisec,Location and Location group when New Form is selected as This Site
        // Created on:  16th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyDisablefield()
        {
            try
            {
                //primary Services
                common.WaitForElement(SiteContentOR.oprimaryServiceTerm_id);
                if (Driver.FindElement(SiteContentOR.oprimaryServiceTerm_id).Displayed)
                {
                    Report.UpdateTestLog("VerifyDisablefield", "Primary Services option is present", Status.PASS);
                    string checkdisable = Driver.FindElement(SiteContentOR.oprimaryServiceTerm_id).GetAttribute("disabled").Trim();
                    if (checkdisable.Equals("true"))
                    {
                        Report.UpdateTestLog("VerifyDisablefield", "Primary Services option is disabled", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyDisablefield", "Primary Services option is enabled", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyDisablefield", "Primary Services option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Location
                common.WaitForElement(SiteContentOR.olocationTerm_id);
                if (Driver.FindElement(SiteContentOR.olocationTerm_id).Displayed)
                {
                    Report.UpdateTestLog("VerifyDisablefield", "Location option is present", Status.PASS);
                    string checkdisable = Driver.FindElement(SiteContentOR.olocationTerm_id).GetAttribute("disabled").Trim();
                    if (checkdisable.Equals("true"))
                    {
                        Report.UpdateTestLog("VerifyDisablefield", "Location option is disabled", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyDisablefield", "Location option is enabled", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyDisablefield", "Location option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Location Group
                common.WaitForElement(SiteContentOR.olocationgroup_id);
                if (Driver.FindElement(SiteContentOR.olocationgroup_id).Displayed)
                {
                    Report.UpdateTestLog("VerifyDisablefield", "Primary Services option is present", Status.PASS);
                    string checkdisable = Driver.FindElement(SiteContentOR.olocationgroup_id).GetAttribute("disabled").Trim();
                    if (checkdisable.Equals("true"))
                    {
                        Report.UpdateTestLog("VerifyDisablefieldFinalStep", "Primary Services option is disabled", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyDisablefield", "Primary Services option is enabled", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyDisablefield", "Primary Services option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyDisablefield", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyDisablefield", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyEnablefield()
        // Method Decs: This method verifies the primary Servisec,Location and Location group when New Form is selected as This Site
        // Created on:  17th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyEnablefield()
        {
            try
            {
                //primary Services
                common.WaitForElement(SiteContentOR.oprimaryServicebutton_id);
                Driver.FindElement(SiteContentOR.oprimaryServicebutton_id).Click();
                common.CallMeWait(500);
                Report.UpdateTestLog("VerifyEnablefield", "Click on primary Services option ", Status.DONE);

                common.WaitForElement(SiteContentOR.oprimaryServicelabel_id);
                string str = Driver.FindElement(SiteContentOR.oprimaryServicelabel_id).Text.Trim();
                if (str.Equals("Primary Service"))
                {
                    Report.UpdateTestLog("VerifyEnablefield", "primary Services option is Ebabled", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyEnablefield", "primary Services option is not Ebabled", Status.PASS);
                }

                common.WaitForElement(SiteContentOR.oprimaryServiceclosebutton_id);
                Driver.FindElement(SiteContentOR.oprimaryServiceclosebutton_id).Click();
                Report.UpdateTestLog("VerifyEnablefield", "Click on Close Button ", Status.DONE);

                //Location
                common.WaitForElement(SiteContentOR.olocationbutton_id);
                Driver.FindElement(SiteContentOR.olocationbutton_id).Click();
                common.CallMeWait(500);
                Report.UpdateTestLog("VerifyEnablefield", "Click on Location option ", Status.DONE);

                common.WaitForElement(SiteContentOR.olocationlabel_id);
                str = Driver.FindElement(SiteContentOR.olocationlabel_id).Text.Trim();
                if (str.Equals("Location"))
                {
                    Report.UpdateTestLog("VerifyEnablefield", "Location option is Ebabled", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyEnablefield", "Location option is not Ebabled", Status.PASS);
                }

                common.WaitForElement(SiteContentOR.olocationclosebutton_id);
                Driver.FindElement(SiteContentOR.olocationclosebutton_id).Click();
                Report.UpdateTestLog("VerifyEnablefield", "Click on Close Button ", Status.DONE);

                //Location Group
                common.WaitForElement(SiteContentOR.olocationgroupbutton_id);
                Driver.FindElement(SiteContentOR.olocationgroupbutton_id).Click();
                common.CallMeWait(500);
                Report.UpdateTestLog("VerifyEnablefield", "Click on Location Group option ", Status.DONE);

                common.WaitForElement(SiteContentOR.olocationgrouplabel_id);
                str = Driver.FindElement(SiteContentOR.olocationgrouplabel_id).Text.Trim();
                if (str.Equals("Location Group"))
                {
                    Report.UpdateTestLog("VerifyEnablefield", "Location Group option is Ebabled", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyEnablefield", "Location Group option is not Ebabled", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.WaitForElement(SiteContentOR.olocationgroupclosebutton_id);
                Driver.FindElement(SiteContentOR.olocationgroupclosebutton_id).Click();
                Report.UpdateTestLog("VerifyEnablefieldFinalStep", "Click on Close Button ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyEnablefield", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyEnablefield", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EnterTitle()
        // Method Decs: This method enters title for the Custome link in edit mode
        // Created on:  17th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void EnterTitle()
        {
            try
            {
                common.WaitForElement(SiteContentOR.ocustomlinktitle_id);
                string ctitle = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                Driver.FindElement(SiteContentOR.ocustomlinktitle_id).Clear();
                Driver.FindElement(SiteContentOR.ocustomlinktitle_id).SendKeys(ctitle);
                Report.UpdateTestLog("EnterTitleFinalStep", "Title entered as " + ctitle, Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterTitle", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterTitle", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: EnterLocation()
        // Method Decs: This method enters location for the News link in edit mode
        // Created on:  17th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void EnterLocation()
        {
            try
            {
                common.WaitForElement(SiteContentOR.olocationTerm_id);
                string location = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                Driver.FindElement(SiteContentOR.olocationTerm_id).Clear();
                Driver.FindElement(SiteContentOR.olocationTerm_id).SendKeys(location);
                Report.UpdateTestLog("EnterLocationFinalStep", "Location entered as " + location, Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterLocation", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterLocation", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: DisplayEmbededImages()
        // Method Decs: This method allows multi media to be displayed in Social Media Web Part 
        // Created on:  17th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void DisplayEmbededImages()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.odisplayimagecheckbox_id) == true)
                {
                    if (Driver.FindElement(SiteContentOR.odisplayimagecheckbox_id).Selected)
                    {
                        Report.UpdateTestLog("DisplayEmbededImagesFinalStep", " Display Embeded Images is already selected", Status.PASS);
                    }
                    else
                    {
                        Driver.FindElement(SiteContentOR.odisplayimagecheckbox_id).Click();
                        Report.UpdateTestLog("DisplayEmbededImagesFinalStep", " Display Embeded Images is selected", Status.PASS);
                    }
                }
                else
                {
                    Report.UpdateTestLog("DisplayEmbededImages", " Display Embeded Images is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DisplayEmbededImages", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DisplayEmbededImages", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: TwitterStreamFunctionality()
        // Method Decs: This method will Verify  the functionality of the DocumentLinks web part login as Auhor
        // Created on: 17th Feb 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void TwitterStreamFunctionality()
        {
            try
            {
                ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(By.XPath("//*[@id='twitter-widget-0']"));
                Driver.SwitchTo().Frame(framecoll[0]);

                // Driver.SwitchTo().framecoll;
                //common.WaitForElement(SiteContentOR.oclicktonewitem_xpath);

                int x = 1;
                //  bool t= Driver.FindElement(SiteContentOR.otwittertext_id).Displayed;
                // common.WaitForElement(SiteContentOR.otwittertext_id);

                string twittertext = Driver.FindElement(SiteContentOR.otwittertext_id).Text.Trim();
                int flag = 0;
                if (twittertext.Contains("Tweets"))
                {
                    flag = 1;

                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(SiteContentOR.otwitterlinksonpage_class);
                    if (elmsElements1.Count > 4)
                    {
                        x = 4;
                    }
                    else
                    {
                        x = elmsElements1.Count;
                    }
                    Report.UpdateTestLog("TwitterStreamFunctionality", "Twitter Blocks are present", Status.PASS);
                    Driver.SwitchTo().DefaultContent();
                }
                else
                {
                    Report.UpdateTestLog("TwitterStreamFunctionality", "Twitter Blocks are Not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    Driver.SwitchTo().DefaultContent();
                }
                if (flag == 1)
                {
                    ReadOnlyCollection<IWebElement> elmsElements2 = Driver.FindElements(SiteContentOR.otwitterlinksonpage_class);
                    for (int i = 0; i < x; i++)
                    {
                        ReadOnlyCollection<IWebElement> framecoll1 = Driver.FindElements(By.XPath("//*[@id='twitter-widget-0']"));
                        Driver.SwitchTo().Frame(framecoll1[0]);
                        elmsElements2 = Driver.FindElements(SiteContentOR.otwitterlinksonpage_class);
                        string linkname = elmsElements2[i].Text.Trim();
                        string linkvalue = elmsElements2[i].GetAttribute("href").Trim();
                        elmsElements2[i].Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("TwitterStreamFunctionality", "clicked on " + linkname, Status.DONE);
                        Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                        string newurl = Driver.Url.Trim();
                        if (newurl.Contains(linkvalue))
                        {
                            Report.UpdateTestLog("TwitterStreamFunctionalityFinalStep", "Successfully Navigated to the " + newurl, Status.PASS);
                            Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
                            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                            common.CallMeWait(1000);
                        }
                        else
                        {
                            Report.UpdateTestLog("TwitterStreamFunctionality", "Unable to Navigate to " + newurl, Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
                            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                            common.CallMeWait(1000);
                        }

                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("TwitterStreamFunctionality", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("TwitterStreamFunctionality", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateBlogWebPart()
        // Method Decs: This method will Verify  Blog Web Part
        // Created on: 02/22/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateBlogWebPart()
        {
            try
            {
                string webParts = DataTable.GetData("General_Data_" + Env, "WebParts").Trim();
                if (common.CheckElement(SiteContentOR.oBlog_XPath) == true)
                {
                    if (Driver.FindElement(SiteContentOR.oBlog_XPath).Text.Trim().Contains(webParts))
                    {
                        Report.UpdateTestLog("ValidateBlogWebPartFinalStep", " Successfully validated that Blog is added and displayed in page ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateBlogWebPart", " Blog is not added and not displayed in page ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateBlogWebPart", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateBlogWebPart", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreateBlog()
        // Method Decs: This method will create Blog after entering the details
        // Created on: 02/23/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void CreateBlog()
        {
            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("CreateBlog", " Click on Edit Page  ", Status.DONE);
                common.CallMeWait(5000);
                // Enter Blog Article Topic
                string ArticleTopic1 = DataTable.GetData("General_Data_" + Env, "PageName").Trim();
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string ArticleTopic = ArticleTopic1 + "_" + ArticleDate;
                string BlogArticleDate = today.ToString("MM/dd/yyyy");
                DateTime Futureday = today.AddDays(60);
                string PublishEndDate = Futureday.ToString("MM/dd/yyyy");
                if (common.CheckElement(SiteContentOR.oBlogArticleTopic_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogArticleTopic_XPath).Click();
                    Driver.FindElement(SiteContentOR.oBlogArticleTopic_XPath).SendKeys(ArticleTopic);
                    Report.UpdateTestLog("CreateBlog", " Entered Blog Article Topic :" + ArticleTopic, Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " Blog Article Topic field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Blog Article Author
                string Author = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(SiteContentOR.oBlogArticleAuthor_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogArticleAuthor_XPath).Click();
                    Driver.FindElement(SiteContentOR.oBlogArticleAuthor_XPath).SendKeys(Author);
                    Report.UpdateTestLog("CreateBlog", " Entered Blog Article Author", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " Blog Article Author field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Enter Blog Article Date
                
                if (common.CheckElement(SiteContentOR.oBlogArticleDate_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogArticleDate_XPath).Click();
                    Driver.FindElement(SiteContentOR.oBlogArticleDate_XPath).SendKeys(BlogArticleDate);
                    Report.UpdateTestLog("CreateBlog", " Entered Blog Article Date", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " Blog Article Date field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Enter Blog Page Content
                string PageContent = ArticleTopic1 + "_Content";
                if (common.CheckElement(SiteContentOR.oBlogContent_id) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogContent_id).Click();
                    Driver.FindElement(SiteContentOR.oBlogPageContent_XPath).SendKeys(PageContent);
                    Report.UpdateTestLog("CreateBlog", " Entered Blog Article Content", Status.DONE);
                    common.CallMeWait(4000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " Blog Article Content Field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Blog Sub Headline
                string SubHeadline = ArticleTopic1 + "_SubHeadline";
                if (common.CheckElement(SiteContentOR.oBlogArticleSubHeadline_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogArticleSubHeadline_XPath).Click();
                    Driver.FindElement(SiteContentOR.oBlogArticleSubHeadline_XPath).SendKeys(SubHeadline);
                    Report.UpdateTestLog("CreateBlog", " Entered Blog Article Sub Headline", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " Blog Article Sub Headline Field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Blog Publish Start Date
                if (common.CheckElement(SiteContentOR.oBlogPublishStartDate_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogPublishStartDate_XPath).Click();
                    Driver.FindElement(SiteContentOR.oBlogPublishStartDate_XPath).SendKeys(BlogArticleDate);
                    Report.UpdateTestLog("CreateBlog", " Entered Blog Article Publish Start Date", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " Blog Article Publish Start Date field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Blog Publish End Date
                if (common.CheckElement(SiteContentOR.oBlogPublishEndDate_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogPublishEndDate_XPath).Click();
                    Driver.FindElement(SiteContentOR.oBlogPublishEndDate_XPath).SendKeys(PublishEndDate);
                    Report.UpdateTestLog("CreateBlog", " Entered Blog Article Publish End Date", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " Blog Article Publish End Date field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Check Allow Commenting checkbox
                string Comment = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();
                if(Comment.Any())
                {
                    if (common.CheckElement(SiteContentOR.oBlogAllowCommenting_XPath) == true)
                    {
                        Driver.FindElement(SiteContentOR.oBlogAllowCommenting_XPath).Click();
                        Report.UpdateTestLog("CreateBlog", " Checked Allow Commenting checkbox", Status.DONE);
                        common.CallMeWait(2000);
                    }
                    else
                    {
                        Report.UpdateTestLog("CreateBlog", " Allow Commenting checkbox is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " Unchecked Allow Commenting checkbox", Status.DONE);
                }
                // Click on Save
                if (common.CheckElement(SiteContentOR.oBlogSave_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogSave_XPath).Click();
                    Report.UpdateTestLog("CreateBlogFinalStep", " Clicked on Save button", Status.PASS);
                    common.CallMeWait(5000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBlog", " save button is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateBlog", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateBlog", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateCommentAndLikeInBlog()
        // Method Decs: This method will validate comment and like functionality in Blog
        // Created on: 02/23/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateCommentAndLikeInBlog()
        {
            try
            {
                string like = Driver.FindElement(SiteContentOR.oBlogLikeCount_XPath).Text.Trim();
                if (like.Contains("0"))
                {
                    Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Like Count is 0", Status.PASS);
                }
                if (common.CheckElement(SiteContentOR.oBlogLike_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogLike_XPath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Clicked on Like button", Status.DONE);
                    like = Driver.FindElement(SiteContentOR.oBlogLikeCount_XPath).Text.Trim();
                    if (like.Contains("1"))
                    {
                        Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Successfully validated that after clicking on the like button like count is increased", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " After clicking on the like button like count is not increased", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Like button is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                string comment = Driver.FindElement(SiteContentOR.oBlogCommentCount_XPath).Text.Trim();
                if (comment.Contains("0"))
                {
                    Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Comment Count is 0", Status.PASS);
                }
                if (common.CheckElement(SiteContentOR.oBlogCommentArea_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogCommentArea_XPath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Clicked on comment Area ", Status.DONE);
                    Driver.FindElement(SiteContentOR.oBlogCommentArea_XPath).SendKeys("Test Comment");
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Entered comment on comment Area ", Status.DONE);
                    Driver.FindElement(SiteContentOR.oBlogPostCommentButton_XPath).Click();
                    Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Clicked on Post Comment button ", Status.DONE);
                    common.CallMeWait(1000);
                    comment = Driver.FindElement(SiteContentOR.oBlogCommentCount_XPath).Text.Trim();
                    if (comment.Contains("1"))
                    {
                        Report.UpdateTestLog("ValidateCommentAndLikeInBlogFinalStep", " Successfully validated that after entering comment, count is increased", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " After entering comment, count is not increased", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Comment section is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCommentAndLikeInBlog", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCommentAndLikeInBlog", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: NavigateToBlogFolder()
        // Method Decs: This method will Navigate To Blog Folder 
        // Created on:  10th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void NavigateToBlogFolder()
        {
            try
            {
                bool flag = false;
                //string pageName = DataTable.GetData("General_Data_" + Env, "PageName").Trim();
                ReadOnlyCollection<IWebElement> elms =
                    Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                for (int i = 1; i < elms.Count; i++)
                {
                    string pageValue = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]/div/a")).Text;
                    string folder = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[2]/a/img")).GetAttribute("src");
                    if (pageValue.Contains("Blogs") && folder.Contains("folder.gif"))
                    {
                        Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]/div/a")).Click();
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    Report.UpdateTestLog("NavigateToBlogFolderFinalStep", " Successfully navigated to blog folder ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("NavigateToBlogFolder", " Blog folder is not present in Pages", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigateToBlogFolder", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToBlogFolder", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: UploadBlogfile()
        // Method Decs: This method upload a Blog in blog Folder under site content
        // Created on:  23rd Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void UploadBlogfile()
        {
            try
            {
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                common.WaitForElement(SiteContentOR.Oselectframe_id);
                ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(SiteContentOR.Oselectframe_id);
                Driver.SwitchTo().Frame(framecoll[0]);
                Report.UpdateTestLog("UploadBlogfile", " File upload window is opened ", Status.PASS);
                //click on the Choose a file option
                common.WaitForElement(SiteContentOR.oclicktoupload_xpath);
                Driver.FindElement(SiteContentOR.oclicktoupload_xpath).Click();
                Report.UpdateTestLog("UploadBlogfile", " Choose a file option is clicked ", Status.PASS);
                // enter image path                 
                AutoItX3 autoit = new AutoItX3();
                autoit.WinActivate("Open");
                autoit.Send(requestType1);
                autoit.Send("{ENTER}");                
                common.CallMeWait(1000);
                //click on Ok button
                common.WaitForElement(SiteContentOR.oclickokbutton_xpath);
                Driver.FindElement(SiteContentOR.oclickokbutton_xpath).Click();            
                common.CallMeWait(2000);
                if (common.CheckElement(SiteContentOR.oBlogCheckIn_id) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogCheckIn_id).Click();
                    Report.UpdateTestLog("UploadBlogfile", " Checked-in Blog ", Status.PASS);
                    common.CallMeWait(1000);
                }               
                Driver.SwitchTo().DefaultContent();
                // Check-in Blog
                //ReadOnlyCollection<IWebElement> framecoll1 = Driver.FindElements(By.XPath("//iframe[contains(@id, 'DlgFrame')]"));
               // Driver.SwitchTo().Frame(framecoll1[0]);

                //////////
                // Handle frame
                if (common.CheckElement(SiteContentOR.oFrameBlog_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> framecoll1 = Driver.FindElements(SiteContentOR.oFrameBlog_xpath);
                    Driver.SwitchTo().Frame(framecoll1[0]);
                    if(common.CheckElement(SiteContentOR.oGoBackToSite_xpath) == true)
                    {
                    Driver.FindElement(SiteContentOR.oGoBackToSite_xpath).Click();
                    Report.UpdateTestLog("UploadBlogfileFinalStep", " Click on Go Back To Site ", Status.PASS);
                    common.CallMeWait(2000);
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("UploadBlogfile", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("UploadBlogfile", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        
        }

        //******************************************************
        // Method Name: EnterNameAndCreate()
        // Method Decs: This method Enter name of the page and click on create button
        // Created on:  24th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void EnterNameAndCreate()
        {
            try
            {
                string PageTitle1 = DataTable.GetData("General_Data_" + Env, "PageName").Trim();
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string PageTitle = PageTitle1 + "_" + ArticleDate;
                //ReadOnlyCollection<IWebElement> detailFrame = Driver.FindElements(By.XPath("//iframe"));
                ReadOnlyCollection<IWebElement> detailFrame = Driver.FindElements(SiteContentOR.oFrameBlog_xpath);
                Driver.SwitchTo().Frame(detailFrame[0]);
                if (common.CheckElement(SiteContentOR.oAddName_id) == true)
                {
                    Driver.FindElement(SiteContentOR.oAddName_id).Click();
                    Driver.FindElement(SiteContentOR.oAddName_id).SendKeys(PageTitle);
                    Report.UpdateTestLog("EnterNameAndCreate", " Entered Page Name: " + PageTitle, Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("EnterNameAndCreate", " Enter Page Name Field is not found " , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.oCreateButton_value) == true)
                {
                    Driver.FindElement(SiteContentOR.oCreateButton_value).Click();
                    Report.UpdateTestLog("EnterNameAndCreateFinalStep", " Clicked on Create button ", Status.PASS);
                    Driver.SwitchTo().DefaultContent();
                    common.CallMeWait(5000);
                }
                else
                {
                    Report.UpdateTestLog("EnterNameAndCreate", " Create button is not found " , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterNameAndCreate", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterNameAndCreate", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidatePageLayout()
        // Method Decs: This method will validate the page layout
        // Created on:  24th Feb 2017
        // Created by:  GI offshore Team		
        //**************************************************** 

        public void ValidatePageLayout()
        {
            try
            {
                common.CallMeWait(2000);
                    ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.oPageColumns_XPath);
                    int totalCount = elms.Count;
                    int columncount = totalCount - 1;
                    if (columncount > 0)
                    {
                        Report.UpdateTestLog("ValidatePageLayoutFinalStep", " Page Layout has " + columncount + " columns ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidatePageLayout", " Page Layout doesn't have any column ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidatePageLayout", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidatePageLayout", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: SetTodayEvent()
        // Method Decs: This method selectes today date for the event
        // Created on: 22th Feb 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void SetTodayEvent()
        {
            try
            {
                string finalstring = null;
                DateTime today = DateTime.Today;
                finalstring = today.ToString().Split(' ')[0];
                string path = "//*[@date='" + finalstring + "']";
                Actions action = new Actions(Driver);
                action.MoveToElement(Driver.FindElement(By.XPath(path)));
                action.Perform();
                common.CallMeWait(2000);
                if (Driver.FindElement(SiteContentOR.oaddevent_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oaddevent_xpath).Click();
                    common.CallMeWait(2000);
                    SendKeys.SendWait(@"{Enter}");
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("SetTodayEventFinalStep", "Clicked on Add option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SetTodayEvent", "Add Option is not displayed", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SetTodayEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SetTodayEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EnterDetailsforEvent()
        // Method Decs: This method enters detail for the event like Title data description etc.
        // Created on: 22th Feb 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void EnterDetailsforEvent()
        {
            try
            {
                DateTime today = DateTime.Today;
                string todatdate = today.ToString().Split(' ')[0];
                string enevttitle = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                string enevtdesc = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                ReadOnlyCollection<IWebElement> framecoll1 = Driver.FindElements(By.XPath("//iframe[contains(@id, 'DlgFrame')]"));
                Driver.SwitchTo().Frame(framecoll1[0]);

                common.WaitForElement(SiteContentOR.oeventtitle_xpath);
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).Click();
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).SendKeys(enevttitle);
                Report.UpdateTestLog("EnterDetailsforEvent", "Title is entered :" + enevttitle, Status.DONE);

                common.WaitForElement(SiteContentOR.oeventstartdate_xpath);
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).Click();
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).SendKeys(todatdate);
                Report.UpdateTestLog("EnterDetailsforEvent", "start date entered " + todatdate, Status.DONE);

                common.WaitForElement(SiteContentOR.oeventenddate_xpath);
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).SendKeys(todatdate);
                Report.UpdateTestLog("EnterDetailsforEvent", "End Date Entered" + todatdate, Status.DONE);

                common.WaitForElement(SiteContentOR.ocalenderdesc_xpath);
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).Click();
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).Clear();
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).SendKeys(enevtdesc);
                Report.UpdateTestLog("EnterDetailsforEventFinalStep", "Description entered" + enevtdesc, Status.PASS);

                string req5 = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                if (req5.Any())
                {
                    try
                    {
                        common.WaitForElement(SiteContentOR.oeventcategory_xpath);
                        Driver.FindElement(SiteContentOR.oeventcategory_xpath).Click();
                        Driver.FindElement(SiteContentOR.oeventcategory_xpath).SendKeys(req5);
                        Report.UpdateTestLog("EnterDetailsforEvent", "Entered event category :" + req5, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterDetailsforEvent", "unable to enter categary", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (req2.Any())
                {
                    try
                    {
                        common.WaitForElement(SiteContentOR.oeventprimariservice_xpath);
                        Driver.FindElement(SiteContentOR.oeventprimariservice_xpath).Clear(); ;
                        Driver.FindElement(SiteContentOR.oeventprimariservice_xpath).Click();
                        Driver.FindElement(SiteContentOR.oeventprimariservice_xpath).SendKeys(req2);
                        Report.UpdateTestLog("EnterDetailsforEvent", "Entered event primery services :" + req2, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterDetailsforEvent", "unable to enter primery services", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                if (req3.Any())
                {
                    try
                    {
                        common.WaitForElement(SiteContentOR.oeventpicture_xpath);
                        Driver.FindElement(SiteContentOR.oeventpicture_xpath).Clear();
                        Driver.FindElement(SiteContentOR.oeventpicture_xpath).Click();
                        Driver.FindElement(SiteContentOR.oeventpicture_xpath).SendKeys(req3);
                        Report.UpdateTestLog("EnterDetailsforEvent", "Entered event picture :" + req3, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterDetailsforEvent", "unable to enter picture", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterDetailsforEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterDetailsforEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SaveEvent()
        // Method Decs: This method click to save option to save event
        // Created on: 22th Feb 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void SaveEvent()
        {
            try
            {
                common.WaitForElement(SiteContentOR.osavebutton_id);
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.osavebutton_id);
                if (elms.Count > 1)
                {
                    elms[1].Click();
                    Report.UpdateTestLog("SaveEventFinalStep", "Save option is clicked", Status.DONE);
                }
                else
                {
                    elms[0].Click();
                    Report.UpdateTestLog("SaveEventFinalStep", "Save option is clicked", Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SaveEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SaveEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }



        //******************************************************
        // Method Name: FindAEvent()
        // Method Decs: This method find the event with name
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void FindAEvent()
        {
            try
            {
                string eventname = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                string path = "//*[text()=\"" + eventname + "\"]";
                common.WaitForElement(By.XPath(path));
                if (Driver.FindElement(By.XPath(path)).Displayed)
                {
                    Driver.FindElement(By.XPath(path)).Click();
                    Report.UpdateTestLog("FindAEventFinalStep", "Event is found and clicked " + eventname, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("FindAEvent", "Unable to find Event : " + eventname, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("FindAEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindAEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: Approveprocess()
        // Method Decs: This method selected required field in oder to approve
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void Approveprocess()
        {
            try
            {
                string eventdesc = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                common.WaitForElement(SiteContentOR.oapprove_xpath);
                Driver.FindElement(SiteContentOR.oapprove_xpath).Click();
                Report.UpdateTestLog("Approveprocess", "Clicked on Approve/Reject option ", Status.PASS);

                common.WaitForElement(SiteContentOR.oallaprroveradio_xpath);
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.oallaprroveradio_xpath);
                if (elms.Count > 1)
                {
                    elms[0].Click();
                    Report.UpdateTestLog("Approveprocess", "Seelcted Approve radio button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("Approveprocess", "Unable to find Approve radio option ", Status.DONE);
                }
                common.WaitForElement(SiteContentOR.oapprovecomment_xpath);
                Driver.FindElement(SiteContentOR.oapprovecomment_xpath).Clear();
                Driver.FindElement(SiteContentOR.oapprovecomment_xpath).SendKeys(eventdesc);
                Report.UpdateTestLog("Approveprocess", "Comment is entered ", Status.PASS);

                common.WaitForElement(SiteContentOR.oapproveok_xpath);
                Driver.FindElement(SiteContentOR.oapproveok_xpath).Click();
                common.CallMeWait(1000);
                Report.UpdateTestLog("ApproveprocessFinalStep", "Clicked on Ok option ", Status.PASS);


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Approveprocess", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Approveprocess", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: FindAEvent()
        // Method Decs: This method call the FindAEvent funtion 
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void FindAEventagain()
        {
            FindAEvent();
        }

        //******************************************************
        // Method Name: DeleteAEvent()
        // Method Decs: This method Delete The find event funtion 
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void DeleteAEvent()
        {
            try
            {
                int flag = 0;
                common.WaitForElement(SiteContentOR.odeleteevent_xpath);

                if (Driver.FindElement(SiteContentOR.odeleteevent_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.odeleteevent_xpath).Click();
                    common.CallMeWait(1000);
                    Driver.SwitchTo().Alert().Accept();
                    common.CallMeWait(1000);
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("DeleteAEventFinalStep", "Event is deleted ",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("DeleteAEvent", "Unable to delete the Event",
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteAEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteAEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: Verifyeventaftercreation()
        // Method Decs: This method verify created event on the page
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void Verifyeventaftercreation()
        {
            try
            {
                string eventname = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                string path = "//*[text()='" + eventname + "']";
                try
                {
                    if (Driver.FindElement(By.XPath(path)).Displayed)
                    {
                        Report.UpdateTestLog("VerifyeventaftercreationFinalStep", "Event is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("Verifyeventaftercreation", "Event is not present : " + eventname, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                catch (Exception)
                {
                    Report.UpdateTestLog("Verifyeventaftercreation", "Event is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Verifyeventaftercreation", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Verifyeventaftercreation", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: NavigateToEvent()
        // Method Decs: This method Navigate to Event folder under site content
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void NavigateToEvent()
        {
            ClickOnTopNavigationItem();
            ClickOnSubMenuTopNavigationItem();
            ClickOnSiteContentsItem();
        }

        //******************************************************
        // Method Name: NavigatetoPageLibrary()
        // Method Decs: This method Navigate to Page folder under site content
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void NavigatetoPageLibraryAgain()
        {
            NavigatetoPageLibrary();
        }
        //******************************************************
        // Method Name: FindPageAgain()
        // Method Decs: This method find the page
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void FindPageAgain()
        {
            FindPage();
        }
        //******************************************************
        // Method Name: Verifyeventafterdeletion()
        // Method Decs: This method verify  event on the page after deletion
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void Verifyeventafterdeletion()
        {
            try
            {
                string eventname = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                string path = "//*[text()='" + eventname + "']";
                try
                {
                    if (Driver.FindElement(By.XPath(path)).Displayed)
                    {
                        Report.UpdateTestLog("Verifyeventaftercreation", "Event is present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyeventaftercreationFinalStep", "Event is not present : " + eventname, Status.PASS);
                    }
                }
                catch (Exception)
                {
                    Report.UpdateTestLog("Verifyeventaftercreation", "Event is not present ", Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("Verifyeventafterdeletion", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Verifyeventafterdeletion", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: VerifyEventDetail()
        // Method Decs: This method verify detail for the event on the page
        // Created on:   23rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyEventDetail()
        {
            try
            {
                string eventname = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                string path = "//*[text()='" + eventname + "']/parent::*/following-sibling::*/div[1]";
                try
                {
                    if (Driver.FindElement(By.XPath(path)).Displayed)
                    {
                        Report.UpdateTestLog("VerifyEventDetail", "Detail for event is :" + Driver.FindElement(By.XPath(path)).Text.Trim(), Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEventDetail", "Detail are not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                catch (Exception)
                {
                    Report.UpdateTestLog("VerifyEventDetail", "Detail are not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                string path1 = "//*[@class='cbre-icons icon2-calender']";
                try
                {
                    if (Driver.FindElements(By.XPath(path1)).Count > 0)
                    {
                        Report.UpdateTestLog("VerifyEventDetailFinalStep", "Calender Icon is present", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEventDetail", "Calender Icon is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                catch (Exception)
                {
                    Report.UpdateTestLog("VerifyEventDetail", "Calender Icon is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyEventDetail", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyEventDetail", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: MoveToOtherSite()
        // Method Decs: This method navigate to URL specified as Test data
        // Created on:   24rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void MoveToOtherSite()
        {
            try
            {
                string url = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                Driver.Navigate().GoToUrl(url);
                common.CallMeWait(3000);
                Report.UpdateTestLog("MoveToOtherSiteFinalStep", " Moved to  " + url, Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("MoveToOtherSite", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("MoveToOtherSite", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: MoveToinitialURL()
        // Method Decs: This method navigate to URL specified as Test data
        // Created on:   24rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void MoveToinitialURL()
        {
            try
            {
                string url = DataTable.GetData("General_Data_" + Env, "URL").Trim();
                Driver.Navigate().GoToUrl(url);
                common.CallMeWait(3000);
                Report.UpdateTestLog("MoveToinitialURLFinalStep", " Moved to  " + url, Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("MoveToinitialURL", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("MoveToinitialURL", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: NavigatetoPageLibraryAsSiteOwner()
        // Method Decs: This method navigate page library as site owner 
        // Created on:   24rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void NavigatetoPageLibraryAsSiteOwner()
        {
            ClickOnTopNavigationItem();
            ClickOnSubMenuTopNavigationItem();
            clickOnSiteContentsItemAsSiteOwner1();
        }

        //******************************************************
        // Method Name: ClickToViewAll()
        // Method Decs: This method Click on the View All option for the web part in the page if present 
        // Created on:   24rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void ClickToViewAll()
        {

            try
            {
                if (Driver.FindElement(SiteContentOR.oviewall_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.oviewall_xpath).Click();
                    Report.UpdateTestLog("ClickToViewAllFinalStep", "View All option is clicked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickToViewAll", "View All option is is not present", Status.DONE);
                }
            }
            catch (Exception)
            {
                Report.UpdateTestLog("ClickToViewAll", "View All option is is not present", Status.DONE);
            }

        }

        //******************************************************
        // Method Name: clickOnSiteContentsItemAsSiteOwner1()
        // Method Decs: This method will click on Site Contents item 
        // Created on:  24th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void clickOnSiteContentsItemAsSiteOwner1()
        {
            int flag = 0;
            string pagecontentvalue = DataTable.GetData("General_Data_" + Env, "SiteContentItem").Trim();
            try
            {
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                for (int i = 3; i <= elms.Count; i++)
                {
                    string innerValue =
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text;

                    if (innerValue.Contains(pagecontentvalue))
                    {
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[1]")).Click();
                        flag = 1;
                        common.CallMeWait(5000);
                        break;
                    }
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("clickOnSiteContentsItemAsSiteOwner1", " Not able to find Pages : ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("clickOnSiteContentsItemAsSiteOwner1FinalStep", " Clicked on Item  Pages : " + pagecontentvalue, Status.PASS);
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("clickOnSiteContentsItemAsSiteOwner1", " Error on  method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: NavigateToEventAsSiteOwner()
        // Method Decs: This method navigate Event library as site owner 
        // Created on:   24rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void NavigateToEventAsSiteOwner()
        {
            ClickOnTopNavigationItem();
            ClickOnSubMenuTopNavigationItem();
            clickOnSiteContentsItemAsSiteOwner();
        }
        //******************************************************
        // Method Name: NavigateBackToPage()
        // Method Decs: This method navigate back to the page
        // Created on:   24rd Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void NavigateBackToPage()
        {
            Driver.Navigate().Back();
            common.CallMeWait(2000);
        }

        //******************************************************
        // Method Name: SelectShowEventForm()
        // Method Decs: This method SelectsShow  Event Form in Web Part 
        // Created on:  24th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectShowEventForm()
        {
            try
            {
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                common.WaitForElement(SiteContentOR.oshoweventform_id);
                if (Driver.FindElement(SiteContentOR.oshoweventform_id).Displayed)
                {
                    Report.UpdateTestLog("SelectShowEventForm", "Form Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oshoweventform_id));
                    oselect.SelectByText(req3);
                    Report.UpdateTestLog("SelectShowEventFormFinalStep", "Form Drop is selected as :" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectShowEventForm", "Form in Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectShowEventForm", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectShowEventForm", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickToCbreLogo()
        // Method Decs: This method clicks on the CBRE logo 
        // Created on:   24th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void ClickToCbreLogo()
        {
            try
            {
                common.WaitForElement(SiteContentOR.ocbrehome_id);
                Driver.FindElement(SiteContentOR.ocbrehome_id).Click();
                common.CallMeWait(2000);
                Report.UpdateTestLog("ClickToCbreLogoFinalStep", "Clciked on the CBRE logo", Status.PASS);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToCbreLogo", "unable to clciked on the CBRE logo", Status.DONE);
            }
        }

        //******************************************************
        // Method Name: CountTotlaEventsOnPage()
        // Method Decs: This method  counts total number of event on the page  
        // Created on:   24th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void CountTotlaEventsOnPage()
        {
            try
            {
                common.WaitForElement(SiteContentOR.oeventtitle_id);
                ReadOnlyCollection<IWebElement> eventcount = Driver.FindElements(SiteContentOR.oeventtitle_id);
                Report.UpdateTestLog("CountTotlaEventsOnPageFinalStep", "Total Event Count : " + eventcount.Count, Status.PASS);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CountTotlaEventsOnPage", "No Event is present", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: CountTotlaEventsOnPageAgain()
        // Method Decs: This method  counts total number of event on the page  
        // Created on:   24th Feb 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void CountTotlaEventsOnPageAgain()
        {
            CountTotlaEventsOnPage();
        }

        //******************************************************
        // Method Name: SelectThisSiteBlog()
        // Method Decs: This method Selects this site
        // Created on:  27th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectThisSiteBlog()
        {
            try
            {
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                common.WaitForElement(SiteContentOR.oBlogform_id);
                if (Driver.FindElement(SiteContentOR.oBlogform_id).Displayed)
                {
                    Report.UpdateTestLog("SelectThisSiteBlog", "Form Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oBlogform_id));
                    oselect.SelectByText(req3);
                    Report.UpdateTestLog("SelectThisSiteBlogFinalStep", "Form Drop is selected as :" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectThisSiteBlog", "Form in Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectThisSiteBlog", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectThisSiteBlog", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectAnotherSiteBlog()
        // Method Decs: This method Selects another site
        // Created on:  27th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectAnotherSiteBlog()
        {
            try
            {
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                common.WaitForElement(SiteContentOR.oBlogform_id);
                if (Driver.FindElement(SiteContentOR.oBlogform_id).Displayed)
                {
                    Report.UpdateTestLog("SelectAnotherSiteBlog", "Form Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oBlogform_id));
                    oselect.SelectByText(req3);
                    Report.UpdateTestLog("SelectAnotherSiteBlogFinalStep", "Form Drop is selected as :" + req3, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectAnotherSiteBlog", "Form in Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectAnotherSiteBlog", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectAnotherSiteBlog", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyCustomlinkNavigation()
        // Method Decs: This method will Verify  the functionality of the Custom link  web part login as Auhor
        // Created on: 2nd March 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyCustomlinkNavigation()
        {
            try
            {
                int x = 1, flag = 0;
                if (common.CheckElement(SiteContentOR.ocustomlinktext_xpath))
                {
                    Report.UpdateTestLog("VerifyCustomlinkNavigation", "Custom link web part is present", Status.PASS);
                    flag = 1;
                }
                else
                {
                    Report.UpdateTestLog("VerifyCustomlinkNavigation", "Custom Links web part is Not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(SiteContentOR.ocustomlinklist_xpath);
                    if (elmsElements1.Count >= 2)
                    {
                        x = 2;
                    }
                    for (int i = 0; i < x; i++)
                    {
                        elmsElements1 = Driver.FindElements(SiteContentOR.ocustomlinklist_xpath);
                        string linkname = elmsElements1[i].Text.Trim();
                        string linkvalue = elmsElements1[i].GetAttribute("href").Trim();
                        elmsElements1[i].Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("VerifyCustomlinkNavigation", "clicked on " + linkname, Status.DONE);
                        string newurl = Driver.Url.Trim();
                        if (newurl.Contains(linkvalue))
                        {
                            Report.UpdateTestLog("VerifyCustomlinkNavigationFinalStep", "Successfully Navigated to the " + newurl, Status.PASS);
                            Driver.Navigate().Back();
                            common.CallMeWait(1000);
                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyCustomlinkNavigation", "Navigated to  " + newurl, Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            Driver.Navigate().Back();
                            common.CallMeWait(1000);
                        }

                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCustomlinkNavigation", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyCustomlinkNavigation", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SelectCategoryInEditWebpartbytext()
        // Method Decs: This method select a Category in Web Part 
        // Created on:  14th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectCategoryInEditWebpartbytext()
        {
            try
            {
                string catagery = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                if (common.CheckElement(SiteContentOR.oCategorydropdown_id))
                {
                    Report.UpdateTestLog("SelectCategoryInEditWebpart", "Category Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oCategorydropdown_id));
                    IList<IWebElement> elmcount = oselect.Options;
                    for (int i = 0; i < elmcount.Count; i++)
                    {
                        string s = elmcount[i].Text.Trim();
                        if (s.Contains(catagery))
                        {
                            elmcount[i].Click();
                            Report.UpdateTestLog("SelectCategoryInEditWebpartFinalStep", "Selected Category is " + s, Status.PASS);
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("SelectCategoryInEditWebpart", "Category Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectCategoryInEditWebpart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectCategoryInEditWebpart", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SuiteBarLinkFunctionality()
        // Method Decs: This method will Verify  the corresponding page opens when user click on the My profile,My Team and My office page
        // Created on: 2nd March 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void SuiteBarLinkFunctionality()
        {
            try
            {
                //verifying My profile link
                string myprofile = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string dynamicXpath = "//*[text()='" + myprofile + "']";
                By myprofile_xpath = By.XPath(dynamicXpath);

                if (common.CheckElement(myprofile_xpath))
                {
                    Report.UpdateTestLog("SuiteBarLinkFunctionality", "My profile link is present ", Status.PASS);
                    IWebElement elm = Driver.FindElement(myprofile_xpath);
                    string linkvalue = elm.GetAttribute("href").Trim();
                    elm.Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("SuiteBarLinkFunctionality", "clicked on " + myprofile, Status.DONE);
                    string newurl = Driver.Url.Trim();
                    if (newurl.Contains(linkvalue))
                    {
                        Report.UpdateTestLog("SuiteBarLinkFunctionality", "Successfully Navigated to the " + newurl, Status.PASS);
                        Driver.Navigate().Back();
                        common.CallMeWait(1000);
                    }
                    else
                    {
                        Report.UpdateTestLog("SuiteBarLinkFunctionality", "Navigated to  " + newurl, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        Driver.Navigate().Back();
                        common.CallMeWait(1000);
                    }
                }
                //verifying My Team link
                string myteam = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string dynamicXpath2 = "//*[text()='" + myteam + "']";
                By myteam_xpath = By.XPath(dynamicXpath2);

                if (common.CheckElement(myteam_xpath))
                {
                    Report.UpdateTestLog("SuiteBarLinkFunctionality", "My Team link is present ", Status.PASS);
                    IWebElement elm = Driver.FindElement(myteam_xpath);
                    string linkvalue = elm.GetAttribute("href").Trim();
                    elm.Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("SuiteBarLinkFunctionality", "clicked on " + myteam, Status.DONE);
                    string newurl = Driver.SwitchTo().Window(Driver.WindowHandles[1]).Url.Trim();
                    if (newurl.Contains(linkvalue))
                    {
                        Report.UpdateTestLog("SuiteBarLinkFunctionality", "Successfully Navigated to the " + newurl, Status.PASS);
                        Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
                        Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                        common.CallMeWait(1000);
                    }
                    else
                    {
                        Report.UpdateTestLog("SuiteBarLinkFunctionality", "Navigated to  " + newurl, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
                        Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                        common.CallMeWait(1000);
                    }
                }
                //verifying My office  link
                string myoffice = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string dynamicXpath3 = "//*[text()='" + myoffice + "']";
                By myoffice_xpath = By.XPath(dynamicXpath3);

                if (common.CheckElement(myoffice_xpath))
                {
                    Report.UpdateTestLog("SuiteBarLinkFunctionality", "My Office link is present ", Status.PASS);
                    IWebElement elm = Driver.FindElement(myprofile_xpath);
                    string linkvalue = elm.GetAttribute("href").Trim();
                    elm.Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("SuiteBarLinkFunctionality", "clicked on " + myoffice, Status.DONE);
                    string newurl = Driver.Url.Trim();
                    if (newurl.Contains(linkvalue))
                    {
                        Report.UpdateTestLog("SuiteBarLinkFunctionalityFinalStep", "Successfully Navigated to the " + newurl, Status.PASS);
                        Driver.Navigate().Back();
                        common.CallMeWait(1000);
                    }
                    else
                    {
                        Report.UpdateTestLog("SuiteBarLinkFunctionality", "Navigated to  " + newurl, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        Driver.Navigate().Back();
                        common.CallMeWait(1000);
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SuiteBarLinkFunctionality", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SuiteBarLinkFunctionality", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnSiteContentLink()
        // Method Decs: This method will click on site content link on left nav
        // Created on: 03/08/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickOnSiteContentLink()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oSiteContentLink_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oSiteContentLink_xpath).Click();
                    Report.UpdateTestLog("ClickOnSiteContentLinkFinalStep", " Clicked on Site Contents link on left nav ", Status.PASS);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnSiteContentLink", " Site Contents link is not present on left nav ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnSiteContentLink", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnSiteContentLink", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickOnNewItemBestBet()
        // Method Description : This method will click on the new item on Best Bet page  
        // Created On: 03/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnNewItemBestBet()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oAddNewProvisioningList_class) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oAddNewProvisioningList_class).Click();
                    Report.UpdateTestLog("ClickOnNewItemBestBetFinalStep", " Clicked on new Item link on best bet page ", Status.PASS);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnNewItemBestBet", " New Item link is not present on best bet page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnNewItemBestBet", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnNewItemBestBet", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method CreateBestBet()
        // Method Description : This method will put details and create best bet  
        // Created On: 03/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void CreateBestBet()
        {
            try
            {
                string Article = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string Description = Article + "_Description";
                string Keyword1 = Article + "_Keyword1";
                string Type = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string URL = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string TargetGeography = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();

                //Enter Best Bet Article
                if (common.CheckElement(SiteContentOR.oBestBetTitle_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBestBetTitle_xpath).Click();
                    Driver.FindElement(SiteContentOR.oBestBetTitle_xpath).SendKeys(Article);
                    Report.UpdateTestLog("CreateBestBet", " Enter Article in Best Bet Article field ", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBestBet", " Best Bet Article field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Best Bet Description
                if (common.CheckElement(SiteContentOR.oBestBetDescription_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBestBetDescription_xpath).Click();
                    Driver.FindElement(SiteContentOR.oBestBetDescription_xpath).SendKeys(Description);
                    Report.UpdateTestLog("CreateBestBet", " Enter description in Best Bet Description field ", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBestBet", " Best Bet Description field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Best Best Type
                if (common.CheckElement(SiteContentOR.oBestBetType_xpath) == true)
                {
                    var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.oBestBetType_xpath));
                    selectElement.SelectByText(Type);
                    Report.UpdateTestLog("CreateBestBet", " Enter type in Best Bet Type field ", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBestBet", " Best Bet Type field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter URL
                if (common.CheckElement(SiteContentOR.oBestBetURL_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBestBetURL_xpath).Click();
                    Driver.FindElement(SiteContentOR.oBestBetURL_xpath).Clear();
                    Driver.FindElement(SiteContentOR.oBestBetURL_xpath).SendKeys(URL);
                    Report.UpdateTestLog("CreateBestBet", " Enter URL in Best Bet URL field ", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBestBet", " Best Bet URL field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Best Bet Keyword1
                if (common.CheckElement(SiteContentOR.oBestBetKeyword1_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBestBetKeyword1_xpath).Click();
                    Driver.FindElement(SiteContentOR.oBestBetKeyword1_xpath).SendKeys(Keyword1);
                    Report.UpdateTestLog("CreateBestBet", " Enter keyword in Best Bet Keyword1 field ", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBestBet", " Best Bet Keyword1 field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Target Geography
                if (common.CheckElement(SiteContentOR.oBestBetTargetGeography_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBestBetTargetGeography_xpath).Click();
                    Driver.FindElement(SiteContentOR.oBestBetTargetGeography_xpath).SendKeys(TargetGeography);
                    Report.UpdateTestLog("CreateBestBet", " Enter "+TargetGeography+" in Best Bet Target Geaography field ", Status.DONE);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBestBet", " Best Bet Target Geaography field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Validate Target Geography is a mandatory field
                if (common.CheckElement(SiteContentOR.oTargetGeographyMand_xpath) == true)
                {
                    if (Driver.FindElement(SiteContentOR.oTargetGeographyMand_xpath).GetAttribute("title").Contains("required"))
                    {
                        Report.UpdateTestLog("CreateBestBet", " Best Bet Target Geaography field is  marked as mandatory", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("CreateBestBet", " Best Bet Target Geaography field is not marked as mandatory", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("CreateBestBet", " Best Bet Target Geaography Label is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // click on Save button
                if (common.CheckElement(SiteContentOR.oBestBetSave_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBestBetSave_xpath).Click();
                    Report.UpdateTestLog("CreateBestBetFinalStep", " Clicked on save button ", Status.PASS);
                    common.CallMeWait(4000);
                }
                else
                {
                    Report.UpdateTestLog("CreateBestBet", " save button is not present on top", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateBestBet", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateBestBet", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method FindBestBet()
        // Method Description : This method will find the newly created best bet  
        // Created On: 03/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void FindBestBet()
        {
            try
            {
                string ExpectedTitle = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(SiteContentOR.oApprovalStatus_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oApprovalStatus_xpath).Click();
                    common.CallMeWait(1000);
                    Driver.FindElement(SiteContentOR.oApprovalStatus_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("FindBestBet", " Clicked twice on Approval status to sort", Status.DONE);
                }
                if (common.CheckElement(SiteContentOR.oBestBetsTitles_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> elems = Driver
                                        .FindElements(SiteContentOR.oBestBetsTitles_xpath);
                    bool flag = false;
                    for (int i = 0; i < elems.Count; i++)
                    {
                        string title = elems[i].Text.Trim();
                        if (title.Equals(ExpectedTitle))
                        {
                            elems[i].Click();
                            Report.UpdateTestLog("FindBestBetFinalStep", " Successfully validated that newly created best buy is present in Best Bet page", Status.PASS);
                            flag = true;
                        }
                    }
                    if(flag == false)
                    {
                        Report.UpdateTestLog("FindBestBet", " Newly created best buy is not present in Best Bet page", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("FindBestBet", " No Best bet row is present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("FindBestBet", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindBestBet", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method DeleteBestBet()
        // Method Description : This method will delete the newly created best bet  
        // Created On: 03/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void DeleteBestBet()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oBestBetItems_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBestBetItems_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeleteBestBet", " Clicked on Items link on top left", Status.DONE);
                    if (common.CheckElement(SiteContentOR.oBestBetDelete_xpath) == true)
                    {
                        Driver.FindElement(SiteContentOR.oBestBetDelete_xpath).Click();
                        common.CallMeWait(1000);
                        Report.UpdateTestLog("DeleteBestBet", " Clicked on Delete Item under Items overlay on top left", Status.DONE);
                        IAlert alert = Driver.SwitchTo().Alert();
                        alert.Accept();
                        common.CallMeWait(4000);
                        Report.UpdateTestLog("DeleteBestBetFinalStep", " Successfully deleted the newly created best bet", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("DeleteBestBet", " Delete Item is not present under Items overlay on top left", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("DeleteBestBet", " Items link is not present on top left" , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteBestBet", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteBestBet", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeletePeoplebyOverrideTitle()
        // Method Decs: This method search peolpe by overirte title and delete people from People List
        // Created on:  9th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void DeletePeoplebyOverrideTitle()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                int i = 1;
                int flags = 0;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);

                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[7]")).GetAttribute("innerText");
                    if (name.Contains(req1))
                    {
                        flags = 1;
                        Report.UpdateTestLog("DeletePeoplebyOverrideTitle", " Override Title '" + req1 + "' is found", Status.PASS);
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.oitemsheader_xpath);
                    IWebElement elm = Driver.FindElement(SiteContentOR.oitemsheader_xpath);
                    elm.Click();
                    //Driver.FindElement(SiteContentOR.oitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.odeleteitemsheader_xpath);
                    Driver.FindElement(SiteContentOR.odeleteitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    Driver.SwitchTo().DefaultContent();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeletePeoplebyOverrideTitleFinalStep", " Override Title '" + req1 + "' is deleted", Status.PASS);
                    IWebElement header = Driver.FindElement(SiteContentOR.oheaderbrowse_xpath);
                    header.Click();
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("DeletePeoplebyOverrideTitle", " name '" + req1 + "' not found", Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeletePeoplebyOverrideTitle", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeletePeoplebyOverrideTitle", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: AddPeoplebyOverrideTitle()
        // Method Decs: This method  add people in People List with Override title only
        // Created on:  9th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void AddPeoplebyOverrideTitle()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();

                if (common.CheckElement(SiteContentOR.oaddnewpeopleplusbtn_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Click();
                    Report.UpdateTestLog("AddPeoplebyOverrideTitle", "clicked to add new item button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddPeoplebyOverrideTitle", "new item button is not displayed", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.ooverridetitle_xpath) == true)
                {
                    // Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Click();
                    Driver.FindElement(SiteContentOR.ooverridetitle_xpath).Click();
                    Driver.FindElement(SiteContentOR.ooverridetitle_xpath).SendKeys(req1);
                    Report.UpdateTestLog("AddPeoplebyOverrideTitle", "override title is entered as :" + req1, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddPeoplebyOverrideTitle", "Unable to enter override title", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (Driver.FindElement((By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]"))).Displayed)
                {
                    Driver.FindElement((By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]"))).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("AddPeoplebyOverrideTitleFinalStep", "clicked to save button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddPeoplebyOverrideTitle", "Unable to click save button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddPeoplebyOverrideTitle", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddPeoplebyOverrideTitle", " Problem in AddPeopleInPeopleList Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyOverrideTitle()
        // Method Decs: This method  verify  Override title on the page
        // Created on:  9th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void VerifyOverrideTitle()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                int flag = 0;
                if (common.CheckElement(SiteContentOR.opeopleshowmore_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.opeopleshowmore_xpath).Click();
                    Report.UpdateTestLog("VerifyOverrideTitle", "clicked to Show More ", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("VerifyOverrideTitle", "Show more is not present", Status.DONE);
                }
                if (common.CheckElement(SiteContentOR.ocardcontainer_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> elems = Driver.FindElements(SiteContentOR.ocardtitle_xpath);
                    for (int i = 0; i < elems.Count(); i++)
                    {
                        if (elems[i].Text.Trim().Contains(req1))
                        {
                            flag = 1;
                            break;

                        }
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyOverrideTitle", "People card is not present on the page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    Report.UpdateTestLog("VerifyOverrideTitleFinalStep", "override title is present as :" + req1, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyOverrideTitle", "override title is not  present as :", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyOverrideTitle", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyOverrideTitle", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: IsPersonMandatory()
        // Method Decs: This method  verify  that person is not a mandatory field
        // Created on:  9th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void IsPersonMandatory()
        {
            try
            {

                if (common.CheckElement(SiteContentOR.opersonmandatory_xpath) == false)
                {
                    Report.UpdateTestLog("IsPersonMandatoryFinalStep", "Person is not a mandatory field", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("IsPersonMandatory", "Person is a mandatory field", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyOverrideTitle", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyOverrideTitle", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyPersonFormField()
        // Method Decs: This method  verify presence of field available on the person form as per test data
        // Created on:  9th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void VerifyPersonFormField()
        {
            try
            {
                int flag = 0;
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                if (common.CheckElement(SiteContentOR.opeoplelist_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyPersonFormField", " People List page id present   ", Status.DONE);
                    ReadOnlyCollection<IWebElement> elems = Driver.FindElements(SiteContentOR.opersonformfield_xpath);
                    for (int i = 0; i < elems.Count(); i++)
                    {
                        if (elems[i].Text.Trim().Contains(req1))
                        {
                            flag = 1;
                            break;

                        }
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyPersonFormField", "Unable to open People List page  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    Report.UpdateTestLog("VerifyPersonFormFieldFinalStep", req1 + " field is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPersonFormField", req1 + " field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPersonFormField", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPersonFormField", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SetNumberOfLinks()
        // Method Decs: This method set the number of link to be displayed in web part 
        // Created on:  9th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SetNumberOfLinks()
        {
            try
            {
                string links = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                if (common.CheckElement(SiteContentOR.olinkdropdown_id))
                {
                    Report.UpdateTestLog("SetNumberOfLinks", "Number of Links to Show drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.olinkdropdown_id));
                    IList<IWebElement> elmcount = oselect.Options;
                    for (int i = 0; i < elmcount.Count; i++)
                    {
                        string s = elmcount[i].Text.Trim();
                        if (s.Contains(links))
                        {
                            elmcount[i].Click();
                            Report.UpdateTestLog("SetNumberOfLinksFinalStep", "Numbr of link is selected as " + s, Status.PASS);
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("SetNumberOfLinks", "Category Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SetNumberOfLinks", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SetNumberOfLinks", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifylinkCountOnPage()
        // Method Decs: This method counts custom/quick links on tha page
        // Created on:  9th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifylinkCountOnPage()
        {
            try
            {
                string links = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                int c = Int32.Parse(links);
                if (common.CheckElement(SiteContentOR.ocustomlinktext_xpath))
                {
                    Report.UpdateTestLog("SetNumberOfLinks", "Custom links present on page", Status.DONE);
                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(SiteContentOR.ocustomlinklist_xpath);
                    if (elmsElements1.Count <= c)
                    {
                        Report.UpdateTestLog("SetNumberOfLinksFinalStep", "number of link present " + elmsElements1.Count, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("SetNumberOfLinks", "Number of link present" + elmsElements1.Count, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }


                }
                else
                {
                    Report.UpdateTestLog("SetNumberOfLinks", "Custom link is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SetNumberOfLinks", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SetNumberOfLinks", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyCustomLinkCountField()
        // Method Decs: This method verify the present of value in Custom link web part drop down 
        // Created on:  10th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyCustomLinkCountField()
        {
            try
            {
                string links = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                string[] alllinks = links.Split(',');
                List<string> list = new List<string>();
                if (common.CheckElement(SiteContentOR.olinkdropdown_id))
                {
                    Report.UpdateTestLog("VerifyCustomLinkCountField", "Number of Links to Show drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.olinkdropdown_id));
                    IList<IWebElement> elmcount = oselect.Options;
                    for (int i = 0; i < elmcount.Count(); i++)
                    {
                        list.Add(elmcount[i].Text.Trim());
                    }
                    for (int i = 0; i < alllinks.Count(); i++)
                    {
                        string s = alllinks[i].Trim();
                        if (list.Contains(s))
                        {
                            Report.UpdateTestLog("VerifyCustomLinkCountFieldFinalStep", "Drop down contains " + s, Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyCustomLinkCountField", "Drop does not contain " + s, Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyCustomLinkCountField", "Category Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCustomLinkCountField", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyCustomLinkCountField", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyQuicklinkCountOnPage()
        // Method Decs: This method counts quick links on the landing page.
        // Created on:  10th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyQuicklinkCountOnPage()
        {
            try
            {
                string links = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                int c = Int32.Parse(links);
                if (common.CheckElement(SiteContentOR.oquicklinktext_xpath))
                {
                    Report.UpdateTestLog("SetNumberOfLinks", "Custom links present on page", Status.DONE);
                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(SiteContentOR.oquicklinklist_xpath);
                    if (elmsElements1.Count <= c)
                    {
                        Report.UpdateTestLog("VerifyQuicklinkCountOnPageFinalStep", "number of link present " + elmsElements1.Count, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyQuicklinkCountOnPage", "Number of link present" + elmsElements1.Count, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }


                }
                else
                {
                    Report.UpdateTestLog("VerifyQuicklinkCountOnPage", "Custom link is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyQuicklinkCountOnPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyQuicklinkCountOnPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        
        //******************************************************
        // Method Name: VerifyMaxTenQuickLink()
        // Method Decs: This method verify the quick link  .
        // Created on:  10th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyMaxTenQuickLink()
        {
            try
            {
                   if (common.CheckElement(SiteContentOR.oquicklinktext_xpath))
                {
                    Report.UpdateTestLog("SetNumberOfLinks", "Custom links present on page", Status.DONE);
                    ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(SiteContentOR.oquicklinklist_xpath);
                    if (elmsElements1.Count <= 10)
                    {
                        Report.UpdateTestLog("VerifyMaxTenQuickLinkFinalStep", "number of link present " + elmsElements1.Count, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyMaxTenQuickLink", "Number of link present" + elmsElements1.Count, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }


                }
                else
                {
                    Report.UpdateTestLog("VerifyMaxTenQuickLink", "Custom link is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyMaxTenQuickLink", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyMaxTenQuickLink", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CheckPersonfield()
        // Method Decs: This method  verify  that person is not a mandatory field
        // Created on:  17th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void CheckPersonfield()
        {
            try
            {

                if (common.CheckElement(SiteContentOR.opersonmandatory_xpath) == false)
                {
                    Report.UpdateTestLog("CheckPersonfieldFinalStep", "Person field is not a mandatory ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CheckPersonfield ", "Person field is a mandatory ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CheckPersonfield", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CheckPersonfield", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyOverrideName()
        // Method Decs: This method  verify  Override name on the page
        // Created on:  17th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void VerifyOverrideName()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                int flag = 0;
                if (common.CheckElement(SiteContentOR.opeopleshowmore_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.opeopleshowmore_xpath).Click();
                    Report.UpdateTestLog("VerifyOverrideName", "clicked to Show More ", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("VerifyOverrideName", "Show more is not present", Status.DONE);
                }
                if (common.CheckElement(SiteContentOR.ocardcontainer_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> elems = Driver.FindElements(SiteContentOR.ocardname_xpath);
                    for (int i = 0; i < elems.Count(); i++)
                    {
                        if (elems[i].Text.Trim().Contains(req1))
                        {
                            flag = 1;
                            break;

                        }
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyOverrideName", "People card is not present on the page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    Report.UpdateTestLog("VerifyOverrideNameFinalStep", "override name is present as :" + req1, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyOverrideName", "override name is not  present as :", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyOverrideTitle", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyOverrideTitle", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: DeletePeoplebyOverrideName()
        // Method Decs: This method search peolpe by overide name and delete people from People List
        // Created on:  17th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void DeletePeoplebyOverrideName()
        {
            try
            {
                string req4 = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                int i = 1;
                int flags = 0;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);

                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[5]")).GetAttribute("innerText");
                    if (name.Contains(req4))
                    {
                        flags = 1;
                        Report.UpdateTestLog("DeletePeoplebyOverrideName", " Override name '" + req4 + "' is found", Status.PASS);
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[1]")).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.oitemsheader_xpath);
                    IWebElement elm = Driver.FindElement(SiteContentOR.oitemsheader_xpath);
                    elm.Click();
                    //Driver.FindElement(SiteContentOR.oitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    common.WaitForElement(SiteContentOR.odeleteitemsheader_xpath);
                    Driver.FindElement(SiteContentOR.odeleteitemsheader_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    Driver.SwitchTo().DefaultContent();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeletePeoplebyOverrideNameFinalStep", " Override Title '" + req4 + "' is deleted", Status.PASS);
                    IWebElement header = Driver.FindElement(SiteContentOR.oheaderbrowse_xpath);
                    header.Click();
                    common.CallMeWait(2000);
                }
                /*else
                {
                    Report.UpdateTestLog("DeletePeoplebyOverrideName", " name '" + req4 + "' not found", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }*/
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeletePeoplebyOverrideName", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeletePeoplebyOverrideName", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: AddPeoplebyOverrideName()
        // Method Decs: This method  add people in People List with Override name only
        // Created on:  20th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void AddPeoplebyOverrideName()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();

                if (common.CheckElement(SiteContentOR.oaddnewpeopleplusbtn_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Click();
                    Report.UpdateTestLog("AddPeoplebyOverrideName", "clicked to add new item button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddPeoplebyOverrideName", "new item button is not displayed", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.ooverridename_xpath) == true)
                {
                    // Driver.FindElement(SiteContentOR.oaddnewpeopleplusbtn_xpath).Click();
                    Driver.FindElement(SiteContentOR.ooverridename_xpath).Click();
                    Driver.FindElement(SiteContentOR.ooverridename_xpath).SendKeys(req1);
                    Report.UpdateTestLog("AddPeoplebyOverrideName", "override name is entered as :" + req1, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddPeoplebyOverrideName", "Unable to enter override name", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (Driver.FindElement((By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]"))).Displayed)
                {
                    Driver.FindElement((By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]"))).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("AddPeoplebyOverrideNameFinalStep", "clicked to save button", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddPeoplebyOverrideName", "Unable to click save button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddPeoplebyOverrideName", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddPeoplebyOverrideName", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyVideoPresence()
        // Method Decs: This method  verify presence if video in video web part
        // Created on:  20th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void VerifyVideoPresence()
        {
            try
            {
                common.CallMeWait(1000);
                ReadOnlyCollection<IWebElement> detailFrame = Driver.FindElements(By.XPath("//iframe"));
                Driver.SwitchTo().Frame(detailFrame[0]);
                if (common.CheckElement(SiteContentOR.videotitle_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyVideoPresenceFinalStep", "Video is present", Status.PASS);
                    Driver.SwitchTo().DefaultContent();
                }
                else
                {
                    Report.UpdateTestLog("VerifyVideoPresence", "video is not present in web part", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    Driver.SwitchTo().DefaultContent();

                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyVideoPresence", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyVideoPresence", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: AddVideoSourceTypeAndID()
        // Method Decs: This method will add Video Source type and video id 
        // Created on:  20th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void AddVideoSourceTypeAndID()
        {
            try
            {

                string videoSource = DataTable.GetData("AddWebPartInfo", "VideoSource").Trim();
                string id = DataTable.GetData("AddWebPartInfo", "ID");

                if (common.CheckElement(SiteContentOR.ovideowebpartlist_id) == true)
                {
                    var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                    common.CallMeWait(1000);
                    selectElement.SelectByText(videoSource);
                    Report.UpdateTestLog("AddVideoSourceTypeAndID", "Video source is added as: " + videoSource, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddVideoSourceTypeAndID", "Unable to add Video source", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.obrightcoveplaylist_id) == true)
                {
                    Driver.FindElement(SiteContentOR.obrightcoveplaylist_id).SendKeys(id);
                    Report.UpdateTestLog("AddVideoSourceTypeAndIDFinalStep", "Video source id added as: " + id, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddVideoSourceTypeAndID", "Unable to add Video id", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddVideoSourceTypeAndID", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddVideoSourceTypeAndID", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: AddRegionInVideoWebPart()
        // Method Decs: This method  select the country as per data entered .
        // Created on:  20th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void AddRegionInVideoWebPart()
        {
            try
            {

                string state = DataTable.GetData("AddWebPartInfo", "State").Trim();
                string dpath = "//input[contains(@id,'ngWebPartsControl_bcRegion') and @value='" + state + "']";
                By statexpath = By.XPath(dpath);
                if (common.CheckElement(statexpath) == true)
                {
                    Driver.FindElement(statexpath).Click();
                    Report.UpdateTestLog("AddRegionInVideoWebPartFinalStep", "Country is selected as: " + state, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddRegionInVideoWebPart", "Unable to select country", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddRegionInVideoWebPart", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddRegionInVideoWebPart", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        
        //******************************************************
        // Method Name: VerifyRegionInVideoWebPart()
        // Method Decs: This method  verify region present for the video web part
        // Created on:  21st March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyRegionInVideoWebPart()
        {
            try
            {

                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string dpath = "//input[contains(@id,'ngWebPartsControl_bcRegion') and @value='" + req1 + "']";
                By statexpath = By.XPath(dpath);
                if (common.CheckElement(statexpath) == true)
                {
                    Report.UpdateTestLog("VerifyRegionInVideoWebPart", req1 + " region is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyRegionInVideoWebPart", req1 + " region is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string dpath2 = "//input[contains(@id,'ngWebPartsControl_bcRegion') and @value='" + req2 + "']";
                By statexpath2 = By.XPath(dpath);
                if (common.CheckElement(statexpath2) == true)
                {
                    Report.UpdateTestLog("VerifyRegionInVideoWebPart", req2 + " region is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyRegionInVideoWebPart", req2 + " region is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string dpath3 = "//input[contains(@id,'ngWebPartsControl_bcRegion') and @value='" + req3 + "']";
                By statexpath3 = By.XPath(dpath);
                if (common.CheckElement(statexpath3) == true)
                {
                    Report.UpdateTestLog("VerifyRegionInVideoWebPartFinalStep", req3 + " region is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyRegionInVideoWebPart", req3 + " region is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyRegionInVideoWebPart", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyRegionInVideoWebPart", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //******************************************************
        // Method Name: VerifyAccountIdBasedOnRegion()
        // Method Decs: This method  verify video id on the basis of regio selected in video web part
        // Created on:  21st March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyAccountIdBasedOnRegion()
        {
            try
            {

                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string dpath1 = "//input[contains(@id,'ngWebPartsControl_bcRegion') and @value='" + req1 + "']";
                By statexpath1 = By.XPath(dpath1);
                if (common.CheckElement(statexpath1) == true)
                {
                    Driver.FindElement(statexpath1).Click();
                    Report.UpdateTestLog("VerifyAccountIdBasedOnRegion", req1 + " region is present ", Status.PASS);
                    string text1 = Driver.FindElement(By.XPath("//input[@id='ngWebPartsControl_bcAccount']")).Text;
                }
                else
                {
                    Report.UpdateTestLog("VerifyAccountIdBasedOnRegion", req1 + " region is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string dpath2 = "//input[contains(@id,'ngWebPartsControl_bcRegion') and @value='" + req2 + "']";
                By statexpath2 = By.XPath(dpath2);
                if (common.CheckElement(statexpath2) == true)
                {
                    Driver.FindElement(statexpath2).Click();
                    Report.UpdateTestLog("VerifyAccountIdBasedOnRegion", req2 + " region is present ", Status.PASS);
                    string text2 = Driver.FindElement(By.XPath("//input[@id='ngWebPartsControl_bcAccount']")).Text;
                }
                else
                {
                    Report.UpdateTestLog("VerifyAccountIdBasedOnRegion", req2 + " region is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string dpath3 = "//input[contains(@id,'ngWebPartsControl_bcRegion') and @value='" + req3 + "']";
                By statexpath3 = By.XPath(dpath3);
                if (common.CheckElement(statexpath3) == true)
                {
                    Driver.FindElement(statexpath2).Click();
                    Report.UpdateTestLog("VerifyRegionInVideoWebPartFinalStep", req3 + " region is present ", Status.PASS);
                    string text3 = Driver.FindElement(By.XPath("//input[@id='ngWebPartsControl_bcAccount']")).Text;
                }
                else
                {
                    Report.UpdateTestLog("VerifyAccountIdBasedOnRegion", req3 + " region is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyAccountIdBasedOnRegion", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyAccountIdBasedOnRegion", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyEnableDisableFuntionaityPlaylist()
        // Method Decs: This method  verify enable and disable funtionality for video id and playlist in video web part
        // Created on:  21st March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyEnableDisableFuntionaityPlaylist()
        {
            try
            {
                //selecting you tube and validate
                string videoSourceyoutube = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(SiteContentOR.ovideowebpartlist_id) == true)
                {
                    var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                    common.CallMeWait(1000);
                    selectElement.SelectByText(videoSourceyoutube);
                    Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Video source is added as: " + videoSourceyoutube, Status.PASS);
                    if (common.CheckElement(SiteContentOR.oplaylistdisable_id) == true)
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is disable", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is enable", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (common.CheckElement(SiteContentOR.oaccountdisable_id) == true)
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Account Id is disable", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is enable", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Unable to add Video source", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //selecting Youku and validate
                string videoSourceYouku = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (common.CheckElement(SiteContentOR.ovideowebpartlist_id) == true)
                {
                    var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                    common.CallMeWait(1000);
                    selectElement.SelectByText(videoSourceYouku);
                    Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Video source is added as: " + videoSourceYouku, Status.PASS);
                    if (common.CheckElement(SiteContentOR.oplaylistdisable_id) == true)
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is disable", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is enable", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (common.CheckElement(SiteContentOR.oaccountdisable_id) == true)
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Account Id is disable", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is enable", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Unable to add Video source", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //selecting Brightcove and validate
                string videoSourceBrightcove = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                if (common.CheckElement(SiteContentOR.ovideowebpartlist_id) == true)
                {
                    var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                    common.CallMeWait(1000);
                    selectElement.SelectByText(videoSourceBrightcove);
                    Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Video source is added as: " + videoSourceBrightcove, Status.PASS);
                    if (common.CheckElement(SiteContentOR.oplaylistdisable_id) == false)
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is enable", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is disable", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (common.CheckElement(SiteContentOR.oaccountdisable_id) == false)
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylistFinalStep", "Brightcove Account Id is enable", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Brightcove Playlist is disable", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", "Unable to add Video source", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyEnableDisableFuntionaityPlaylist", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyFreeFromTextForRegionOther()
        // Method Decs: This method  verify that video playlist and video id are free from text when region is selected as Other
        // Created on:  21st March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyFreeFromTextForRegionOther()
        {
            try
            {

                string videoSourceBrightcove = DataTable.GetData("AddWebPartInfo", "VideoSource").Trim();
                if (common.CheckElement(SiteContentOR.ovideowebpartlist_id) == true)
                {
                    var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                    common.CallMeWait(1000);
                    selectElement.SelectByText(videoSourceBrightcove);
                    Report.UpdateTestLog("VerifyFreeFromTextForRegionOther", "Video source is added as: " + videoSourceBrightcove, Status.PASS);
                    if (common.CheckElement(SiteContentOR.oplaylistdisable_id) == false)
                    {
                        Report.UpdateTestLog("VerifyFreeFromTextForRegionOther", "Brightcove Playlist is free from text", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyFreeFromTextForRegionOther", "Brightcove Playlist is not free from text", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (common.CheckElement(SiteContentOR.oaccountdisable_id) == false)
                    {
                        Report.UpdateTestLog("VerifyFreeFromTextForRegionOtherFinalStep", "Brightcove Account Id free from text", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyFreeFromTextForRegionOther", "Brightcove Playlist is not free from text", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyFreeFromTextForRegionOther", "Unable to add Video source", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyFreeFromTextForRegionOther", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyFreeFromTextForRegionOther", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EditWebPartInPages()
        // Method Decs: This method will add web part in 2 Column layout page
        // Created on:  21st Mar 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void EditWebPartInPages()
        {
            string webPartCategories = DataTable.GetData("General_Data_" + Env, "WebPartCategories");
            string webParts = DataTable.GetData("General_Data_" + Env, "WebParts");
            string videoSource = DataTable.GetData("AddWebPartInfo", "VideoSource");
            string CheckVideoStatus = DataTable.GetData("AddWebPartInfo", "CheckVideoStatus");
            try
            {
                IJavaScriptExecutor js = Driver as IJavaScriptExecutor;

                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                Report.UpdateTestLog("EditWebPartInPages", " Click on Edit Page  ", Status.PASS);
                common.CallMeWait(5000);
                IWebElement addwebpart = Driver.FindElement(By.XPath("//*[@id='MSOZone']/div[1]"));
                js.ExecuteScript("CoreInvoke('ShowWebPartAdder', 'MainZone');");

                Report.UpdateTestLog("EditWebPartInPages", " Click on Add a Web Part element  ", Status.PASS);
                ClickOnWebpartCategory(webPartCategories);
                ClickOnWebPart(webParts);

                IWebElement addBtn = Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath);

                addBtn.Click();

                //js.ExecuteScript("arguments[0].style.border='2px groove green'", addBtn);
                //Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath).Click();
                Report.UpdateTestLog("EditWebPartInPages", " Click on Add button  ", Status.PASS);
                Driver.FindElement(SiteContentOR.oaddwebpartwebelementsavebtn_xpath).Click();
                common.CallMeWait(5000);
                Report.UpdateTestLog("EditWebPartInPagesFinalStep", " Click on Save button  ", Status.PASS);
                common.CallMeWait(5000);
               // if (videoSource.Count() > 0)
              //  {
               //     AddYouTubeInfo();
               // }

                //Verification
                /* int count = Driver.FindElements(SiteContentOR.owebpartcountwebelemets_xpath).Count;
                 if (Driver.FindElements(SiteContentOR.owebpartcountwebelemets_xpath).Count >= 1)
                 {
                     Report.UpdateTestLog("AddwebPartin2Column", " Number of web part: " + count + " Available in the page", Status.PASS);
                 }
                 else
                 {
                     Report.UpdateTestLog("AddwebPartin2Column", " Number of web part: " + count + " Available in the page but expected is 1 ", Status.FAIL);
                 }
                 if (CheckVideoStatus.Count() > 0)
                 {
                     CheckVideoPlayStatus();
                 } */

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EditWebPartInPages", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EditWebPartInPages", " There is a problem in  Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }


        }

        //******************************************************
        // Method Name: VerifyPresenceofCustumlinkonPage()
        // Method Decs: This method verify presence of a custom link on the page by name
        // Created on:  23rd March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyPresenceofCustumlinkonPage()
        {
            try
            {
                int flag = 0;
                string linkname = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(SiteContentOR.ocustomlinktext_xpath))
                {
                    try
                    {
                        Report.UpdateTestLog("VerifyPresenceofCustumlinkonPage", "Custom links present on page", Status.DONE);
                        ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(SiteContentOR.ocustomlinktextname_xpath);
                        for (int i = 0; i <= elmsElements1.Count(); i++)
                        {
                            string s = elmsElements1[i].Text.Trim();
                            if (linkname.Equals(s))
                            {
                                flag = 1;
                                break;
                            }

                        }
                    }
                    catch
                    {
                        flag = 0;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyPresenceofCustumlinkonPage", "Custom link is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("VerifyPresenceofCustumlinkonPageFinalStep", "Custom link is not present with name :" + linkname, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPresenceofCustumlinkonPage", "Custom link is present with name: " + linkname, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPresenceofCustumlinkonPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPresenceofCustumlinkonPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: CheckToOpenInNewTab()
        // Method Decs: This method click on the option to open custom/quick link in new tab
        // Created on:  23rd March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void CheckToOpenInNewTab()
        {
            try
            {

                if (common.CheckElement(SiteContentOR.ocheckbox_xpath))
                {
                    Driver.FindElement(SiteContentOR.ocheckbox_xpath).Click();
                    Report.UpdateTestLog("CheckToOpenInNewTabFinalStep", "open in new tab option is checked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CheckToOpenInNewTab", "Unable to check open in new tab option ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CheckToOpenInNewTab", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CheckToOpenInNewTab", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: VerifySplitName()
        // Method Decs: This method verify split name of custiom link on the page
        // Created on: 23rd March 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifySplitName()
        {
            try
            {
                int flag = 0;
                string linkname = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string linknamefirstpart = linkname.ToString().Split('@')[0];
                if (common.CheckElement(SiteContentOR.ocustomlinktext_xpath))
                {
                    try
                    {
                        Report.UpdateTestLog("VerifySplitName", "Custom links present on page", Status.DONE);
                        ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(SiteContentOR.olinebreakeintile_xpath);
                        for (int i = 0; i <= elmsElements1.Count(); i++)
                        {
                            string s = elmsElements1[i].Text.Trim();
                            if (linknamefirstpart.Equals(s))
                            {
                                flag = 1;
                                break;
                            }

                        }
                    }
                    catch
                    {
                        flag = 0;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifySplitName", "Custom link is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (flag == 1)
                {
                    Report.UpdateTestLog("VerifySplitNameFinalStep", "Break in title is present:", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySplitName", "Break in title is not  present: ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySplitName", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySplitName", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreateACustomLinkwithWeight()
        // Method Decs: This method create a custom link with weight
        // Created on:  6th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void CreateACustomLinkwithWeight()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3");
                string req4 = DataTable.GetData("General_Data_" + Env, "RequestType4");
                common.WaitForElement(SiteContentOR.onewitemlink_xpath);
                common.CallMeWait(2000);
                if (Driver.FindElement(SiteContentOR.onewitemlink_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.onewitemlink_xpath).Click();
                    Report.UpdateTestLog("CreateACustomLinkwithWeight", "clicked on New Item link", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateACustomLinkwithWeight", "unable to click on new item link", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.WaitForElement(SiteContentOR.otitle_xpath);
                Driver.FindElement(SiteContentOR.otitle_xpath).Clear();
                Driver.FindElement(SiteContentOR.otitle_xpath).SendKeys(req1);
                Report.UpdateTestLog("CreateACustomLinkwithWeight", "tittle is entered as :" + req1, Status.PASS);

                common.WaitForElement(SiteContentOR.ourl_xpath);
                Driver.FindElement(SiteContentOR.ourl_xpath).Clear();
                Driver.FindElement(SiteContentOR.ourl_xpath).SendKeys(req2);
                Report.UpdateTestLog("CreateACustomLinkwithWeight", "Link is entered as :" + req2, Status.PASS);

                common.WaitForElement(SiteContentOR.oIntOrgCategory_xpath);
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).Clear();
                Driver.FindElement(SiteContentOR.oIntOrgCategory_xpath).SendKeys(req3);
                Report.UpdateTestLog("CreateACustomLinkwithWeight", "Intranet :" + req3, Status.PASS);

                if (common.CheckElement(SiteContentOR.oweight_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oweight_xpath).Clear();
                    Driver.FindElement(SiteContentOR.oweight_xpath).SendKeys(req4);
                    Report.UpdateTestLog("CreateACustomLinkwithWeightFinalStep", "Intranet :" + req4, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateACustomLinkwithWeight", "Unable to click save data", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateACustomLinkwithWeight", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateACustomLinkwithWeight", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SaveForm()
        // Method Decs: This method save the form after filing the fields 
        // Created on:  28th March 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void SaveForm()
        {
            try
            {
                common.WaitForElement(SiteContentOR.oribbonsaveoption_xpath);
                if (common.CheckElement(SiteContentOR.oribbonsaveoption_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Click();
                    Report.UpdateTestLog("SaveFormFinalStep", "clicked on save", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SaveForm", "Unable to click save data", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.CallMeWait(2000);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SaveForm", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SaveForm", " There is a problem in Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //27 march 
        //******************************************************
        // Method Name: VerifyNewsPresence()
        // Method Decs: This method  verify presence of News web Part on the page
        // Created on:  27th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void VerifyNewsPresence()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.onews_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyNewsPresenceFinalStep", "New web part is present on the page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyNewsPresence", "New web part is not present on the page", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyNewsPresence", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyNewsPresence", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyNewsArticlePresence()
        // Method Decs: This method verify presence of News web Part on the page
        // Created on:  27th March 2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void VerifyNewsArticlePresence()
        {
            try
            {
                common.WaitForElement(SiteContentOR.onewsrow_xpath);
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.onewsrow_xpath);
                if (elms.Count() > 0)
                {
                    Report.UpdateTestLog("VerifyNewsArticlePresenceFinalStep", "Total article present :" + elms.Count(), Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyNewsArticlePresence", "No news article  is present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyNewsArticlePresence", "No news article  is present  " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyNewsArticlePresence", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyShowNewsFormOptions()
        // Method Decs: This method verify option available under news form in news web part 
        // Created on:  27th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyShowNewsFormOptions()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string req4 = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                string req5 = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                string req6 = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                IList<string> data = new List<string>();
                data.Add(req1);
                data.Add(req2);
                data.Add(req3);
                data.Add(req4);
                data.Add(req5);
                data.Add(req6);
                data.Add(req7);
                int flag = 0;
                int j;
                common.WaitForElement(SiteContentOR.oshownewsform_id);
                if (Driver.FindElement(SiteContentOR.oshownewsform_id).Displayed)
                {
                    Report.UpdateTestLog("VerifyShowNewsFormOptions", "Form Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oshownewsform_id));
                    IList<IWebElement> elmcount = oselect.Options;
                    for (j = 0; j < 7; j++)
                    {
                        flag = 0;
                        for (int i = 0; i < elmcount.Count; i++)
                        {
                            string s = elmcount[i].Text.Trim();
                            if (s.Contains(data[j]))
                            {
                                Report.UpdateTestLog("VerifyShowNewsFormOptionsFinalStep", data[j] + " is present", Status.PASS);
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {

                            Report.UpdateTestLog("VerifyShowNewsFormOptions", data[j] + " is not present", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }

                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyShowNewsFormOptions", "Form in Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyShowNewsFormOptions", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyShowNewsFormOptions", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectShowNewsFormSecondtimes()
        // Method Decs: This method Selects Show  Newss Form second times in Web Part 
        // Created on:  27th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectShowNewsFormSecondtimes()
        {
            try
            {
                OpenPagetoEdit();
                OpenWebpartinEditMode();
                string req4 = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                common.WaitForElement(SiteContentOR.oshownewsform_id);
                if (Driver.FindElement(SiteContentOR.oshownewsform_id).Displayed)
                {

                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oshownewsform_id));
                    oselect.SelectByText(req4);
                    Report.UpdateTestLog("SelectShowNewsFormSecondtimesFinalStep", "Form Drop is selected as :" + req4, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectShowNewsFormSecondtimes", "Form in Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ClickToApply();
                ClickToOK();
                Savepage();
                VerifyNewsArticlePresence();

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectShowNewsFormSecondtimes", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectShowNewsFormSecondtimes", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SelectShowNewsFormThirdtimes()
        // Method Decs: This method Selects Show  News Form third times in Web Part 
        // Created on:  27th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectShowNewsFormThirdtimes()
        {
            try
            {
                OpenPagetoEdit();
                OpenWebpartinEditMode();
                string req5 = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                common.WaitForElement(SiteContentOR.oshownewsform_id);
                if (Driver.FindElement(SiteContentOR.oshownewsform_id).Displayed)
                {

                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oshownewsform_id));
                    oselect.SelectByText(req5);
                    Report.UpdateTestLog("SelectShowNewsFormThirdtimesFinalStep", "Form Drop is selected as :" + req5, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectShowNewsFormThirdtimes", "Form in Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ClickToApply();
                ClickToOK();
                Savepage();
                VerifyNewsArticlePresence();

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectShowNewsFormThirdtimes", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectShowNewsFormThirdtimes", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectEventCategoryInWebpart()
        // Method Decs: This select a event category in web part of Event
        // Created on:  29th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectEventCategoryInWebpart()
        {
            try
            {


                string req5 = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                common.WaitForElement(SiteContentOR.oevenrcategorywebpart_id);
                if (Driver.FindElement(SiteContentOR.oevenrcategorywebpart_id).Displayed)
                {
                    Report.UpdateTestLog("SelectEventCategoryInWebpart", "Category Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oevenrcategorywebpart_id));
                    oselect.SelectByText(req5);
                    Report.UpdateTestLog("SelectEventCategoryInWebpartFinalStep", "Category  is selected as :" + req5, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectEventCategoryInWebpart", "Category Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectEventCategoryInWebpart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectEventCategoryInWebpart", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: NavigateToPages()
        // Method Decs: This select Navigates to pages
        // Created on:  03/30/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void NavigateToPages()
        {
            try
            {
                String url = DataTable.GetData("General_Data_" + Env, "URL");
                Driver.Navigate().GoToUrl(url);
                Report.UpdateTestLog("NavigateToPages", "Navigate to " + url, Status.PASS);
                common.CallMeWait(2000);
                ClickOnTopNavigationItem();
                ClickOnSubMenuTopNavigationItem();
                int flag = 0;                
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                for (int i = 2; i <= elms.Count; i++)
                {
                    string innerValue =
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text;

                    if (innerValue.Contains("Pages"))
                    {
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[1]")).Click();
                        flag = 1;
                        common.CallMeWait(5000);
                        break;
                    }
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("NavigateToPages", " Not able to find Pages ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("NavigateToPagesFinalStep", " Clicked on Item  Pages ", Status.PASS);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigateToPages", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToPages", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateDocInPage()
        // Method Decs: This method validate the doc based on the category
        // Created on:  03/30/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateDocInPage()
        {
            try
            {
                bool flag = false;
                String Title = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (common.CheckElement(SiteContentOR.oDocTitles_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> titles = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                    if (titles.Count == 1)
                    {
                        if (titles[0].Text.Trim().Contains(Title))
                        {
                            Report.UpdateTestLog("ValidateDocInPageFinalStep", " Successfully validated that only the document is displayed based on the selected category " , Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateDocInPage", " Document is displayed but not based on the selected category ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < titles.Count; i++)
                        {
                            if (titles[i].Text.Trim().Contains(Title))
                            {
                                Report.UpdateTestLog("ValidateDocInPageFinalStep", " Successfully validated that only the document is displayed based on the selected category ", Status.PASS);
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("ValidateDocInPage", " Document is displayed but not based on the selected category ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateDocInPage", " No Document is displayed ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDocInPage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDocInPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: NavigateToDocuments()
        // Method Decs: This select Navigates to pages
        // Created on:  03/30/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void NavigateToDocuments()
        {
            try
            {
                String url = DataTable.GetData("General_Data_" + Env, "URL");
                Driver.Navigate().GoToUrl(url);
                Report.UpdateTestLog("NavigateToDocuments", "Navigate to " + url, Status.PASS);
                common.CallMeWait(2000);
                ClickOnTopNavigationItem();
                ClickOnSubMenuTopNavigationItem();
                int flag = 0;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                for (int i = 2; i <= elms.Count; i++)
                {
                    string innerValue =
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[2]/div/div")).Text;

                    if (innerValue.Contains("Documents"))
                    {
                        Driver.FindElement(By.XPath("//*[@id='applist']/child::*[" + i + "]/div[1]")).Click();
                        flag = 1;
                        common.CallMeWait(5000);
                        break;
                    }
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("NavigateToDocuments", " Not able to find Documents ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("NavigateToDocumentsFinalStep", " Clicked on Item Documents ", Status.PASS);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigateToDocuments", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateToDocuments", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateWebParts()
        // Method Decs: This method validates web parts in page
        // Created on:  03/30/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateWebParts()
        {
            try
            {
                string WebPart = DataTable.GetData("General_Data_" + Env, "WebParts").Trim();
                bool flag = false;
                if (common.CheckElement(SiteContentOR.oWebParts_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> webparts = Driver.FindElements(SiteContentOR.oWebParts_xpath);
                    for (int i = 0; i < webparts.Count; i++)
                    {
                        if (webparts[i].Text.Trim().Contains(WebPart))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("ValidateWebPartsFinalStep", " Successfully validated that " + webparts.Count+ " '" + WebPart + "' Web part present in page ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateWebParts", " Expected '" + WebPart + "' Web part is not present in page ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("ValidateWebParts", " No Web part is present in page " , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateWebParts", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateWebParts", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectMultipleEventCategoryInWebpart()
        // Method Decs: This select multiple event category in web part of Event
        // Created on:  30th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectMultipleEventCategoryInWebpart()
        {
            try
            {


                string req5 = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                common.WaitForElement(SiteContentOR.oevenrcategorywebpart_id);
                if (Driver.FindElement(SiteContentOR.oevenrcategorywebpart_id).Displayed)
                {
                    Report.UpdateTestLog("SelectEventCategoryInWebpart", "Category Drop down is present", Status.PASS);
                    string[] arr = req5.Split(';');

                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oevenrcategorywebpart_id));
                    for (int i = 0; i < arr.Count(); i++)
                    {
                        oselect.SelectByText(arr[i].Trim());
                        Report.UpdateTestLog("SelectMultipleEventCategoryInWebpartFinalStep", "Category  is selected as :" + arr[i], Status.PASS);
                    }
                }
                else
                {
                    Report.UpdateTestLog("SelectMultipleEventCategoryInWebpart", "Category   is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectMultipleEventCategoryInWebpart", "No option is present in Categories to Filter by :", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectMultipleEventCategoryInWebpart", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SelectShowEventFormAgain()
        // Method Decs: This method SelectsShow  Event Form in Web Part 
        // Created on:  30th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectShowEventFormAgain()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                common.WaitForElement(SiteContentOR.oshoweventform_id);
                if (Driver.FindElement(SiteContentOR.oshoweventform_id).Displayed)
                {
                    Report.UpdateTestLog("SelectShowEventFormAgain", "Form Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oshoweventform_id));
                    oselect.SelectByText(req1);
                    Report.UpdateTestLog("SelectShowEventFormAgainFinalStep", "Form Drop is selected as :" + req1, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectShowEventFormAgain", "Form in Drop down is not present", Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectShowEventFormAgain", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectShowEventFormAgain", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyManageNewsURL()
        // Method Decs: This method verify manages new url 
        // Created on:  31th March 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyManageNewsURL()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "NavigationURL").Trim();
                string url= Driver.Url;
                if (url.Contains(req1))
                {
                    Report.UpdateTestLog("VerifyManageNewsURLFinalStep", "Successfully navigated to Manage News Page", Status.PASS);
                   
                }
                else
                {
                    Report.UpdateTestLog("VerifyManageNewsURL", "Unable to navigate Manage News Page", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyManageNewsURL", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyManageNewsURL", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyPageLayOutDuringEdit()
        // Method Decs: This method verify the layout of page during edit of page
        // Created on:  31st March 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifyPageLayOutDuringEdit()
        {

            try
            {
                
                string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                string[] data = req7.Split(',');
              
                for (int i = 0; i < data.Length; i++)
                {
                    string dynamicpath = "//*[text()='" + data[i].Trim() + "']";
                    try
                    {
                        Driver.FindElement(By.XPath(dynamicpath));
                        Report.UpdateTestLog("ChangePageLayOut", data[i]+" is present", Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("ChangePageLayOut", data[i] + " is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ChangePageLayOut", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ChangePageLayOut", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClikOnPageLayoutOption()
        // Method Decs: This method verify click on the page lay out option 
        // Created on:  31st March 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void ClikOnPageLayoutOption()
        {
            try
            {
                common.WaitForElement(SiteContentOR.opagelayout_xpath);

                if (Driver.FindElement(SiteContentOR.opagelayout_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.opagelayout_xpath).Click();
                   
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClikOnPageLayoutOptionFinalStep", "Clicked on Layout option", Status.PASS);
                }               
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClikOnPageLayoutOption", " Unable to click on the page lay out option  " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClikOnPageLayoutOption", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SendEscKey()
        // Method Decs: This method sends escape key from the key board
        // Created on:  31st March 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void SendEscKey()
        {
            try
            {
               // Actions action = new Actions(Driver);
                SendKeys.SendWait(@"{Esc}");
                SendKeys.SendWait(@"{Esc}");
             
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SendEscKey", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SelectShowEventFormAgain()
        // Method Decs: This method SelectsShow  Event Form in Web Part and take data from Request8 column in data sheet
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectEventForm()
        {
            try
            {
                string req8 = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                common.WaitForElement(SiteContentOR.oshoweventform_id);
                if (Driver.FindElement(SiteContentOR.oshoweventform_id).Displayed)
                {
                    Report.UpdateTestLog("SelectEventForm", "Form Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oshoweventform_id));
                    oselect.SelectByText(req8);
                    Report.UpdateTestLog("SelectEventFormFinalStep", "Form Drop is selected as :" + req8, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectEventForm", "Form in Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectEventForm", " Event form is not present " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectEventForm", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: EnterTitleInAccordionPage()
        // Method Decs: This method enter title in the accordion page 
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void EnterTitleInAccordionPage()
        {
            try
            {
                string req9 = DataTable.GetData("General_Data_" + Env, "RequestType9").Trim();
                common.WaitForElement(SiteContentOR.oAccordionSection1Title_id);
                if (Driver.FindElement(SiteContentOR.oAccordionSection1Title_id).Displayed)
                {

                    Driver.FindElement(SiteContentOR.oAccordionSection1Title_id).Clear();
                     Driver.FindElement(SiteContentOR.oAccordionSection1Title_id).SendKeys(req9);
                    Report.UpdateTestLog("EnterTitleInAccordionPageFinalStep", "Accordion Section 1 title is entered as : " + req9, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterTitleInAccordionPage", "Unable to enter title ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterTitleInAccordionPage", "Accordion Section 1 title element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterTitleInAccordionPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClcikOnAddWeBpartAccordionPage()
        // Method Decs: This method click on the  
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ClcikOnAddWeBpartAccordionPage()
        {
            try
            {
                Driver.FindElement(SiteContentOR.oclickaccordionwebpart_xpath).Click();
                common.CallMeWait(1000);
               Report.UpdateTestLog("ClcikOnAddWeBpartAccordionPageFinalStep", "Click on Add Web part for Accordion page ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClcikOnAddWeBpartAccordionPage", "Unable to click on Add Web part for Accordion page " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClcikOnAddWeBpartAccordionPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SelectWebpart()
        // Method Decs: This method add web part in page
        // Created on:  3rd Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void SelectWebpart()
        {
            string webPartCategories = DataTable.GetData("General_Data_" + Env, "WebPartCategories");
            string webParts = DataTable.GetData("General_Data_" + Env, "WebParts");
             try
            {              
                ClickOnWebpartCategory(webPartCategories);
                ClickOnWebPart(webParts);
                 IWebElement addBtn = Driver.FindElement(SiteContentOR.oaddwebpartwebelementaddbtn_xpath);
                addBtn.Click();
                common.CallMeWait(4000);
                Report.UpdateTestLog("SelectWebpartFinalStep", "Clicked on Add Button", Status.PASS); 
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectWebpart", "Unable to click add button" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectWebpart", " There is a problem in  Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickToArrowOnAccordionPage()
        // Method Decs: This method click on the right arrow on the accordion page
        // Created on:  3rd Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void ClickToArrowOnAccordionPage()
        {
            try
            {

                IWebElement arrow = Driver.FindElement(SiteContentOR.oAccordionpagearrow_xpath);
                arrow.Click();
                common.CallMeWait(1000);
                Report.UpdateTestLog("ClickToArrowOnAccordionPageFinalStep", "Clicked on Arrcow icon", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickToArrowOnAccordionPage", "Unable to click on arrow icon" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToArrowOnAccordionPage", " There is a problem in  Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyPresenceOfAccordionModeOptions()
        // Method Decs: This method verify all the accordion mode option are present in the drop down
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyPresenceOfAccordionModeOptions()
        {
            try
            {
                string req10 = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();
                string[] data = req10.Split(',');
                SelectElement oselect = new SelectElement(Driver.FindElement(SiteContentOR.oaccordionModeSelect_id));
                Report.UpdateTestLog("VerifyPresenceOfAccordionModeOptions", "Accordion Drop down is present", Status.PASS);
                   
                    IList<IWebElement> elmcount = oselect.Options;
                    List<string> elmcounttext = new List<string>();
                    for (int i = 0; i < elmcount.Count; i++)
                    {
                        string s = elmcount[i].Text.Trim();
                        elmcounttext.Add(s);
                       
                    }
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (elmcounttext.Contains(data[i]))
                        {
                            Report.UpdateTestLog("VerifyPresenceOfAccordionModeOptionsFinalStep", data[i] + " is present ", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("VerifyPresenceOfAccordionModeOptions", data[i] + " is not present ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
  
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPresenceOfAccordionModeOptions", "accordion mode option are not present :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPresenceOfAccordionModeOptions", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyAccordionSectionCount()
        // Method Decs: This method count the accordion section in the accordion page and it should be max 
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyAccordionSectionCount()
        {
            try
            {
                string req8 = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                int n = Int32.Parse(req8);
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.oaccordionsection_xpath);
                if (elms.Count()<=n)
                {
                    Report.UpdateTestLog("VerifyAccordionSectionCountFinalStep", "Total Accordion section present " + elms.Count(), Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyAccordionSectionCount", "Total Accordion section present " + elms.Count(), Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyAccordionSectionCount", "accordion mode option are not present :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyAccordionSectionCount", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: OpenFormToCreatePage()
        // Method Decs: This method Click on the File option under Site Content 
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void OpenFormToCreatePage()
        {
            try
            {
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                Report.UpdateTestLog("OpenFormToCreatePage", " Clicked on File option", Status.PASS);
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                Report.UpdateTestLog("OpenFormToCreatePage", "Clicked on New Document option", Status.PASS);
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.ocreatecbreintrapage_xpath);
                Driver.FindElement(SiteContentOR.ocreatecbreintrapage_xpath).Click();
                Report.UpdateTestLog("OpenFormToCreatePageFinalStep", "Clicked on CBRE Intranet Page option", Status.PASS);
                common.CallMeWait(1000);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("OpenFormToCreatePage", "Unable to open Page form" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("OpenFormToCreatePage", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: EnterPageTitle()
        // Method Decs: This method Enter Page Title in the page Creation Form 
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void EnterPageTitle()
        {
            try
            {
                string pagename1 = DataTable.GetData("General_Data_" + Env, "PageName");
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string pagename = pagename1 + "_" + ArticleDate;
                common.WaitForElement(SiteContentOR.otitleTextBox_xpath);
                Driver.FindElement(SiteContentOR.otitleTextBox_xpath).SendKeys(pagename);
                Report.UpdateTestLog("EnterPageTitleFinalStep", "Page Title is : " + pagename1, Status.PASS);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterPageTitle", "Unable to enter page title    " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterPageTitle", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickToCreatePage()
        // Method Decs: This method clicks the Create Page option on the Page Creation form 
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ClickToCreatePage()
        {
            try
            {
                common.WaitForElement(SiteContentOR.ocreatepage_xpath);
                Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                Report.UpdateTestLog("ClickToCreatePageFinalStep", "Click on Create Page Button", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickToCreatePage", "Unable to click Create Page Button" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToCreatePage", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectPageType()
        // Method Decs: This method select type of page to be create
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectPageType()
        {
            try
            {
                string pagetype = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                string dxpath = "//*[text()='" + pagetype + "']";
                By pagetype_xpath = By.XPath(dxpath);
                common.WaitForElement(pagetype_xpath);
                Driver.FindElement(pagetype_xpath).Click();
                Report.UpdateTestLog("SelectPageType", "Page type is :" + pagetype, Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectPageType", "Unable to select page type:  " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectPageType", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateMenuIcon()
        // Method Decs: This method validates the menu icon beside every document
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ValidateMenuIcon()
        {
            try
            {
                bool flag = false;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                int rowCount = elms.Count;
                for (int i = 1; i <= rowCount; i++)
                {
                    string icon = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[4]/div/a")).GetAttribute("title");
                    if (icon.Equals("Open Menu"))
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    Report.UpdateTestLog("ValidateMenuIconFinalStep", " Documents have an '...' icon beside ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateMenuIconFinalStep", " Documents don't have an '...' icon beside ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateMenuIcon", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateMenuIcon", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateDocumentsInWebPart()
        // Method Decs: This method validates documents in Document web part
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateDocumentsInWebPart()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oWebParts_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> webparts = Driver.FindElements(SiteContentOR.oWebParts_xpath);
                    if (webparts.Count == 2)
                    {
                        ReadOnlyCollection<IWebElement> DocTitleFirstWebPart = Driver.FindElements(By.XPath("//*[@class='ms-webpart-zone ms-fullWidth']/div[1]/div/div/div/div/wp-documents/div/div/table/tbody/tr/td[2]/a"));
                        if (DocTitleFirstWebPart.Count == 1)
                        {
                            Report.UpdateTestLog("ValidateDocumentsInWebPart", " Successfully Verify that the new web part only displays the category/s that were selected ", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateDocumentsInWebPart", " Unable to Verify that the new web part only displays the category/s that were selected ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                        ReadOnlyCollection<IWebElement> DocTitleSecondWebPart = Driver.FindElements(By.XPath("//*[@class='ms-webpart-zone ms-fullWidth']/div[2]/div/div/div/div/wp-documents/div/div/table/tbody/tr/td[2]/a"));
                        if (DocTitleFirstWebPart.Count >= 1)
                        {
                            Report.UpdateTestLog("ValidateDocumentsInWebPartFinalStep", " Successfully Verify the old web part displays all documents ", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateDocumentsInWebPart", " Unable to Verify the old web part displays all documents ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateDocumentsInWebPart", " No Web Part is present in page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDocumentsInWebPart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDocumentsInWebPart", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateSimpleView()
        // Method Decs: This method validates headers in simple view
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateSimpleView()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oicon_xpath) == true)
                {
                    string icontext = Driver.FindElement(SiteContentOR.oicon_xpath).GetAttribute("src");
                    if (icontext.Contains(".gif"))
                    {
                        Report.UpdateTestLog("ValidateSimpleView", " Document Icon is present in simple view ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateSimpleView", " Document Icon is not present or not matched with .gif format in simple view", Status.FAIL);
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateSimpleView", " Document Icon field is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                bool flag = true;
                ReadOnlyCollection<IWebElement> Titles = Driver.FindElements(SiteContentOR.oDocHeaders_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType6");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 1; i < Titles.Count; i++)
                    {
                        if (links[j].Trim() != Titles[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateSimpleViewFinalStep", " link '" + links[j].Trim() + "' is present in simple view", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateSimpleView", " link '" + links[j].Trim() + "' is not present in simple view", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSimpleView", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSimpleView", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ModifyViewInWebPart()
        // Method Decs: This method modifies the view option in edit web part section
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ModifyViewInWebPart()
        {
            try
            {
                OpenPagetoEdit();
                OpenWebpartinEditMode();
                if (common.CheckElement(SiteContentOR.DetailedView_id) == true)
                {
                    string value = Driver.FindElement(SiteContentOR.DetailedView_id).GetAttribute("value");
                    if (value.Contains("detailed"))
                    {
                        Driver.FindElement(SiteContentOR.DetailedView_id).Click();
                        Report.UpdateTestLog("ModifyViewInWebPartFinalStep", " Clicked Detailed radio button in View section ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ModifyViewInWebPart", " Detailed view radio button is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ModifyViewInWebPart", " Second Radio button is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ClickToApply();
                ClickToOK();
                Savepage();
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ModifyViewInWebPart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ModifyViewInWebPart", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateDetailedView()
        // Method Decs: This method validates headers in detailed view
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateDetailedView()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oicon_xpath) == true)
                {
                    string icontext = Driver.FindElement(SiteContentOR.oicon_xpath).GetAttribute("src");
                    if (icontext.Contains(".gif"))
                    {
                        Report.UpdateTestLog("ValidateDetailedView", " Document Icon is present in detailed view ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateDetailedView", " Document Icon is not present or not matched with .gif format in detailed view", Status.FAIL);
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateDetailedView", " Document Icon field is not present in detailed view", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                bool flag = true;
                ReadOnlyCollection<IWebElement> Titles = Driver.FindElements(SiteContentOR.oDocHeaders_xpath);
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType7");
                string[] links = requestType1.Split(',');
                for (int j = 0; j < links.Length; j++)
                {
                    for (int i = 1; i < Titles.Count; i++)
                    {
                        if (links[j].Trim() != Titles[i].Text.Trim())
                        {
                            flag = false;
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateDetailedViewFinalStep", " link '" + links[j].Trim() + "' is present in detailed view", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateDetailedView", " link '" + links[j].Trim() + "' is not present in detailed view", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDetailedView", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDetailedView", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreateFolder()
        // Method Decs: This method creates a folder in documents page
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void CreateFolder()
        {
            try
            {
                string FolderName1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string FolderName = FolderName1 + "_" + ArticleDate;
                int i = 0;
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.oNewFolder_xpath).Click();
                common.CallMeWait(1000);
                Report.UpdateTestLog("CreateFolder", " Clicked on New Folder icon ", Status.PASS);
                common.WaitForElement(SiteContentOR.Oselectframe_id);
                ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(SiteContentOR.Oselectframe_id);
                Driver.SwitchTo().Frame(framecoll[0]);
                if (common.CheckElement(SiteContentOR.oNameField_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oNameField_xpath).Click();
                    common.CallMeWait(1000);
                    Driver.FindElement(SiteContentOR.oNameField_xpath).SendKeys(FolderName);
                    Report.UpdateTestLog("CreateFolder", " Entered Folder Name : " + FolderName, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateFolder", " Name input field is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

                }
                ReadOnlyCollection<IWebElement> savebuttons = Driver.FindElements(SiteContentOR.oSaveButton_xpath);
                if (savebuttons.Count > 1)
                {
                    i = savebuttons.Count() - 1;
                }
                else
                {
                    i = 0;
                }
                savebuttons[i].Click();
                Report.UpdateTestLog("CreateFolderFinalStep", " Clicked on Save button ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateFolder", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateFolder", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EnterIntoFolder()
        // Method Decs: This method select and enters into the newly created folder
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void EnterIntoFolder()
        {
            try
            {
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                int i = 1;
                int flags = 0;
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]")).GetAttribute("innerText");
                    if (name.Contains(req2))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]/div/a")).Click();
                    Report.UpdateTestLog("EnterIntoFolderFinalStep", " clicked on  " + req2, Status.PASS);
                    common.CallMeWait(2000);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterIntoFolder", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterIntoFolder", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: CreateSubfolder()
        // Method Decs: This method creates a subfolder in a folder in documents page
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void CreateSubfolder()
        {
            try
            {
                string SubFolderName = DataTable.GetData("General_Data_" + Env, "RequestType6");
                int i = 0;
                //Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                // common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.oNewFolder_xpath).Click();
                common.CallMeWait(1000);
                Report.UpdateTestLog("CreateSubfolder", " Clicked on New Folder icon ", Status.PASS);
                common.WaitForElement(SiteContentOR.Oselectframe_id);
                ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(SiteContentOR.Oselectframe_id);
                Driver.SwitchTo().Frame(framecoll[0]);
                if (common.CheckElement(SiteContentOR.oNameField_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oNameField_xpath).Click();
                    common.CallMeWait(1000);
                    Driver.FindElement(SiteContentOR.oNameField_xpath).SendKeys(SubFolderName);
                    Report.UpdateTestLog("CreateSubfolder", " Entered Folder Name : " + SubFolderName, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateSubfolder", " Name input field is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ReadOnlyCollection<IWebElement> savebuttons = Driver.FindElements(SiteContentOR.oSaveButton_xpath);
                if (savebuttons.Count > 1)
                {
                    i = savebuttons.Count() - 1;
                }
                else
                {
                    i = 0;
                }
                savebuttons[i].Click();
                Report.UpdateTestLog("CreateSubfolderFinalStep", " Clicked on Save button ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateSubfolder", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateSubfolder", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: UploadAnotherFile()
        // Method Decs: This method upload a file in a Folder under site content
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void UploadAnotherFile()
        {
            try
            {
                ClickTonewItem();
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType4");
                common.WaitForElement(SiteContentOR.Oselectframe_id);
                ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(SiteContentOR.Oselectframe_id);
                Driver.SwitchTo().Frame(framecoll[0]);
                Report.UpdateTestLog("UploadAnotherFile", " File upload window is opened ", Status.PASS);
                //click on the Choose a file option
                common.WaitForElement(SiteContentOR.oclicktoupload_xpath);
                Driver.FindElement(SiteContentOR.oclicktoupload_xpath).Click();
                Report.UpdateTestLog("UploadAnotherFile", " Choose a file option is clicked ", Status.PASS);
                // enter image path                 
                AutoItX3 autoit = new AutoItX3();
                autoit.WinActivate("Open");
                autoit.Send(requestType1);
                autoit.Send("{ENTER}");
                common.CallMeWait(1000);
                //click on Ok button
                common.WaitForElement(SiteContentOR.oclickokbutton_xpath);
                Driver.FindElement(SiteContentOR.oclickokbutton_xpath).Click();
                common.CallMeWait(2000);
                //Click on the save option 
                common.WaitForElement(SiteContentOR.Oclicktosave_xpath);
                Report.UpdateTestLog("UploadAnotherFile", " file path is selected ", Status.PASS);
                Driver.FindElement(SiteContentOR.Oclicktosave_xpath).Click();
                Report.UpdateTestLog("UploadAnotherFileFinalStep", " file save button is clicked ", Status.PASS);
                common.CallMeWait(2000);
                Driver.SwitchTo().DefaultContent();
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("UploadAnotherFile", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("UploadAnotherFile", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EnterIntoSubFolder()
        // Method Decs: This method select and enters into the newly created subfolder
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void EnterIntoSubFolder()
        {
            try
            {
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType6");
                int i = 1;
                int flags = 0;
                int rowCount;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(By.XPath("//*[@class='ms-listviewtable']/tbody/tr"));
                rowCount = elms.Count;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                for (i = 1; i <= rowCount; i++)
                {
                    string name = Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]")).GetAttribute("innerText");
                    if (name.Contains(req2))
                    {
                        flags = 1;
                        break;
                    }
                }
                if (flags == 1)
                {
                    Driver.FindElement(By.XPath("//*[@class='ms-listviewtable']/tbody/tr[" + i + "]/td[3]/div/a")).Click();
                    Report.UpdateTestLog("EnterIntoSubFolderFinalStep", " clicked on  " + req2, Status.PASS);
                    common.CallMeWait(2000);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterIntoSubFolder", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterIntoSubFolder", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateFolderSubFolderInWebPart()
        // Method Decs: This method validate folder, subfolder and the documents
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateFolderSubFolderInWebPart()
        {
            try
            {
                bool flag = false;
                string ExpectedTitle = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (common.CheckElement(SiteContentOR.oDocTitles_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> titles = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                    for (int i = 0; i < titles.Count; i++)
                    {
                        string ActualTitle = titles[i].Text.Trim();
                        if (ExpectedTitle.Equals(ActualTitle))
                        {
                            Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Folder is present in Document Webpart ", Status.PASS);
                            titles[i].Click();
                            Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Clicked on folder ", Status.PASS);
                            common.CallMeWait(2000);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Newly created Folder is not present in Document Webpart ", Status.FAIL);
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " No Document is present in web part ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                bool flag1 = false;
                string ExpectedSubTitle = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                if (common.CheckElement(SiteContentOR.oDocTitles_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> subtitles = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                    for (int i = 0; i < subtitles.Count; i++)
                    {
                        string ActualSubTitle = subtitles[i].Text.Trim();
                        if (ExpectedSubTitle.Equals(ActualSubTitle))
                        {
                            Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Sub Folder is present into the Folder ", Status.PASS);
                            subtitles[i].Click();
                            Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Clicked on subfolder ", Status.PASS);
                            common.CallMeWait(2000);
                            flag1 = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Newly created SubFolder is not present in into the folder ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " No Sub Document is present into folder ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ReadOnlyCollection<IWebElement> docs = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                if (docs.Count() - 1 == 2)
                {
                    Report.UpdateTestLog("ValidateFolderSubFolderInWebPartFinalStep", " Both the documents are present in sub folder", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Both the documents are not present in sub folder", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateFolderSubFolderInWebPart", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateFolderSubFolderWIthCategory()
        // Method Decs: This method validate folder, subfolder and the documents based on the category
        // Created on:  04/03/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateFolderSubFolderWIthCategory()
        {
            try
            {
                bool flag = false;
                string ExpectedTitle = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (common.CheckElement(SiteContentOR.oDocTitles_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> titles = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                    for (int i = 0; i < titles.Count; i++)
                    {
                        string ActualTitle = titles[i].Text.Trim();
                        if (ExpectedTitle.Equals(ActualTitle))
                        {
                            Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Folder is present in Document Webpart ", Status.PASS);
                            titles[i].Click();
                            Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Clicked on folder ", Status.PASS);
                            common.CallMeWait(2000);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Newly created Folder is not present in Document Webpart ", Status.FAIL);
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " No Document is present in web part ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                bool flag1 = false;
                string ExpectedSubTitle = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                if (common.CheckElement(SiteContentOR.oDocTitles_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> subtitles = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                    for (int i = 0; i < subtitles.Count; i++)
                    {
                        string ActualSubTitle = subtitles[i].Text.Trim();
                        if (ExpectedSubTitle.Equals(ActualSubTitle))
                        {
                            Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Sub Folder is present into the Folder ", Status.PASS);
                            subtitles[i].Click();
                            Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Clicked on subfolder ", Status.PASS);
                            common.CallMeWait(2000);
                            flag1 = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Newly created SubFolder is not present in into the folder ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " No Sub Document is present into folder ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ReadOnlyCollection<IWebElement> docs = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                if (docs.Count() - 1 == 1)
                {
                    Report.UpdateTestLog("ValidateFolderSubFolderWIthCategoryFinalStep", " Both the documents are present in sub folder", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Both the documents are not present in sub folder", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateFolderSubFolderWIthCategory", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //4 april
        //******************************************************
        // Method Name: EnterTitleInTabPage()
        // Method Decs: This method enter title in the Tab page 
        // Created on:  4th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void EnterTitleInTabPage()
        {
            try
            {
                string req9 = DataTable.GetData("General_Data_" + Env, "RequestType9").Trim();
                common.WaitForElement(SiteContentOR.oTabSection1Title_id);
                if (Driver.FindElement(SiteContentOR.oTabSection1Title_id).Displayed)
                {

                    Driver.FindElement(SiteContentOR.oTabSection1Title_id).Clear();
                    Driver.FindElement(SiteContentOR.oTabSection1Title_id).SendKeys(req9);
                    Report.UpdateTestLog("EnterTitleInTabPageFinalStep", "Tab Section 1 title is entered as : " + req9, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterTitleInTabPage", "Unable to enter title ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterTitleInTabPage", "Tab Section 1 title element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterTitleInTabPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClcikOnAddWeBpartTabPage()
        // Method Decs: This method click on the Add web part option under Tab lay out page 
        // Created on:  4th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ClcikOnAddWeBpartTabPage()
        {
            try
            {
                Driver.FindElement(SiteContentOR.oclickTabwebpart_id).Click();
                common.CallMeWait(1000);
                Report.UpdateTestLog("ClcikOnAddWeBpartTabPageFinalStep", "Click on Add Web part for Tab page ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClcikOnAddWeBpartTabPage", "Unable to click on Add Web part for Tab page " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClcikOnAddWeBpartTabPage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyTabSectionCount()
        // Method Decs: This method count the tab section in the accordion page and it should be max 5 
        // Created on:  3rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyTabSectionCount()
        {
            try
            {
                string req8 = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                int n = Int32.Parse(req8);
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.otabsection_id);
                if (elms.Count() <= n)
                {
                    Report.UpdateTestLog("VerifyTabSectionCountFinalStep", "Total Tab section present " + elms.Count(), Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyTabSectionCount", "Total Tab section present " + elms.Count(), Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyTabSectionCount", "Tab mode option are not present :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyTabSectionCount", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: UncheckSubFolder()
        // Method Decs: This method unchecks the Show Subfolders checkbox in edit web part window
        // Created on:  04/04/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void UncheckSubFolder()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oSubFolderChkBox_id) == true)
                {
                    Driver.FindElement(SiteContentOR.oSubFolderChkBox_id).Click();
                    Report.UpdateTestLog("UncheckSubFolderFinalStep", " Uncheck the Show SubFoders checkbox ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("UncheckSubFolder", " Show SubFoders checkbox field is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("UncheckSubFolder", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("UncheckSubFolder", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateDocumentInList()
        // Method Decs: This method validates the documents in list view from folders and subfolders also
        // Created on:  04/04/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateDocumentInList()
        {
            try
            {
                bool flag = false;
                if (common.CheckElement(SiteContentOR.oDocTitles_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> ActualTitles = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                    string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                    string[] ExpectedTitles = req7.Split(',');
                    for (int i = 0; i < ExpectedTitles.Count(); i++)
                    {
                        for (int k = 0; k < ActualTitles.Count; k++)
                        {
                            if (ExpectedTitles[i].Contains(ActualTitles[k].Text.Trim()))
                            {
                                flag = true;
                            }
                        }
                    }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("ValidateDocumentInList", " Verified that the web part shows the content that was organized in the subfolders as a single list ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateDocumentInList", " Documents that were organized in the subfolders not displaying as a single list", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateDocumentInList", " Documents are not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDocumentInList", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDocumentInList", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: AddYouTubeSourceAndLink()
        // Method Decs: This method will add You Tube Source type and link in video web part
        // Created on:  5th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void AddVideoSourceAndLink()
        {
            try
            {

                string videoSource = DataTable.GetData("AddWebPartInfo", "VideoSource").Trim();
                string link = DataTable.GetData("AddWebPartInfo", "Link").Trim();
                if (common.CheckElement(SiteContentOR.ovideowebpartlist_id) == true)
                {
                    var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                    common.CallMeWait(1000);
                    selectElement.SelectByText(videoSource);
                    Report.UpdateTestLog("AddVideoSourceAndLink", "Video source is added as: " + videoSource, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("AddVideoSourceAndLink", "Unable to add Video source", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.ovideowebpartlinktextbox_id) == true)
                {
                    Driver.FindElement(SiteContentOR.ovideowebpartlinktextbox_id).SendKeys(link);
                    Report.UpdateTestLog("AddVideoSourceAndLinkFinalStep", " Select video source link as  " + link, Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("AddVideoSourceAndLink", "Unable to add Video link", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("AddVideoSourceAndLink", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddVideoSourceAndLink", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ValidateActiveTab()
        // Method Decs: This method validates the active path
        // Created on:  04/12/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateActiveTab()
        {
            try
            {
                bool flag = false;
                bool TabPresent = false;
                string sExpectedTab = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();
                if (common.CheckElement(SiteContentOR.oTabs_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> Tabs = Driver.FindElements(SiteContentOR.oTabs_xpath);
                    for (int i = 0; i < Tabs.Count; i++)
                    {
                        string sActualTab = Tabs[i].Text.Trim();
                        if (sExpectedTab.Equals(sActualTab))
                        {
                            TabPresent = true;
                            if (Tabs[i].GetAttribute("class").Contains("active"))
                            {
                                Report.UpdateTestLog("ValidateActiveTabFinalStep", " Tab '" + sExpectedTab + " is active", Status.PASS);
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateActiveTab", " Tab '" + sExpectedTab + "' is not active", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (TabPresent == false)
                    {
                        Report.UpdateTestLog("ValidateActiveTab", " Tab '" + sExpectedTab + " is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateActiveTab", " Tabs field are not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateActiveTab", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateActiveTab", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnTab()
        // Method Decs: This method clicks on a Tab
        // Created on:  04/12/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ClickOnTab()
        {
            try
            {
                bool flag = false;
                string sExpectedTab = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();
                if (common.CheckElement(SiteContentOR.oTabs_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> Tabs = Driver.FindElements(SiteContentOR.oTabs_xpath);
                    for (int i = 0; i < Tabs.Count; i++)
                    {
                        string sActualTab = Tabs[i].Text.Trim();
                        if (sExpectedTab.Equals(sActualTab))
                        {
                            Tabs[i].Click();
                            common.CallMeWait(5000);
                            Report.UpdateTestLog("ValidateActiveTabFinalStep", " Tab '" + sExpectedTab + "' is clicked", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateActiveTab", " Tab '" + sExpectedTab + "' is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateActiveTab", " Tabs field are not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnTab", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnTab", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateGoogleAnalytics()
        // Method Decs: This method validates google analytics
        // Created on:  04/12/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateGoogleAnalytics()
        {
            try
            {
                bool flag = false;
                string RequestType9 = DataTable.GetData("General_Data_" + Env, "RequestType9").Trim();
                string[] sExpectedHeaders = RequestType9.Split(',');
                if (common.CheckElement(SiteContentOR.oGraprhHeaders_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> sActualHeaders = Driver.FindElements(SiteContentOR.oGraprhHeaders_xpath);
                    for (int i = 0; i < sExpectedHeaders.Length; i++)
                    {
                        for (int j = 0; j < sActualHeaders.Count; j++)
                        {
                            if (sExpectedHeaders[i].Contains(sActualHeaders[j].Text.Trim()))
                            {
                                Report.UpdateTestLog("ValidateGoogleAnalyticsFinalStep",
                                    " Google Analytics graph header '" + sExpectedHeaders[i] + "' is present",
                                    Status.PASS);
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
                            Report.UpdateTestLog("ValidateGoogleAnalytics", " Google Analytics graph header '" + sExpectedHeaders[i] + "' is not present", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateGoogleAnalytics", " Google Analytics graph headers field are not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateGoogleAnalytics", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateGoogleAnalytics", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // 13th April /////////////////////////////////////////////////////////////////////////////

        //******************************************************
        // Method Name: CreateNewsPageAsNewsAuthor()
        // Method Decs: This method will create a page with news layout
        // Created on:  04/13/2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void CreateNewsPageAsNewsAuthor()
        {
            try
            {
                int flag = 0;
                string pagename1 = DataTable.GetData("General_Data_" + Env, "PageName");
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string pagename = pagename1 + "_" + ArticleDate;
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.ocreatecbreintrapage_xpath);
                Driver.FindElement(SiteContentOR.ocreatecbreintrapage_xpath).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.otitleTextBox_xpath);
                Driver.FindElement(SiteContentOR.otitleTextBox_xpath).SendKeys(pagename);
                common.WaitForElement(SiteContentOR.oNewsPage_xpath);
                Driver.FindElement(SiteContentOR.oNewsPage_xpath).Click();
                common.WaitForElement(SiteContentOR.ocreatepage_xpath);
                Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (common.CheckElement((SiteContentOR.ofilelink_xpath)) == true)
                {
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("CreateNewsPageAsNewsAuthorFinalStep", "Page is cretaed with name :" + pagename,
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateNewsPageAsNewsAuthor", "Unable to create page" + pagename,
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateNewsPageAsNewsAuthor", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateNewsPageAsNewsAuthor", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: clickSiteContentsAsNewsAuthor()
        // Method Decs: This method will click on Site Contents item 
        // Created on:  04/13/2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void clickSiteContentsAsNewsAuthor()
        {
            try
            {
                bool flag = false;
                string pagecontentvalue = DataTable.GetData("General_Data_" + Env, "Pagecontentvalue");
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(SiteContentOR.ositecontentspagelist_xapth);
                for (int i = 1; i <= elms.Count; i++)
                {
                    string innerValue =
                        Driver.FindElement(By.XPath("//*[@id='applist']/div[" + i + "]/div[2]/div[1]/div/a")).Text;

                    if (innerValue.Contains(pagecontentvalue))
                    {
                        Driver.FindElement(By.XPath("//*[@id='applist']/div[" + i + "]/div[1]")).Click();
                        flag = true;
                        common.CallMeWait(2000);
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("clickSiteContentsAsNewsAuthor", " Not able to find Pages : ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("clickSiteContentsAsNewsAuthorFinalStep", " Clicked on Item  Pages : " + pagecontentvalue, Status.PASS);
                    
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("clickSiteContentsAsNewsAuthor", " Error on ClickOnSiteContentsItem method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateLanguageOption()
        // Method Decs: This method will validate language option 
        // Created on:  04/13/2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ValidateLanguageOption()
        {
            try
            {
                if (common.CheckElement(SiteContentOR.oLanguageSwitcher_class) == false)
                {
                    Report.UpdateTestLog("ValidateLanguageOptionFinalStep", " The new page does not have any language options ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateLanguageOption", " The new page has language options " , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLanguageOption", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLanguageOption", " Problem in VerifyIntranetCategory Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeletepageAsNewsAuthor()
        // Method Decs: This method will find a page and delete the click on page 
        // Created on:  25th Jan 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void DeletepageAsNewsAuthor()
        {
            int flag = 0;
            try
            {
                ClickOnTopNavigationItem();
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.oSaveRibbon_xpath);
                Driver.FindElement(SiteContentOR.oSaveRibbon_xpath).Click();
                common.WaitForElement(SiteContentOR.odeletepage_xpath);
                //Driver.FindElement(SiteContentOR.ocreatepage_xpath).Click();
                if (Driver.FindElement(SiteContentOR.odeletepage_xpath).Displayed)
                {
                    Driver.FindElement(SiteContentOR.odeletepage_xpath).Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Alert().Accept();
                    common.CallMeWait(1000);
                    flag = 1;
                }

                if (flag == 1)
                {
                    Report.UpdateTestLog("DeletepageAsNewsAuthorFinalStep", "Page is deleted ",
                        Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("DeletepageAsNewsAuthor", "Unable to delete the page",
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeletepageAsNewsAuthor", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeletepageAsNewsAuthor", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: PresenceOfViseoSourceType()
        // Method Decs: This method will verify presence of all video source ubder video source type
        // Created on:  04/13/2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void PresenceOfViseoSourceType()
        {
            try
            {
                bool flag = false;
                string RequestType8 = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                string[] Expectedvideoname = RequestType8.Split(',');
                if (common.CheckElement(SiteContentOR.ovideowebpartlist_id) == true)
                {
                    Report.UpdateTestLog("PresenceOfViseoSourceType", "Video source Type is present ", Status.PASS);
                    var selectElement = new SelectElement(Driver.FindElement(SiteContentOR.ovideowebpartlist_id));
                    IList<IWebElement> Actualvideoname = selectElement.Options;
                    for (int i = 0; i < Expectedvideoname.Count(); i++)
                    {

                        for (int j = 0; j < Actualvideoname.Count(); j++)
                        {
                            if (Expectedvideoname[i].Trim().Contains(Actualvideoname[j].Text.Trim()))
                            {
                                Report.UpdateTestLog("PresenceOfViseoSourceTypeFinalStep", Expectedvideoname[i].Trim() + " is present ", Status.PASS);
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {

                            Report.UpdateTestLog("PresenceOfViseoSourceType", Expectedvideoname[i].Trim() + " is not  present ", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("PresenceOfViseoSourceType", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("PresenceOfViseoSourceType", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyTabInAnalyticsDashboard()
        // Method Decs: This method validates Tab in Analytics Dashboard
        // Created on:  04/14/2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyTabInAnalyticsDashboard()
        {
            try
            {
                string alltime = DataTable.GetData("General_Data_" + Env, "RequestType1");
                if (common.CheckElement(SiteContentOR.oleastViewed) == true)
                {
                    Report.UpdateTestLog("VerifyTabInAnalyticsDashboard", " Least popular is present ", Status.PASS);
                    string leastpopularheader = Driver.FindElement(SiteContentOR.oleastViewed).Text.Trim();
                    ReadOnlyCollection<IWebElement> elms1 = Driver.FindElements(SiteContentOR.oleastViewedoption);
                    string path1 = "//*[@id='leastViewed']/div/div[2]/div";
                    DashboardDataAnalyser(alltime, elms1, leastpopularheader, path1);
                }
                else
                {
                    Report.UpdateTestLog("VerifyTabInAnalyticsDashboard", " Least popular is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SiteContentOR.omostViewed) == true)
                {
                    Report.UpdateTestLog("VerifyTabInAnalyticsDashboard", " Most popular is present ", Status.PASS);
                    string mostpopularheader = Driver.FindElement(SiteContentOR.omostViewed).Text.Trim();
                    ReadOnlyCollection<IWebElement> elms2 = Driver.FindElements(SiteContentOR.omostViewedoption);
                    string path2 = "//*[@id='mostViewed']/div/div[2]/div";
                    DashboardDataAnalyser(alltime, elms2, mostpopularheader, path2);
                }
                else
                {
                    Report.UpdateTestLog("VerifyTabInAnalyticsDashboard", " Most popular is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyTabInAnalyticsDashboard", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyTabInAnalyticsDashboard", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateCommentNotAvailable()
        // Method Decs: This method validates comment section not available
        // Created on: 04/17/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateCommentNotAvailable()
        {
            try
            {                
                if (common.CheckElement(SiteContentOR.oBlogCommentArea_XPath) == false)
                {
                    Report.UpdateTestLog("ValidateCommentNotAvailableFinalStep", " Comment section is not present ", Status.PASS);                    
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentNotAvailable", " Comment section is present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCommentNotAvailable", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCommentNotAvailable", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClicktoAddwebPartinPage()
        // Method Decs: This method click on add web part option during edit page
        // Created on:  18th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void ClicktoAddwebPartinPage()
        {

            try
            {
                IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
                IWebElement addwebpart = Driver.FindElement(By.XPath("//*[@id='MSOZone']/div[1]"));
                js.ExecuteScript("CoreInvoke('ShowWebPartAdder', 'MainZone');");
                Report.UpdateTestLog("ClicktoAddwebPartinPageFinalStep", " Click on Add a Web Part element  ", Status.PASS);
                common.CallMeWait(1000);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClicktoAddwebPartinPage", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClicktoAddwebPartinPage", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyWebPartBackgroundColor()
        // Method Decs: This method will click given web part and verify its background color
        // Created on:  18th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void VerifyWebPartBackgroundColor()
        {
            string webPartCategories = DataTable.GetData("General_Data_" + Env, "WebPartCategories").Trim();
            string webParts = DataTable.GetData("General_Data_" + Env, "WebParts").Trim();
            string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();

            ClickOnWebpartCategory(webPartCategories);
            try
            {

                Driver.FindElement(By.XPath("//*[@title=\"" + webParts + "\"]")).Click();
                Report.UpdateTestLog("VerifyWebPartBackgroundColor", " Click on  Web Part element : " + webParts, Status.PASS);
                string c = Driver.FindElement(By.XPath("//*[@title=\"" + webParts + "\"]")).GetCssValue("color").Trim();
                if (c.Contains(req1))
                {
                    Report.UpdateTestLog("VerifyWebPartBackgroundColorFinalStep", "back ground color for web part is blue",
                         Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyWebPartBackgroundColor", "Can't find what you are looking for Text color not matched",
                   Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyWebPartBackgroundColor", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyWebPartBackgroundColor", " There is a problem in  Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: CancleAddingWebPart()
        // Method Decs: This method will click on cancle button given web part and verify its background colorso that wen part can not be added
        // Created on:  18th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void CancleAddingWebPart()
        {
            try
            {

                if (common.CheckElement(SiteContentOR.owebpartcancle_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.owebpartcancle_xpath).Click();
                    Report.UpdateTestLog("CancleAddingWebPartFinalStep", "Clicked on Cancle option ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CancleAddingWebPart", "Unable to cancle adding web part", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CancleAddingWebPart", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CancleAddingWebPart", " There is a problem in  Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickOnAddButton()
        // Method Decs: This method will click on Add button in order to add selected web part in the page
        // Created on:  18th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ClickOnAddButton()
        {
            try
            {

                if (common.CheckElement(SiteContentOR.owebpartadd_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.owebpartadd_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClickOnAddButtonFinalStep", "Clicked on add option ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnAddButton", "Unable to add adding web part", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnAddButton", " Element not found : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnAddButton", " There is a problem in  Method : " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EnterDetailsforMonthEvent()
        // Method Decs: This method enters detail for the event like Title data description etc.
        // Created on: 05/30/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void EnterDetailsforMonthEvent()
        {
            try
            {
                //DateTime today = DateTime.Today;
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                string SDate = startDate.ToString().Split(' ')[0];
                string EDate = endDate.ToString().Split(' ')[0];
                string enevttitle = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                string enevtdesc = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                ReadOnlyCollection<IWebElement> framecoll1 = Driver.FindElements(By.XPath("//iframe[contains(@id, 'DlgFrame')]"));
                Driver.SwitchTo().Frame(framecoll1[0]);

                common.WaitForElement(SiteContentOR.oeventtitle_xpath);
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).Click();
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).SendKeys(enevttitle);
                Report.UpdateTestLog("EnterDetailsforMonthEvent", "Title is entered :" + enevttitle, Status.DONE);

                common.WaitForElement(SiteContentOR.oeventstartdate_xpath);
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).Click();
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).SendKeys(SDate);
                Report.UpdateTestLog("EnterDetailsforMonthEvent", "start date entered " + SDate, Status.DONE);

                common.WaitForElement(SiteContentOR.oeventenddate_xpath);
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).SendKeys(EDate);
                Report.UpdateTestLog("EnterDetailsforMonthEvent", "End Date Entered" + EDate, Status.DONE);

                common.WaitForElement(SiteContentOR.ocalenderdesc_xpath);
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).Click();
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).Clear();
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).SendKeys(enevtdesc);
                Report.UpdateTestLog("EnterDetailsforMonthEventFinalStep", "Description entered" + enevtdesc, Status.PASS);

                string req5 = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                if (req5.Any())
                {
                    try
                    {
                        common.WaitForElement(SiteContentOR.oeventcategory_xpath);
                        Driver.FindElement(SiteContentOR.oeventcategory_xpath).Click();
                        Driver.FindElement(SiteContentOR.oeventcategory_xpath).SendKeys(req5);
                        Report.UpdateTestLog("EnterDetailsforMonthEvent", "Entered event category :" + req5, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterDetailsforMonthEvent", "unable to enter categary", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                string req2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (req2.Any())
                {
                    try
                    {
                        common.WaitForElement(SiteContentOR.oeventprimariservice_xpath);
                        Driver.FindElement(SiteContentOR.oeventprimariservice_xpath).Clear(); ;
                        Driver.FindElement(SiteContentOR.oeventprimariservice_xpath).Click();
                        Driver.FindElement(SiteContentOR.oeventprimariservice_xpath).SendKeys(req2);
                        Report.UpdateTestLog("EnterDetailsforMonthEvent", "Entered event primery services :" + req2, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterDetailsforMonthEvent", "unable to enter primery services", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                if (req3.Any())
                {
                    try
                    {
                        common.WaitForElement(SiteContentOR.oeventpicture_xpath);
                        Driver.FindElement(SiteContentOR.oeventpicture_xpath).Clear();
                        Driver.FindElement(SiteContentOR.oeventpicture_xpath).Click();
                        Driver.FindElement(SiteContentOR.oeventpicture_xpath).SendKeys(req3);
                        Report.UpdateTestLog("EnterDetailsforMonthEvent", "Entered event picture :" + req3, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterDetailsforMonthEvent", "unable to enter picture", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterDetailsforMonthEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterDetailsforMonthEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateMonthsForEvent()
        // Method Decs: This method enters detail for the event like Title data description etc.
        // Created on: 05/30/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateMonthsForEvent()
        {
            try
            {
                //ValidateCurrentMonth
                DateTime now = DateTime.Now;
                string sExpectedMonth = now.ToString("MMM");
                if (common.CheckElement(SiteContentOR.oCurrentMonth_id) == true)
                {
                    string sActualMonth = Driver.FindElement(SiteContentOR.oCurrentMonth_id).Text.Trim();
                    if (sActualMonth.Contains(sExpectedMonth))
                    {
                        Report.UpdateTestLog("ValidateMonthsForEvent", " Actual month is showing the current month " + sExpectedMonth, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateMonthsForEvent", " Actual month is not showing current month, Expected = "+sExpectedMonth+", Actual = "+sActualMonth, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateMonthsForEvent", " Current Month Field is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //ValidateNextMonth
                if (common.CheckElement(SiteContentOR.oNextMonth_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateMonthsForEvent", " Next Month Field is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateMonthsForEvent", " Next Month Field is not present " , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //ValidatePreviousMonth
                if (common.CheckElement(SiteContentOR.oPreviousMonth_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateMonthsForEventFinalStep", " Previous Month Field is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateMonthsForEvent", " Previous Month Field is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateMonthsForEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateMonthsForEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DocumentValidationInList()
        // Method Decs: This method validates the documents in list view from folders and subfolders also
        // Created on:  06/08/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void DocumentValidationInList()
        {
            try
            {
                bool flag = false;
                if (common.CheckElement(SiteContentOR.oDocTitles_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> ActualTitles = Driver.FindElements(SiteContentOR.oDocTitles_xpath);
                    string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                    string[] ExpectedTitles = req7.Split(',');
                    for (int i = 0; i < ExpectedTitles.Count(); i++)
                    {
                        for (int k = 0; k < ActualTitles.Count; k++)
                        {
                            if (ExpectedTitles[i].Contains(ActualTitles[k].Text.Trim()))
                            {
                                flag = true;
                            }
                        }
                    }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("DocumentValidationInListFinalStep", " Verified that the web part shows the content that was organized in the subfolders as a single list ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("DocumentValidationInList", " Documents that were organized in the subfolders not displaying as a single list", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("DocumentValidationInList", " Documents are not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDocumentInList", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DocumentValidationInList", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: PersonfieldNotMandatory()
        // Method Decs: This method  verify  that person is not a mandatory field
        // Created on:  06/09/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void PersonfieldNotMandatory()
        {
            try
            {

                if (common.CheckElement(SiteContentOR.opersonmandatory_xpath) == false)
                {
                    Report.UpdateTestLog("PersonfieldNotMandatoryFinalStep", "Person field is not a mandatory ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("PersonfieldNotMandatory ", "Person field is a mandatory ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("PersonfieldNotMandatory", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("PersonfieldNotMandatory", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

    }
}
