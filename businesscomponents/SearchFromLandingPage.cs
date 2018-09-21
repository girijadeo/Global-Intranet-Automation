using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using CRAFT.BusinessComponents;
using CRAFT.SupportLibraries;
using CRAFT.Uimap;
using Framework_Reporting;
using Framework_Utilities;
using NPOI.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace CRAFT.businesscomponents
{
    internal class SearchFromLandingPage : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;
        private HomePageSearch homepage;
        public SearchFromLandingPage(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
            common = new CommonComponents(ScriptHelper);
            homepage = new HomePageSearch(scriptHelper);
        }

        //******************************************************
        // Method Name: verifyLoginSuccessfulinLandingPage()
        // Method Decs: Verify successful login on landing page
        // Created on: 4th Jan 2017			
        //****************************************************	

        public void VerifyLoginSuccessfulinLandingPage()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.lnkSignOff)== true)
                {
                    Report.UpdateTestLog("VerifyLoginSuccessfulinLandingPageFinalStep", " Login succeeded for valid user", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyLoginSuccessfulinLandingPage", " Login not successful for valid user", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    //FrameworkParameters.StopExecution(true);
                    //FrameworkParameters.
                   // throw new FrameworkException("Verify Login", "Login failed for valid user");
                    //Driver.Quit();
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyLoginSuccessfulinLandingPage ", "Problem in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name:RefinerNamePosition()
        // Method Description: This method will return the position of the refiner tab
        // Created on 01/19/2017
        // Created By: GI offShore Team
        // *****************************************************
        public int RefinerNamePosition(string name)
        {
            int pos = 0;
            try
            {

                int flag = 0;
                ReadOnlyCollection<IWebElement> elems =
                    Driver.FindElements(By.XPath("//*[@class=' ms-ref-refinername']"));
                foreach (var elm in elems)
                {
                    pos++;
                    if (elm.GetAttribute("innerText").Contains(name))
                    {
                        flag = 1;
                        Report.UpdateTestLog("RefinerNamePositionFinalStep", " Found RefinerNamePosition " , Status.PASS);
                        // pos++;
                        break;
                    }
                }
                if (flag == 0)
                {
                    pos = 0;
                }


            }
            catch (Exception e)
            {
                Report.UpdateTestLog("RefinerNamePosition", "Error in RefinerNamePosition " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                
            }
            return pos;

        }
        
        //******************************************************
        // Method Name: verifysearchbox
        // Method Decs: Verify Search Box on landing page
        // Created on: 4th Jan 2017			
        //****************************************************
        public void Verifysearchbox()
        {
            try
            {


                if (Driver.FindElement(SearchFromLandingPageOR.searchdropdown).Displayed)
                {
                    Report.UpdateTestLog("VerifysearchboxFinalStep", "Searchbox is displayed", Status.PASS);
                    Selectoption();
                }
                else
                {
                    Report.UpdateTestLog("Verifysearchbox", "Searchbox is not displayed", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Verifysearchbox", "Error in Verifysearchbox" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: selectoption()
        // Method Decs: Verify Search Box with the selected Search Type
        // Created on: 4th Jan 2017				
        //****************************************************

        public void Selectoption()
        {
            try
            {


                if (Driver.FindElement(SearchFromLandingPageOR.searchdropdown).Displayed)
                {
                    Driver.FindElement(SearchFromLandingPageOR.searchdropdown).Click();
                    //Driver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);

                    if (Driver.FindElement(SearchFromLandingPageOR.event1).Displayed)
                    {
                        Report.UpdateTestLog("Selectoption", "Drop down appears with options", Status.PASS);
                        Driver.FindElement(SearchFromLandingPageOR.event1).Click();

                        if (!Driver.FindElement(SearchFromLandingPageOR.event1).Displayed)
                        {
                            Report.UpdateTestLog("SelectoptionFinalStep", "Events option is selected", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("Selectoption", "Events option is not selected", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }

                    }
                    else
                    {
                        Report.UpdateTestLog("Selectoption", "Drop down doesn't appear with options", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Selectoption ", "Error in Selectoption Method ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: searchfromlandingpage()
        // Method Decs: Parform Search  from landing page
        // Created on: 4th Jan 2017				
        //****************************************************

        public void Searchfromlandingpage()
        {
            try
            {
                String search = DataTable.GetData("General_Data_" + Env, "Search");
                Driver.FindElement(SearchFromLandingPageOR.searchtext).SendKeys(search);
                Driver.FindElement(SearchFromLandingPageOR.searchtext).SendKeys(Keys.Enter);
                //waitForElement((HomePage1.oallContentlink_link));
                common.CallMeWait(2000);


                Report.UpdateTestLog("SearchfromlandingpageFinalStep", "Search done from landing page: " + search, Status.PASS);
                if (common.CheckElement(HomePageSearchOR.oFilterRemoveLink) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oFilterRemoveLink).Click();
                    Report.UpdateTestLog("Searchfromlandingpage", "Remove the Filter with country ",
                    Status.DONE);
                    common.CallMeWait(2000);
                }
            
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("Searchfromlandingpage", "Element Not found: " + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Searchfromlandingpage", "Error in seach method: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: validatesearchpage()
        // Method Decs: Validate Search page after performing the search
        // Created on: 4th Jan 2017				
        //****************************************************

        public void Validatesearchpage()
        {
            try
            {


                if (Driver.FindElement(SearchFromLandingPageOR.eventresult).Displayed)
                {
                    Report.UpdateTestLog("ValidatesearchpageFinalStep", "User is taken to the results page", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("Validatesearchpage", "User is not taken to the results page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Validatesearchpage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: validatecountforFiletrAmerica() it calls clickonFilterLocationAmerica()
        // Method Decs: Validate count page after performing the filter operation (location America)
        // Created on: 4th Jan 2017				
        //****************************************************

        public void ValidatecountforFiletrAmerica()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elems =
                    Driver.FindElements(SearchFromLandingPageOR.osearchpagefiltercountwithAmerica_xpath);
                IWebElement elm = elems[3];
                String count = elm.Text;
                //System.out.println(count);
                int iCount = int.Parse(count);
                ClickonFilterLocationAmerica();

                while (Driver.FindElement(HomePageSearchOR.oloadmorebtn_xpath).Displayed)
                {

                    Driver.FindElement(HomePageSearchOR.oloadmorebtn_xpath).Click();

                    Thread.Sleep(3000);
                    //System.out.println("Clicked");
                }

                ReadOnlyCollection<IWebElement> elements =
                    Driver.FindElements(SearchFromLandingPageOR.oresultFilterAmericacountwebelement_xpath);
                int size = elements.Count;
                //System.out.println(size);
                if (iCount == size)
                {
                    Report.UpdateTestLog("validatecountforFiletrAmericaFinalStep",
                        "Filter Count Matched according to the filter Location America  ", Status.PASS);
                }
                else
                    Report.UpdateTestLog("validatecountforFiletrAmerica",
                        "Filter Count not Matched according to the filter Location America. Expected " + iCount +
                        "Actual " +
                        size, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidatecountforFiletrAmerica", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidatecountforFiletrAmerica", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: clickonFilterLocationAmerica() 
        // Method Decs: Perform filter operation with option location America
        // Created on: 4th Jan 2017				
        //****************************************************

        public void ClickonFilterLocationAmerica()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elems =
                    Driver.FindElements(SearchFromLandingPageOR.osearchpagefilterwithAmerica_xpath);
                IWebElement elm = elems[1];
                //System.out.println(elm.getText());
                elm.Click();
                Thread.Sleep(3000);
                Report.UpdateTestLog("ClickonFilterLocationAmericaFinalStep", "News link is clicked: ", Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickonFilterLocationAmerica", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickonFilterLocationAmerica", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: validateRefiner(). It is calling getSearchCount()
        // Method Decs: Perform filter operation with option location America
        // Created on: 10th Jan 2017				
        //****************************************************

        public void ValidateRefiner()
        {
            try
            {
                common.CallMeWait(2000);
                int searchcount = GetSearchCount();
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string DateModifierflag = DataTable.GetData("General_Data_" + Env, "DateModifier");                
                string filterName = DataTable.GetData("General_Data_" + Env, "RequestType2");
                IWebElement elm;
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(filterName);
                if (pos == 0)
                {
                    pos = RefinerNamePosition("Location");
                    elm = elems[pos - 1];
                }
                else
                {
                    elm = elems[pos - 1];
                }
                ReadOnlyCollection<IWebElement> Requesttype =
                    elm.FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];
                    
                    string typename = elm2.FindElement(By.Id("RefinementName")).Text.Trim();
                    //string typename = elm2.Text.Trim();
                    if (typename.Contains(requestType1.Trim()))
                    {
                        elm2.FindElement(By.Id("RefinementName")).Click();
                        //elm2.Click();
                        common.CallMeWait(1000);
                        Report.UpdateTestLog("validateRefiner", "Clicked on " + requestType1, Status.PASS);
                        //Thread.Sleep(5000);
                        break;
                    }
                }
               /* ReadOnlyCollection<IWebElement> appclr =
                    elm.FindElements(HomePageSearchOR.oApplyClear_xpath);
                for (int k = 0; k < appclr.Count; k++)
                {
                    if (appclr[k].Text.Trim().Contains("Apply"))
                    {
                        appclr[k].Click();
                        Report.UpdateTestLog("validateRefiner", "Clicked on Apply" , Status.PASS);
                        common.CallMeWait(4000);
                        break;
                    }
                }*/
                    if (DateModifierflag.Trim().Equals("Yes"))
                    {
                        if (Driver.FindElement(SearchFromLandingPageOR.odatemodifier_xpath).Displayed)
                        {
                            Driver.FindElement(SearchFromLandingPageOR.odatemodifier_xpath).Click();
                            Thread.Sleep(3000);
                            Report.UpdateTestLog("validateRefiner",
                                "Clicked on Date Modifier ", Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("validateRefiner", "Date Modifier is not present in Search Page ",
                                Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                int refinesearchcount = GetSearchCount();
                if (searchcount > refinesearchcount)
                {
                    Report.UpdateTestLog("validateRefiner",
                        "Validated refined search, Before refine, search count is " + searchcount +
                        " After refine, search count is " + refinesearchcount, Status.PASS);
                }
                else
                {

                    Report.UpdateTestLog("validateRefiner",
                        "Validation failed, Before refine search count is " + searchcount +
                        "After refine searchcount is " + refinesearchcount, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

                }

                // close the filfer 
                try
                {
                   /* string filterName1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                    IWebElement elm3;
                ReadOnlyCollection<IWebElement> elems1 = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos1 = RefinerNamePosition(filterName1);
                if (pos1 == 0)
                {
                    pos1 = RefinerNamePosition("Location");
                    elm3 = elems1[pos1 - 1];
                }
                else
                {
                    elm3 = elems1[pos1 - 1];
                }*/
                  Driver.FindElement(SearchFromLandingPageOR.oclosefilter).Click();
                   /* ReadOnlyCollection<IWebElement> appclr1 =
                    elm3.FindElements(HomePageSearchOR.oApplyClear_xpath);
                    for (int k = 0; k < appclr1.Count; k++)
                    {
                        if (appclr1[k].Text.Trim().Contains("Clear"))
                        {
                            appclr1[k].Click();
                            Report.UpdateTestLog("validateRefiner", "Clicked on Clear", Status.PASS);
                            common.CallMeWait(4000);
                            break;
                        }
                    }*/
                    Thread.Sleep(3000);
                    Report.UpdateTestLog("ValidateRefiner",
                        "Clicked on Close(x) beside text " + requestType1, Status.PASS);
                    if (DateModifierflag.Trim().Equals("Yes"))
                    {
                        int countwithdatemodifier = GetSearchCount();
                        if (countwithdatemodifier > refinesearchcount)
                        {
                            Report.UpdateTestLog("validateRefinerFinalStep",
                                "Validated refined search, With refiner and datemodifier the count is " +
                                refinesearchcount +
                                " With only date modifier the count is " + countwithdatemodifier, Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("validateRefiner",
                                "Refined search validation failed, With refiner and datemodifier the count is " +
                                refinesearchcount +
                                " With only date modifier the count is " + countwithdatemodifier, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        if (GetSearchCount() == searchcount)
                        {
                            Report.UpdateTestLog("validateRefinerFinalStep",
                                "Matched, Expected: " + searchcount + " Actual : " + GetSearchCount(), Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("validateRefiner",
                                "Matched, Expected: " + searchcount + " Actual : " + GetSearchCount(), Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Report.UpdateTestLog("validateRefiner",
                        "Unable to click on Clear ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("validateRefiner", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("validateRefiner", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }



        }


        //******************************************************
        // Method Name: ValidateRefinerWithoutDateModifier(). It is calling getSearchCount()
        // Method Decs: Perform filter operation with option location America
        // Created on: 24th Jan 2017				
        //****************************************************

        public void ValidateRefinerWithoutDateModifier()
        {
            try
            {

                common.CallMeWait(2000);
                int searchcount = GetSearchCount();
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                //string DateModifierflag = DataTable.GetData("General_Data_" + Env, "DateModifier");
                string filterName = DataTable.GetData("General_Data_" + Env, "RequestType2");

                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(filterName);
                IWebElement elm = elems[pos - 1];
                ReadOnlyCollection<IWebElement> Requesttype =
                    elm.FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];

                   // string typename = elm2.FindElement(By.Id("RefinementName")).Text.Trim();
                    string typename = elm2.Text.Trim();
                    if (typename.Contains(requestType1.Trim()))
                    {                        
                       // elm2.FindElement(By.Id("RefinementName")).Click();
                        elm2.Click();
                        Report.UpdateTestLog("ValidateRefinerWithoutDateModifier", "Clicked on " + requestType1 + "under " + filterName + "Refiner", Status.PASS);
                        common.CallMeWait(2000);
                        break;
                    }
                }
                /* ReadOnlyCollection<IWebElement> appclr =
                   elm.FindElements(HomePageSearchOR.oApplyClear_xpath);
                 for (int k = 0; k < appclr.Count; k++)
                 {
                     if (appclr[k].Text.Trim().Contains("Apply"))
                     {
                         appclr[k].Click();
                         Report.UpdateTestLog("ValidateRefinerWithoutDateModifier", "Clicked on Apply", Status.PASS);
                         common.CallMeWait(4000);
                         break;
                     }
                 }*/

                int refinesearchcount = GetSearchCount();
                if (searchcount >= refinesearchcount)
                {
                    Report.UpdateTestLog("ValidateRefinerWithoutDateModifier",
                        "Validated refined search, Before refine search count is " + searchcount +
                        " After refine search count is " + refinesearchcount, Status.PASS);
                }
                else
                {

                    Report.UpdateTestLog("ValidateRefinerWithoutDateModifier",
                        "Validation failed, Before refine search count is " + searchcount +
                        "After refine searchcount is " + refinesearchcount, Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

                }

                // close the filfer 
              /*  try
                {
                    string filterName1 = DataTable.GetData("General_Data_" + Env, "RequestType2");
                    IWebElement elm3;
                    ReadOnlyCollection<IWebElement> elems1 = Driver
                        .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                    int pos1 = RefinerNamePosition(filterName1);
                    if (pos1 == 0)
                    {
                        pos1 = RefinerNamePosition("Location");
                        elm3 = elems1[pos1 - 1];
                    }
                    else
                    {
                        elm3 = elems1[pos1 - 1];
                    }
                    ReadOnlyCollection<IWebElement> appclr1 =
                   elm3.FindElements(HomePageSearchOR.oApplyClear_xpath);
                    for (int k = 0; k < appclr1.Count; k++)
                    {
                        if (appclr1[k].Text.Trim().Contains("Clear"))
                        {
                            appclr1[k].Click();
                            Report.UpdateTestLog("ValidateRefinerWithoutDateModifier", "Clicked on Clear", Status.PASS);
                            common.CallMeWait(4000);
                            break;
                        }
                    }*/
                    Driver.FindElement(SearchFromLandingPageOR.oclosefilter).Click();
                    Report.UpdateTestLog("ValidateRefinerWithoutDateModifier", " Clicked on the close refiner icon", Status.PASS);
                    common.CallMeWait(1000);

                    if (GetSearchCount() == searchcount)
                    {
                        Report.UpdateTestLog("ValidateRefinerWithoutDateModifierFinalStep",
                            "Matched, Expected: " + searchcount + "Actual : " + GetSearchCount(), Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateRefinerWithoutDateModifier",
                            "Notmatched, Expected: " + searchcount + "Actual : " + GetSearchCount(), Status.FAIL); 
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
               /* catch (Exception e)
                {
                    Report.UpdateTestLog("ValidateRefinerWithoutDateModifier",
                        "Unable to click on clear link " , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }*/
            
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateRefinerWithoutDateModifier", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateRefinerWithoutDateModifier", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        


        }
        //******************************************************
        // Method Name: SearchCount(). 
        // Method Decs: Get the search count
        // Created on: 10th Jan 2017				
        //****************************************************

        public void SearchCount()
        {
            try
            {
                int iCount = GetSearchCount();
                if (iCount > 0)
                {
                    Report.UpdateTestLog("SearchCountFinalStep", " Total Number of results :" + iCount, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SearchCount", " No result is displaying" , Status.PASS);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SearchCount", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SearchCount", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: getSearchCount(). 
        // Method Decs: Get the search count
        // Created on: 10th Jan 2017				
        //****************************************************

        public int GetSearchCount()
        {             
                IWebElement elm = Driver.FindElement(SearchFromLandingPageOR.osearchresultcount_xpath);
                String Searchtext = elm.Text.Trim();
                string[] words = Searchtext.Split(' ');
                if (words[0].Contains("About"))
                {
                    Searchtext = words[1].Trim();
                }
                else
                {
                    Searchtext = words[0].Trim();
                }
                if (Searchtext.Contains(","))
                {
                    Searchtext = Searchtext.Replace(",", "");
                }
                return (int.Parse(Searchtext));                      
        }

        //******************************************************
        // Method Name: MouseoverToServiceLines()
        // Method Decs: Hover mouse to a particualr wen element
        // Created on: 10th Jan 2017				
        //****************************************************

        public void MouseoverToServiceLines()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms =
                    Driver.FindElements(SearchFromLandingPageOR.oserviceLinesTopNav_xpath);
                Actions action = new Actions(Driver);
                int flag = 0;

                By sublinktext = By.XPath("//*[text()='Advisory & Transaction Services']");
                string value = elms[0].Text;
                action.MoveToElement(elms[0]);

                action.Perform();

                //action.MoveToElement(elms[0]).ContextClick();
                for (int i = 0; i < 10; i++)
                {

                    if (common.CheckElement(sublinktext) == false)
                    {
                        action.MoveToElement(elms[0]);

                        action.Perform();

                    }
                    else
                    {
                        Driver.FindElement(By.XPath("//*[text()='Advisory & Transaction Services']")).Click();
                        flag = 1;
                        break;
                    }
                }


                if (flag == 1)
                    Report.UpdateTestLog("MouseoverToServiceLinesFinalStep", "Successfully hover on " + value, Status.PASS);
                else
                {
                    Report.UpdateTestLog("MouseoverToServiceLines", "Failed hover on " + value, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("MouseoverToServiceLines", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("MouseoverToServiceLines", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // Method ClickOnEventsLink()
        // Method Description : This method will Click on Events link
        // Created On: 01/18/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnEventsLink()
        {
            try
            {
                bool flag = false;
                common.CallMeWait(2000);
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.odocumentlink_xapth);
                IWebElement elm = elems[1];
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.odocumentlinktext_xapth);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];
                    //System.out.println(elm2.Text);
                    if (elm2.Text.Trim().Equals("Events"))
                    {
                        elm2.Click();
                        //	callMeWait(2000);
                        Report.UpdateTestLog("ClickOnEventsLinkFinalStep", "Successfully clicked on Events link ", Status.PASS);
                        flag = true;
                        break;

                    }
                }
                if (!flag)
                {
                    Report.UpdateTestLog("ClickOnEventsLink", "Not found Events link ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(HomePageSearchOR.oFilterRemoveLink) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oFilterRemoveLink).Click();
                    Report.UpdateTestLog("Search ", "Remove the Filter with country ",
                    Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnEventsLink", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnEventsLink", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickOnRefinerLink()
        // Method Description : This method will Click on a particular refiner
        // Created On: 01/18/2017
        // Created By: GI offShore Team
        // *****************************************      

        public void ClickOnRefinerLink()
        {
            try
            {
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string filterName = DataTable.GetData("General_Data_" + Env, "RequestType2");
                bool flag = false;

                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(filterName);
                IWebElement elm = elems[pos - 1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                //  IWebElement elm10;
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];

                    string typename = elm2.FindElement(By.Id("RefinementName")).Text.Trim();
                    //string typename = elm2.Text.Trim();
                    if (typename.Equals(requestType1.Trim()))
                    {
                        elm2.FindElement(By.Id("RefinementName")).Click();
                        //elm2.Click();
                        Report.UpdateTestLog("ClickOnRefinerLinkFinalStep", "Clicked on " + requestType1 + " Under " + filterName + " Refiner", Status.PASS);
                        Thread.Sleep(5000);
                        //   elm10 = elm2.FindElement(By.Id("RefinementName"));
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ClickOnRefinerLink", " refiner is not found", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
              /*  ReadOnlyCollection<IWebElement> appclr =
                   elm.FindElements(HomePageSearchOR.oApplyClear_xpath);
                for (int k = 0; k < appclr.Count; k++)
                {
                    if (appclr[k].Text.Trim().Contains("Apply"))
                    {
                        appclr[k].Click();
                        Report.UpdateTestLog("ClickOnRefinerLink", "Clicked on Apply", Status.PASS);
                        common.CallMeWait(4000);
                        break;
                    }
                }*/
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnRefinerLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnRefinerLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        // Method ClickOnPagesTab()
        // Method Description : This method will Click on Pages Tab on Search result page
        // Created On: 01/19/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnPagesTab()
        {
            try
            {
                bool flag = false;
                common.CallMeWait(2000);
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.odocumentlink_xapth);
                IWebElement elm = elems[1];
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.odocumentlinktext_xapth);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];
                    //System.out.println(elm2.Text);
                    if (elm2.Text.Trim().Equals("Pages"))
                    {
                        elm2.Click();
                        //	callMeWait(2000);
                        Report.UpdateTestLog("ClickOnPagesTabFinalStep", "Successfully clicked on Pages Tab ", Status.PASS);
                        flag = true;
                        break;

                    }
                }
                if (!flag)
                {
                    Report.UpdateTestLog("ClickOnPagesTab", "Not found Pages Tab ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(HomePageSearchOR.oFilterRemoveLink) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oFilterRemoveLink).Click();
                    Report.UpdateTestLog("ClickOnPagesTab ", "Remove the Filter with country ",
                    Status.DONE);
                    common.CallMeWait(2000);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnPagesTab", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnPagesTab", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        // ******************************************************
        // Method Name: VerifyResultCountinPagesTab()
        // Method Description: Verify the count of search results in pages tab .
        // Created on 01/19/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void VerifyResultCountinPagesTab()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.resultcountwebelement_xpath);
                int count = elems.Count;
                //count = count - 1;
                if (count == 0)
                {
                    Report.UpdateTestLog("verifyResultCountinPagesTabFinalStep",
                        "Successfully verified that in Pages Tab no results are showing when search by Imran Khan ",
                        Status.PASS);
                }
                else
                    Report.UpdateTestLog("verifyResultCountinPagesTab",
                        "Validation failed. Expected result = 0 , Actual result " + count, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("verifyResultCountinPagesTab", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("verifyResultCountinPagesTab", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        // ******************************************************
        // Method Name: VerifyResultScope()
        // Method Description: Verify the search results in particular tab .
        // Created on 01/19/2017
        // Created By: GI offShore Team
        // ****************************************************  

        public void VerifyResultScope()
        {
            try
            {
                IWebElement elm = Driver.FindElement(SearchFromLandingPageOR.oeventstabinsearchresultpage_xpath);
                String text = elm.GetAttribute("class");
                if (text.Contains("selected"))
                {
                    Report.UpdateTestLog("VerifyResultScopeFinalStep", "Successfully validated that the search results show in the events tab", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyResultScope", "The search results do not show in the events tab", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyResultScope", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyResultScope", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        //**********************************************
        // Method ClickOnAllContentsLink()
        // Method Description : This method will Click on All Contents link
        // Created On: 01/19/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnAllContentsLink()
        {
            try
            {


                bool flag = false;
                common.CallMeWait(2000);
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.odocumentlink_xapth);
                IWebElement elm = elems[1];
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.odocumentlinktext_xapth);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];
                    //System.out.println(elm2.Text);
                    if (elm2.Text.Trim().Equals("All Content"))
                    {
                        elm2.Click();
                        //	callMeWait(2000);
                        Report.UpdateTestLog("ClickOnAllContentsLinkFinalStep", "Successfully clicked on All Content link ",
                            Status.PASS);
                        flag = true;
                        break;

                    }
                }
                if (!flag)
                {
                    Report.UpdateTestLog("ClickOnAllContentsLink", "Not found All Contents link ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(HomePageSearchOR.oFilterRemoveLink) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oFilterRemoveLink).Click();
                    Report.UpdateTestLog("ClickOnAllContentsLink ", "Remove the Filter with country ",
                    Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnAllContentsLink", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnAllContentsLink", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        //**********************************************
        // Method ValidateProfilePage()
        // Method Description : This method will Validate the user profile page
        // Created On: 01/24/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateProfilePage()
        {
            try
            {
                //Validate Skills Field

                IWebElement skill = Driver.FindElement(SearchFromLandingPageOR.oSkills_xpath);
                if (skill.Displayed)
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Successfully Validated Skills Field ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Skills Field is not present, element is mapped to " + skill.Text, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // Validate About Me Field

                IWebElement AboutMe = Driver.FindElement(SearchFromLandingPageOR.oAboutMe_xpath);
                if (AboutMe.Displayed)
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Successfully Validated About Me Field ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateProfilePage", " About Me Field is not present, element is mapped to " + AboutMe.Text, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // Validate Interests Field

                IWebElement Interests = Driver.FindElement(SearchFromLandingPageOR.oInterests_xpath);
                if (Interests.Displayed)
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Successfully Validated Interests Field ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Interests Field is not present, element is mapped to " + Interests.Text, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // Validate Schools Field

                IWebElement Schools = Driver.FindElement(SearchFromLandingPageOR.oSchools_xpath);
                if (Schools.Displayed)
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Successfully Validated Schools Field ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Schools Field is not present, element is mapped to " + Schools.Text, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // Validate Past Projects Field

                IWebElement PastProjects = Driver.FindElement(SearchFromLandingPageOR.oPastProjects_xpath);
                if (PastProjects.Displayed)
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Successfully Validated Past Projects Field ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Past Projects Field is not present, element is mapped to " + PastProjects.Text, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                // Validate Ask Me About Field

                IWebElement AskMeAbout = Driver.FindElement(SearchFromLandingPageOR.oAskMeAbout_xpath);
                if (AskMeAbout.Displayed)
                {
                    Report.UpdateTestLog("ValidateProfilePageFinalStep", " Successfully Validated Ask Me About Field ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateProfilePage", " Ask Me About Field is not present, element is mapped to " + AskMeAbout.Text, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateProfilePage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateProfilePage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }

        }

        //**********************************************
        // Method ValidateEnglishTag()
        // Method Description : This method will Validate English Tag in search results
        // Created On: 01/25/2017
        // Created By: GI offShore Team
        // *****************************************


        public void ValidateEnglishTag()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elems = Driver
                                .FindElements(SearchFromLandingPageOR.oEnglishTag_xpath);
                int icount = elems.Count;
                if (icount > 1)
                {
                    Report.UpdateTestLog("ValidateEnglishTagFinalStep", "User is able to find an article using language tag, Total English Tag count is " + icount, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateEnglishTag", "No English Tag is present in search result ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }

            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateEnglishTag", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateEnglishTag", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method VerifyRefinerSortingOrder()
        // Method Description : This method will Validate English Tag in search results
        // Created On: 01/25/2017
        // Created By: GI offShore Team
        // *****************************************
        public void VerifyRefinerSortingOrder()
        {
            try
            {
                int searchcount = GetSearchCount();
                var data1 = new List<String>();
                var data2 = new List<String>();
                string filterName = DataTable.GetData("General_Data_" + Env, "RequestType2");
                IWebElement elm;
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(filterName);

                    elm = elems[pos - 1];
               
                ReadOnlyCollection<IWebElement> Requesttype =
                    elm.FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];

                   // string typename = elm2.FindElement(By.Id("RefinementName")).Text.Trim();
                    string typename = elm2.Text.Trim();
                    data1.Add(typename);
                    data2.Add(typename);
                    
                }
                int check=0;
                data2.Sort();
                for (int i = 0; i < data1.Count; i++)
                {
                    if (!data1[i].Equals(data2[i]))
                    {
                        check = 1;
                    }

                }
                if (check==1)
                {
                    Report.UpdateTestLog("VerifyRefinerSortingOrder", "Refiner are not in sorted order", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("VerifyRefinerSortingOrderFinalStep", "Refiner are in sorted order", Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyRefinerSortingOrder", "Element not in VerifyRefinerSortingOrder found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyRefinerSortingOrder", "Error in VerifyRefinerSortingOrder method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
   
        // ******************************************************
        // Method Name: ValidateIntranetPage()
        // Method Description: This method will click the first link and validate
        // Created on 02/09/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateIntranetPage()
        {
            try
            {              
                if (common.CheckElement(HomePageSearchOR.oAmericasIT_xpath) == true)
                {
                    IWebElement elm = Driver.FindElement(HomePageSearchOR.oAmericasIT_xpath);
                    string title = elm.GetAttribute("title").Trim();
                    elm.Click();
                    common.CallMeWait(2000);
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    if (common.CheckElement(HomePageSearchOR.oPageTitle_xpath) == true)
                    {
                        IWebElement elm1 = Driver.FindElement(HomePageSearchOR.oPageTitle_xpath);
                        string sNewTitle = elm1.Text.Trim();
                        if (title == sNewTitle)
                        {
                            Report.UpdateTestLog("ValidateIntranetPageFinalStep", "Successfully validated that clicking on a link in search result new page is opened in a new tab. Page Name : " + title, Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateIntranetPage", "Page title is not matching. Page Name in search result is : " + title + " ,Page in new tab is : " + sNewTitle, Status.PASS);
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateIntranetPage", "Page Header not present in new tab" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateIntranetPage", "No page link is presnt in the search result", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateIntranetPage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateIntranetPage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateAmericaTag()
        // Method Description : This method will Validate America Tag in search results
        // Created On: 02/09/2017
        // Created By: GI offShore Team
        // *****************************************


        public void ValidateAmericaTag()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> elems = Driver
                                .FindElements(SearchFromLandingPageOR.oAmericaTag_xpath);
                int icount = elems.Count;
                for (int i = 1; i < icount; i++)
                {
                    string stag = elems[i].Text.Trim();
                    if (stag.Contains("Americas") || stag.Contains("United States"))
                    {                                               
                    }
                    else
                    {
                        flag = false;
                        
                    }
                }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("ValidateAmericaTagFinalStep", "Successfully validated that all the links have Americas/United States tag ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateAmericaTag", " Americas/United States Tag is not present in search result links", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }           

            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAmericaTag", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAmericaTag", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateIntranetSearchPages()
        // Method Description: This method will click the links of the search pages and validate the Intranet URL
        // Created on 02/10/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateIntranetSearchPages()
        {
            try
            {
                bool flag = true;
                ReadOnlyCollection<IWebElement> elems = Driver
                                               .FindElements(SearchFromLandingPageOR.oIntranetPageLink_xpath);
                for (int i = 0; i < elems.Count; i++)
                {
                    elems[i].Click();
                    common.CallMeWait(2000);
                    string url = Driver.SwitchTo().Window(Driver.WindowHandles[1]).Url;
                    if (url.Contains("intranet"))
                    {

                    }
                    else
                    {
                        flag = false;
                    }
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]).Close();
                    Driver.SwitchTo().Window(Driver.WindowHandles[0]);
                    elems = Driver.FindElements(SearchFromLandingPageOR.oIntranetPageLink_xpath);
                }
                if (flag == true)
                {
                    Report.UpdateTestLog("ValidateIntranetSearchPagesFinalStep", " Successfully validated that Intranet pages are opening in new tab", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateIntranetSearchPages", " The pages are not Intranet pages", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateIntranetSearchPages", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateIntranetSearchPages", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateSiteScope()
        // Method Description: This method will validate the search site scope
        // Created on 03/07/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateSiteScope()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oSearchScopes_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> scopes = Driver.FindElements(SearchFromLandingPageOR.oSearchScopes_xpath);
                    bool flag = false;
                    for (int i = 0; i < scopes.Count; i++)
                    {
                        string scope = scopes[i].Text.Trim();
                        if (scope == "Site")
                        {
                            flag = true;
                            if (scopes[i].GetAttribute("class").Contains("selected"))
                            {
                                Report.UpdateTestLog("ValidateSiteScopeFinalStep", " Successfully validated that Site Scope search is initiated ", Status.PASS);
                            }
                            else
                            {
                                Report.UpdateTestLog("ValidateSiteScope", " Site Scope search is not initiated ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateSiteScope", " Site Scope is not present in search result page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateSiteScope", " Search scopes are not present in search result page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSiteScope", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSiteScope", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateServices()
        // Method Description : This method will validate primary and secondary service and click on a refiner under primary service
        // Created On: 03/07/2017
        // Created By: GI offShore Team
        // *****************************************      

        public void ValidateServices()
        {
            try
            {
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string PrimaryService = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string SecondaryService = DataTable.GetData("General_Data_" + Env, "RequestType3");


                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(PrimaryService);
                if (pos > 0)
                {
                    Report.UpdateTestLog("ValidateServices", "Tag "+PrimaryService+" is present on left menu ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateServices", "Tag " + PrimaryService + " is not present on left menu ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                int pos1 = RefinerNamePosition(SecondaryService);
                if (pos1 > 0)
                {
                    Report.UpdateTestLog("ValidateServices", "Tag " + SecondaryService + " is present on left menu ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateServices", "Tag " + SecondaryService + " is not present on left menu ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                IWebElement elm = elems[pos - 1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                //  IWebElement elm10;
                if (Requesttype.Count > 0)
                {
                    for (int i = 0; i < Requesttype.Count; i++)
                    {
                        IWebElement elm2 = Requesttype[i];

                        string typename = elm2.FindElement(By.Id("RefinementName")).Text.Trim();
                        //string typename = elm2.Text.Trim();
                       // if (typename.Equals(requestType1.Trim()))
                        // {
                            elm2.FindElement(By.Id("RefinementName")).Click();
                            //elm2.Click();

                            Report.UpdateTestLog("ValidateServicesFinalStep", "Clicked on " + typename + " Under " + PrimaryService + " Refiner ", Status.PASS);
                            Thread.Sleep(5000);
                            //   elm10 = elm2.FindElement(By.Id("RefinementName"));

                            break;
                       // }
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateServices", " No refiner is present under secondary service", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateServices", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateServices", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        // *****************************************
        // Method ValidateServicesNotAvailable()
        // Method Description : This method will validate unavailability of primary and secondary service 
        // Created On: 03/07/2017
        // Created By: GI offShore Team
        // *****************************************      

        public void ValidateServicesNotAvailable()
        {
            try
            {
                string PrimaryService = DataTable.GetData("General_Data_" + Env, "RequestType2");
                string SecondaryService = DataTable.GetData("General_Data_" + Env, "RequestType3");
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(PrimaryService);
                if (pos > 0)
                {
                    Report.UpdateTestLog("ValidateServicesNotAvailable", "Tag " + PrimaryService + " is present on left menu ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("ValidateServicesNotAvailable", "Tag " + PrimaryService + " is not present on left menu ", Status.PASS);
                }
                int pos1 = RefinerNamePosition(SecondaryService);
                if (pos1 > 0)
                {
                    Report.UpdateTestLog("ValidateServicesNotAvailable", "Tag " + SecondaryService + " is present on left menu ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("ValidateServicesNotAvailableFinalStep", "Tag " + SecondaryService + " is not present on left menu ", Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateServicesNotAvailable", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateServicesNotAvailable", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateLanguageInNewsFeedPage()
        // Method Description : This method will validate locale in news feed page
        // Created On: 03/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateLanguageInNewsFeedPage()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oLocale_xpath) == true)
                {
                    string locale = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                    string sActuallocale = Driver.FindElement(SearchFromLandingPageOR.oLocale_xpath).Text.Trim();
                    if (sActuallocale.Contains(locale))
                    {
                        Report.UpdateTestLog("ValidateLanguageInNewsFeedPageFinalStep", " Language " + sActuallocale + " is present in news feed page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateLanguageInNewsFeedPage", " English Language is not present in news feed page, Expected language: " + locale + " Actual Language: " + sActuallocale, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateLanguageInNewsFeedPage", " Language option is not present in news feed page" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLanguageInNewsFeedPage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLanguageInNewsFeedPage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateLanguageInHomePage()
        // Method Description : This method will validate locale in home page
        // Created On: 03/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateLanguageInHomePage()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oLocale_xpath) == true)
                {
                    string locale = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                    string sActuallocale = Driver.FindElement(SearchFromLandingPageOR.oLocale_xpath).Text.Trim();
                    if (sActuallocale.Contains(locale))
                    {
                        Report.UpdateTestLog("ValidateLanguageInHomePageFinalStep", " Language " + sActuallocale + " is present in home page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateLanguageInHomePage", " English Language is not present in home page, Expected language: " + locale + " Actual Language: " + sActuallocale, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateLanguageInHomePage", " Language option is not present in home page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLanguageInHomePage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLanguageInHomePage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateAvailableOption()
        // Method Description : This method will validate a locale from available locale 
        // Created On: 03/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateAvailableOption()
        {
            try
            {
                string AvailableLocale = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();
                bool flag = false;
                if (common.CheckElement(SearchFromLandingPageOR.oLocale_xpath) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oLocale_xpath).Click();
                    Report.UpdateTestLog("ValidateAvailableOption", " Clicked on Locale" , Status.DONE);
                    common.CallMeWait(1000);
                    if (common.CheckElement(SearchFromLandingPageOR.oLocaleDropDown_xpath) == true)
                    {
                        Report.UpdateTestLog("ValidateAvailableOption", " Locale is opened in Edit Mode", Status.PASS);
                        IWebElement dropdown = Driver.FindElement(SearchFromLandingPageOR.oLocaleDropDown_xpath);
                        var selectElement = new SelectElement(dropdown);
                        IList<IWebElement> options = selectElement.Options;
                        for (int i = 0; i < options.Count;i++ )
                        {
                            string slocale = options[i].Text.Trim();
                            if (slocale.Contains(AvailableLocale))
                            {
                                Report.UpdateTestLog("ValidateAvailableOptionFinalStep", " Locale " + slocale + " is available in drop down", Status.PASS);
                                flag = true;
                                break;
                            }

                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("ValidateAvailableOption", " Locale " + AvailableLocale + " is not available in drop down", Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateAvailableOption", " Locale is not opened in Edit Mode", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateAvailableOption", " Language option is not present in home page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAvailableOption", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAvailableOption", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateLocaleNotAvailable()
        // Method Description : This method will validate a locale not available  
        // Created On: 03/07/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateLocaleNotAvailable()
        {
            try
            {
                string NotAvailableLocale = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                bool flag = false;
                    if (common.CheckElement(SearchFromLandingPageOR.oLocaleDropDown_xpath) == true)
                    {                      
                        IWebElement dropdown = Driver.FindElement(SearchFromLandingPageOR.oLocaleDropDown_xpath);
                        var selectElement = new SelectElement(dropdown);
                        IList<IWebElement> options = selectElement.Options;
                        for (int i = 0; i < options.Count; i++)
                        {
                            string slocale = options[i].Text.Trim();
                            if (slocale.Contains(NotAvailableLocale))
                            {
                                Report.UpdateTestLog("ValidateLocaleNotAvailable", " Locale " + slocale + " is available in drop down", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                flag = true;
                                break;
                            }

                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("ValidateLocaleNotAvailableFinalStep", " Locale " + NotAvailableLocale + " is not available in drop down", Status.PASS);
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateLocaleNotAvailable", " Locale is not opened in Edit Mode", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAvailableOption", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAvailableOption", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickOnNewItemProvisioningList()
        // Method Description : This method will click on the new item on provisioning list page  
        // Created On: 03/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnNewItemProvisioningList()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oAddNewProvisioningList_class) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oAddNewProvisioningList_class).Click();
                    Report.UpdateTestLog("ClickOnNewItemProvisioningListFinalStep", " Clicked on new Item link on provisioning list page ", Status.PASS);
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnNewItemProvisioningList", " New Item link is not present on provisioning list page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnNewItemProvisioningList", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnNewItemProvisioningList", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateSecondaryLanguage()
        // Method Description : This method will validate the secondary Language on create new provisioning item form  
        // Created On: 03/08/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateSecondaryLanguage()
        {
            try
            {
                string SecondaryLanguageLabel = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string ExpectedLanguage = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                if (common.CheckElement(SearchFromLandingPageOR.oSecondaryLanguageLabel_xpath) == true)
                {
                    string slabel = Driver.FindElement(SearchFromLandingPageOR.oSecondaryLanguageLabel_xpath).Text.Trim();
                    if (slabel.Contains(SecondaryLanguageLabel))
                    {
                        Report.UpdateTestLog("ValidateSecondaryLanguage", " secondary Language label is present on create new provisioning item form ", Status.PASS);
                        if (common.CheckElement(SearchFromLandingPageOR.oSecondaryLanguages_xpath) == true)
                        {
                            ReadOnlyCollection<IWebElement> languages = Driver.FindElements(SearchFromLandingPageOR.oSecondaryLanguages_xpath);
                            bool flag = false;
                            for (int i = 0; i < languages.Count; i++)
                            {
                                string sActualLanguage = languages[i].Text.Trim();
                                if (sActualLanguage.Contains(ExpectedLanguage))
                                {
                                    Report.UpdateTestLog("ValidateSecondaryLanguageFinalStep", " Language " + ExpectedLanguage + " is present under Secondary Language on create new provisioning item form ", Status.PASS);
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag == false)
                            {
                                Report.UpdateTestLog("ValidateSecondaryLanguage", " Language " + ExpectedLanguage + " is not present under Secondary Language on create new provisioning item form ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }

                        }
                        else
                        {
                            Report.UpdateTestLog("ValidateSecondaryLanguage", " No language is present under secondary Language label on create new provisioning item form ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateSecondaryLanguage", " secondary Language label is not present on create new provisioning item form ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateSecondaryLanguage", " Language label is not present on create new provisioning item form " , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSecondaryLanguage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSecondaryLanguage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method SelectLocale()
        // Method Description : This method will select a locale from available locale 
        // Created On: 03/23/2017
        // Created By: GI offShore Team
        // *****************************************

        public void SelectLocale()
        {
            try
            {
                string AvailableLocale = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                bool flag = false;
                if (common.CheckElement(SearchFromLandingPageOR.oLocale_xpath) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oLocale_xpath).Click();
                    Report.UpdateTestLog("SelectLocale", " Clicked on Locale", Status.DONE);
                    common.CallMeWait(1000);
                    if (common.CheckElement(SearchFromLandingPageOR.oLocaleDropDown_xpath) == true)
                    {
                        Report.UpdateTestLog("SelectLocale", " Locale is opened in Edit Mode", Status.PASS);
                        IWebElement dropdown = Driver.FindElement(SearchFromLandingPageOR.oLocaleDropDown_xpath);
                        var selectElement = new SelectElement(dropdown);
                        IList<IWebElement> options = selectElement.Options;
                        for (int i = 0; i < options.Count; i++)
                        {
                            string slocale = options[i].Text.Trim();
                            if (slocale.Contains(AvailableLocale))
                            {
                                Report.UpdateTestLog("SelectLocale", " Locale " + slocale + " is available in drop down", Status.PASS);                               
                                selectElement.SelectByText(AvailableLocale);
                                common.CallMeWait(2000);
                                Report.UpdateTestLog("SelectLocaleFinalStep", " Locale " + slocale + " is selected from drop down", Status.PASS);
                                flag = true;
                                break;
                            }

                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("SelectLocale", " Locale " + AvailableLocale + " is not available in drop down", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("SelectLocale", " Locale is not opened in Edit Mode", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("SelectLocale", " Language option is not present in home page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectLocale", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectLocale", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateLocale()
        // Method Description : This method will validate the selected locale 
        // Created On: 03/23/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateLocale()
        {
            try
            {
                string Locale = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(SearchFromLandingPageOR.oLocale_xpath) == true)
                {
                    string sActualLocale = Driver.FindElement(SearchFromLandingPageOR.oLocale_xpath).Text.Trim();
                    if (sActualLocale.Contains(Locale))
                    {
                        Report.UpdateTestLog("ValidateLocaleFinalStep", " Successfully validated that locale '" + Locale+"' is selected", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateLocale", " Locale '" + Locale + "' is not selected; Actual Locale is : " + sActualLocale, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateLocale", " Locale field is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLocale", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLocale", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateNewsFeedUrl()
        // Method Description : This method will validate the news Feed URL 
        // Created On: 03/23/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateNewsFeedUrl()
        {
            try
            {
                string sExpectedURL = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string sActaulURL = Driver.Url;
                if (sActaulURL.Contains(sExpectedURL))
                {
                    Report.UpdateTestLog("ValidateNewsFeedUrlFinalStep", " NewsFeed URL is coming as expected, URL is " + sActaulURL, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsFeedUrl", " NewsFeed URL not matched, Expected URL: " + sExpectedURL + " , Actual URL: " + sActaulURL, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNewsFeedUrl", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNewsFeedUrl", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        // 13th April /////////////////////////////////////////////////////////////////////////

        // *****************************************
        // Method ValidateTeamPageUrl()
        // Method Description : This method will validate the team page URL 
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateTeamPageUrl()
        {
            try
            {
                Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                string sExpectedURL = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string sActaulURL = Driver.Url;
                if (sActaulURL.Contains(sExpectedURL))
                {
                    Report.UpdateTestLog("ValidateTeamPageUrlFinalStep", " Team page URL is coming as expected, URL is " + sActaulURL, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateTeamPageUrl", " Team page URL not matched, Expected URL: " + sExpectedURL + " , Actual URL: " + sActaulURL, Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateTeamPageUrl", "Element not found" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateTeamPageUrl", "Error in method" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ChangeLocale()
        // Method Description : This method will change the locale
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ChangeLocale()
        {
            try
            {
                string AvailableLocale = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                bool flag = false;
                if (common.CheckElement(SearchFromLandingPageOR.oLocale_xpath) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oLocale_xpath).Click();
                    Report.UpdateTestLog("ChangeLocale", " Clicked on Locale", Status.DONE);
                    common.CallMeWait(1000);
                    if (common.CheckElement(SearchFromLandingPageOR.oLocaleDropDown_xpath) == true)
                    {
                        Report.UpdateTestLog("ChangeLocale", " Locale is opened in Edit Mode", Status.PASS);
                        IWebElement dropdown = Driver.FindElement(SearchFromLandingPageOR.oLocaleDropDown_xpath);
                        var selectElement = new SelectElement(dropdown);
                        IList<IWebElement> options = selectElement.Options;
                        for (int i = 0; i < options.Count; i++)
                        {
                            string slocale = options[i].Text.Trim();
                            if (slocale.Contains(AvailableLocale))
                            {
                                Report.UpdateTestLog("ChangeLocale", " Locale " + slocale + " is available in drop down", Status.PASS);
                                selectElement.SelectByText(AvailableLocale);
                                common.CallMeWait(4000);
                                Report.UpdateTestLog("ChangeLocaleFinalStep", " Locale " + slocale + " is selected from drop down", Status.PASS);
                                flag = true;
                                break;
                            }

                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("ChangeLocale", " Locale " + AvailableLocale + " is not available in drop down", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                    else
                    {
                        Report.UpdateTestLog("ChangeLocale", " Locale is not opened in Edit Mode", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ChangeLocale", " Language option is not present in home page", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ChangeLocale", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ChangeLocale", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateTeamPageLocale()
        // Method Description : This method will validate the team page URL 
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateTeamPageLocale()
        {
            try
            {
                string dynamicXpath = "//*[text()='My Teams']";
                if (common.CheckElement(By.XPath(dynamicXpath)) == true)
                {
                    Driver.FindElement(By.XPath(dynamicXpath)).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ValidateTeamPageLocale", " Clicked on My Teams " , Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("ValidateTeamPageLocale", " My Teams is not present on top ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                Driver.SwitchTo().Window(Driver.WindowHandles[2]);
                string sExpectedURL = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                string sActaulURL = Driver.Url;
                if (sActaulURL.Contains(sExpectedURL))
                {
                    Report.UpdateTestLog("ValidateTeamPageLocaleFinalStep", " Team page URL is coming as expected, URL is " + sActaulURL, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateTeamPageLocale", " Team page URL not matched, Expected URL: " + sExpectedURL + " , Actual URL: " + sActaulURL, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateTeamPageUrl", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateTeamPageUrl", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateEnglishLanguage()
        // Method Description : This method will validate the English Language
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateEnglishLanguage()
        {
            try
            {
                string sExpectedURL = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string sActaulURL = Driver.Url;
                if (sActaulURL.Contains(sExpectedURL))
                {
                    Report.UpdateTestLog("ValidateEnglishLanguageFinalStep", " Team page URL is coming as expected, URL is " + sActaulURL, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateEnglishLanguage", " Team page URL not matched, Expected URL: " + sExpectedURL + " , Actual URL: " + sActaulURL, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }  
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateEnglishLanguage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateEnglishLanguage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateCzechLanguage()
        // Method Description : This method will validate the Czech Language
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateCzechLanguage()
        {
            try
            {
                string sExpectedURL = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string sActaulURL = Driver.Url;
                if (sActaulURL.Contains(sExpectedURL))
                {
                    Report.UpdateTestLog("ValidateCzechLanguageFinalStep", " Team page URL is coming as expected, URL is " + sActaulURL, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateCzechLanguage", " Team page URL not matched, Expected URL: " + sExpectedURL + " , Actual URL: " + sActaulURL, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCzechLanguage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCzechLanguage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateDanishLanguage()
        // Method Description : This method will validate the Danish Language
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateDanishLanguage()
        {
            try
            {
                string sExpectedURL = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string sActaulURL = Driver.Url;
                if (sActaulURL.Contains(sExpectedURL))
                {
                    Report.UpdateTestLog("ValidateDanishLanguageFinalStep", " Team page URL is coming as expected, URL is " + sActaulURL, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateDanishLanguage", " Team page URL not matched, Expected URL: " + sExpectedURL + " , Actual URL: " + sActaulURL, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDanishLanguage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDanishLanguage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateGermanLanguage()
        // Method Description : This method will validate the German Language
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateGermanLanguage()
        {
            try
            {
                string sExpectedURL = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                string sActaulURL = Driver.Url;
                if (sActaulURL.Contains(sExpectedURL))
                {
                    Report.UpdateTestLog("ValidateGermanLanguageFinalStep", " Team page URL is coming as expected, URL is " + sActaulURL, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateGermanLanguage", " Team page URL not matched, Expected URL: " + sExpectedURL + " , Actual URL: " + sActaulURL, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateGermanLanguage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateGermanLanguage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateSpanishLanguage()
        // Method Description : This method will validate the Spanish Language
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateSpanishLanguage()
        {
            try
            {
                string sExpectedURL = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                string sActaulURL = Driver.Url;
                if (sActaulURL.Contains(sExpectedURL))
                {
                    Report.UpdateTestLog("ValidateSpanishLanguageFinalStep", " Team page URL is coming as expected, URL is " + sActaulURL, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateSpanishLanguage", " Team page URL not matched, Expected URL: " + sExpectedURL + " , Actual URL: " + sActaulURL, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSpanishLanguage", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSpanishLanguage", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickonCzechLink()
        // Method Description : This method clicks Czech link
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickonCzechLink()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oCzech_xpath) == true)
                {
                    Report.UpdateTestLog("ClickonCzechLink", " Link Czech is present ", Status.PASS);
                    Driver.FindElement(SearchFromLandingPageOR.oCzech_xpath).Click();
                    Report.UpdateTestLog("ClickonCzechLinkFinalStep", " Link Czech is clicked ", Status.PASS);
                   // common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickonCzechLink", " Link Czech not found ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickonCzechLink", "Element not found" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickonCzechLink", "Error in method" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickonDanskLink()
        // Method Description : This method clicks Dansk link
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickonDanskLink()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oDansk_xpath) == true)
                {
                    Report.UpdateTestLog("ClickonDanskLink", " Link Dansk is present ", Status.PASS);
                    Driver.FindElement(SearchFromLandingPageOR.oDansk_xpath).Click();
                    Report.UpdateTestLog("ClickonDanskLinkFinalStep", " Link Dansk is clicked ", Status.PASS);
                   // common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickonDanskLink", " Link Dansk not found ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickonDanskLink", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickonDanskLink", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickonDeutchLink()
        // Method Description : This method clicks Deutch link
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickonDeutchLink()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oDeutsch_xpath) == true)
                {
                    Report.UpdateTestLog("ClickonDeutchLink", " Link Deutch is present ", Status.PASS);
                    Driver.FindElement(SearchFromLandingPageOR.oDeutsch_xpath).Click();
                    Report.UpdateTestLog("ClickonDeutchLinkFinalStep", " Link Deutch is clicked ", Status.PASS);
                    //common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickonDeutchLink", " Link Deutch not found ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickonDeutchLink", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickonDeutchLink", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickonEspanolLink()
        // Method Description : This method clicks Espanol link
        // Created On: 04/13/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickonEspanolLink()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oEspanol_xpath) == true)
                {
                    Report.UpdateTestLog("ClickonEspanolLink", " Link Espanol is present ", Status.PASS);
                    Driver.FindElement(SearchFromLandingPageOR.oEspanol_xpath).Click();
                    Report.UpdateTestLog("ClickonEspanolLinkFinalStep", " Link Espanol is clicked ", Status.PASS);
                    //common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickonEspanolLink", " Link Espanol not found ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickonEspanolLink", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickonEspanolLink", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateDocumentTypeRefiner()
        // Method Description : This method validates the document type refiners
        // Created On: 04/19/2017
        // Created By: GI offShore Team
        // *****************************************      

        public void ValidateDocumentTypeRefiner()
        {
            try
            {                             
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string[] ExpectedRefiners = requestType1.Split(',');
                string filterName = DataTable.GetData("General_Data_" + Env, "RequestType2");
                bool flag = false;

                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(filterName);
                IWebElement elm = elems[pos - 1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement2_xpath);
                //  IWebElement elm10;
                for (int k = 0; k < ExpectedRefiners.Length; k++)
                {
                    string ExpectedRefiner = ExpectedRefiners[k];
                    for (int i = 0; i < Requesttype.Count; i++)
                    {
                        string ActualRefiner = Requesttype[i].Text.Trim();
                        if (ExpectedRefiner.Equals(ActualRefiner))
                        {
                            Report.UpdateTestLog("ValidateDocumentTypeRefinerFinalStep", " Refiner '" + ExpectedRefiner + "' is present under category '" + filterName + "'", Status.PASS);
                            flag = true;
                            break;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ValidateDocumentTypeRefiner", " All the expected refiners are not present ", Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDocumentTypeRefiner", "Element not found" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDocumentTypeRefiner", "Error in method" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method MouseHoverOnDocument()
        // Method Description : This method hovers over a document
        // Created On: 04/19/2017
        // Created By: GI offShore Team
        // *****************************************

        public void MouseHoverOnDocument()
        {
            try
            {
                ReadOnlyCollection<IWebElement> documents = Driver.FindElements(HomePageSearchOR.odocumentsearchlink_xapth);
                Actions action = new Actions(Driver);
                action.MoveToElement(documents[1]);
                action.Perform();
                common.CallMeWait(1000);
                if (common.CheckElement(SearchFromLandingPageOR.oHoverClose_class) == true)
                {
                    Report.UpdateTestLog("MouseHoverOnDocumentFinalStep", " Successfully mouse hover on document", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("MouseHoverOnDocument", " Unable to mouse hover on document", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("MouseHoverOnDocument", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("MouseHoverOnDocument", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateHoverPopUp()
        // Method Description : This method validates the pop-up after mouse hover
        // Created On: 04/19/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateHoverPopUp()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oHoverTitle_class) == true)
                {
                    Report.UpdateTestLog("MouseHoverOnDocument", " Document title is present in small window after mouse hover on a document", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("MouseHoverOnDocument", " Document title is not present in small window after mouse hover on a document", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(SearchFromLandingPageOR.oHoverView_class) == true)
                {
                    Report.UpdateTestLog("MouseHoverOnDocumentFinalStep", " VIEW link is present in small window after mouse hover on a document", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("MouseHoverOnDocument", " VIEW link is not present in small window after mouse hover on a document", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateHoverPopUp", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateHoverPopUp", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateErrorMessage()
        // Method Description : This method validates error message in search result page
        // Created On: 04/20/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateErrorMessage()
        {
            try
            {
                string sExpectedError = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(SearchFromLandingPageOR.oSearchError_class) == true)
                {
                    string sActualError = Driver.FindElement(SearchFromLandingPageOR.oSearchError_class).Text.Trim();
                    if (sActualError.Contains(sExpectedError))
                    {
                        Report.UpdateTestLog("ValidateErrorMessage", " Search error message is as expected. The Error message is : '" + sActualError + "'." , Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateErrorMessage", " Search error message is not as expected. Actual Error message is : '" + sActualError + "'. Expected Error message is : '" + sExpectedError+"'.", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateErrorMessage", " Search error field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateErrorMessage", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateErrorMessage", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickOnSearchIcon()
        // Method Description : This method clicks on the search icon
        // Created On: 04/21/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnSearchIcon()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.searchicon) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.searchicon).Click();
                    Report.UpdateTestLog("ClickOnSearchIconFinalStep", " Clicked on search icon ", Status.PASS);
                    common.CallMeWait(1000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnSearchIcon", " Search icon not found" , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnSearchIcon", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnSearchIcon", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateNoSearchResult()
        // Method Description : This method validates that there is no search result
        // Created On: 04/21/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateNoSearchResult()
        {
            try
            {

                if (common.CheckElement(SearchFromLandingPageOR.oFeaturedNews_class)==true)
                {
                    Report.UpdateTestLog("ValidateNoSearchResultFinalStep", " After clicking on the search icon system doesn't show any result and remains in the same page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateNoSearchResult", " After clicking on the search icon different page opened ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNoSearchResult", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNoSearchResult", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method CreateProvisionSite()
        // Method Description : This method creates provision site
        // Created On: 04/24/2017
        // Created By: GI offShore Team
        // *****************************************

        public void CreateProvisionSite()
        {
            try
            {
                string Title = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                DateTime today = DateTime.Now;
                string ArticleDate = today.ToString("yyyyMMddHHmmss");
                string SiteTitle = Title + "_" + ArticleDate;
                string ContentOwner = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string Language = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();               
                //Enter Site Title
                if (common.CheckElement(SearchFromLandingPageOR.oSiteTitleInput_title) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oSiteTitleInput_title).Click();
                    Driver.FindElement(SearchFromLandingPageOR.oSiteTitleInput_title).SendKeys(SiteTitle);
                    Report.UpdateTestLog("CreateProvisionSite", " Entered Site Title : " + SiteTitle, Status.PASS);
                    common.CallMeWait(1000);
                }
                else
                {
                    Report.UpdateTestLog("CreateProvisionSite", " Site Title field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Enter Content Owner
                if (common.CheckElement(SearchFromLandingPageOR.oSiteContentOwnerDiv_title) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oSiteContentOwnerDiv_title).Click();
                    common.CallMeWait(1000);
                    Driver.FindElement(SearchFromLandingPageOR.oSiteContentOwner_title).SendKeys(ContentOwner);
                    Report.UpdateTestLog("CreateProvisionSite", " Entered Content owner : " + ContentOwner, Status.PASS);
                    common.CallMeWait(1000);
                }
                else
                {
                    Report.UpdateTestLog("CreateProvisionSite", " Site Content Owner field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // Select Primary language
                if (common.CheckElement(SearchFromLandingPageOR.oSitePrimaryLanguage_title) == true)
                {
                    var dropdown = Driver.FindElement(SearchFromLandingPageOR.oSitePrimaryLanguage_title);
                    var selectElement = new SelectElement(dropdown);
                    common.CallMeWait(1000);
                    selectElement.SelectByText(Language);
                    Report.UpdateTestLog("CreateProvisionSiteFinalStep", " Selected Primary Language " + Language, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("CreateProvisionSite", " Primary language field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateProvisionSite", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateProvisionSite", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeleteProvisionSite()
        // Method Decs: This method deletes provision site 
        // Created on:  04/24/2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void DeleteProvisionSite()
        {
            bool flag = false;
            try
            {
                //common.WaitForElement(SiteContentOR.ofilelink_xpath);
                //Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                //common.CallMeWait(1000);
                //common.WaitForElement(SiteContentOR.odeletedoc_xpath);
                if (common.CheckElement(SearchFromLandingPageOR.oRibbonItems_id) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oRibbonItems_id).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeleteProvisionSite", " Clicked on Items on Ribbon ", Status.PASS);
                    if (common.CheckElement(SiteContentOR.oBestBetDelete_xpath) == true)
                    {
                        Driver.FindElement(SiteContentOR.oBestBetDelete_xpath).Click();
                        common.CallMeWait(1000);
                        Driver.SwitchTo().Alert().Accept();
                        common.CallMeWait(1000);
                        flag = true;
                    }
                    else
                    {
                        Report.UpdateTestLog("DeleteProvisionSite", "Delete option is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("DeleteProvisionSiteFinalStep", " provision site is deleted ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("DeleteProvisionSite", "Unable to delete provision site", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("DeleteProvisionSite", " Items field on ribbon not found", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteProvisionSite", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteProvisionSite", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectAProvisionSite()
        // Method Decs: This Method select a site
        // Created on:  04/24/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void SelectAProvisionSite()
        {
            try
            {
                common.CallMeWait(2000);
                ReadOnlyCollection<IWebElement> SiteTitles = Driver.FindElements(LinksOR.oSiteTitles_xpath);
                ReadOnlyCollection<IWebElement> checkboxes = Driver.FindElements(LinksOR.oSelectLinks_xpath);
                string ExpectedSiteTitle = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                bool flag = false;
                for (int i = 0; i < SiteTitles.Count; i++)
                {
                    string ActualSiteTitle = SiteTitles[i].Text.Trim();
                    if (ActualSiteTitle.Contains(ExpectedSiteTitle))
                    {
                        checkboxes[i+1].Click();
                        Report.UpdateTestLog("SelectAProvisionSiteFinalStep", " Selected Site Title row to edit ", Status.PASS);
                        flag = true;
                        common.CallMeWait(2000);
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("SelectAProvisionSite", " Expected Site Title is not present in the site list ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectAProvisionSite", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectAProvisionSite", " Error in method : " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: OpenProvisionSite()
        // Method Decs: This Method opens a provision site
        // Created on:  04/24/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void OpenProvisionSite()
        {
            try
            {
                common.CallMeWait(2000);
                ReadOnlyCollection<IWebElement> SiteTitles = Driver.FindElements(LinksOR.oSiteTitles_xpath);
                ReadOnlyCollection<IWebElement> SiteLocations = Driver.FindElements(LinksOR.oNewSiteLocation_xpath);
                string ExpectedSiteTitle = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                bool flag = false;
                for (int i = 0; i < SiteTitles.Count; i++)
                {
                    string ActualSiteTitle = SiteTitles[i].Text.Trim();
                    if (ActualSiteTitle.Contains(ExpectedSiteTitle))
                    {
                        SiteLocations[i].Click();
                        Report.UpdateTestLog("OpenProvisionSiteFinalStep", " Clicked on Site Location to open ", Status.PASS);
                        flag = true;
                        common.CallMeWait(2000);
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("OpenProvisionSite", " Expected Site Title is not present in the site list ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("OpenProvisionSite", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("OpenProvisionSite", " Error in method : " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: NavigateBackToProvisionList()
        // Method Decs: This Method navigates back to provision site
        // Created on:  04/24/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void NavigateBackToProvisionList()
        {
            try
            {
                Driver.Navigate().Back();
                Report.UpdateTestLog("NavigateBackToProvisionListFinalStep", " Navigates back to provision list", Status.PASS);
                common.CallMeWait(2000);
                SelectAProvisionSite();
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NavigateBackToProvisionList", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NavigateBackToProvisionList", " Error in method : " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: AddNewSiteLocation()
        // Method Decs: This Method navigates back to provision site
        // Created on:  04/24/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void AddNewSiteLocation()
        {
            try
            {
                string SiteLocation = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                if (common.CheckElement(SearchFromLandingPageOR.oNewSiteLocation_title) == true)
                {
                    Driver.FindElement(SearchFromLandingPageOR.oNewSiteLocation_title).Click();
                    Driver.FindElement(SearchFromLandingPageOR.oNewSiteLocation_title).SendKeys(SiteLocation);
                    Report.UpdateTestLog("AddNewSiteLocationFinalStep", " Entered New Site Location : " + SiteLocation, Status.PASS);
                    common.CallMeWait(1000);
                }
                else
                {
                    Report.UpdateTestLog("AddNewSiteLocation", " New Site Location field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
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
                Report.UpdateTestLog("AddNewSiteLocation", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("AddNewSiteLocation", " Error in method : " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ValidateRefinerCount()
        // Method Description : This method will validate the refiner count with filtered result
        // Created On: 05/15/2017
        // Created By: GI offShore Team
        // *****************************************      

        public void ValidateRefinerCount()
        {
            try
            {
                int RefinerCount = 0;
                int FilteredCount = 0;
                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string filterName = DataTable.GetData("General_Data_" + Env, "RequestType2");
                bool flag = false;

                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(filterName);
                IWebElement elm = elems[pos - 1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                //  IWebElement elm10;
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];

                    string typename = elm2.FindElement(By.Id("RefinementName")).Text.Trim();
                    //string typename = elm2.Text.Trim();
                    if (typename.Equals(requestType1.Trim()))
                    {
                        string sRefinerCount = elm2.FindElement(By.Id("RefinementCount")).Text.Trim();
                        RefinerCount = int.Parse(sRefinerCount);
                        elm2.FindElement(By.Id("RefinementName")).Click();
                        //elm2.Click();
                        Report.UpdateTestLog("ValidateRefinerCount", "Clicked on " + requestType1 + " Under " + filterName + " Refiner", Status.PASS);
                        Thread.Sleep(5000);
                        //   elm10 = elm2.FindElement(By.Id("RefinementName"));
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ValidateRefinerCount", " Refiner is not found", Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                FilteredCount = GetSearchCount();
                if (RefinerCount == FilteredCount)
                {
                    Report.UpdateTestLog("ValidateRefinerCountFinalStep", " Filtered result count is matching with the refiner count. Refiner Count = "+RefinerCount+", Filtered result count = "+FilteredCount, Status.PASS); 
                }
                else
                {
                    Report.UpdateTestLog("ValidateRefinerCount", " Filtered result count is not matching with the refiner count. Refiner Count = " + RefinerCount + ", Filtered result count = " + FilteredCount, Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateRefinerCount", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateRefinerCount", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        // *****************************************
        // Method ValidateSearchResultAfterCloseRefiner()
        // Method Description : This method validates the result after refiner closed
        // Created On: 05/15/2017
        // Created By: GI offShore Team
        // ***************************************** 

        public void ValidateSearchResultAfterCloseRefiner()
        {
            try
            {
                int iCountWithRefiner = GetSearchCount();
                homepage.ClickOnCloseRefinerIcon();
                int iCountWithoutRefiner = GetSearchCount();
                if (iCountWithoutRefiner > iCountWithRefiner)
                {
                    Report.UpdateTestLog("ValidateSearchResultAfterCloseRefinerFinalStep", " Search result count is increased after refiner closed. With refiner the count was : "+iCountWithRefiner+", and Without refiner the count is : "+iCountWithoutRefiner, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateSearchResultAfterCloseRefiner", " Search result count is not increased after refiner closed. With refiner the count was : " + iCountWithRefiner + ", and Without refiner the count is : " + iCountWithoutRefiner, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSearchResultAfterCloseRefiner", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSearchResultAfterCloseRefiner", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        // ******************************************************
        // Method Name: ValidateSearchResultsinPagesTab()
        // Method Description: Validates the count of search results in pages tab .
        // Created on 05/17/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateSearchResultsinPagesTab()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.resultcountwebelement_xpath);
                int count = elems.Count;
                //count = count - 1;
                if (count > 0)
                {
                    Report.UpdateTestLog("ValidateSearchResultsinPagesTabFinalStep",
                        "Successfully verified that in Pages Tab " + count + "results are showing when search by Imran Khan ",
                        Status.PASS);
                }
                else
                    Report.UpdateTestLog("ValidateSearchResultsinPagesTab",
                        " No result is showing in Pages tab ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSearchResultsinPagesTab", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSearchResultsinPagesTab", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }

        // *****************************************
        // Method ValidateCountOfRefiners()
        // Method Description : This method validates the count of each of the refiners
        // Created On: 05/18/2017
        // Created By: GI offShore Team
        // *****************************************      

        public void ValidateCountOfRefiners()
        {
            try
            {             
                string filterName = DataTable.GetData("General_Data_" + Env, "RequestType2");
                bool flag = false;

                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition(filterName);
                IWebElement elm = elems[pos - 1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                //  IWebElement elm10;
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];
                    string typename = elm2.FindElement(By.Id("RefinementName")).Text.Trim();
                    if(elm2.FindElement(By.Id("RefinementName")).Displayed)
                    {
                        string Count = elm2.FindElement(By.Id("RefinementCount")).Text.Trim();                 
                        Report.UpdateTestLog("ValidateCountOfRefinersFinalStep", " Refiner " + typename + " has "+Count+" numbers of results on his right side ", Status.PASS);
                        flag = true; 
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateCountOfRefiners", " Refiner " + typename + " has no results onhis right side ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCountOfRefiners", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCountOfRefiners", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
        }


    }
}




