using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
using Framework_Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
//using System.Windows.Forms;

namespace CRAFT.businesscomponents
{


    internal class HomePageSearch : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;
        public HomePageSearch(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
             common = new CommonComponents(ScriptHelper);
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
                        break;
                    }
                }
                if (flag == 0)
                {
                    flag = 0;
                }
                
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("RefinerNamePosition", "Error in RefinerNamePosition " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false; 
            }
            return pos;

        }
        // ******************************************************
        // Method Name:search()
        // Method Description: It will search text from home page
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void Search()
        {            
            string search = DataTable.GetData("General_Data_" + Env, "Search");
            string advSearch = DataTable.GetData("General_Data_" + Env, "AdvSearch");
            int searchFlag = 0;
            try
            {
                if (advSearch.Any())
                {
                    Driver.FindElement(HomePageSearchOR.searchdropdown).Click();
                    common.CallMeWait(1000);
                    ReadOnlyCollection<IWebElement> elems = Driver
                .FindElements(HomePageSearchOR.osearchlisttextbox_xpath);
                    foreach (IWebElement elm in elems)
                    {
                        if (elm.Text.Equals(advSearch))
                        {
                            //common.CallMeWait(1000);
                            elm.Click();
                            Report.UpdateTestLog("Search", " Option " +advSearch + " is Clicked in search box ", Status.PASS);
                            searchFlag = 1;
                            break;
                        }
                    }
                    if (searchFlag == 0)
                    {
                        Report.UpdateTestLog("Search", advSearch + " is not Clicked in search box ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false; 
                    }
                    
                }

                Driver.FindElement(HomePageSearchOR.osearchtextbox_id).SendKeys(search);
                Driver.FindElement(HomePageSearchOR.osearchtextbox_id1).SendKeys(Keys.Enter);
                //waitForElement((HomePageSearchOR.oallContentlink_link));
                Report.UpdateTestLog("SearchFinalStep", "Search done: " + search,
                    Status.DONE);
                common.CallMeWait(2000);
                if (common.CheckElement(HomePageSearchOR.oFilterRemoveLink)==true)
                {
                    Driver.FindElement(HomePageSearchOR.oFilterRemoveLink).Click();
                    Report.UpdateTestLog("Search ", "Remove the Filter with country " ,
                    Status.DONE);
                    common.CallMeWait(2000);
                }

            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("Search", "Element Not found: "
                                                          + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Search", "Error in seach method: "
                                                       + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        // ******************************************************
        // Method Name:ClickOnAllContentlink()
        // Method Description: It will Click on All Content link
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void ClickOnAllContentlink()
        {
            try
            {
                Driver.FindElement(HomePageSearchOR.oallContentlink_link).Click();
                ;
                Report.UpdateTestLog("ClickOnAllContentlinkFinalStep", "All Content link is Clicked: ",
                    Status.PASS);
                if (common.CheckElement(HomePageSearchOR.oFilterRemoveLink) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oFilterRemoveLink).Click();
                    Report.UpdateTestLog("ClickOnAllContentlink ", "Remove the Filter with country ",
                    Status.DONE);
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("Element not found", "Element Not found: "
                                                          + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Error in ClickOnAllContentlink ",
                    "Error in ClickOnAllContentlink: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: verifyResultType()
        // Method Description: Verify text for result type.
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void VerifyResultType()
        {
            try
            {
                ArrayList dataset = new ArrayList();
                
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition("Result Type");
                IWebElement elm = elems[pos-1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);


                if (Requesttype.Count() > 0)
                {
                    Report.UpdateTestLog("VerifyResultTypeFinalStep", " Result type section is Present  ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyResultType", " Result type section is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("verifyResultType", "Element not found" +e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("verifyResultType", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                
            }

        }

        // ******************************************************
        // Method Name: ClickOnLinkApacNav()
        // Method Description: It will click on Apac Nav Link.
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ClickOnLinkApacNav()
        {
            try
            {
                bool flag = false;
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                IWebElement elm = elems[0];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];
                    //System.out.println(elm2.Text.Trim());
                    if (elm2.Text.Trim().Contains("APAC Navigator"))
                    {
                        elm2.Click();
                        Report.UpdateTestLog("ClickOnLinkApacNavFinalStep", "Apac is Clicked: ",
                            Status.PASS);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ClickOnLinkApacNav", "Apac link is not present ",
                                                Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnLinkApacNav", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnLinkApacNav", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ClickOnNewsLink()
        // Method Description: Verify the News link and Click on the News link.
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // ****************************************************
        public void ClickOnNewsLink()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elems = Driver.FindElements(HomePageSearchOR.onewslink_xpath);
                IWebElement elm = elems[5];
                elm.Click();
                Report.UpdateTestLog("ClickOnNewsLinkFinalStep", "News link is Clicked: ",
                    Status.PASS);

                if (common.CheckElement(HomePageSearchOR.oFilterRemoveLink) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oFilterRemoveLink).Click();
                    Report.UpdateTestLog("ClickOnNewsLink", "Remove the Filter with country ",
                    Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnNewsLink", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnNewsLink", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: verifyResultCount()
        // Method Description: Verify the count of search result .
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void VerifyResultCount()
        {
            try
            {
                common.CallMeWait(2000);
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.resultcountwebelement_xpath);
                int count = elems.Count;
                count = count - 1;
                if (count > 0)
                {
                    Report.UpdateTestLog("verifyResultCountFinalStep", "Number of links are : " + count,
                        Status.PASS);
                    if (common.CheckElement(HomePageSearchOR.oloadmorebtn_xpath) == true)
                    {
                        Driver.FindElement(HomePageSearchOR.oloadmorebtn_xpath).Click();
                        common.CallMeWait(3000);

                        elems = Driver.FindElements(HomePageSearchOR.resultcountwebelement_xpath);
                        int count1 = elems.Count;
                        count1 = count1 - 1;
                        if (count1 <= (count + 15))
                        {
                            Report.UpdateTestLog("verifyResultCount", " After clicking on 'Show More' additional maximum 15 results populated ",
                                Status.PASS);
                        }
                        else
                        {
                            Report.UpdateTestLog("verifyResultCount",
                                " After clicking on 'Show More' more than additional 15 links displayed" + count, Status.FAIL);
                            CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("verifyResultCount",
                        " No link is displayed", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("verifyResultCount", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("verifyResultCount", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ClickOnHomeNavLink()
        // Method Description: Verify the HOME link and Click .
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ClickOnHomeNavLink()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.ohomelink_xpath) == true)
                {
                    Driver.FindElement(HomePageSearchOR.ohomelink_xpath).Click();
                    Report.UpdateTestLog("ClickOnHomeNavLinkFinalStep", " Home link is Clicked: ",
                        Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnHomeNavLink", " Home link is not present ",
                                            Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("Element not found", "Element Not found: "
                                                          + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Error in ClickOnHomeNavLink ",
                    "Error in ClickOnHomeNavLink: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: VerifyLanguage()
        // Method Description: Verify the language appear in Refine your search
        // section.
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void VerifyLanguage()
        {
            try
            {
                String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                String engLan = null;
                int pos = RefinerNamePosition("Language");
                IWebElement elm = elems[pos-1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm.FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);

                if (Requesttype.Count() > 0)
                {
                    Report.UpdateTestLog("VerifyLanguageFinalStep", " Language section is present ", Status.PASS);
                }
                
                 else{
                     Report.UpdateTestLog("VerifyLanguage", " Language section is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyLanguage ",
                    "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyLanguage ",
                    "Error in verifyLanguage: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        // ******************************************************
        // Method Name: VerifyLocation()
        // Method Description: Verify locations in Refine your search section.
        // Created on 01/04/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void VerifyLocation()
        {
            try
            {
                ArrayList dataset = new ArrayList();
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition("Location");
                IWebElement elm = elems[pos-1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];
                    // System.out.println(elm2.Text);
                    String temp1 = (elm2.FindElement(By.Id("RefinementName")).Text.Trim());
                    //String temp1 = elm2.Text.Trim();                    
                    dataset.Add(temp1.Trim());
                }

                if (dataset.Count > 0)
                {
                    Report.UpdateTestLog("verifyLocationFinalStep",
                        dataset.Count + " Locations present under Location Section", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("verifyLocation",
                        " Location not found under Location Section", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("verifyLocation",
                        " Element not found " +e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("verifyLocation",
                        " Error in method", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        // *****************************************
        // Method Name: VerifyJustInNewsShare()
        // Method Description : "

        // Created On: 01/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void VerifyJustInNewsShare()
        {
            try
            {
            String requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
            common.WaitForElement(HomePageSearchOR.ojustinnewslabel_xpath);
            IWebElement element = Driver.FindElement(HomePageSearchOR.ojustinnewslabel_xpath);
            
            String s = element.Text.Trim();
            if (s.Contains(requestType1.Trim()))
            {
                Report.UpdateTestLog("verifyJustInNewsShare", "Matched, Expected: " + requestType1 + "Actual : " + s, Status.PASS);
            }
            else
            {
                Report.UpdateTestLog("verifyJustInNewsShare", " Not Matched, Expected: " + requestType1 + "Actual : " + s, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

            ReadOnlyCollection<IWebElement> Requesttype = Driver.FindElements(HomePageSearchOR.ojustinnewsfirstnews_xpath);
            IWebElement elm = Requesttype[0];
            common.CallMeWait(3000);
            //if((elm.FindElement(By.TagName("h5"))=true){
            elm.FindElement(By.TagName("h5")).Click();
            common.CallMeWait(3000);
            
                common.WaitForElement(HomePageSearchOR.osharelink_xapth);
                IWebElement sharelink = Driver.FindElement(HomePageSearchOR.osharelink_xapth);
                Report.UpdateTestLog("verifyJustInNewsShare"," Share link is present " ,Status.PASS);
                string s1 = Driver.FindElement(By.XPath("//*[@id='cbre-share-article']")).Text;
                if (s1.Contains("Share"))
                {
                    Report.UpdateTestLog("verifyJustInNewsShareFinalStep", " Link text Matched, Expected: Share " + "Actual : " + s1, Status.PASS); 
                }
                else
                {
                    Report.UpdateTestLog("verifyJustInNewsShare", " Link text not Matched, Expected: Share " + "Actual : " + s1, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false; 
                }

            }
            catch (NoSuchElementException e)
            {

                Report.UpdateTestLog("verifyJustInNewsShare", " Share link is not present " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
           
            //}

        }

        // *****************************************
        // Method verifySearchResultsPagewise()
        // Method Description : This method will verify 15 document in one page by
        // default and after Clicking "Load more result"
        // more 15 result should be load in search page.
        // Created On: 01/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void VerifySearchResultsPagewise()
        {
            try
            {
                common.CallMeWait(2000);
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.odocumentsearchlink_xapth);
                common.CallMeWait(2000);
                int count = elems.Count;
                count = count - 1;
                if (count > 0)
                {
                    // one element is not the result
                    Report.UpdateTestLog("verifySearchResultsPagewiseFinalStep",
                        "Total " + count + " links are present in search result ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("verifySearchResultsPagewise",
                        " No Link is displayed ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (common.CheckElement(HomePageSearchOR.oloadmorebtn_xpath) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oloadmorebtn_xpath).Click();
                    common.CallMeWait(3000);

                    elems = Driver.FindElements(HomePageSearchOR.odocumentsearchlink_xapth);
                    int count1 = elems.Count;
                    count1 = count1 - 1;
                    if ((count1 <= (count + 15)))
                    {
                        Report.UpdateTestLog("verifySearchResultsPagewise",
                            " After clicking on the Show More button another maximum 15 results are populated ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("verifySearchResultsPagewise",
                            " After clicking on the Show More button another more than 15 results are populated ", Status.FAIL); 
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySearchResultsPagewise", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySearchResultsPagewise", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickOnDocumentLink()
        // Method Description : This method will Click on Document link
        // Created On: 01/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnDocumentLink()
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
                    if (elm2.Text.Trim().Equals("Documents"))
                    {
                        elm2.Click();
                        //	callMeWait(2000);
                        Report.UpdateTestLog("ClickOnDocumentLinkFinalStep", " Clicked On Document Link ", Status.PASS);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ClickOnDocumentLink", " Document Link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (common.CheckElement(HomePageSearchOR.oFilterRemoveLink) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oFilterRemoveLink).Click();
                    Report.UpdateTestLog("ClickOnDocumentLink", "Remove the Filter with country ",
                    Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnDocumentLink", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnDocumentLink", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method name:verifyServiceDepartmentRefiners()
        // Method Description : This method verify the values in Services and
        // Department section
        // Created On: 01/04/2017
        // Created By: GI offShore Team
        // *****************************************

        public void VerifyServiceDepartmentRefiners()
        {
            try
            {
                ArrayList dataset = new ArrayList();

                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                IWebElement elm = elems[2];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                    .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                for (int i = 0; i < Requesttype.Count; i++)
                {
                    IWebElement elm2 = Requesttype[i];
                    //System.out.println(elm2.Text);
                    //dataset.Add(elm2.FindElement(By.Id("RefinementName")).Text.Trim());
                    dataset.Add(elm2.Text.Trim());

                }

                if (dataset.Count > 0)
                {
                    Report.UpdateTestLog("verifyServiceDepartmentRefinersFinalStep",
                        dataset.Count + " Services and Department are present.", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("verifyServiceDepartmentRefiners",
                        " No Services and Department are present.", Status.PASS);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyServiceDepartmentRefiners", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyServiceDepartmentRefiners", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method name:VerifyDocumentType()
        // Method Description : This method verify the type of search result
        // Department section
        // Created On: 01/10/2017
        // Created By: GI offShore Team
        // *****************************************

        public void VerifyDocumentType()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elems =
                    Driver.FindElements(By.XPath("//div[contains(@class,'srch-row')]"));

                for (int i = 1; i < elems.Count; i++)
                {
                    string extension = Driver.FindElement(
                        By.XPath(
                            "//div[contains(@class,'ms-srch-group-content')]/child::*[" + i +
                            "]/child::*[1]/div/div/div[3]/child::*[last()]/a")).GetAttribute("href");
                   // string extension = linkValue.Substring(linkValue.Length - 4).ToLower();

                    if (extension.Contains(".pdf") || extension.Contains(".doc") || extension.Contains(".xls") ||
                        extension.Contains(".ppt") || extension.Contains(".xlsx") || extension.Contains(".docx") ||
                        extension.Contains(".pptx") || extension.Contains(".txt") || extension.Contains(".aspx"))
                    {
                        Report.UpdateTestLog("VerifyDocumentTypeFinalStep", "Document type matched, " + "Actual " + extension,
                            Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyDocumentType", "Document type Not Matched, " + "Actual " + extension,
                            Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                        
                    }
                }

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyDocumentType", "problem in VerifyDocumentType method" + e,
                             Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method name:SearchPeopleNameAndClickonImage()
        // Method Description : This method Search the people and click on the Image 
        // Created On: 01/19/2017
        // Created By: GI offShore Team
        // *****************************************
        public void SearchPeopleNameAndClickonImage()
        {
            try
            {
                string peopleName = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string dynamicPath = "//*[@class='ms-srch-group-content']/child::*[1]/div/div/div[2]/div[1]/div/a";
                int count = 0;
                int flag = 0;
                ReadOnlyCollection<IWebElement> peopleList = Driver.FindElements(By.XPath("//*[@class='ms-srch-group-content']/child::*"));
                for(int i =0;i<peopleList.Count;i++)
                {
                    count = i + 1;
                    dynamicPath = "//*[@class='ms-srch-group-content']/child::*["+count+"]/div/div/div[2]/div[1]/div/a";
                    string value = Driver.FindElement(By.XPath(dynamicPath)).Text;
                    if (value.Contains(peopleName.Trim()))
                    {
                        Driver.FindElement(By.XPath("//*[@class='ms-srch-group-content']/child::*["+count+"]/div/div/div[1]")).Click();
                        Report.UpdateTestLog("SearchPeopleNameAndClick", "Clicked on image for  " + value, Status.PASS);
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                    common.WaitForElement(HomePageSearchOR.downloadcontactlink_xpath);
                    bool elementflag = common.CheckElement(HomePageSearchOR.downloadcontactlink_xpath);
                    Driver.SwitchTo().DefaultContent();
                    if (elementflag == true)
                        Report.UpdateTestLog("SearchPeopleNameAndClickFinalStep", "Profile page succesfully loaded  ",
                            Status.PASS);
                    else
                    {
                        Report.UpdateTestLog("SearchPeopleNameAndClick", "Profile page not loaded   ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("SearchPeopleNameAndClick", "Profile Not found,profile name is " + peopleName, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SearchPeopleNameAndClick", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SearchPeopleNameAndClick", "Error in Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        // *****************************************
        // Method name:SearchPeopleNameAndClickonName()
        // Method Description : This method Search the people and click on the Name 
        // Created On: 01/19/2017
        // Created By: GI offShore Team
        // *****************************************

        public void SearchPeopleNameAndClickonName()
        {
            try
            {


                string peopleName = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string dynamicPath = "//*[@class='ms-srch-group-content']/child::*[1]/div/div/div[2]/div[1]/div/a";
                int count = 0;
                int flag = 0;
                ReadOnlyCollection<IWebElement> peopleList = Driver.FindElements(By.XPath("//*[@class='ms-srch-group-content']/child::*"));
                for (int i = 0; i < peopleList.Count; i++)
                {
                    count = i + 1;
                    dynamicPath = "//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[2]/div[1]/div/a";
                    string value = Driver.FindElement(By.XPath(dynamicPath)).Text;
                    if (value.Contains(peopleName.Trim()))
                    {
                        Driver.FindElement(By.XPath("//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[1]")).Click();
                        Report.UpdateTestLog("SearchPeopleNameAndClickonName", "Clicked on name for  " + value, Status.PASS);
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                    common.WaitForElement(HomePageSearchOR.downloadcontactlink_xpath);
                    bool elementflag = common.CheckElement(HomePageSearchOR.downloadcontactlink_xpath);
                    Driver.SwitchTo().DefaultContent();
                    if (elementflag == true)
                        Report.UpdateTestLog("SearchPeopleNameAndClickonNameFinalStep", "Profile page succesfully loaded  ",
                            Status.PASS);
                    else
                    {
                        Report.UpdateTestLog("SearchPeopleNameAndClickonName", "Profile page not loaded   ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("SearchPeopleNameAndClickonName", "Profile Not found,profile name is " + peopleName, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SearchPeopleNameAndClickonName", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SearchPeopleNameAndClickonName", "Error in Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        // ******************************************************
        // Method Name: VerifyResultCountWithRefinerSelected()
        // Method Description: Verify the count of search result .
        // Created on 01/24/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void VerifyResultCountWithRefinerSelected()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.resultcountwebelement_xpath);
                int count = elems.Count;
                count = count - 1;
                if (count >0)
                {
                    Report.UpdateTestLog("VerifyResultCountWithRefinerSelectedFinalStep", " Total " + count + " links are present in search result ",
                        Status.PASS);
                }
                else
                    Report.UpdateTestLog("VerifyResultCountWithRefinerSelected",
                        " No link is present in search result" , Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                if (common.CheckElement(HomePageSearchOR.oloadmorebtn_xpath) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oloadmorebtn_xpath).Click();
                    common.CallMeWait(3000);

                    elems = Driver.FindElements(HomePageSearchOR.resultcountwebelement_xpath);
                    count = elems.Count;
                    count = count - 1;
                    if (count == 30)
                    {
                        Report.UpdateTestLog("VerifyResultCountWithRefinerSelected ", "Number of links are 30 ",
                            Status.PASS);
                    }
                    else
                        Report.UpdateTestLog("VerifyResultCountWithRefinerSelected ",
                            "Number of links is 30 not displayed, Actual Count = " + count, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("VerifyResultCountWithRefinerSelected ", "Element Not found: "
                                                          + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyResultCountWithRefinerSelected ",
                    "Error in ClickOnHomeNavLink: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        // ******************************************************
        // Method Name: WaitForSelectSite()
        // Method Description: This method will wait for Select site dropdown 
        // Created on 01/24/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void WaitForSelectSite()
        {
            common.WaitForElement(HomePageSearchOR.oselctSitedropdown);
        }

        // ******************************************************
        // Method Name: ValidatePublishDetails()
        // Method Description: This method will validate publish details 
        // Created on 01/24/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidatePublishDetails()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oPageHeader_xpath) == true)
                {
                    Report.UpdateTestLog("ValidatePublishDetails", "Successfully Navigated to the publish page",
                        Status.PASS);
                    common.WaitForElement(HomePageSearchOR.oPublishDate_xpath);
                    IWebElement elm = Driver.FindElement(HomePageSearchOR.oPublishDate_xpath);
                    if (common.CheckElement(HomePageSearchOR.oPublishDate_xpath) == true)
                    {
                        string publishtext = elm.Text.Trim();
                        string publishdate = publishtext.Substring(16,17);
                        Report.UpdateTestLog("ValidatePublishDetails",
                            " Successfully validate that on the published page publish date is present, the publish date is : " +
                            publishdate, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidatePublishDetails",
                            " On the published page publish date is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    common.WaitForElement(HomePageSearchOR.oPublishedBy_xpath);
                    IWebElement elm1 = Driver.FindElement(HomePageSearchOR.oPublishedBy_xpath);
                    if (common.CheckElement(HomePageSearchOR.oPublishedBy_xpath) == true)
                    {
                        string publishby = elm1.Text.Trim();
                        Report.UpdateTestLog("ValidatePublishDetailsFinalStep",
                            " Successfully validate that on the published page author's name is present, the name is : " +
                            publishby, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidatePublishDetails",
                            " On the published page author's name is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidatePublishDetails", "Failed to navigate to the publish page",
                        Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidatePublishDetails", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidatePublishDetails", "Error in Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method name:ClickNameAndValidateProfile()
        // Method Description : This method click on the Name and validate profile
        // Created On: 02/16/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickNameAndValidateProfile()
        {
            try
            {


                string peopleName = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string dynamicPath = "//*[@class='ms-srch-group-content']/child::*[1]/div/div/div[2]/div[1]/div/a";
                int count = 0;
                int flag = 0;
                ReadOnlyCollection<IWebElement> peopleList = Driver.FindElements(By.XPath("//*[@class='ms-srch-group-content']/child::*"));
                for (int i = 0; i < peopleList.Count; i++)
                {
                    count = i + 1;
                    dynamicPath = "//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[2]/div[1]/div/a";
                    string value = Driver.FindElement(By.XPath(dynamicPath)).Text;
                    if (value.Contains(peopleName.Trim()))
                    {
                        Driver.FindElement(By.XPath("//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[1]")).Click();
                        Report.UpdateTestLog("ClickNameAndValidateProfile", "Clicked on name for  " + value, Status.PASS);
                        common.CallMeWait(2000);
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                    common.WaitForElement(HomePageSearchOR.downloadcontactlink_xpath);
                    bool elementflag = common.CheckElement(HomePageSearchOR.downloadcontactlink_xpath);
                    //Driver.SwitchTo().DefaultContent();
                    if (elementflag == true)
                        Report.UpdateTestLog("ClickNameAndValidateProfileFinalStep", "Profile page succesfully loaded  ",
                            Status.PASS);
                    else
                    {
                        Report.UpdateTestLog("ClickNameAndValidateProfile", "Profile page not loaded   ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ClickNameAndValidateProfile", "Profile Not found,profile name is " + peopleName, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickNameAndValidateProfile", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickNameAndValidateProfile", "Error in Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        // *****************************************
        // Method name:ClickImageAndValidateProfile()
        // Method Description : This method click on the Image and validate profile
        // Created On: 02/16/2017
        // Created By: GI offShore Team
        // *****************************************
        public void ClickImageAndValidateProfile()
        {
            try
            {
                string peopleName = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string dynamicPath = "//*[@class='ms-srch-group-content']/child::*[1]/div/div/div[2]/div[1]/div/a";
                int count = 0;
                int flag = 0;
                ReadOnlyCollection<IWebElement> peopleList = Driver.FindElements(By.XPath("//*[@class='ms-srch-group-content']/child::*"));
                for (int i = 0; i < peopleList.Count; i++)
                {
                    count = i + 1;
                    dynamicPath = "//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[2]/div[1]/div/a";
                    string value = Driver.FindElement(By.XPath(dynamicPath)).Text;
                    if (value.Contains(peopleName.Trim()))
                    {
                        Driver.FindElement(By.XPath("//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[1]")).Click();
                        Report.UpdateTestLog("ClickImageAndValidateProfile", "Clicked on image for  " + value, Status.PASS);
                        common.CallMeWait(2000);
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                    common.WaitForElement(HomePageSearchOR.downloadcontactlink_xpath);
                    bool elementflag = common.CheckElement(HomePageSearchOR.downloadcontactlink_xpath);
                    Driver.SwitchTo().DefaultContent();
                    if (elementflag == true)
                        Report.UpdateTestLog("ClickImageAndValidateProfileFinalStep", "Profile page succesfully loaded  ",
                            Status.PASS);
                    else
                    {
                        Report.UpdateTestLog("ClickImageAndValidateProfile", "Profile page not loaded   ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ClickImageAndValidateProfile", "Profile Not found,profile name is " + peopleName, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickImageAndValidateProfile", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickImageAndValidateProfile", "Error in Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }        
       }

        // *****************************************
        // Method name:ClickOnNameLink()
        // Method Description : This method click on the Name 
        // Created On: 02/16/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnNameLink()
        {
            try
            {
                string peopleName = DataTable.GetData("General_Data_" + Env, "RequestType1");
                string dynamicPath = "//*[@class='ms-srch-group-content']/child::*[1]/div/div/div[2]/div[1]/div/a";
                int count = 0;
                string value = peopleName;
                bool flag = false;
                ReadOnlyCollection<IWebElement> peopleList = Driver.FindElements(By.XPath("//*[@class='ms-srch-group-content']/child::*"));
                for (int i = 0; i < peopleList.Count; i++)
                {
                    count = i + 1;
                    dynamicPath = "//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[2]/div[1]/div/a";
                    value = Driver.FindElement(By.XPath(dynamicPath)).Text;
                    if (value.Contains(peopleName.Trim()))
                    {
                        Driver.FindElement(By.XPath("//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[1]")).Click();
                        //Report.UpdateTestLog("ClickOnNameLink", "Clicked on name for " + value, Status.PASS);
                        flag = true;                                  
                        break;
                    }
                }
                if (flag == true)
                {
                    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
                    string sname = Driver.FindElement(MyProfileOR.oSupervisorName_xpath).Text.Trim();
                    Report.UpdateTestLog("ClickOnNameLinkFinalStep", "Clicked on name link for " + sname, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnNameLink", " Name is not present in list ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //common.CallMeWait(2000);
                //Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnNameLink", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnNameLink", "Error in Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        // *****************************************
        // Method name:ValidateNameAndJobTitle()
        // Method Description : This method Validate the names and Job Title 
        // Created On: 02/18/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateNameAndJobTitle()
        {
            try
            {
                ReadOnlyCollection<IWebElement> NameList = Driver
                    .FindElements(HomePageSearchOR.oNameList_xpath);
                ReadOnlyCollection<IWebElement> JobTitleList = Driver
                    .FindElements(HomePageSearchOR.oJobTitleList_xpath);

                int iNameCount = NameList.Count;
                int iJobTitleCount = JobTitleList.Count;

                if (iNameCount == iJobTitleCount)
                {
                    Report.UpdateTestLog("ValidateNameAndJobTitleFinalStep", " All the names have Job Title tagged.", Status.PASS);
                    for (int i = 0; i < iNameCount; i++)
                    {
                        Report.UpdateTestLog("ValidateNameAndJobTitle", " Name = " + NameList[i].Text.Trim() + " , Job Title =" + JobTitleList[i].Text.Trim(), Status.PASS);
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateNameAndJobTitle", " Not all the names have Job Title tagged. Total Count of Names: " + iNameCount + " , Total Count of Job Title: " + iJobTitleCount, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNameAndJobTitle", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNameAndJobTitle", "Error in Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }


        //**********************************************
        // Method VerifyDescendingOrder()
        // Method Description : This method will Validate the sort in descending order
        // Created On: 02/18/2017
        // Created By: GI offShore Team
        // *****************************************
        public void VerifySortDescendingOrder()
        {
            try
            {               
                List<int> data1 = new List<int>();
                List<int> data2 = new List<int>();
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

                   string scount = elm2.FindElement(By.Id("RefinementCount")).Text.Trim();
                    //string scount = elm2.Text.Trim();
                   int iCount = Int32.Parse(scount);
                    data1.Add(iCount);
                    data2.Add(iCount);

                }
                int check = 0;
                data2.Sort((a, b) => -1 * a.CompareTo(b));
                for (int i = 0; i < data1.Count; i++)
                {
                    if (!data1[i].Equals(data2[i]))
                    {
                        check = 1;
                    }

                }
                if (check == 1)
                {
                    Report.UpdateTestLog("VerifySortDescendingOrder", "Refiner " + filterName + " are not sorted in descending order", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("VerifySortDescendingOrderFinalStep", "Refiner " + filterName + " are sorted in descending order", Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySortDescendingOrder", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySortDescendingOrder", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: MousehoverToServiceLinesAndSelectService()
        // Method Decs: Hover mouse to a particualr Service Lines and select a service
        // Created on: 21st Feb 2017	
        // Created By: GI offShore Team	
        //****************************************************

        public void MousehoverToServiceLinesAndSelectService()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms =
                    Driver.FindElements(SearchFromLandingPageOR.oserviceLinesTopNav_xpath);
                Actions action = new Actions(Driver);
                int flag = 0;

                By sublinktext = By.XPath("//*[text()='Asset Services']");
                string value = elms[0].Text;
                action.MoveToElement(elms[0]);

                action.Perform();
                common.CallMeWait(1000);
                //action.MoveToElement(elms[0]).ContextClick();


                if (common.CheckElement(HomePageSearchOR.oafterhover_xpath) == true)
                {
                    Report.UpdateTestLog("MousehoverToServiceLinesAndSelectService", "Lay out is appearing after mouse hover on Resources", Status.PASS);
                    if (common.CheckElement(sublinktext) == true)
                    {
                        Driver.FindElement(sublinktext).Click();
                        Report.UpdateTestLog("MousehoverToServiceLinesAndSelectServiceFinalStep", "Successfully clicked on Asset Services link", Status.PASS);
                        common.CallMeWait(3000);
                    }
                    else
                    {
                        Report.UpdateTestLog("MousehoverToServiceLinesAndSelectService", "Asset Services link is not present ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else 
                {
                    Report.UpdateTestLog("MousehoverToServiceLinesAndSelectService", "Lay out is not appearing after mouse hover on Resources ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("MousehoverToServiceLinesAndSelectService", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("MousehoverToServiceLinesAndSelectService", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // Method ValidateChildLinks()
        // Method Description : This method will validate the child links under a parent link
        // Created On: 02/21/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateChildLinks()
        {
            try
            {
                int count = 0;
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(HomePageSearchOR.oAssetServicesChilds_xpath);
                for (int i = 0; i < elms.Count; i++)
                {
                    if (elms[i].GetAttribute("class").Contains("child-link"))
                    {
                        count = count + 1;
                    }
                }
                if (count > 0)
                {
                    Report.UpdateTestLog("ValidateChildLinksFinalStep", " Total " + count + " child links are present under asset services", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateChildLinks", " No child link is present under asset services", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateChildLinks", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateChildLinks", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method VerifySortAlphabetically()
        // Method Description : This method will Validate the sort in Alphabetically order
        // Created On: 02/27/2017
        // Created By: GI offShore Team
        // *****************************************
        public void VerifySortAlphabetically()
        {
            try
            {
                List<string> data1 = new List<string>();
                List<string> data2 = new List<string>();
                //string filterName = DataTable.GetData("General_Data_" + Env, "RequestType2");
               // IWebElement elm;
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oDepartmentLinks_xpath);

                for (int i = 0; i < elems.Count; i++)
                {
                    IWebElement elm2 = elems[i];

                    string link = elm2.Text.Trim();
                    //int iCount = Int32.Parse(scount);
                    data1.Add(link);
                    data2.Add(link);

                }
                int check = 0;
                data2.Sort((a, b) => 1 * a.CompareTo(b));
                //data2.Sort();
                for (int i = 0; i < data1.Count; i++)
                {
                    if (!data1[i].Equals(data2[i]))
                    {
                        check = 1;
                    }

                }
                if (check == 1)
                {
                    Report.UpdateTestLog("VerifySortAlphabetically", " Links in departments page are not in sorted Alphabetically", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("VerifySortAlphabeticallyFinalStep", " Links in departments page are in sorted Alphabetically", Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySortAlphabetically", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySortAlphabetically", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnDepartments()
        // Method Decs: This method will click on Departments link
        // Created on: 27th Feb 2017	
        // Created By: GI offShore Team	
        //****************************************************

        public void ClickOnDepartments()
        {
            try
            {
                IWebElement elm = Driver.FindElement(HomePageSearchOR.oDepartmentsTopNav_xpath);
                elm.Click();
                Report.UpdateTestLog("ClickOnDepartments", " Clicked on Departments link ", Status.DONE);
                common.CallMeWait(2000);
                if(common.CheckElement(HomePageSearchOR.oDepartmentsPageTitle_id)==true)
                 {
                     Report.UpdateTestLog("ClickOnDepartmentsFinalStep", " Successfully Navigated to Departments page ", Status.PASS);
                 }
               else
                {
                    Report.UpdateTestLog("ClickOnDepartments", " Failed to Navigate to Departments page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }             
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnDepartments", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnDepartments", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method VerifyColumnAndChildLinks()
        // Method Description : This method will Validate column layout and Child links
        // Created On: 02/27/2017
        // Created By: GI offShore Team
        // *****************************************

        public void VerifyColumnAndChildLinks()
        {
            try 
            {
                ReadOnlyCollection<IWebElement> elems = Driver.FindElements(HomePageSearchOR.oDepartmentsColumns_XPath);
                int iColumnCount = elems.Count();
                if (iColumnCount == 2)
                {
                    Report.UpdateTestLog("VerifyColumnAndChildLinks", " Page has 2 columns" , Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyColumnAndChildLinks", " Page has "+iColumnCount+" columns. Expected column is 2", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ReadOnlyCollection<IWebElement> childlinks = Driver.FindElements(HomePageSearchOR.oChildLinks_class);
                int iChildLinkCount = childlinks.Count();
                if (iChildLinkCount > 0)
                {
                    Report.UpdateTestLog("VerifyColumnAndChildLinksFinalStep", " Department Page has " + iChildLinkCount + " child links", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyColumnAndChildLinks", " Department Page contains no child link", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyColumnAndChildLinks", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyColumnAndChildLinks", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
           }
       }

        //******************************************************
        // Method Name: VerifyServicesLine()
        // Method Decs: Hover mouse to a particualr Service Lines 
        // Created on: 6Th March 2017	
        // Created By: GI offShore Team	
        //****************************************************
        
        public void VerifyServicesLine()
        {
            try
            {
                int flag = 0;

                if (common.CheckElement(SearchFromLandingPageOR.oserviceLinesTopNav_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyServicesLine", "Service line option is present", Status.PASS);
                    Actions action = new Actions(Driver);
                    action.MoveToElement(Driver.FindElement(SearchFromLandingPageOR.oserviceLinesTopNav_xpath));
                    action.Perform();

                    for (int i = 0; i < 10; i++)
                    {

                        if (common.CheckElement(HomePageSearchOR.oafterhover_xpath) == false)
                        {
                            action.MoveToElement(Driver.FindElement(SearchFromLandingPageOR.oserviceLinesTopNav_xpath));
                            action.Perform();
                        }
                        else
                        {
                            action.MoveToElement(Driver.FindElement(HomePageSearchOR.osignout_xpath));
                            common.CallMeWait(2000);
                            flag = 1;
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyServicesLine", "Service line option is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (flag == 1)
                {
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("VerifyServicesLineFinalStep", "Successfully hover on Service line ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyServicesLine", "Failed hover on service line ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyServicesLine", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyServicesLine", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyDepartment()
        // Method Decs: Hover mouse to a particualr Department Lines 
        // Created on: 6Th March 2017	
        // Created By: GI offShore Team	
        //****************************************************
        
        public void VerifyDepartment()
        {
            try
            {
                int flag = 0;

                if (common.CheckElement(HomePageSearchOR.odepartmentTopNav_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyDepartment", "Service line option is present", Status.PASS);
                    Actions action = new Actions(Driver);
                    action.MoveToElement(Driver.FindElement(HomePageSearchOR.odepartmentTopNav_xpath));
                    action.Perform();

                    for (int i = 0; i < 10; i++)
                    {

                        if (common.CheckElement(HomePageSearchOR.oafterhover_xpath) == false)
                        {
                            action.MoveToElement(Driver.FindElement(HomePageSearchOR.odepartmentTopNav_xpath));
                            action.Perform();
                        }
                        else
                        {
                            action.MoveToElement(Driver.FindElement(HomePageSearchOR.osignout_xpath));
                            common.CallMeWait(2000);
                            flag = 1;
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyDepartment", "Department option is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (flag == 1)
                {
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("VerifyDepartmentFinalStep", "Successfully hover on Department ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyDepartment", "Failed hover on Department ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyDepartment", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyDepartment", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyResource()
        // Method Decs: Hover mouse to a particualr Resource 
        // Created on: 6Th March 2017	
        // Created By: GI offShore Team	
        //****************************************************
        
        public void VerifyResource()
        {
            try
            {
                int flag = 0;

                if (common.CheckElement(HomePageSearchOR.oresourcesTopNav_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyResource", "Service line option is present", Status.PASS);
                    Actions action = new Actions(Driver);
                    action.MoveToElement(Driver.FindElement(HomePageSearchOR.oresourcesTopNav_xpath));
                    action.Perform();

                    for (int i = 0; i < 10; i++)
                    {

                        if (common.CheckElement(HomePageSearchOR.oafterhover_xpath) == false)
                        {
                            action.MoveToElement(Driver.FindElement(HomePageSearchOR.oresourcesTopNav_xpath));
                            action.Perform();
                        }
                        else
                        {
                            action.MoveToElement(Driver.FindElement(HomePageSearchOR.osignout_xpath));
                            common.CallMeWait(2000);
                            flag = 1;
                            break;
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyResource", "Resource option is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (flag == 1)
                {
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("VerifyResourceFinalStep", "Successfully hover on Resource ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyResource", "Failed hover on Resource ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyResource", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyResource", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyHomelink()
        // Method Decs:  Verify  particular Home link 
        // Created on: 6Th March 2017	
        // Created By: GI offShore Team	
        //****************************************************
        
        public void VerifyHomelink()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.ohomelink_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyHomelinkFinalStep", "Home link is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyHomelink", "Home link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyHomelink", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyHomelink", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyNewslink()
        // Method Decs:  Verify to a particualr Home 
        // Created on: 6Th March 2017	
        // Created By: GI offShore Team	
        //****************************************************
        
        public void VerifyNewslink()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.onewslink1_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyNewslinkFinalStep", "News link is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyNewslink", "News link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyNewslink", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyNewslink", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyMegamenuPosition()
        // Method Decs:  Verify location of mega Menu 
        // Created on: 6Th March 2017	
        // Created By: GI offShore Team	
        //****************************************************
        
        public void VerifyMegamenuPosition()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.omegamenurightside_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyMegamenuPositionFinalStep", "Mega Menu at top right side", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMegamenuPosition", "Mega Menu is not at top right side", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyMegamenuPosition", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyMegamenuPosition", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateNoSiteSwitcher()
        // Method Decs:  This method will verify there is no site switcher in page 
        // Created on: 03/14/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void ValidateNoSiteSwitcher()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oSelectSite_xpath) == false)
                {
                    Report.UpdateTestLog("ValidateNoSiteSwitcherFinalStep", " Site Switcher is not found ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateNoSiteSwitcher", " Site Switcher is present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNoSiteSwitcher", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNoSiteSwitcher", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateSiteSwitcher()
        // Method Decs:  This method will verify there is site switcher in page 
        // Created on: 03/15/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void ValidateSiteSwitcher()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oSelectSite_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateSiteSwitcherFinalStep", " Site Switcher is present beside the title of the page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateSiteSwitcher", " Site Switcher is not present beside the title of the page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSiteSwitcher", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSiteSwitcher", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnSiteSwitcher()
        // Method Decs:  This method will click on the Site Switcher link 
        // Created on: 03/15/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void ClickOnSiteSwitcher()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oSelectSite_xpath) == true)
                {
                    Driver.FindElement(HomePageSearchOR.oSelectSite_xpath).Click();
                    Report.UpdateTestLog("ClickOnSiteSwitcherFinalStep", " Clicked on the Site Switcher beside the title of the page ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnSiteSwitcher", " Site Switcher is not present beside the title of the page ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnSiteSwitcher", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnSiteSwitcher", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: MouseHoverToSelectSite()
        // Method Decs:  This method will mouse hover to select site 
        // Created on: 03/15/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void MouseHoverToSelectSite()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms =
                    Driver.FindElements(HomePageSearchOR.oSelectSiteDropDown_xpath);
                Actions action = new Actions(Driver);
                int flag = 0;
                for (int i = 0; i < elms.Count; i++)
                {

                    if (elms[i].Text.Trim().Contains("Select Site"))
                    {
                        action.MoveToElement(elms[i]);
                        action.Perform();
                        Report.UpdateTestLog("MouseHoverToSelectSiteFinalStep", " Successfully mouse hover to Select Site ", Status.PASS);
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    Report.UpdateTestLog("MouseHoverToSelectSite", " Unable to mouse hover to Select Site ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("MouseHoverToSelectSite", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("MouseHoverToSelectSite", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateFlyOutMenu()
        // Method Decs:  This method will validate the flyout menu 
        // Created on: 03/15/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void ValidateFlyOutMenu()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oSelectSiteFlyOut_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateFlyOutMenuFinalStep", " Successfully validated that fly out menu is appeared ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateFlyOutMenu", " Fly out menu is not appeared ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateFlyOutMenu", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateFlyOutMenu", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateDropDownMenu()
        // Method Decs:  This method will validate the Drop Down menu 
        // Created on: 03/15/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void ValidateDropDownMenu()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms =
                                    Driver.FindElements(HomePageSearchOR.oSelectSiteDropDown_xpath);
                bool flag = false;
                if (elms.Count() > 0)
                {
                    Report.UpdateTestLog("ValidateDropDownMenuFinalStep", " Menus are present in dropdown", Status.PASS);
                    for (int i = 0; i < elms.Count; i++)
                    {
                        Report.UpdateTestLog("ValidateDropDownMenu", " Menu '"+elms[i].Text.Trim()+"' is present in the drop down ", Status.PASS);
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateDropDownMenu", " No menu is present in the drop down ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateDropDownMenu", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateDropDownMenu", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyBreakLine()
        // Method Decs: Verify that there is a line break between top level links and global/regional links in the megamenu
        // Created on: 22 March 2017	
        // Created By: GI offShore Team	
        //****************************************************

        public void VerifyBreakLine()
        {
            try
            {
                int flag1 = 0, flag2 = 0;
                string text = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string path1 = "//a[text()='" + text + "']/parent::*/br";

                By breakline = By.XPath(path1);
                //  By breakline = By.XPath("//*[text()='Asset Services']");
                ReadOnlyCollection<IWebElement> elms =
                      Driver.FindElements(SearchFromLandingPageOR.oserviceLinesTopNav_xpath);

                Actions action = new Actions(Driver);
                string value = elms[0].Text;
                action.MoveToElement(elms[0]);

                action.Perform();
                common.CallMeWait(1000);
                if (common.CheckElement(HomePageSearchOR.oafterhover_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyBreakLine", "Lay out is appearing after mouse hover on Resources", Status.PASS);
                    try
                    {
                        IWebElement breaklinelem = Driver.FindElement(breakline);
                        Report.UpdateTestLog("VerifyBreakLine", "line break between top level links and global/regional links is present", Status.PASS);
                    }
                    catch
                    {
                        flag1 = 0; Report.UpdateTestLog("VerifyBreakLine", "line break between top level links and global/regional links is not present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                    //verify Global link
                    string text2 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                    string path2 = "//a[text()='" + text2 + "']/parent::*/a[2]";
                    By pathforglobal = By.XPath(path2);
                    if (common.CheckElement(pathforglobal) == true)
                    {
                        Report.UpdateTestLog("VerifyBreakLineFinalStep", " global/regional links is present", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyBreakLine", " global/regional links is not  present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("VerifyBreakLine", "Lay out is appearing after mouse hover on Resources", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
 
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyBreakLine", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyBreakLine", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ISPreFilterPresent()
        // Method Decs:  This method will validate presence of pre filter option on the search result page
        // Created on: 04/07/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void ISPreFilterPresent()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.prefilter_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> elms =
                                    Driver.FindElements(HomePageSearchOR.prefilter_xpath);

                    if (elms.Count() >= 1)
                    {
                        Report.UpdateTestLog("ISPreFilterPresent", " Pre filter option is present as  " + elms[1].Text.Trim(), Status.PASS);
                        elms[1].Click();
                        common.CallMeWait(2000);
                        Report.UpdateTestLog("ISPreFilterPresentFinalStep", " Click on the option Prefilter option ", Status.DONE);
                    }
                }
                else
                {
                    Report.UpdateTestLog("ISPreFilterPresent", " Pre filter option is not present  ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }             
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ISPreFilterPresent", "Unable to locate filter option:  " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ISPreFilterPresent", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
 
        // ******************************************************
        // Method Name:Advancesearch()
        // Method Description: It will search text from home page
        // Created on 04/07/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void Advancesearch()
        {


            string search = DataTable.GetData("General_Data_" + Env, "Search");
            string advSearch = DataTable.GetData("General_Data_" + Env, "AdvSearch");
            int searchFlag = 0;
            try
            {
                if (advSearch.Any())
                {
                    Driver.FindElement(HomePageSearchOR.osearchdropdownarrow_xpath).Click();
                    common.CallMeWait(1000);
                    ReadOnlyCollection<IWebElement> elems = Driver
                .FindElements(HomePageSearchOR.osearchlisttextbox_xpath);
                    foreach (IWebElement elm in elems)
                    {
                        if (elm.Text.Equals(advSearch))
                        {
                            common.CallMeWait(1000);
                            elm.Click();
                            Report.UpdateTestLog("Advancesearch", advSearch + " is Clicked in search box ", Status.PASS);
                            searchFlag = 1;
                            break;
                        }
                    }
                    if (searchFlag == 0)
                    {
                        Report.UpdateTestLog("Advancesearch", advSearch + " is not Clicked in search box ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }

                Driver.FindElement(HomePageSearchOR.osearchtextbox_id).SendKeys(search);
                Driver.FindElement(HomePageSearchOR.osearchtextbox_id1).SendKeys(Keys.Enter);
                //waitForElement((HomePageSearchOR.oallContentlink_link));
                Report.UpdateTestLog("AdvancesearchFinalStep", "Search done: " + search,
                    Status.DONE);
                common.CallMeWait(2000);
               
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("Advancesearch", "Element Not found: "
                                                          + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("Advancesearch", "Error in seach method: "
                                                       + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: NoPreFilter()
        // Method Decs:  This method validates that pre filter is not present
        // Created on: 04/07/2017
        // Created By: GI offShore Team	
        //****************************************************

        public void NoPreFilter()
        {
            try
            {

                if (common.CheckElement(HomePageSearchOR.prefilter_xpath) == false)
                {
                    Report.UpdateTestLog("NoPreFilterFinalStep", " filter option  is not  present  ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("NoPreFilter", " filter option is present  ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
               
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NoPreFilter", " No such element   " +e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NoPreFilter", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateHomeLink()
        // Method Description: Verify the HOME link locale As French Canadian Visitor
        // Created on 04/07/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateHomeLink()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.ohomelink_xpath) == true)
                {
                    string ActualHomeLinkName = Driver.FindElement(HomePageSearchOR.ohomelink_xpath).Text.Trim();
                    string ExpectedHomeLinkName = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                    if (ExpectedHomeLinkName.Equals(ActualHomeLinkName))
                    {
                        Report.UpdateTestLog("ValidateHomeLinkFinalStep", " Home link  is coming as expected locale : '" + ActualHomeLinkName + "'", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateHomeLink", " Home link name is not appearing as expected locale. Expected Locale : '" + ExpectedHomeLinkName + "', Actual Locale : '" + ActualHomeLinkName + "'", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateHomeLink", " Home link is not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("ValidateHomeLink", "Element Not found: " + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateHomeLink", "Error in method: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateSearchOption()
        // Method Description: Verify search option as french canadian visitor
        // Created on 04/07/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateSearchOption()
        {
            try
            {
                bool flag = false;
                string ExpectedSearchOption = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                Driver.FindElement(HomePageSearchOR.searchdropdown).Click();
                common.CallMeWait(1000);
                ReadOnlyCollection<IWebElement> elems = Driver.FindElements(HomePageSearchOR.osearchlisttextbox_xpath);
                foreach (IWebElement elm in elems)
                {
                    if (elm.Text.Equals(ExpectedSearchOption))
                    {
                        Report.UpdateTestLog("ValidateSearchOptionFinalStep", ExpectedSearchOption + " locale is displaying on the search bar ", Status.PASS);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ValidateSearchOptionFinalStep", ExpectedSearchOption + " locale is not displaying as People search option on the search bar ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("ValidateSearchOption", "Element Not found: " + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSearchOption", "Error in method: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateSearchScope()
        // Method Description: This method validate the search scope
        // Created on 04/10/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateSearchScope()
        {
            try
            {
                bool flag = false;
                string ExpectedScope = DataTable.GetData("General_Data_" + Env, "RequestType9").Trim();
                if (common.CheckElement(HomePageSearchOR.oSearchScope_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> ScopeTabs = Driver.FindElements(HomePageSearchOR.oSearchScope_xpath);
                    for (int i = 0; i < ScopeTabs.Count; i++)
                    {
                        string ScopeTab = ScopeTabs[i].Text.Trim();
                        if (ScopeTab.Equals(ExpectedScope))
                        {
                            if (ScopeTabs[i].GetAttribute("class").Contains("selected"))
                            {
                                Report.UpdateTestLog("ValidateSearchScopeFinalStep", " Successfully validated that '" + ExpectedScope+"' scope search is initiated", Status.PASS);
                            }
                            else
                            {
                                Report.UpdateTestLog("ValidateSearchScopeFinalStep", " '" + ExpectedScope + "' scope search is not initiated", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                            }
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateSearchScope", " scope tab '" + ExpectedScope+ "' is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateSearchScope", " Search scope tabs are not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("ValidateSearchScope", "Element Not found: " + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSearchScope", "Error in method: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateRefinerCategories()
        // Method Description: This method validate the search scope
        // Created on 04/10/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateRefinerCategories()
        {
            try
            {
                bool flag = false;
                string RequestType2 = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();
                string[] ExpRefinerCategories = RequestType2.Split(',');
                if (common.CheckElement(HomePageSearchOR.oRefinerCategories_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> ActRefinerCategories = Driver.FindElements(HomePageSearchOR.oRefinerCategories_xpath);
                    for (int i = 0; i < ExpRefinerCategories.Length; i++)
                    {
                        string ExpRefinerCategory = ExpRefinerCategories[i];
                        for (int k = 0; k < ActRefinerCategories.Count; k++)
                        {
                            string ActRefinerCategory = ActRefinerCategories[k].Text.Trim();
                            if (ExpRefinerCategory.Equals(ActRefinerCategory))
                            {
                                Report.UpdateTestLog("ValidateRefinerCategoriesFinalStep", " Refiner category '" + ExpRefinerCategory + "' is present on left nav", Status.PASS);
                                flag = true;
                                break;
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                    if (flag = false)
                    {
                        Report.UpdateTestLog("ValidateRefinerCategories", " Refiner category '" + RequestType2 + "' are not present ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateRefinerCategories", " Refiner categories field are not found ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("ValidateRefinerCategories", "Element Not found: " + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateRefinerCategories", "Error in method: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateRefinerCategoriesUnavailable()
        // Method Description: This method validate the search scope
        // Created on 04/10/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateRefinerCategoriesUnavailable()
        {
            try
            {
                bool flag = true;
                string RequestType2 = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();
                string[] ExpRefinerCategories = RequestType2.Split(',');
                if (common.CheckElement(HomePageSearchOR.oRefinerCategories_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> ActRefinerCategories = Driver.FindElements(HomePageSearchOR.oRefinerCategories_xpath);
                    for (int i = 0; i < ExpRefinerCategories.Length; i++)
                    {
                        string ExpRefinerCategory = ExpRefinerCategories[i];
                        for (int k = 0; k < ActRefinerCategories.Count; k++)
                        {
                            string ActRefinerCategory = ActRefinerCategories[k].Text.Trim();
                            if (ExpRefinerCategory.Equals(ActRefinerCategory))
                            {
                                flag = false;
                                break;
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                    }
                    if (flag = true)
                    {
                        Report.UpdateTestLog("ValidateRefinerCategoriesUnavailableFinalStep", " Refiner categories '" + RequestType2 + "' are not present on left menu ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateRefinerCategoriesUnavailableFinalStep", " Refiner categories '" + RequestType2 + "' are present on left menu", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateRefinerCategoriesUnavailable", " Refiner categories field are not found ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("ValidateRefinerCategoriesUnavailable", "Element Not found: " + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateRefinerCategoriesUnavailable", "Error in method: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ClickImageofJustIn()
        // Method Description: this method verify and click on the fist image under jut in section on the Home page
        // Created on 04/010/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ClickImageofJustIn()
        {
            try
            {

                ReadOnlyCollection<IWebElement> elm = Driver.FindElements(HomePageSearchOR.ojustInImagestextheader_xpath);

                if (elm.Count() > 0)
                {
                    Report.UpdateTestLog("ClickImageofJustIn", " Image are present under just in section ", Status.PASS);
                    string url = null;
                    string curl = null;
                    for (int i = 0; i < elm.Count(); i++)
                    {
                        if (elm[i].Text.Trim() == "")
                        {
                            continue;
                        }
                        else
                        {
                            url = elm[i].GetAttribute("data-ng-href");
                            elm[i].Click();
                            Report.UpdateTestLog("ClickImageofJustIn", "clicked on the first image header text", Status.PASS);
                            common.CallMeWait(2000);
                            curl = Driver.Url;
                            break;
                        }
                    }

                    if (curl.Contains(url))
                    {
                        Report.UpdateTestLog("ClickImageofJustInFinalStep", "clicked page is opened correctly :  " + curl, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ClickImageofJustIn", "clicked page opened incorrectly", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ClickImageofJustIn", " Image are not  present under just in section ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("ClickImageofJustIn", "Element Not found: " + ex, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickImageofJustIn", "Error in method: " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateNewsWebPart()
        // Method Description: this method verifies the details of news articles in a news web part
        // Created on 04/11/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateNewsWebPart()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oNewsWebPart_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateNewsWebPart", " News Web Part is present ", Status.PASS);
                    ReadOnlyCollection<IWebElement> Dates = Driver.FindElements(HomePageSearchOR.oNewsDate_xpath);
                    bool dateflag = false;
                    for (int i = 0; i < Dates.Count; i++)
                    {
                        if (Dates[i].GetAttribute("class").Contains("date"))
                        {
                            dateflag = true;
                        }
                        else
                        {
                            dateflag = false;
                        }
                    }
                    if (dateflag == true)
                    {
                        Report.UpdateTestLog("ValidateNewsWebPart", " The date for an article appears on the left below the title ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsWebPart", " The date for an article doesn't appear on the left below the title ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    ReadOnlyCollection<IWebElement> Authors = Driver.FindElements(HomePageSearchOR.oNewsAuthor_xpath);
                    bool authorflag = false;
                    for (int j = 0; j < Authors.Count; j++)
                    {
                        if (Authors[j].GetAttribute("class").Contains("author"))
                        {
                            authorflag = true;
                        }
                        else
                        {
                            authorflag = false;
                        }
                    }
                    if (authorflag == true)
                    {
                        Report.UpdateTestLog("ValidateNewsWebPart", " The author of an article appears on the right below the title ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsWebPart", " The author of an article doesn't appear on the right below the title ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    ReadOnlyCollection<IWebElement> DateFormats = Driver.FindElements(HomePageSearchOR.oNewsDate_xpath);
                    bool dateformatflag = false;
                    for (int k = 0; k < DateFormats.Count; k++)
                    {
                        if (DateFormats[k].Text.Contains("ago"))
                        {
                            dateformatflag = true;
                        }
                        else
                        {
                            dateformatflag = false;
                        }
                    }
                    if (dateformatflag == true)
                    {
                        Report.UpdateTestLog("ValidateNewsWebPartFinalStep", " The date format for an article appears with 'ago' string ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateNewsWebPart", " The date format for an article doesn't showing  with 'ago' string ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateNewsWebPart", " News Web Part is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("ValidateNewsWebPart", "Element Not found: " + ex, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNewsWebPart", "Error in method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name:searchSpecialCharacter()
        // Method Description: It will search text from home page
        // Created on 04/20/2017
        // Created By: GI offShore Team
        // *****************************************************

        public void searchSpecialCharacter()
        {           
            int searchFlag = 0;
            try
            {
               

                Driver.FindElement(HomePageSearchOR.osearchtextbox_id).SendKeys("#@!$%^&*()+=` { }|,.;");
                Driver.FindElement(HomePageSearchOR.osearchtextbox_id1).SendKeys(Keys.Enter);
                //waitForElement((HomePageSearchOR.oallContentlink_link));
                Report.UpdateTestLog("searchSpecialCharacterFinalStep", "Search done with special character " ,
                    Status.PASS);
                common.CallMeWait(2000);
            }
            catch (NoSuchElementException ex)
            {
                Report.UpdateTestLog("searchSpecialCharacter", "Element Not found: "
                                                          + ex, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("searchSpecialCharacter", "Error in  method: "
                                                       + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method name:ValidateSearchResult()
        // Method Description : This method Search the people validate the result
        // Created On: 04/21/2017
        // Created By: GI offShore Team
        // *****************************************
        public void ValidateSearchResult()
        {
            try
            {
                string peopleName = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
               // string dynamicPath = "//*[@class='ms-srch-group-content']/child::*[1]/div/div/div[2]/div[1]/div/a";
                int count = 0;
                bool flag = false;
                ReadOnlyCollection<IWebElement> peopleList = Driver.FindElements(By.XPath("//*[@class='ms-srch-group-content']/child::*"));
                for (int i = 0; i < peopleList.Count; i++)
                {
                    count = i + 1;
                    string dynamicPath = "//*[@class='ms-srch-group-content']/child::*[" + count + "]/div/div/div[2]/div[1]/div/a";
                    string value = Driver.FindElement(By.XPath(dynamicPath)).Text.Trim();
                    if (value.Contains(peopleName))
                    {
                        Report.UpdateTestLog("ValidateSearchResultFinalStep", " Validated the search result with the input string: " + peopleName, Status.PASS);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ValidateSearchResultFinalStep", " The search result is not matching with the input string: " + peopleName, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSearchResult", "Element not found " + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSearchResult", "Error in Method " + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateTagsInSearchResult()
        // Method Description: This method validates the total count of tags in each search result
        // Created on 05/04/2017
        // Created By: GI offShore Team
        // ****************************************************

        public void ValidateTagsInSearchResult()
        {
            try
            {
                bool flag = false;
                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oSearchResults);
                int count = elems.Count;
                count = count - 1;
                for (int i = 1; i <= count; i++)
                {
                    string path = "//div[contains(@id,'groupContent')]/div[" + i + "]/div[1]/div/div/div[3]/div[1]/child::*";
                    ReadOnlyCollection<IWebElement> Tags = Driver.FindElements(By.XPath(path));
                    if (Tags.Count <= 10)
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
                    Report.UpdateTestLog("ValidateTagsInSearchResultFinalStep", "Search Results don't have more than 10 Tags attached", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateTagsInSearchResult", " Search Results have more than 10 Tags attached" , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateTagsInSearchResult", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateTagsInSearchResult", "Error in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: LocationCountBeforeClickonShowmore()
        // Method Description: Returns locations count in Refine your search section.
        // Created on 05/10/2017
        // Created By: GI offShore Team
        // ****************************************************

        public int LocationCountBeforeClickonShowmore()
        {
            int lc = 0;
            try
            {

                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.oresultypewebelement_xpath);
                int pos = RefinerNamePosition("Location");
                IWebElement elm = elems[pos - 1];
                // System.out.println(elm.Text);
                ReadOnlyCollection<IWebElement> Requesttype = elm
                   .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                lc = Requesttype.Count;
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("LocationCountBeforeClickonShowmore",
                        " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("LocationCountBeforeClickonShowmore",
                        " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            return lc;

        }
        // ******************************************************
        // Method Name: LocationCountAfterClickonShowmore()
        // Method Description: Returns locations count in Refine your search section.
        // Created on 05/10/2017
        // Created By: GI offShore Team
        // ****************************************************

        public int LocationCountAfterClickonShowmore()
        {
            int alc = 0;
            try
            {

                ReadOnlyCollection<IWebElement> elems = Driver
                    .FindElements(HomePageSearchOR.olocationlistafterclickonshowmore);

                ReadOnlyCollection<IWebElement> Requesttype = elems[1]
                   .FindElements(HomePageSearchOR.oresultypetextwebelement_xpath);
                alc = Requesttype.Count;
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("LocationCountAfterClickonShowmore",
                        " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("LocationCountAfterClickonShowmore",
                        " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            return alc;

        }
        // ******************************************************
        // Method Name: VerifyShowMoreOnLocaion()
        // Method Description: click on show more option of locations Refine your search section.
        // Created on 05/10/2017
        // Created By: GI offShore Team
        // ****************************************************
        public void VerifyShowMoreOnLocaion()
        {

            try
            {
                int precount = LocationCountBeforeClickonShowmore();
                Report.UpdateTestLog("VerifyShowMoreOnLocaion", " location count before click on Show more option  " + precount, Status.PASS);
                ClickShowMoreOnLocaion();
                int postcount = LocationCountAfterClickonShowmore();
                Report.UpdateTestLog("VerifyShowMoreOnLocaion", " location count after click on Show more option  " + postcount, Status.PASS);
                if (postcount >= precount)
                {
                    Report.UpdateTestLog("VerifyShowMoreOnLocaionFinalStep", " More location are discplayed ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyShowMoreOnLocaion", " No More location are displayed ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyShowMoreOnLocaion",
                        " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("VerifyShowMoreOnLocaion",
                        " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        // ******************************************************
        // Method Name: ClickShowMoreOnLocaion()
        // Method Description: click on show more option of locations Refine your search section.
        // Created on 05/10/2017
        // Created By: GI offShore Team
        // ****************************************************
        public void ClickShowMoreOnLocaion()
        {

            try
            {
                if (common.CheckElement(HomePageSearchOR.oshowmore) == true)
                {
                    Report.UpdateTestLog("ClickShowMoreOnLocaion",
                                            " Show more option is present at the bottom of refiners", Status.PASS);
                    ReadOnlyCollection<IWebElement> Requesttype = Driver.FindElements(HomePageSearchOR.oshowmore);
                    Requesttype[1].Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClickShowMoreOnLocaionFinalStep",
                                            "Clicked on location show more option ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickShowMoreOnLocaion",
                                                                " Show more option is not present at the bottom of refiners", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickShowMoreOnLocaion",
                        " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("ClickShowMoreOnLocaion",
                        " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: SelectARefiner()
        // Method Decs: this method select a refiner on the search result page.
        // Created on: 05/10/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void SelectARefiner()
        {
            try
            {

                string requestType1 = DataTable.GetData("General_Data_" + Env, "RequestType1");
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
                    if (typename.Equals(requestType1.Trim()))
                    {
                        elm2.FindElement(By.Id("RefinementName")).Click();
                        //elm2.Click();
                        common.CallMeWait(1000);
                        Report.UpdateTestLog("SelectARefinerFinalStep", "Clicked on " + requestType1, Status.PASS);
                        //Thread.Sleep(5000);
                        break;
                    }
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectARefiner", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectARefiner", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateClearAllLink()
        // Method Decs: this method validates clear all link is present or not
        // Created on: 05/11/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateClearAllLink()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oClearAll_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateClearAllLinkFinalStep", " Clear All link is present on Top of the refiners", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateClearAllLink", " Clear All link is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateClearAllLink", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateClearAllLink", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnClearAllLink()
        // Method Decs: this method clicks on clear all link 
        // Created on: 05/11/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickOnClearAllLink()
        {
            try
            {
                Driver.FindElement(HomePageSearchOR.oClearAll_xpath).Click();
                Report.UpdateTestLog("ClickOnClearAllLinkFinalStep", " Clicked on Clear All link", Status.PASS);
                common.CallMeWait(1000);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnClearAllLink", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnClearAllLink", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateClearAllSelectedRefiner()
        // Method Decs: this method validates no Clear All filter should be present
        // Created on: 05/11/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateClearAllSelectedRefiner()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oClearAll_xpath) == false)
                {
                    Report.UpdateTestLog("ValidateClearAllSelectedRefinerFinalStep", " Successfully validated that there is no selected refiner present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateClearAllLink", " Selected refiner is present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateClearAllSelectedRefiner", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateClearAllSelectedRefiner", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateCloseRefinerIcon()
        // Method Decs: this method validates close refiner icon is present or not
        // Created on: 05/11/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateCloseRefinerIcon()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oclosefilter) == true)
                {
                    Report.UpdateTestLog("ValidateCloseRefinerIconFinalStep", " Close refiner icon is present on right side of the refiner label", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateCloseRefinerIcon", " Close refiner icon is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCloseRefinerIcon", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCloseRefinerIcon", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnCloseRefinerIcon()
        // Method Decs: this method clicks on the close refiner icon
        // Created on: 05/11/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickOnCloseRefinerIcon()
        {
            try
            {
                Driver.FindElement(SearchFromLandingPageOR.oclosefilter).Click();
                Report.UpdateTestLog("ClickOnCloseRefinerIconFinalStep", " Clicked on the close refiner icon", Status.PASS);
                common.CallMeWait(1000);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnCloseRefinerIcon", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnCloseRefinerIcon", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateIconNotDisplaying()
        // Method Decs: this method validates no close refiner icon is present
        // Created on: 05/11/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateIconNotDisplaying()
        {
            try
            {
                if (common.CheckElement(SearchFromLandingPageOR.oclosefilter) == false)
                {
                    Report.UpdateTestLog("ValidateIconNotDisplayingFinalStep", " Successfully validated that there is no selected refiner present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateCloseRefinerIcon", " Selected refiner is present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateIconNotDisplaying", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateIconNotDisplaying", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateShowMoreInRefiners()
        // Method Description: This method validated Show More link in refiners
        // Created on 05/12/2017
        // Created By: GI offShore Team
        // ****************************************************
        public void ValidateShowMoreInRefiners()
        {

            try
            {
                if (common.CheckElement(HomePageSearchOR.oshowmore) == true)
                {
                    Report.UpdateTestLog("ValidateShowMoreInRefinersFinalStep",
                                            " Show more option is present at the bottom of refiners", Status.PASS);                    
                    
                }
                else
                {
                    Report.UpdateTestLog("ValidateShowMoreInRefiners",
                                                                " Show more option is not present at the bottom of refiners or number of refiners are not greater than 5", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateShowMoreInRefiners",
                        " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("ValidateShowMoreInRefiners",
                        " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: ValidateRefinersListedNotBasedOnSearch()
        // Method Description: This method validates refiners listed not based on search string
        // Created on 05/17/2017
        // Created By: GI offShore Team
        // ****************************************************
        public void ValidateRefinersListedNotBasedOnSearch()
        {

            try
            {
                int count = LocationCountBeforeClickonShowmore();

                if (count > 1)
                {
                    Report.UpdateTestLog("ValidateRefinersListedNotBasedOnSearchFinalStep", " Successfully validated that refiners listed in page are not based on the search string ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateRefinersListedNotBasedOnSearch", " Refiners listed in page are based on the search string ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateRefinersListedNotBasedOnSearch",
                        " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("ValidateRefinersListedNotBasedOnSearch",
                        " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method name:ValidateWorkSchedule()
        // Method Description : This method validates the work schedule section
        // Created On: 05/22/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateWorkSchedule()
        {
            try
            {
                if (common.CheckElement(HomePageSearchOR.oWorkSchedule_id) == true)
                {
                    Report.UpdateTestLog("ValidateWorkScheduleFinalStep", " Visitor is able to view the work schedule of other profile ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateWorkSchedule"," Visitor is not able to view the work schedule of other profile " , Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateWorkSchedule"," Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("ValidateWorkSchedule"," Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method name: ValidateWorkScheduleSubsections()
        // Method Description : This method validates the sub sections of work schedule 
        // Created On: 05/22/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateWorkScheduleSubsections()
        {
            try
            {
                bool flag = false;
                string RequestType1 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string[] ExpSubsections = RequestType1.Split(',');
                if (common.CheckElement(HomePageSearchOR.oWorkScheduleSubsections_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> ActSubsections = Driver.FindElements(HomePageSearchOR.oWorkScheduleSubsections_xpath);
                    for (int i = 0; i < ExpSubsections.Length; i++)
                    {
                        for (int k = 0; k < ActSubsections.Count; k++)
                        {
                            string ExpectedSubSection = ExpSubsections[i].Trim();
                            string ActualSubSection = ActSubsections[k].Text.Trim();
                            if (ExpectedSubSection.Contains(ActualSubSection))
                            {
                                Report.UpdateTestLog("ValidateWorkScheduleSubsectionsFinalStep", " SubSection '" + ExpectedSubSection + "' is present under Work scheduler", Status.PASS);
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
                        Report.UpdateTestLog("ValidateWorkScheduleSubsections", " All the SubSections '" + RequestType1 + "' are not present under Work scheduler", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateWorkScheduleSubsections", " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("ValidateWorkScheduleSubsections", " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method name: ValidateWorkScheduleSubsectionsValue()
        // Method Description : This method validates the sub sections value of work schedule 
        // Created On: 05/24/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateWorkScheduleSubsectionsValue()
        {
            try
            {
                bool flag = false;
                string RequestType1 = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string[] ExpSubsections = RequestType1.Split(',');
                if (common.CheckElement(HomePageSearchOR.oWorkScheduleSubsections_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> ActSubsections = Driver.FindElements(HomePageSearchOR.oWorkScheduleSubsections_xpath);
                    ReadOnlyCollection<IWebElement> ActSubsectionsValue = Driver.FindElements(HomePageSearchOR.oWorkScheduleSubsectionsValue_xpath);
                    for (int i = 0; i < ExpSubsections.Length; i++)
                    {
                        for (int k = 0; k < ActSubsections.Count; k++)
                        {
                            string ExpectedSubSection = ExpSubsections[i].Trim();
                            string ActualSubSection = ActSubsections[k].Text.Trim();
                            if (ExpectedSubSection.Contains(ActualSubSection))
                            {
                                if (ActSubsectionsValue[k].Text.Trim().Contains("–"))
                                {
                                    Report.UpdateTestLog("ValidateWorkScheduleSubsectionsValueFinalStep", " System displays '-' value under SubSection '" + ExpectedSubSection + "'", Status.PASS);
                                    flag = true;
                                    break;
                                }
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateWorkScheduleSubsectionsValue", " System doesn't display '-' value for all the SubSections '" + RequestType1 + "'", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateWorkScheduleSubsectionsValue", " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("ValidateWorkScheduleSubsectionsValue", " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickOnDocumentLinkOnJAsite()
        // Method Description : This method will Click on Document link
        // Created On: 06/02/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ClickOnDocumentLinkOnJAsite()
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
                    if (elm2.Text.Trim().Equals("Documents"))
                    {
                        elm2.Click();
                        //	callMeWait(2000);
                        Report.UpdateTestLog("ClickOnDocumentLinkOnJAsiteFinalStep", " Clicked On Document Link ", Status.PASS);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ClickOnDocumentLinkOnJAsite", " Document Link is not present", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnDocumentLinkOnJAsite", " Web Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnDocumentLinkOnJAsite", " Problem in  Method " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
    
    }
}
