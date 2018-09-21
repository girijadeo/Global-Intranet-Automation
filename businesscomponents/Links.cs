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
using OpenQA.Selenium.Interactions;
using System.Configuration;

namespace CRAFT.BusinessComponents
{

    /// <summary>
    /// Business Component Library template

    /// </summary>
    public class Links : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;
        /// <summary>
        /// Constructor to initialize the business component library
        /// </summary>
        /// <param name="scriptHelper"> The ScriptHelper object passed from the DriverScript</param>
        public Links(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
            common = new CommonComponents(ScriptHelper);
        }

        // *****************************************
        // Method ClickToEdit()
        // Created On: 24th Feb
        // Method Description : This method click on the edit link option
        // Created By: GI offShore Team
        // *****************************************
        public void ClickToEdit()
        {
            try
            {
                if (common.CheckElement(LinksOR.oeditlink))
                {
                    Driver.FindElement(LinksOR.oeditlink).Click();
                    Report.UpdateTestLog("ClickToEditFinalStep", "edit option is clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickToEdit", "unable to find edit option ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToEdit", "Error in method" + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method ClickToAddlink()
        // Method Description : This method click on the Add link option
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void ClickToAddlink()
        {
            try
            {
                if (common.CheckElement(LinksOR.oaddlink)==true)
                {
                    Driver.FindElement(LinksOR.oaddlink).Click();
                    Report.UpdateTestLog("ClickToAddlinkFinalStep", "Add link option is clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickToAddlink", "unable to find Add link option ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToAddlink", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method EnterlinkDetails()
        // Method Description : This method enters detail of link
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void EnterlinkDetails()
        {
            try
            {

                if (common.CheckElement(LinksOR.oiframe))
                {
                    ReadOnlyCollection<IWebElement> detailFrame = Driver.FindElements(LinksOR.oiframe);
                    Driver.SwitchTo().Frame(detailFrame[1]);
                    Report.UpdateTestLog("EnterlinkDetails", "switched to frame ", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("EnterlinkDetails", "unable to switch to frame ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(LinksOR.otexttobedisplayed))
                {
                    string nametobedisplay = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                    Driver.FindElement(LinksOR.otexttobedisplayed).Clear();
                    Driver.FindElement(LinksOR.otexttobedisplayed).SendKeys(nametobedisplay);
                    Report.UpdateTestLog("EnterlinkDetails", "Link name is entred ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterlinkDetails", "unable to enter link name ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(LinksOR.oaddress))
                {
                    string linkvalue = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                    Driver.FindElement(LinksOR.oaddress).Clear();
                    Driver.FindElement(LinksOR.oaddress).SendKeys(linkvalue);
                    Report.UpdateTestLog("EnterlinkDetailsFinalStep", "Link value is entred ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterlinkDetails", "unable to enter link value ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterlinkDetails", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method ClickOnOk()
        // Method Description : This method click on the OK button
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void ClickOnOk()
        {
            try
            {
                if (common.CheckElement(LinksOR.ookbutton))
                {
                    Driver.FindElement(LinksOR.ookbutton).Click();
                    Report.UpdateTestLog("ClickOnOkFinalStep", "OK button option is clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnOk", "unable to find OK button ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                Driver.SwitchTo().DefaultContent();
                common.CallMeWait(1000);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnOk", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method ClickOnSave()
        // Method Description : This method click on the Save button
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void ClickOnSave()
        {
            try
            {

                if (common.CheckElement(LinksOR.osavebutton) == true)
                {
                    Driver.FindElement(LinksOR.osavebutton).Click();
                    Report.UpdateTestLog("ClickOnSaveFinalStep", "Save button option is clicked ", Status.PASS);
                    common.CallMeWait(1000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnSave", "unable to find Save button ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

               

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnSave", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method FindAndDeleteLink()
        // Method Description : This method find the link and delete it 
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void FindAndDeleteLink()
        {
            try
            {
                ClickToEdit();
                string nametobedisplay = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(LinksOR.oallQuickLaunchMenuitemname) == true)
                {
                    ReadOnlyCollection<IWebElement> elms1 = Driver.FindElements(LinksOR.oallQuickLaunchMenuitemname);
                    ReadOnlyCollection<IWebElement> elms2 = Driver.FindElements(LinksOR.oallQuickLaunchMenuitemcross);
                    for (int i = 0; i < elms1.Count; i++)
                    {
                        if (nametobedisplay.Equals(elms1[i].Text.Trim()))
                        {
                            Report.UpdateTestLog("FindAndDeleteLinkFinalStep", "link is found and deleted ", Status.PASS);
                            elms2[i].Click();
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("FindAndDeleteLink", "no link is present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ClickOnSave();
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindAndDeleteLink", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method VerifyNavigationOfLink()
        // Method Description : This method find the link and verifies the the navigation is correct
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void VerifyNavigationOfLink()
        {
            try
            {

                string nametobedisplay = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string expUrl = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                string linkurl = null;
                string url = null;
                ReadOnlyCollection<IWebElement> elms1 = Driver.FindElements(LinksOR.oalllinkname);
                ReadOnlyCollection<IWebElement> elms2 = Driver.FindElements(LinksOR.oalllink);
                if (elms1.Count > 0)
                {

                    for (int i = 0; i < elms1.Count; i++)
                    {
                        if (nametobedisplay.Equals(elms1[i].Text.Trim()))
                        {
                            Report.UpdateTestLog("VerifyNavigationOfLink", "link is found" + nametobedisplay, Status.PASS);
                            linkurl = elms2[i].GetAttribute("href").Trim();
                            elms2[i].Click();
                            url = Driver.Url;
                            if (url.Contains(expUrl))
                            {
                                Report.UpdateTestLog("VerifyNavigationOfLinkFinalStep", "Navigated currectly to " + url, Status.PASS);
                                Driver.Navigate().Back();
                                common.CallMeWait(2000);
                            }
                            else
                            {
                                Report.UpdateTestLog("VerifyNavigationOfLink", "Navigated wrongly to " + url,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                                Driver.Navigate().Back();
                                common.CallMeWait(2000);
                            }

                            break;
                        }
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyNavigationOfLink", "no link id present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyNavigationOfLink", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method VerifyPageUpdateDetail()
        // Method Description : This method verifies the page auhor and last updated date
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void VerifyPageUpdateDetail()
        {
            try
            {
                if (common.CheckElement(LinksOR.opublishedInfo) == true)
                {
                    string pblishdate = Driver.FindElement(LinksOR.opublishedInfo).Text.Trim();
                    Report.UpdateTestLog("VerifyPageUpdateDetail", "Publish Date is :" + pblishdate, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageUpdateDetail", "Publish Date is not present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                if (common.CheckElement(LinksOR.opublishedAuthor) == true)
                {
                    string author = Driver.FindElement(LinksOR.opublishedAuthor).Text.Trim();
                    Report.UpdateTestLog("VerifyPageUpdateDetailFinalStep", "Author is :" + author, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageUpdateDetail", "Author is not present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPageUpdateDetail", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: CreateMoreLinks()
        // Method Decs:This method create many link on the home page as per number entered in the data table
        // Created on:  24th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void CreateMoreLinks()
        {
            try
            {
                bool flag = false;
                string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7");
                int n = Int32.Parse(req7);
                for (int i = 1; i <= n; i++)
                {
                    ClickToEdit();
                    ClickToAddlink();
                    EnterlinkDetailsOnCall(i.ToString());
                    ClickOnOk();
                    ClickOnSave();
                    Report.UpdateTestLog("CreateMoreLinksFinalStep", " link created :" + i, Status.PASS);
                    flag = true;
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("CreateMoreLinks", " link not created ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CreateMoreLinks", " Element not found : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CreateMoreLinks", " There is a problem in Method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        // *****************************************
        // Method EnterlinkDetailsOnCall()
        // Method Description : This method create many link name on the home page as per number entered in the data table
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void EnterlinkDetailsOnCall(string c)
        {
            try
            {

                if (common.CheckElement(LinksOR.oiframe))
                {
                    ReadOnlyCollection<IWebElement> detailFrame = Driver.FindElements(LinksOR.oiframe);
                    Driver.SwitchTo().Frame(detailFrame[1]);
                    Report.UpdateTestLog("EnterlinkDetailsOnCall", "switched to frame ", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("EnterlinkDetailsOnCall", "unable to switch to frame ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(LinksOR.otexttobedisplayed))
                {
                    string nametobedisplay = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim() + c;
                    Driver.FindElement(LinksOR.otexttobedisplayed).Clear();
                    Driver.FindElement(LinksOR.otexttobedisplayed).SendKeys(nametobedisplay);
                    Report.UpdateTestLog("EnterlinkDetailsOnCall", "Link name is entred ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterlinkDetailsOnCall", "unable to enter link name ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(LinksOR.oaddress))
                {
                    string linkvalue = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                    Driver.FindElement(LinksOR.oaddress).Clear();
                    Driver.FindElement(LinksOR.oaddress).SendKeys(linkvalue);
                    Report.UpdateTestLog("EnterlinkDetailsOnCallFinalStep", "Link value is entred ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterlinkDetailsOnCall", "unable to enter link value ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterlinkDetailsOnCall", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method DragandDrop()
        // Method Description : This method finds to link and change its position mutualy by dragging and drop
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void DragandDrop()
        {
            try
            {
                ClickToEdit();
                string nametobedisplay = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                string link1 = nametobedisplay + "1";
                string link2 = nametobedisplay + "2";
                IWebElement From = null;
                IWebElement To = null;
                if (common.CheckElement(LinksOR.oallQuickLaunchMenuitemname) == true)
                {
                    ReadOnlyCollection<IWebElement> elms1 = Driver.FindElements(LinksOR.oallQuickLaunchMenuitemname);
                    //ReadOnlyCollection<IWebElement> elms2 = Driver.FindElements(LinksOR.oallQuickLaunchMenuitemcross);
                    for (int i = 0; i < elms1.Count; i++)
                    {
                        if (link1.Equals(elms1[i].Text.Trim()))
                        {
                            From = elms1[i];
                            Report.UpdateTestLog("DragandDrop", "link is found: " + link1, Status.PASS);
                        }
                        if (link2.Equals(elms1[i].Text.Trim()))
                        {
                            To = elms1[i];
                            Report.UpdateTestLog("DragandDrop", "link is found: " + link2, Status.PASS);
                        }

                    }
                }
                else
                {
                    Report.UpdateTestLog("FindAndDeleteLink", "no link is present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.CallMeWait(2000);
                Actions builder = new Actions(Driver);
                builder.ClickAndHold(From);
                builder.MoveToElement(To);
                builder.Release(From);
                builder.Build();

                //   builder.ClickAndHold(From).MoveToElement(To).Release(To).Build().Perform();
                String xto = To.Location.X.ToString();
                String yto = To.Location.Y.ToString();
                /* IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
                 js.ExecuteScript("function simulate(f,c,d,e){var b,a=null;for(b in eventMatchers)if(eventMatchers[b].test(c)){a=b;break}if(!a)return!1;document.createEvent?(b=document.createEvent(a),a==\"HTMLEvents\"?b.initEvent(c,!0,!0):b.initMouseEvent(c,!0,!0,document.defaultView,0,d,e,d,e,!1,!1,!1,!1,0,null),f.dispatchEvent(b)):(a=document.createEventObject(),a.detail=0,a.screenX=d,a.screenY=e,a.clientX=d,a.clientY=e,a.ctrlKey=!1,a.altKey=!1,a.shiftKey=!1,a.metaKey=!1,a.button=1,f.fireEvent(\"on\"+c,a));return!0} var eventMatchers={HTMLEvents:/^(?:load|unload|abort|error|select|change|submit|reset|focus|blur|resize|scroll)$/,MouseEvents:/^(?:click|dblclick|mouse(?:down|up|over|move|out))$/}; " +
   "simulate(arguments[0],\"mousedown\",0,0); simulate(arguments[0],\"mousemove\",arguments[1],arguments[2]); simulate(arguments[0],\"mouseup\",arguments[1],arguments[2]); ",
   To, xto, yto);
                 common.CallMeWait(5000);*/

                ClickOnSave();
                common.CallMeWait(2000);

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindAndDeleteLink", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method FindAndDeleteLinkOnCall()
        // Method Description : This method find the link and delete it 
        // Created On: 24th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void FindAndDeleteLinkOnCall(string c)
        {
            try
            {
                ClickToEdit();
                string nametobedisplay = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim() + c;
                if (common.CheckElement(LinksOR.oallQuickLaunchMenuitemname) == true)
                {
                    ReadOnlyCollection<IWebElement> elms1 = Driver.FindElements(LinksOR.oallQuickLaunchMenuitemname);
                    ReadOnlyCollection<IWebElement> elms2 = Driver.FindElements(LinksOR.oallQuickLaunchMenuitemcross);
                    for (int i = 0; i < elms1.Count; i++)
                    {
                        if (nametobedisplay.Equals(elms1[i].Text.Trim()))
                        {
                            Report.UpdateTestLog("FindAndDeleteLinkOnCallFinalStep", "link is found and deleted ", Status.PASS);
                            elms2[i].Click();
                        }
                    }
                }
                else
                {
                    Report.UpdateTestLog("FindAndDeleteLinkOnCall", "no link is present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ClickOnSave();
                common.CallMeWait(2000);
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindAndDeleteLinkOnCall", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DeleteMoreLinks()
        // Method Decs:This method delete many link on the home page as per number entered in the data table
        // Created on:  24th Feb  2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void DeleteMoreLinks()
        {
            try
            {
                string req7 = DataTable.GetData("General_Data_" + Env, "RequestType7");
                int n = Int32.Parse(req7);
                for (int i = 1; i <= n; i++)
                {
                    FindAndDeleteLinkOnCall(i.ToString());

                    Report.UpdateTestLog("DeleteMoreLinksFinalStep", " link deleted :" + i, Status.DONE);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteMoreLinks", " Element not found : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteMoreLinks", " There is a problem in Method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        // *****************************************
        // Method VerifyLeftNav()
        // Method Description : This method verifies presence of left nav on the page
        // Created On: 27th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void VerifyLeftNav()
        {
            try
            {

                if (common.CheckElement(LinksOR.oleftnav_id))
                {

                    Report.UpdateTestLog("VerifyLeftNavFinalStep", "Left Nav is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyLeftNav", "Left Nav is not present",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }

            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyLeftNav", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        // *****************************************
        // Method VerifyMobileTabletoption()
        // Method Description : This method verifies presence of mobile and Tablet option present on the page
        // Created On: 27th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void VerifyMobileTabletoption()
        {
            try
            {

                if (common.CheckElement(LinksOR.omobileview_id))
                {

                    Report.UpdateTestLog("VerifyMobileTabletoption", "Mobile view option is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMobileTabletoption", "Mobile view option is not present",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(LinksOR.otabletlandscape_id))
                {

                    Report.UpdateTestLog("VerifyMobileTabletoption", "Tablet landscape view option is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMobileTabletoption", "Tablet landscape view option is not present",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(LinksOR.otabletportrait_id))
                {

                    Report.UpdateTestLog("VerifyMobileTabletoptionFinalStep", "Tablet portrait view option is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMobileTabletoption", "Tablet portrait view option is  not  present",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }

            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyMobileTabletoption", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // *****************************************
        // Method VerifyFooter()
        // Method Description : This method verifies presence of Footer on the page
        // Created On: 27th Feb
        // Created By: GI offShore Team
        // *****************************************
        public void VerifyFooter()
        {
            try
            {

                if (common.CheckElement(LinksOR.ofooter_id))
                {

                    Report.UpdateTestLog("VerifyFooterFinalStep", "Footer is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyFooter", "Footer is not present",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }

            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyFooter", "Error in method " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyTopNavigationItem()
        // Method Decs: This Metion verifies top navigation menu 
        // Created on:  27th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyTopNavigationItem()
        {
            try
            {

                string topnavitem = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string[] words = topnavitem.Split(',');

                for (int i = 0; i < words.Length; i++)
                {
                    string t = words[i].Trim();
                    string dynamicXpath = "//*[text()='" + t + "']";
                    By elm = By.XPath(dynamicXpath);
                    if (common.CheckElement(elm))
                    {

                        Report.UpdateTestLog("VerifyTopNavigationItemFinalStep", t + "  is present", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyTopNavigationItem", t + "  is not present",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyTopNavigationItem", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyTopNavigationItem", " Error on  method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyAdminContent()
        // Method Decs: This Methon verifies link present under Admin navigation menu 
        // Created on:  27th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyAdminContent()
        {
            try
            {
                if (common.CheckElement(LinksOR.oadmin_xpath))
                {
                    Driver.FindElement((LinksOR.oadmin_xpath)).Click();
                    Report.UpdateTestLog("VerifyPageEditMode", "Clicked on Admin option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageEditMode", "Unable to click on Admin option",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                string topnavitem = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                string[] words = topnavitem.Split(',');
                for (int i = 0; i < words.Length; i++)
                {
                    string t = words[i].Trim();
                    // [contains(text(), 'Assign Rate')]
                    string dynamicXpath = "//*[contains(text(), '" + t + "')]";
                    By elm = By.XPath(dynamicXpath);

                    if (common.CheckElement(elm))
                    {
                        Report.UpdateTestLog("VerifyAdminContentFinalStep", t + "  is present", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyAdminContent", t + "  is not present",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyAdminContent", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyAdminContent", " Error on ClickOnTopNavigationItem method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyPageEditMode()
        // Method Decs: This Method verifies that page is oped in edit mode
        // Created on:  27th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyPageEditMode()
        {
            try
            {

                if (common.CheckElement(LinksOR.oeditpage_xpath))
                {
                    Driver.FindElement((LinksOR.oeditpage_xpath)).Click();
                    Report.UpdateTestLog("VerifyPageEditMode", "Clicked on edit page option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageEditMode", "Unable to click on edit page option",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(LinksOR.odeletepage_xpath))
                {

                    Report.UpdateTestLog("VerifyPageEditModeFinalStep", "page is opened in edit mode", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPageEditMode", "Unable to open page in edit mode",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPageEditMode", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPageEditMode", " Error on ClickOnTopNavigationItem method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        
        //******************************************************
        // Method Name: VerifySearchResultPage()
        // Method Decs: This Method verifies that search result page is opened
        // Created on:  28th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifySearchResultPage()
        {
            try
            {

                if (common.CheckElement(LinksOR.orefinesearchtext_xpath))
                {
                    Report.UpdateTestLog("VerifySearchResultPageFinalStep", "Search Result page is opened", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySearchResultPage", "Unable to open search result page",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySearchResultPage", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySearchResultPage", " Error in method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateProvisioningListPage()
        // Method Decs: This Method verifies the page title
        // Created on:  03/29/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateProvisioningListPage()
        {
            try
            {
                string ExpectedTitle = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(LinksOR.oPageTitle_xpath) == true)
                {
                    string ActualTitle = Driver.FindElement(LinksOR.oPageTitle_xpath).Text.Trim();
                    if (ActualTitle.Contains(ExpectedTitle))
                    {
                        Report.UpdateTestLog("ValidateProvisioningListPageFinalStep", " Page Title is matching, title is = " + ExpectedTitle, Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateProvisioningListPage", " Page Title is not matching, Expected = " + ExpectedTitle + ", Actual = " + ActualTitle,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateProvisioningListPage", " Page Title not present " ,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateProvisioningListPage", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateProvisioningListPage", " Error in method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectASite()
        // Method Decs: This Method select a site
        // Created on:  03/29/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void SelectASite()
        {
            try
            {
                if (common.CheckElement(LinksOR.oSiteTitleHeader_xpath) == true)
                {
                    Driver.FindElement(LinksOR.oSiteTitleHeader_xpath).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("SelectASite", " Clicked on Site Title header to sort ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectASite", " Site Title header is not present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                ReadOnlyCollection<IWebElement> SiteTitles = Driver.FindElements(LinksOR.oSiteTitles_xpath);
                ReadOnlyCollection<IWebElement> checkboxes = Driver.FindElements(LinksOR.oSelectLinks_xpath);
                string ExpectedSiteTitle = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                bool flag = false;
                for (int i = 0; i < SiteTitles.Count; i++)
                {
                    string ActualSiteTitle = SiteTitles[i].Text.Trim();
                    if (ActualSiteTitle.Contains(ExpectedSiteTitle))
                    {
                        checkboxes[i].Click();
                        Report.UpdateTestLog("SelectASiteFinalStep", " Selected Site Title row to edit ", Status.PASS);
                        flag = true;
                        common.CallMeWait(2000);
                        break;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("SelectASiteFinalStep", " Expected Site Title is not present in the site list ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectASite", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectASite", " Error in method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EditItem()
        // Method Decs: This Method edit the selected site
        // Created on:  03/29/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void EditItem()
        {
            try
            {
                if (common.CheckElement(LinksOR.oItems_xpath) == true)
                {
                    Driver.FindElement(LinksOR.oItems_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("EditItem", " Clicked on Items on top left ", Status.PASS);
                    if (common.CheckElement(LinksOR.oEditItems_id) == true)
                    {
                        Driver.FindElement(LinksOR.oEditItems_id).Click();
                        Report.UpdateTestLog("EditItemFinalStep", " Clicked on Edit Item ", Status.PASS);
                        common.CallMeWait(2000);
                    }
                    else
                    {
                        Report.UpdateTestLog("EditItem", " Edit Item element is not present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("EditItem", " Items element is not present on top left ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EditItem", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EditItem", " Error in method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateAction()
        // Method Decs: This Method validates Action drop down field
        // Created on:  03/29/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateAction()
        {
            try
            {
                string ExpectedOption = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                bool flag = false;
                if (common.CheckElement(LinksOR.oActionDropDown_xpath) == true)
                {
                    IWebElement dropdown = Driver.FindElement(LinksOR.oActionDropDown_xpath);
                    var selectElement = new SelectElement(dropdown);
                    IList<IWebElement> options = selectElement.Options;
                    for (int i = 0; i < options.Count; i++)
                    {
                        string sActualOption = options[i].Text.Trim();
                        if (ExpectedOption.Equals(sActualOption))
                        {
                            Report.UpdateTestLog("ValidateActionFinalStep", " Option '" + ExpectedOption+"' is present in Action dropdown", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateAction", " Option '" + ExpectedOption + "' is not present in Action dropdown",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateAction", " Action drop down field is not present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAction", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAction", " Error in method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectAction()
        // Method Decs: This Method select a Action from drop down field
        // Created on:  03/29/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void SelectAction()
        {
            try
            {
                string ExpectedOption = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                bool flag = false;
                if (common.CheckElement(LinksOR.oActionDropDown_xpath) == true)
                {
                    IWebElement dropdown = Driver.FindElement(LinksOR.oActionDropDown_xpath);
                    var selectElement = new SelectElement(dropdown);
                    IList<IWebElement> options = selectElement.Options;
                    for (int i = 0; i < options.Count; i++)
                    {
                        string sActualOption = options[i].Text.Trim();
                        if (ExpectedOption.Equals(sActualOption))
                        {
                            Report.UpdateTestLog("SelectAction", " Option '" + ExpectedOption + "' is present in Action dropdown", Status.PASS);
                            selectElement.SelectByValue(ExpectedOption);
                            Report.UpdateTestLog("SelectActionFinalStep", " Option '" + ExpectedOption + "' is selected from Action dropdown", Status.PASS);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("SelectAction", " Option '" + ExpectedOption + "' is not present in Action dropdown",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("SelectAction", " Action drop down field is not present ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectAction", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectAction", " Error in method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateActionAfterSave()
        // Method Decs: This Method validate the action field after edit
        // Created on:  03/29/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateActionAfterSave()
        {
            try
            {
                ReadOnlyCollection<IWebElement> SiteTitles = Driver.FindElements(LinksOR.oSiteTitles_xpath);
                ReadOnlyCollection<IWebElement> checkboxes = Driver.FindElements(LinksOR.oSelectLinks_xpath);
                string ExpectedSiteTitle = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();               
                for (int i = 0; i < SiteTitles.Count; i++)
                {
                    string ActualSiteTitle = SiteTitles[i].Text.Trim();
                    if (ExpectedSiteTitle.Equals(ActualSiteTitle))
                    {
                        checkboxes[i].Click();
                        Report.UpdateTestLog("ValidateActionAfterSave", " Selected Site Title row to edit ", Status.PASS);
                        common.CallMeWait(2000);
                        break;
                    }
                }
                EditItem();
                string ExpectedOption = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                bool flag = false;
                if (common.CheckElement(LinksOR.oActionDropDown_xpath) == true)
                {
                    IWebElement dropdown = Driver.FindElement(LinksOR.oActionDropDown_xpath);
                    var selectElement = new SelectElement(dropdown);
                    IList<IWebElement> options = selectElement.Options;
                    for (int i = 0; i < options.Count; i++)
                    {
                        string sActualOption = options[i].Text.Trim();
                        if (ExpectedOption.Equals(sActualOption))
                        {                           
                            if (options[i].GetAttribute("selected") == "true")
                            {
                                Report.UpdateTestLog("ValidateActionAfterSave", " Successfully validated that user is able to save item correctly & action colum is updated accordigly " , Status.PASS);
                                flag = true;
                                selectElement.SelectByValue("No Action");
                                Report.UpdateTestLog("ValidateActionAfterSaveFinalStep", " Successfully changed the Action value to the default value ", Status.PASS);
                                break;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        Report.UpdateTestLog("ValidateActionAfterSave", " User is not able to save item correctly & action colum is not updated accordigly ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
               
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateActionAfterSave", "Element not found " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateActionAfterSave", " Error in method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SaveSite()
        // Method Decs: This method save the site after editing the fields 
        // Created on:  03/29/2017
        // Created by:  GI offshore Team	
        //****************************************************

        public void SaveSite()
        {
            try
            {
                common.WaitForElement(SiteContentOR.oribbonsaveoption_xpath);
                if (common.CheckElement(SiteContentOR.oribbonsaveoption_xpath) == true)
                {
                    Driver.FindElement(SiteContentOR.oribbonsaveoption_xpath).Click();
                    Report.UpdateTestLog("SaveSiteFinalStep", "clicked on save", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SaveSite", "Unable to click save data",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

                common.CallMeWait(2000);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SaveSite", " Element not found : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SaveSite", " There is a problem in Method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //6th april
        //******************************************************
        // Method Name: ClickOnMegaMenu()
        // Method Decs: This method click on the Mega Menu option 
        // Created on:  04/06/2017
        // Created by:  GI offshore Team	
        //****************************************************
        public void ClickOnMegaMenu()
        {
            try
            {
                common.WaitForElement(LinksOR.omegamenu_Xpath);
                string Option = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                ReadOnlyCollection<IWebElement> magamenu = Driver.FindElements(LinksOR.omegamenu_Xpath);
                for (int i = 0; i < magamenu.Count(); i++)
                {
                    string s = magamenu[i].Text.Trim();
                    if (s.Contains(Option))
                    {
                        magamenu[i].Click();
                        Report.UpdateTestLog("ClickOnMegaMenuFinalStep", "Click on : " + s, Status.PASS);
                        common.CallMeWait(2000);
                        break;
                    }
 
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnMegaMenu", " Element not found : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnMegaMenu", " There is a problem in Method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
       
        //******************************************************
        // Method Name: IsArticleInJapanies()
        // Method Decs: This method verify share, Read More and Commect option in article in Japanies Language 
        // Created on:  04/06/2017
        // Created by:  GI offshore Team	
        //****************************************************

        public void IsArticleInJapanies()
        {
            try
            {
              common.WaitForElement(LinksOR.ojshare_xpath);
                ReadOnlyCollection<IWebElement> jshare = Driver.FindElements(LinksOR.ojshare_xpath);
                if (jshare.Count() > 0)
                {
                    Report.UpdateTestLog("IsArticleInJapanies", "share option is present in japanies  ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("IsArticleInJapanies", "share option is not present in japanies  ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.WaitForElement(LinksOR.ojcomment_xpath);
                ReadOnlyCollection<IWebElement> jcomment = Driver.FindElements(LinksOR.ojcomment_xpath);
                if (jcomment.Count() > 0)
                {
                    Report.UpdateTestLog("IsArticleInJapanies", "Comment option is present in japanies  ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("IsArticleInJapanies", "Comment option is not present in japanies ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                common.WaitForElement(LinksOR.oreadmore_xpath);
                ReadOnlyCollection<IWebElement> readmore = Driver.FindElements(LinksOR.oreadmore_xpath);
                if (readmore.Count() > 0)
                {
                    Report.UpdateTestLog("IsArticleInJapaniesFinalStep", "Read More option is present in japanies  ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("IsArticleInJapanies", "Reas More option is not present in japanies  ",Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("IsArticleInJapanies", " Element not found : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("IsArticleInJapanies", " There is a problem in Method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyPageURL()
        // Method Decs: This method verify current url of the page with data input 
        // Created on:  04/06/2017
        // Created by:  GI offshore Team	
        //****************************************************
        public void VerifyPageURL()
        {
            try
            {
                string url = DataTable.GetData("General_Data_" + Env, "NavigationURL").Trim();
               string curl=Driver.Url;
               if (curl.Contains(url))
               {
                   Report.UpdateTestLog("VerifyPageURLFinalStep", "Page URL is present is as : "+curl, Status.PASS);
               }
               else
               {
                   Report.UpdateTestLog("VerifyPageURL", "Navigate to URL:  " + curl,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
               }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPageURL", " Element not found : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPageURL", " There is a problem in Method : " + e,Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
       
        //12th april
        //******************************************************
        // Method Name: ForwardAndBackwardFeatureInNewSlide()
        // Method Decs: This method verify presence of farward and bachward feature of new slider on Home page
        // Created on:  12th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ForwardAndBackwardFeatureInNewSlide()
        {
            try
            {

                if (common.CheckElement(LinksOR.oprevslider_xpath) == true)
                {
                    Report.UpdateTestLog("ForwardAndBackwardFeatureInNewSlide", " Backward slider option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ForwardAndBackwardFeatureInNewSlide", " Backward slider option is not present ", Status.PASS);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                if (common.CheckElement(LinksOR.onextslider_xpath) == true)
                {
                    Report.UpdateTestLog("ForwardAndBackwardFeatureInNewSlideFinalStep", " Farward slider option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ForwardAndBackwardFeatureInNewSlide", " Farward slider option is not present ", Status.PASS);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ForwardAndBackwardFeatureInNewSlide", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ForwardAndBackwardFeatureInNewSlide", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickReadMoreOnSlider()
        // Method Decs: This method verify presence of Read More option on the Home page Slider and click on it.
        // Created on:  12th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ClickReadMoreOnSlider()
        {
            try
            {
                ReadOnlyCollection<IWebElement> readmorelinks = Driver.FindElements(LinksOR.oreadmoreslider_xpath);
               
                if(readmorelinks.Count()>0)
                {
                    Report.UpdateTestLog("ClickReadMoreOnSliderFinalStep", " Read More option is present ", Status.PASS);
                   
                }
                else
                {
                    Report.UpdateTestLog("ClickReadMoreOnSlider", "  Read More option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
              
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickReadMoreOnSlider", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickReadMoreOnSlider", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifySlidingFarwardFeature()
        // Method Decs: This method verify sliding feature of the slider on clicking next on the Home page.
        // Created on:  14th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifySlidingFarwardFeature()
        {
            try
            {

                if (common.CheckElement(LinksOR.onextslider_xpath) == true)
                {
                    Report.UpdateTestLog("VerifySlidingFarwardFeature", " Farward slider option is present ", Status.PASS);
                    Driver.FindElement(LinksOR.onextslider_xpath).Click();
                    Report.UpdateTestLog("VerifySlidingFarwardFeature", "clicked on next slide ", Status.DONE);
                    // common.CallMeWait(400);
                    string c1 = Driver.FindElement(LinksOR.oslidernumber_xpath).Text.Trim();
                    string s1 = c1.Substring(0, 1);

                    int count1 = Int32.Parse(s1);
                    if (count1 == 2)
                    {
                        Report.UpdateTestLog("VerifySlidingFarwardFeatureFinalStep", " farwarded to next slide ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySlidingFarwardFeature", "Unable to farward to next e ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifySlidingFarwardFeature", " Farward slider option is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySlidingFarwardFeature", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySlidingFarwardFeature", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifySlidingBackwardFeature()
        // Method Decs: This method verify sliding feature of the slider on clicking previous on the Home page.
        // Created on:  14th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifySlidingBackwardFeature()
        {
            try
            {
                // verify next slide after clicking next option;
                if (common.CheckElement(LinksOR.onextslider_xpath) == true)
                {
                    Report.UpdateTestLog("VerifySlidingFarwardFeature", " Farward slider option is present ", Status.PASS);
                    Driver.FindElement(LinksOR.onextslider_xpath).Click();
                    Report.UpdateTestLog("VerifySlidingFarwardFeature", "clicked on next slide ", Status.DONE);

                    string c1 = Driver.FindElement(LinksOR.oslidernumber_xpath).Text.Trim();
                    string s1 = c1.Substring(0, 1);

                    int count1 = Int32.Parse(s1);
                    if (count1 == 2)
                    {
                        Report.UpdateTestLog("VerifySlidingBackwardFeatureFinalStep", " farwarded to next slide ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySlidingBackwardFeature", "Unable to farward to next slide ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifySlidingBackwardFeature", "Previous option for slider is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // verify next slide after clicking next option;
                if (common.CheckElement(LinksOR.oprevslider_xpath) == true)
                {
                    Report.UpdateTestLog("VerifySlidingFarwardFeature", " Backward slider option is present ", Status.PASS);
                    Driver.FindElement(LinksOR.oprevslider_xpath).Click();
                    Report.UpdateTestLog("VerifySlidingFarwardFeature", "clicked on previous option ", Status.DONE);

                    string c2 = Driver.FindElement(LinksOR.oslidernumber_xpath).Text.Trim();
                    string s2 = c2.Substring(0, 1);

                    int count2 = Int32.Parse(s2);
                    if (count2 == 1)
                    {
                        Report.UpdateTestLog("VerifySlidingBackwardFeature", " Moved to previous slide ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifySlidingBackwardFeature", "Unable to move to previous slide ", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifySlidingBackwardFeature", "Previous option for slider is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySlidingBackwardFeature", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySlidingBackwardFeature", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: PresenceOfBlogPostsOptions()
        // Method Decs: This method verify all the option present under blog post drop down of Blog web part 
        // Created on:  14th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void PresenceOfBlogPostsOptions()
        {
            try
            {
                bool flag = false;
                string s = null;
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string[] blogdata = req3.Split(',');
                if (Driver.FindElement(LinksOR.oblogpost_id).Displayed)
                {
                    Report.UpdateTestLog("PresenceOfBlogPostsOptions", "Blog Spot Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(LinksOR.oblogpost_id));
                    IList<IWebElement> elmcount = oselect.Options;
                    for (int j = 0; j < blogdata.Length; j++)
                    {
                        for (int i = 0; i < elmcount.Count; i++)
                        {
                            s = elmcount[i].Text.Trim();
                            if (blogdata[j].Trim().Contains(s))
                            {
                                elmcount[i].Click();
                                Report.UpdateTestLog("PresenceOfBlogPostsOptionsFinalStep", "Present Blog Spot option is " + s, Status.PASS);
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("SelectCategoryInEditWebpartFinalStep", s + " blog option is not present ", Status.FAIL);
                        }
                    }


                }
                else
                {
                    Report.UpdateTestLog("PresenceOfBlogPostsOptions", "Blog post Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("PresenceOfBlogPostsOptions", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("PresenceOfBlogPostsOptions", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: PresenceOfBlogTimePeriodOptions()
        // Method Decs: This method verify all the option present under blog post drop down of Blog web part 
        // Created on:  14th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void PresenceOfBlogTimePeriodOptions()
        {
            try
            {
                bool flag = false;
                string s = null;
                string req3 = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string[] blogdata = req3.Split(',');
                if (Driver.FindElement(LinksOR.oblogtimeperiod_id).Displayed)
                {
                    Report.UpdateTestLog("PresenceOfBlogTimePeriodOptions", "Blog time period Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(LinksOR.oblogtimeperiod_id));
                    IList<IWebElement> elmcount = oselect.Options;
                    for (int j = 0; j < blogdata.Length; j++)
                    {
                        for (int i = 0; i < elmcount.Count; i++)
                        {
                            s = elmcount[i].Text.Trim();
                            if (blogdata[j].Trim().Contains(s))
                            {
                                elmcount[i].Click();
                                Report.UpdateTestLog("PresenceOfBlogTimePeriodOptionsFinalStep", "Present Blog time period option is " + s, Status.PASS);
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("PresenceOfBlogTimePeriodOptions", s + " blog time period option is not present ", Status.FAIL);
                        }
                    }


                }
                else
                {
                    Report.UpdateTestLog("PresenceOfBlogTimePeriodOptions", "Blog time period Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("PresenceOfBlogTimePeriodOptions", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("PresenceOfBlogTimePeriodOptions", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: PresenceOfBlogDisplayTypeOptions()
        // Method Decs: This method verify all the option present under blog display type of Blog web part 
        // Created on:  17th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void PresenceOfBlogDisplayTypeOptions()
        {
            try
            {
                bool flag = false;
                string s = null;
                string req4 = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                string[] blogdata = req4.Split(',');
                if (Driver.FindElement(LinksOR.oblogdisplaytype_id).Displayed)
                {
                    Report.UpdateTestLog("PresenceOfBlogDisplayTypeOptions", "Blog Display type drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(LinksOR.oblogdisplaytype_id));
                    IList<IWebElement> elmcount = oselect.Options;
                    for (int j = 0; j < blogdata.Length; j++)
                    {
                        for (int i = 0; i < elmcount.Count; i++)
                        {
                            s = elmcount[i].Text.Trim();
                            if (blogdata[j].Trim().Contains(s))
                            {
                                elmcount[i].Click();
                                Report.UpdateTestLog("PresenceOfBlogDisplayTypeOptionsFinalStep", "Present Blog display type option is " + s, Status.PASS);
                                flag = true;
                                break;
                            }
                        }
                        if (flag == false)
                        {
                            Report.UpdateTestLog("PresenceOfBlogDisplayTypeOptions", s + " blog display type option is not present ", Status.FAIL);
                        }
                    }


                }
                else
                {
                    Report.UpdateTestLog("PresenceOfBlogDisplayTypeOptions", "Blog display type Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("PresenceOfBlogDisplayTypeOptions", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("PresenceOfBlogDisplayTypeOptions", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //17th april
        //******************************************************
        // Method Name: PresenceOfBlogFilterOptions()
        // Method Decs: This method verify presence of blog filter option of Blog web part 
        // Created on:  17th Feb 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void PresenceOfBlogFilterOptions()
        {
            try
            {
                if (Driver.FindElement(LinksOR.oblogcategoryfilter_id).Displayed)
                {
                    Report.UpdateTestLog("PresenceOfBlogFilterOptions", "Blog filter option is present", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("PresenceOfBlogFilterOptions", "Blog filter option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("PresenceOfBlogFilterOptions", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("PresenceOfBlogFilterOptions", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyCommentOnFeaturedNews()
        // Method Decs: This method verify presence of Comment option on the Home page Slider.
        // Created on:  17th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyCommentOnFeaturedNews()
        {
            try
            {
                ReadOnlyCollection<IWebElement> readmorelinks = Driver.FindElements(LinksOR.onewsbannercomment_id);

                if (readmorelinks.Count() > 0)
                {

                    Report.UpdateTestLog("VerifyCommentOnFeaturedNewsFinalStep", " Comment option is present on Featured News", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("VerifyCommentOnFeaturedNews", "  Comment option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCommentOnFeaturedNews", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyCommentOnFeaturedNews", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyCommentOnNewscarousel()
        // Method Decs: This method verify presence of Comment option under News carousel on the Home page Slider.
        // Created on:  17th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyCommentOnNewscarousel()
        {
            try
            {


                ReadOnlyCollection<IWebElement> readmorelinks = Driver.FindElements(LinksOR.onewsbannercomment_id);

                if (readmorelinks.Count() > 0)
                {

                    Report.UpdateTestLog("VerifyCommentOnNewscarouselFinalStep", " Comment option on News Carousel is present on Featured News-carousel ", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("VerifyCommentOnNewscarousel", "  Comment option on News Carousel is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCommentOnNewscarousel", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyCommentOnNewscarousel", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickReadMoreOnCarousel()
        // Method Decs: This method verify presence of Read More option on the Home page News Caruosel and click on it.
        // Created on:  19th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void ClickReadMoreOnCarousel()
        {
            try
            {
                bool flag = false;
                ReadOnlyCollection<IWebElement> readmorelinks = Driver.FindElements(LinksOR.onewscarouselreadmore_xpath);

                if (readmorelinks.Count() > 0)
                {
                    Report.UpdateTestLog("ClickReadMoreOnCarousel", " Read More option is present on news Carousel ", Status.PASS);
                    for (int i = 0; i < readmorelinks.Count; i++)
                    {
                        if (readmorelinks[i].Text.Trim().Contains("READ MORE"))
                        {
                            flag = true;
                            readmorelinks[i].Click();
                            break;
                        }

                    }
                    if (flag == true)
                    {
                        Report.UpdateTestLog("ClickReadMoreOnCarouselFinalstep", "Read More option is clicked", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ClickReadMoreOnCarousel", "Unable to click on the Read More option on Carousel", Status.FAIL);
                    }


                }
                else
                {
                    Report.UpdateTestLog("ClickReadMoreOnCarousel", "Read More option is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickReadMoreOnCarousel", " Web Element not found :" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickReadMoreOnCarousel", " Problem in  Method: " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
       
    }
}
