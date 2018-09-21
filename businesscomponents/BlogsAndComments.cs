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
using System.Windows.Forms;

namespace CRAFT.BusinessComponents
{

    /// <summary>
    /// Business Component Library template

    /// </summary>
    public class BlogsAndComments : ReusableLibrary
    {
        string Env = ConfigurationManager.AppSettings["Environment"];
        private CommonComponents common;     
        /// <summary>
        /// Constructor to initialize the business component library
        /// </summary>
        /// <param name="scriptHelper"> The ScriptHelper object passed from the DriverScript</param>
        public BlogsAndComments(ScriptHelper scriptHelper)
            : base(scriptHelper)
        {
            common = new CommonComponents(ScriptHelper);
        }


        //******************************************************
        // Method Name: OpenFormToCreateBlog()
        // Method Decs: This method Click on the File >> New documnt>> blog  option under Site Content 
        // Created on:  19th April
        // Created by:  GI offshore Team		
        //****************************************************
        public void OpenFormToCreateBlog()
        {
            try
            {
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                Report.UpdateTestLog("OpenFormToCreateBlog", " Clicked on File option", Status.PASS);
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                Report.UpdateTestLog("OpenFormToCreateBlog", "Clicked on New Document option", Status.PASS);
                common.CallMeWait(1000);
                common.WaitForElement(BlogsAndCommentsOR.ocreatecbreintrablog_id);
                Driver.FindElement(BlogsAndCommentsOR.ocreatecbreintrablog_id).Click();
                Report.UpdateTestLog("OpenFormToCreateBlogFinalStep", "Clicked on CBRE Intranet blog option", Status.PASS);
                common.CallMeWait(1000);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("OpenFormToCreateBlog", "Unable to open blog form" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("OpenFormToCreateBlog", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyBlogFormPage()
        // Method Decs: This method verfy presence of field on the blog form page to create a blog 
        // Created on:   19th April
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyBlogFormPage()
        {
            try
            {
                //verify presence of page title
                if (common.CheckElement(BlogsAndCommentsOR.opagetitle_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Page title is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Page title is not  present ", Status.FAIL);
                }
                //verify presence of page Description
                if (common.CheckElement(BlogsAndCommentsOR.opagedesc_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Page Description field is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Page Description field is not  present ", Status.FAIL);
                }
                //verify presence of page url
                if (common.CheckElement(BlogsAndCommentsOR.opageurl_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Page url field is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Page url field is not  present ", Status.FAIL);
                }
                //verify presence of page layout
                if (common.CheckElement(BlogsAndCommentsOR.opagelayout_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Page layout field is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Page layout field is not  present ", Status.FAIL);
                }

                //verify presence of Create page option
                if (common.CheckElement(SiteContentOR.ocreatepage_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyBlogFormPageFinalStep", "Create page option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyBlogFormPage", "Create page option not  present ", Status.FAIL);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyBlogFormPage", "Unable to enter page title    " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyBlogFormPage", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SelectBlogPostsOptions()
        // Method Decs: This method select  the option present under blog post drop down of Blog web part 
        // Created on:  20th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void SelectBlogPostsOptions()
        {
            try
            {

                string req9 = DataTable.GetData("General_Data_" + Env, "RequestType9").Trim();

                if (Driver.FindElement(LinksOR.oblogpost_id).Displayed)
                {
                    Report.UpdateTestLog("SelectBlogPostsOptions", "Blog Spot Drop down is present", Status.PASS);
                    SelectElement oselect = new SelectElement(Driver.FindElement(LinksOR.oblogpost_id));
                    oselect.SelectByText(req9);
                    Report.UpdateTestLog("SelectBlogPostsOptionsFinalStep", req9 + " Blog Spot Drop option is selected", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("SelectBlogPostsOptions", "Blog post Drop down is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectBlogPostsOptions", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectBlogPostsOptions", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyActivityFeed()
        // Method Decs: This method verify that Activity Feed option is already selected on the My Dashboard page
        // Created on:  23rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyActivityFeed()
        {
            try
            {

                if (Driver.FindElement(BlogsAndCommentsOR.oactivityfeed_xpath).Displayed)
                {
                    string tabname = Driver.FindElement(BlogsAndCommentsOR.oactivityfeed_xpath).Text.Trim();
                    if (tabname.Contains("Activity Feed"))
                    {
                        Report.UpdateTestLog("VerifyActivityFeedFinalStep", "Activity Feed is selected by default My Dashboard page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyActivityFeed", "other tab is active and name is :" + tabname, Status.PASS);
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyActivityFeed", "Unable to find Activity Feed on My Dashboard page", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyActivityFeed", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyActivityFeed", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyAdministerCommentsTab()
        // Method Decs: This method verify that Administer Comments option  on the My Dashboard page
        // Created on:  23rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyAdministerCommentsTab()
        {
            try
            {

                if (Driver.FindElement(BlogsAndCommentsOR.oadmincomment_xpath).Displayed)
                {
                    string tabname = Driver.FindElement(BlogsAndCommentsOR.oadmincomment_xpath).Text.Trim();
                    if (tabname.Contains("Administer Comments"))
                    {
                        Report.UpdateTestLog("VerifyAdministerCommentsTabFinalStep", "Administer Comments is present My Dashboard page", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifyAdministerCommentsTab", "other tab is present and name is :" + tabname, Status.PASS);
                    }

                }
                else
                {
                    Report.UpdateTestLog("VerifyAdministerCommentsTab", "Unable to findAdminister Comments tab on My Dashboard page", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyAdministerCommentsTab", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyAdministerCommentsTab", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifySubTabOfActivityFeedTab()
        // Method Decs: This method verify that sun tab options under the Activity Feed tab on the My Dashboard page
        // Created on:  23rd April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifySubTabOfActivityFeedTab()
        {
            try
            {
                //verify Recent Activity Last 7 Days tab
                if (Driver.FindElement(BlogsAndCommentsOR.orescentactivity_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", "Recent Activity Last 7 Days tab under Activity Feed tab on My Dashboard page is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", "Recent Activity Last 7 Days tab under Activity Feed tab on My Dashboard page is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify My Articles by Article Date 
                if (Driver.FindElement(BlogsAndCommentsOR.omyarticla_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", "My Articles by Article Date  tab under Activity Feed tab on My Dashboard page is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", "My Articles by Article Date  tab under Activity Feed tab on My Dashboard page is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Today tab
                ReadOnlyCollection<IWebElement> elm = Driver.FindElements(BlogsAndCommentsOR.otoday_xpath);
                if (elm.Count > 0)
                {
                    Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", "Today tab under Activity Feed tab on My Dashboard page is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", "Today tab under Activity Feed tab on My Dashboard page is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Yesterday
                ReadOnlyCollection<IWebElement> elm2 = Driver.FindElements(BlogsAndCommentsOR.oyesterday_xpath);
                if (elm2.Count > 0)
                {
                    Report.UpdateTestLog("VerifySubTabOfActivityFeedTabFinalStep", "Yesterday tab under Activity Feed tab on My Dashboard page is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", "Yesterday Feed tab under Activity Feed tab on My Dashboard page is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: HoverOverAnArticle()
        // Method Decs: This method find the article under My Articles by Article Date on the My Dashboard page and hover the first one 
        // Created on:  24th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void HoverOverAnArticle()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(BlogsAndCommentsOR.omostlikearticle_xpath);
                //int iCount = elms.Count;
                if (elms.Count > 0)
                {
                    //Report.UpdateTestLog("HoverOverAnArticle", iCount + " article is present under  My Articles by Article Date on the My Dashboard page ", Status.PASS);
                    Actions action = new Actions(Driver);
                    action.MoveToElement(elms[0]);
                    action.Perform();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("HoverOverAnArticleFinalStep",  " First Articel is hovered ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("HoverOverAnArticle", "No article is present under  My Articles by Article Date on the My Dashboard page ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("HoverOverAnArticle", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("HoverOverAnArticle", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyArticleDetail()
        // Method Decs: This method verify detail of aricle under under My Articles by Article Date on the My Dashboard page
        // Created on:  24th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyArticleDetail()
        {
            try
            {
                //verify Edit Article option
                if (Driver.FindElement(BlogsAndCommentsOR.oeditarticle_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Edit Article option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Edit Article option is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Article Date option
                if (Driver.FindElement(BlogsAndCommentsOR.oarticledate_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Article Date option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Article Date option is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify View Article option
                if (Driver.FindElement(BlogsAndCommentsOR.oviewaticle_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "View Article option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "View Article option is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Article Type option
                if (Driver.FindElement(BlogsAndCommentsOR.oarticletype_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Article Type option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Article Type option is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Creator option
                if (Driver.FindElement(BlogsAndCommentsOR.ocreator_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Creator option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Creator option is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Edit Article option
                if (Driver.FindElement(BlogsAndCommentsOR.olastmodified_xpath).Displayed)
                {
                    Report.UpdateTestLog("VerifyArticleDetailFinalStep", "Edit Article option is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyArticleDetail", "Last Modified Date option is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifySubTabOfActivityFeedTab", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyCommentsFeed()
        // Method Decs: This method verify data  under FEED of Recent Activity Last 7 Days on the My Dashboard page  
        // Created on:  24th April 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void VerifyCommentsFeed()
        {
            try
            {

                if (Driver.FindElement(BlogsAndCommentsOR.onewsfeedupdate_xpath).Displayed)
                {

                    Report.UpdateTestLog("VerifyCommentsFeedFinalStep", "Like and Comment feed are present  ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyCommentsFeed", "Like and Comment feed are not present  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCommentsFeed", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyCommentsFeed", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //**********************************************
        // Method ValidateAdministerCommentsTabVisibility()
        // Method Description : This method will Validate Administer comments tab visibility on My Dashboard page
        // Created On: 04/24/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateAdministerCommentsTabVisibilityAsVisitor()
        {
            try
            {
                IWebElement elm = Driver.FindElement(MyDashboardOR.oAdministerComments_xpath);
                if (elm.Displayed)
                {
                    Report.UpdateTestLog("ValidateAdministerCommentsTabVisibilityAsVisitorFinalStep",
                        "  Administer Comments tab is present on My Dashboard page", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("ValidateAdministerCommentsTabVisibilityAsVisitor",
                          "Successfully validated that Administer comments tab is not present on My Dashboard page ", Status.PASS);

                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateAdministerCommentsTabVisibilityAsVisitor", "Element not found" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateAdministerCommentsTabVisibilityAsVisitor", "Error in method" + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateRecentActivity()
        // Method Description : This method validates the recent activity section
        // Created On: 04/25/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateRecentActivity()
        {
            try
            {
                if (common.CheckElement(BlogsAndCommentsOR.oRecentActivity7Days_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateRecentActivityFinalStep", " Recent activity in last 7 days field is present in My Dashboard Activity feed", Status.PASS);  
                }
                else
                {
                    Report.UpdateTestLog("ValidateRecentActivity", " Recent activity in last 7 days field is not present in My Dashboard Activity feed", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateRecentActivity", "Element not found" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateRecentActivity", "Error in method" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateComment()
        // Method Decs: This method will validate comment functionality in Blog
        // Created on: 04/25/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateComment()
        {
            try
            {

                string comment = Driver.FindElement(SiteContentOR.oBlogCommentCount_XPath).Text.Trim();
                if (comment.Contains("0"))
                {
                    Report.UpdateTestLog("ValidateComment", " Comment Count is 0", Status.PASS);
                }
                if (common.CheckElement(SiteContentOR.oBlogCommentArea_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogCommentArea_XPath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ValidateComment", " Clicked on comment Area ", Status.DONE);
                    Driver.FindElement(SiteContentOR.oBlogCommentArea_XPath).SendKeys("Test Comment");
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ValidateComment", " Entered comment on comment Area ", Status.DONE);
                    Driver.FindElement(SiteContentOR.oBlogPostCommentButton_XPath).Click();
                    Report.UpdateTestLog("ValidateComment", " Clicked on Post Comment button ", Status.DONE);
                    common.CallMeWait(1000);
                    comment = Driver.FindElement(SiteContentOR.oBlogCommentCount_XPath).Text.Trim();
                    if (comment.Contains("1"))
                    {
                        Report.UpdateTestLog("ValidateCommentFinalStep", " Successfully validated that after entering comment, count is increased", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateComment", " After entering comment, count is not increased", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateComment", " Comment section is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateComment", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateComment", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ValidateLikeIncrease()
        // Method Decs: This method will validate like is increaded after click it
        // Created on: 04/25/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateLikeIncrease()
        {
            try
            {
                string like = Driver.FindElement(SiteContentOR.oBlogLikeCount_XPath).Text.Trim();
                if (like.Contains("0"))
                {
                    Report.UpdateTestLog("ValidateLikeIncrease", " Like Count is 0", Status.PASS);
                }
                if (common.CheckElement(SiteContentOR.oBlogLike_XPath) == true)
                {
                    Driver.FindElement(SiteContentOR.oBlogLike_XPath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ValidateLikeIncrease", " Clicked on Like button", Status.DONE);
                    like = Driver.FindElement(SiteContentOR.oBlogLikeCount_XPath).Text.Trim();
                    if (like.Contains("1"))
                    {
                        Report.UpdateTestLog("ValidateLikeIncreaseFinalStep", " Successfully validated that after clicking on the like button like count is increased", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateLikeIncrease", " After clicking on the like button like count is not increased", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateLikeIncrease", " Like button is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLikeIncrease", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLikeIncrease", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateArticleCount()
        // Method Decs: This method will validate articles count in Article section Activity feed page
        // Created on: 04/26/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateArticleCount()
        {
            try
            {
                if (common.CheckElement(BlogsAndCommentsOR.oArticleLikeCounts_xpath) == true)
                {
                    ReadOnlyCollection<IWebElement> ArticleCounts = Driver.FindElements(BlogsAndCommentsOR.oArticleLikeCounts_xpath);
                    int iCount = ArticleCounts.Count;
                    if (iCount <= 10)
                    {
                        Report.UpdateTestLog("ValidateArticleCountFinalStep", " Widget shows upto 10 articles in activity page, Total article number : " + iCount, Status.PASS);                       
                    }
                    else
                    {
                        Report.UpdateTestLog("ValidateArticleCount", " Widget doesn't show upto 10 articles in activity page, Total article number : "+ iCount, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ValidateArticleCount", " No Article is present in Article section", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateArticleCount", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateArticleCount", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateArticleSortOrder()
        // Method Description : This method will Validate the sort in descending order of articles
        // Created On: 04/26/2017
        // Created By: GI offShore Team
        // *****************************************
        public void ValidateArticleSortOrder()
        {
            try
            {
                List<int> data1 = new List<int>();
                List<int> data2 = new List<int>();
                ReadOnlyCollection<IWebElement> ArticleCounts = Driver.FindElements(BlogsAndCommentsOR.oArticleLikeCounts_xpath);
                for (int i = 0; i < ArticleCounts.Count; i++)
                {
                    IWebElement elm2 = ArticleCounts[i];
                    string scount = elm2.Text.Trim();
                    //string scount = elm2.Text.Trim();
                    int iCount = Int32.Parse(scount);
                    data1.Add(iCount);
                    data2.Add(iCount);
                }
                bool flag = true;
                data2.Sort((a, b) => -1 * a.CompareTo(b));
                for (int i = 0; i < data1.Count; i++)
                {
                    if (!data1[i].Equals(data2[i]))
                    {
                        flag = false;
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ValidateArticleSortOrder", " Articles like count are not sorted in descending order", Status.FAIL); 
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                else
                {
                    Report.UpdateTestLog("ValidateArticleSortOrderFinalStep", " Articles like count are sorted in descending order", Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateArticleSortOrder", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateArticleSortOrder", "Error in method" + e, Status.FAIL); 
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //**********************************************
        // Method ValidateShowMore()
        // Method Description : This method will Validate show more button in Article section
        // Created On: 04/26/2017
        // Created By: GI offShore Team
        // *****************************************

        public void ValidateShowMore()
        {
            try
            {
                ReadOnlyCollection<IWebElement> ArticleCounts = Driver.FindElements(BlogsAndCommentsOR.oArticleLikeCounts_xpath);
                int iCount = ArticleCounts.Count;
                if (common.CheckElement(BlogsAndCommentsOR.oArticleShowMore_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateShowMoreFinalStep", " Show More button is present in Article section", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateShowMore", " Show More button is not present, Total Article count: " + iCount, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateShowMore", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateShowMore", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EnterComment()
        // Method Decs: This method add comment on the new detail article page
        // Created on: 04/26/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void EnterComment()
        {
            try
            {
                string req1 = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                if (common.CheckElement(BlogsAndCommentsOR.ocommenttextarea_xpath))
                {
                    Report.UpdateTestLog("EnterComment", "comment text area is present", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.ocommenttextarea_xpath).SendKeys(req1);
                    Report.UpdateTestLog("EnterCommentFinalStep", "comment is entered as : " + req1, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterComment", "Unable to find commrnt text area", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterComment", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterComment", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickPostCommentButton()
        // Method Decs: This method click on Post Comment button on the new detail article page
        // Created on: 04/26/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void ClickPostCommentButton()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.opostcomment_xpath))
                {
                    Report.UpdateTestLog("ClickPostCommentButtonFinalStep", "Clicked on Post Comment button", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.opostcomment_xpath).Click();
                    common.CallMeWait(2000);
                }
                else
                {
                    Report.UpdateTestLog("ClickPostCommentButton", "Unable to Clicked on Post Comment button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickPostCommentButton", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickPostCommentButton", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnLikeAndVerify()
        // Method Decs: This method click on like option on the new detail article page and verify like increment
        // Created on: 04/26/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void ClickOnLikeAndVerify()
        {
            try
            {
                string prelikecount = Driver.FindElement(BlogsAndCommentsOR.olikecount_xpath).Text.Trim();
                int prelikecountint = Int32.Parse(prelikecount);
                if (common.CheckElement(BlogsAndCommentsOR.olikethumb_xpath))
                {
                    Report.UpdateTestLog("ClickOnLikeAndVerify", "Like option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.olikethumb_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClickOnLikeAndVerify", "Like option is clicked ", Status.PASS);
                    string postlikecount = Driver.FindElement(BlogsAndCommentsOR.olikecount_xpath).Text.Trim();
                    int postlikecountint = Int32.Parse(postlikecount);

                    if (postlikecountint > prelikecountint)
                    {
                        Report.UpdateTestLog("ClickOnLikeAndVerifyFinalStep", "like count is increased", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ClickOnLikeAndVerify", "like count is not increased", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ClickOnLikeAndVerify", " Article is already liked ", Status.FAIL);
                    //CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }              
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnLikeAndVerify", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnLikeAndVerify", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickOnDisLikeAndVerify()
        // Method Decs: This method click on like option on the new detail article page and verify like increment
        // Created on: 04/26/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void ClickOnDisLikeAndVerify()
        {
            try
            {
                string predislikecount = Driver.FindElement(BlogsAndCommentsOR.olikecount_xpath).Text.Trim();
                int predislikecountint = Int32.Parse(predislikecount);
                if (common.CheckElement(BlogsAndCommentsOR.odislikethumb_xpath))
                {
                    Report.UpdateTestLog("ClickOnDisLikeAndVerify", "Dislike option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.odislikethumb_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClickOnDisLikeAndVerify", "Dislike option is clicked ", Status.PASS);
                    string postdislikecount = Driver.FindElement(BlogsAndCommentsOR.olikecount_xpath).Text.Trim();
                    int postdislikecountint = Int32.Parse(postdislikecount);

                    if (postdislikecountint < predislikecountint)
                    {
                        Report.UpdateTestLog("ClickOnDisLikeAndVerifyFinalStep", "like count is decreased", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("ClickOnDisLikeAndVerify", "like count is not decreased", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                else
                {
                    Report.UpdateTestLog("ClickOnDisLikeAndVerify", " Article is not liked so unable to dislike ", Status.FAIL);
                    //CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnDisLikeAndVerify", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnDisLikeAndVerify", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: DeleteAComment()
        // Method Decs: This method delete a comment on the News Detail page in case there are more then one then it  deletes first one
        // Created on: 04/26/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void DeleteAComment()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(BlogsAndCommentsOR.odeletecomment_xpath);
                if (elms.Count >= 1)
                {
                    Report.UpdateTestLog("DeleteAComment", "Delete  button is found", Status.PASS);
                    elms[0].Click();
                    common.CallMeWait(1000);
                    ReadOnlyCollection<IWebElement> yesno = Driver.FindElements(BlogsAndCommentsOR.odeletepopup_xpath);
                    yesno[0].Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("DeleteACommentFinalStep", "Comment is deleted", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("DeleteAComment", "Unable to find Delete button", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteAComment", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteAComment", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: CommentCount()
        // Method Decs: This method count comment on the new detail page
        // Created on: 04/26/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void CommentCount()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.ocomment_xpath))
                {
                    string commentcount = Driver.FindElement(BlogsAndCommentsOR.ocomment_xpath).Text.Trim();
                    string[] count = commentcount.Split(' ');
                    int commentcountint = Int32.Parse(count[0]);
                    Report.UpdateTestLog("CommentCountFinalStep", "Comment count is " + commentcountint, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("CommentCount", "Unable to find Comment Count", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CommentCount", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CommentCount", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateLikeCommentCount()
        // Method Decs: This method validates articles like comment count beside article title
        // Created on: 04/27/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateLikeCommentCount()
        {
            try
            {
                if (common.CheckElement(BlogsAndCommentsOR.oArticleLikeCounts_xpath) == true)
                {
                    Report.UpdateTestLog("ValidateLikeCommentCountFinalStep", " like/comment count is present beside artile title ", Status.PASS); 
                }
                else
                {
                    Report.UpdateTestLog("ValidateLikeCommentCount", " like/comment count is not present beside artile title ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLikeCommentCount", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLikeCommentCount", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateCommentCountAfterDelete()
        // Method Decs: This method validates comment count decreases after delete a comment
        // Created on: 04/27/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateCommentCountAfterDelete()
        {
            try
            {
                int iCommentCountBefore=0;
                int iCommentCountAfter=0;
                if (common.CheckElement(BlogsAndCommentsOR.ocomment_xpath))
                {
                    string commentcount = Driver.FindElement(BlogsAndCommentsOR.ocomment_xpath).Text.Trim();
                    string[] count = commentcount.Split(' ');
                    iCommentCountBefore = Int32.Parse(count[0]);                  
                }
                else
                {
                    Report.UpdateTestLog("CommentCount", "Unable to find Comment Count", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                DeleteAComment();
                string commentcountafter = Driver.FindElement(BlogsAndCommentsOR.ocomment_xpath).Text.Trim();
                string[] count1 = commentcountafter.Split(' ');
                iCommentCountAfter = Int32.Parse(count1[0]);
                if(iCommentCountAfter<iCommentCountBefore)
                {
                    Report.UpdateTestLog("ValidateCommentCountAfterDeleteFinalStep", " Comment count decreased after delete comment, Before delete comment count was : " + iCommentCountBefore + ", After delete comment count : " + iCommentCountAfter , Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentCountAfterDelete", " Comment count not decreased after delete comment, Before delete comment count was : " + iCommentCountBefore + ", After delete comment count : " + iCommentCountAfter, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCommentCountAfterDelete", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCommentCountAfterDelete", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateCommentDeleted()
        // Method Decs: This method validates comment is not available after deletion
        // Created on: 04/28/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateCommentDeleted()
        {
            try
            {
                bool flag = true;
                string sExpectedComment = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                ReadOnlyCollection<IWebElement> comments = Driver.FindElements(BlogsAndCommentsOR.oArticleComments_xpath);
                for (int i = 0; i < comments.Count; i++)
                {
                    string sActualComment = comments[i].Text.Trim();
                    if (sActualComment.Contains(sExpectedComment))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                {
                    Report.UpdateTestLog("ValidateCommentDeletedFinalStep", " User is not able to view the deleted comment", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentDeleted", " User is able to view the deleted comment", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCommentDeleted", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCommentDeleted", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateCommentDisplay()
        // Method Decs: This method validates recent comment coming on top
        // Created on: 04/28/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateCommentDisplay()
        {
            try
            {
                string sExpectedComment = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();
                ReadOnlyCollection<IWebElement> comments = Driver.FindElements(BlogsAndCommentsOR.oArticleComments_xpath);
                string sActualComment = comments[0].Text.Trim();
                if (sActualComment.Contains(sExpectedComment))
                {
                    Report.UpdateTestLog("ValidateCommentDisplayFinalStep", " Most recent comment displays on top", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateCommentDisplay", " Most recent comment doesn't display on top", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateCommentDisplay", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateCommentDisplay", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ValidateSiteHighlighted()
        // Method Decs: This Method validated the selected site gets highlighted
        // Created on:  04/28/2017
        // Created by:  GI offshore Team		
        //****************************************************

        public void ValidateSiteHighlighted()
        {
            try
            {
                ReadOnlyCollection<IWebElement> SiteTitles = Driver.FindElements(LinksOR.oSiteTitles_xpath);
                ReadOnlyCollection<IWebElement> Rows = Driver.FindElements(LinksOR.oProvisionSiteRows_xpath);
                string ExpectedSiteTitle = DataTable.GetData("General_Data_" + Env, "RequestType2").Trim();
                bool flag = false;
                for (int i = 0; i < SiteTitles.Count; i++)
                {
                    string ActualSiteTitle = SiteTitles[i].Text.Trim();
                    if (ActualSiteTitle.Contains(ExpectedSiteTitle))
                    {
                        if (Rows[i].GetAttribute("class").Contains("selected"))
                        {
                            Report.UpdateTestLog("ValidateSiteHighlightedFinalStep", " Selected Provision site is highlighted ", Status.PASS);
                            flag = true;                          
                            break;
                        }
                    }
                }
                if (flag == false)
                {
                    Report.UpdateTestLog("ValidateSiteHighlighted", "Selected Provision site is not highlighted ", Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateSiteHighlighted", "Element not found " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateSiteHighlighted", " Error in method : " + e, Status.FAIL); CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: CountLike()
        // Method Decs: This method count like on the new detail page
        // Created on: 04/27/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void CountLike()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.olikecount_xpath))
                {
                    string likecount = Driver.FindElement(BlogsAndCommentsOR.olikecount_xpath).Text.Trim();
                    int likecountint = Int32.Parse(likecount);
                    Report.UpdateTestLog("CommentCountFinalStep", "like count is " + likecountint, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("CommentCount", "Unable to find like Count", Status.FAIL);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CommentCount", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CommentCount", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //28th april 
        //******************************************************
        // Method Name: VerifyIncreamentDecrementOfComment()
        // Method Decs: This method count increment and decrement of Comment
        // Created on: 04/28/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyIncreamentDecrementOfComment()
        {
            CommentCount();
            EnterComment();
            ClickPostCommentButton();
            CommentCount();
            DeleteAComment();
            CommentCount();

        }

        //******************************************************
        // Method Name: SelectAtabPageOnSearchResultPage()
        // Method Decs: This method select a page on the search result page after a search is performed
        // Created on: 05/03/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void SelectAtabPageOnSearchResultPage()
        {
            try
            {
                string tabname = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                string dpath = "//a[contains(@title,'" + tabname + "')]";
                ReadOnlyCollection<IWebElement> tabnameall = Driver.FindElements(By.XPath(dpath));
                if (tabnameall.Count > 0)
                {
                    for (int i = 0; i < tabnameall.Count; i++)
                    {
                        if (tabnameall[i].Text.Trim().Contains(tabname))
                        {
                            tabnameall[i].Click();
                            common.CallMeWait(1000);
                            Report.UpdateTestLog("SelectAtabPageOnSearchResultPageFinalStep", tabname + " is clicked ", Status.DONE);
                        }

                    }
                }
                else
                {
                    Report.UpdateTestLog("SelectAtabPageOnSearchResultPage", tabname + " is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectAtabPageOnSearchResultPage", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectAtabPageOnSearchResultPage", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: SetTomorrowEvent()
        // Method Decs: This method selects Tomorrow date for the event
        // Created on: 4th May 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void SetTomorrowEvent()
        {
            try
            {
                string finalstring = null;
                DateTime today = DateTime.Today.AddDays(+1);
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
                    Report.UpdateTestLog("SetTomorrowEventFinalStep", "Clicked on Add option", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SetTomorrowEvent", "Add Option is not displayed", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SetTomorrowEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SetTomorrowEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: EnterTomorrowDetailsforEvent()
        // Method Decs: This method enters detail for the event like Title , tomorrow date, description etc.
        // Created on: 4th May 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void EnterTomorrowDetailsforEvent()
        {
            try
            {
                DateTime tomorrow = DateTime.Today.AddDays(+1);
                string tomorrowdate = tomorrow.ToString().Split(' ')[0];
                string enevttitle = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                string enevtdesc = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                ReadOnlyCollection<IWebElement> framecoll1 = Driver.FindElements(By.XPath("//iframe[contains(@id, 'DlgFrame')]"));
                Driver.SwitchTo().Frame(framecoll1[0]);

                common.WaitForElement(SiteContentOR.oeventtitle_xpath);
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).Click();
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventtitle_xpath).SendKeys(enevttitle);
                Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "Title is entered :" + enevttitle, Status.DONE);

                common.WaitForElement(SiteContentOR.oeventstartdate_xpath);
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).Click();
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventstartdate_xpath).SendKeys(tomorrowdate);
                Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "start date entered " + tomorrowdate, Status.DONE);

                common.WaitForElement(SiteContentOR.oeventenddate_xpath);
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).Clear();
                Driver.FindElement(SiteContentOR.oeventenddate_xpath).SendKeys(tomorrowdate);
                Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "End Date Entered" + tomorrowdate, Status.DONE);

                common.WaitForElement(SiteContentOR.ocalenderdesc_xpath);
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).Click();
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).Clear();
                Driver.FindElement(SiteContentOR.ocalenderdesc_xpath).SendKeys(enevtdesc);
                Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "Description entered" + enevtdesc, Status.PASS);

                string req5 = DataTable.GetData("General_Data_" + Env, "RequestType5").Trim();
                if (req5.Any())
                {
                    try
                    {
                        common.WaitForElement(SiteContentOR.oeventcategory_xpath);
                        Driver.FindElement(SiteContentOR.oeventcategory_xpath).Click();
                        Driver.FindElement(SiteContentOR.oeventcategory_xpath).SendKeys(req5);
                        Report.UpdateTestLog("EnterTomorrowDetailsforEventFinalStep", "Entered event category :" + req5, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "unable to enter categary", Status.FAIL);
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
                        Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "Entered event primery services :" + req2, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "unable to enter primery services", Status.FAIL);
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
                        Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "Entered event picture :" + req3, Status.PASS);
                    }
                    catch (NoSuchElementException)
                    {
                        Report.UpdateTestLog("EnterTomorrowDetailsforEvent", "unable to enter picture", Status.FAIL);
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
                Report.UpdateTestLog("EnterTomorrowDetailsforEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyMonthViewOfCalender()
        // Method Decs: This method make a conunt of month in the calender and it should be 12 to validate month view
        // Created on: 4th May 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyMonthViewOfCalender()
        {
            try
            {
                ReadOnlyCollection<IWebElement> slectedmonth = Driver.FindElements(BlogsAndCommentsOR.oselectedmonth_xpath);
                ReadOnlyCollection<IWebElement> remainingmonths = Driver.FindElements(BlogsAndCommentsOR.omonths_xpath);
                int totalmonth = slectedmonth.Count + remainingmonths.Count;
                if (totalmonth == 12)
                {
                    Report.UpdateTestLog("VerifyMonthViewOfCalenderFinlaStep", "Calender Month View is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMonthViewOfCalender", "Calender Month View is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyMonthViewOfCalender", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyMonthViewOfCalender", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: IsCalenderViewEditable()
        // Method Decs: This method verify that calender view in noe editaable
        // Created on: 4th May 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void IsCalenderViewEditable()
        {
            try
            {
                ReadOnlyCollection<IWebElement> slectedmonth = Driver.FindElements(BlogsAndCommentsOR.oselectedmonth_xpath);
                ReadOnlyCollection<IWebElement> remainingmonths = Driver.FindElements(BlogsAndCommentsOR.omonths_xpath);
                int totalmonth = slectedmonth.Count + remainingmonths.Count;
                if (totalmonth == 12)
                {
                    Report.UpdateTestLog("IsCalenderViewEditableFinlaStep", "Calender Month View is not editable ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("IsCalenderViewEditable", "Calender Month View is editable ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("IsCalenderViewEditable", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("IsCalenderViewEditable", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyCalenderWeekDays()
        // Method Decs: This method verify the week days name and order on the Calender
        // Created on: 4th May 2017
        // Created By: GI offShore Team		
        //****************************************************
        public void VerifyCalenderWeekDays()
        {
            try
            {
                ReadOnlyCollection<IWebElement> slectedmonth = Driver.FindElements(BlogsAndCommentsOR.oweekdays_xpath);
                string[] weekdays = new string[] { "SUNDAY", "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY" };
                bool flag = true;
                for (int i = 0; i < slectedmonth.Count; i++)
                {
                    if (slectedmonth[i].Text.Trim().Contains(weekdays[i]) && flag == true)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }

                }
                if (flag == true)
                {
                    Report.UpdateTestLog("VerifyCalenderWeekDaysFinalStep", "Calender Days are present from sunday to saturday ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyCalenderWeekDays", "Calender Days are not present from sunday to saturday  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyCalenderWeekDays", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyCalenderWeekDays", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifytomorrowEventaftercreation()
        // Method Decs: This method verify tomorrow  created event on the page
        // Created on:  5th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifytomorrowEventaftercreation()
        {
            try
            {
                string eventname = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                string path = "//*[text()='" + eventname + "']";
                try
                {
                    if (Driver.FindElement(By.XPath(path)).Displayed)
                    {
                        Report.UpdateTestLog("VerifytomorrowEventaftercreationFinalStep", "Event is present ", Status.PASS);
                    }
                    else
                    {
                        Report.UpdateTestLog("VerifytomorrowEventaftercreation", "Event is not present : " + eventname, Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                }
                catch (Exception)
                {
                    Report.UpdateTestLog("VerifytomorrowEventaftercreation", "Event is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifytomorrowEventaftercreation", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifytomorrowEventaftercreation", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }
        //******************************************************
        // Method Name: FindTomorrowEvent()
        // Method Decs: This method find the event with name
        // Created on:   5th May	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void FindTomorrowEvent()
        {
            try
            {
                string eventname = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                string path = "//*[text()=\"" + eventname + "\"]";
                common.WaitForElement(By.XPath(path));
                if (Driver.FindElement(By.XPath(path)).Displayed)
                {
                    Driver.FindElement(By.XPath(path)).Click();
                    Report.UpdateTestLog("FindTomorrowEventFinalStep", "Event is found and clicked " + eventname, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("FindTomorrowEvent", "Unable to find Event : " + eventname, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("FindTomorrowEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindTomorrowEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyNoResult()
        // Method Decs: This method verify in case no result is found on the search result page
        // Created on:   8th May	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyNoResult()
        {
            try
            {
                if (common.CheckElement(BlogsAndCommentsOR.onoresult_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyNoResultFinalStep", "No Result is found", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyNoResult", "Unable to validate no result found ", Status.FAIL);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyNoResult", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyNoResult", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //9th may 
        //******************************************************
        // Method Name: IsClearRefienerPresent()
        // Method Decs: This method verify the presence of Clear All refiner  on the search result page
        // Created on:   9th May	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void IsClearRefienerPresent()
        {
            try
            {
                if (common.CheckElement(BlogsAndCommentsOR.oclearrefiner_xpath) == true)
                {
                    Report.UpdateTestLog("IsClearRefienerPresentFinalStep", "Clear refiner option is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("IsClearRefienerPresent", "Clear refiner option is not present ", Status.FAIL);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("IsClearRefienerPresent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("IsClearRefienerPresent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: CurrentresultCount()
        // Method Decs: This method returns the result count on the search result page
        // Created on:   9th May	
        // Created by:  GI offshore Team	
        //****************************************************  
        public int CurrentresultCount()
        {
            int cc = 0;
            try
            {
                    string s = null;
             
                    string c = Driver.FindElement(BlogsAndCommentsOR.oresultcount_xpath).Text.Trim();
                    string[] count = c.Split(' ');
                    if (count[0].Contains("About"))
                    {
                        s = count[1];
                    }
                    else
                    {
                        s = count[0];
                    }
                    if (s.Contains(","))
                    {
                        s = s.Replace(",", "");
                    }
                    
                  cc = Int32.Parse(s);
                 
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("CurrentresultCount", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("CurrentresultCount", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            
            return cc;
           
        }
        //******************************************************
        // Method Name: VerifyClearAlloptionFunctionality()
        // Method Decs: This method click on the  Clear All option and verify that refiner are cleared  on the search result page
        // Created on:   9th May	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyClearAlloptionFunctionality()
        {
            try
            {
                if (common.CheckElement(BlogsAndCommentsOR.oclearrefiner_xpath) == true)
                {
                    int precount =CurrentresultCount();
                    Report.UpdateTestLog("IsClearRefienerPresentFinalStep", "Clear refiner option is present", Status.DONE);
                    Driver.FindElement(BlogsAndCommentsOR.oclearrefiner_xpath).Click();
                    Report.UpdateTestLog("IsClearRefienerPresentFinalStep", "Clear refiner option is clicked", Status.DONE);
                    int postcount =CurrentresultCount();
                    common.CallMeWait(1000);
                    if (postcount >= precount)
                    {
                        Report.UpdateTestLog("IsClearRefienerPresentFinalStep", "Filter is cleared", Status.PASS);
                    }
                }
                else
                {
                    Report.UpdateTestLog("IsClearRefienerPresent", "Clear refiner option is not present ", Status.FAIL);
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("IsClearRefienerPresent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("IsClearRefienerPresent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        // ******************************************************
        // Method Name: VerifySearchResult()
        // Method Description: verify presence of result page and its result count.
        // Created on 05/10/2017
        // Created By: GI offShore Team
        // ****************************************************
        public void VerifySearchResult()
        {

            try
            {
                int resultcount = CurrentresultCount();
                if (resultcount > 0)
                {
                    Report.UpdateTestLog("VerifySearchResultFinalStep", " Total matched with search string" + resultcount, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifySearchResult", " No result matched", Status.PASS);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifySearchResult",
                        " Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception)
            {
                Report.UpdateTestLog("VerifySearchResult",
                        " Error in method", Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }

        }

        //******************************************************
        // Method Name: ClickOnFirstSearchResult()
        // Method Decs: this method click on the header of the first item in the search result
        // Created on: 05/10/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickOnFirstSearchResult()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(BlogsAndCommentsOR.resultrow_xpath);
                if (elms.Count > 0)
                {
                    Report.UpdateTestLog("ClickOnFirstSearchResult", " Search result displayed", Status.DONE);
                    elms[1].Click();
                    Report.UpdateTestLog("ClickOnFirstSearchResultFinalStep", " Clicked on first result", Status.DONE);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnFirstSearchResult", "Unable to display search result", Status.FAIL);
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnFirstSearchResult", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;

            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnFirstSearchResult", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

                //******************************************************
        // Method Name: EnterServiceLineInArticle()
        // Method Decs: this method enters value in the service line/department  during creation of article
        // Created on: 05/12/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void EnterServiceLineInArticle()
        {
            try
            {
                string serviceline = DataTable.GetData("General_Data_" + Env, "RequestType6").Trim();
                if (common.CheckElement(BlogsAndCommentsOR.rserviceline_xpath))
                {
                    Report.UpdateTestLog("EnterServiceLineInArticle", "Targeted service line/Department is present", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.rserviceline_xpath).Click();
                    Driver.FindElement(BlogsAndCommentsOR.rserviceline_xpath).SendKeys(serviceline);

                    Report.UpdateTestLog("EnterServiceLineInArticleFinalStep", "Targeted service line/Department is entered as: " + serviceline, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterServiceLineInArticle", "Targeted service line/Department is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterServiceLineInArticle", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterServiceLineInArticle", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClicktoGearicon()
        // Method Decs: This method click on the gear icon under the news article
        // Created on: 05/15/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClicktoGearicon()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.ogearicon_xpath))
                {
                    Report.UpdateTestLog("ClicktoGearicon", "Gear icon is present", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.ogearicon_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClicktoGeariconFinalStep", "clicked on gear icon", Status.PASS);


                }
                else
                {
                    Report.UpdateTestLog("ClicktoGearicon", "Gear icon is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }


            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClicktoGearicon", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClicktoGearicon", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: UncheckArticlePriority()
        // Method Decs: This method uncheck the  article priority option under the news article
        // Created on: 05/15/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void UncheckArticlePriority()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.oarticlepriority_xpath))
                {
                    Report.UpdateTestLog("UncheckArticlePriority", "Uncheck priority option for  article option is present", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.oarticlepriority_xpath).Click();
                    Report.UpdateTestLog("UncheckArticlePriorityFinalStep", "Uncheck priority option for  option is Clicked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("UncheckArticlePriority", "Uncheck priority option for  option is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("UncheckArticlePriority", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("UncheckArticlePriority", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickToSaveArticle()
        // Method Decs: This method click save option to save news article
        // Created on: 05/15/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickToSaveArticle()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.oarticlepriority_xpath))
                {
                    Report.UpdateTestLog("ClickToSaveArticle", "Save  article option is present", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.oarticlepriority_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClickToSaveArticleFinalStep", "Save article option is Clicked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickToSaveArticle", "Save  option is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickToSaveArticle", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToSaveArticle", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickGearSubMenu()
        // Method Decs: This method click sone of the option present under gear sub menu
        // Created on: 05/15/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickGearSubMenu()
        {
            try
            {
                string req9 = DataTable.GetData("General_Data_" + Env, "RequestType9").Trim();
                string path = "//*[contains(text(),'" + req9 + "')]";

                if (common.CheckElement(By.XPath(path)))
                {
                    Report.UpdateTestLog("ClickGearSubMenu", req9 + " option is present", Status.PASS);
                    Driver.FindElement(By.XPath(path)).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClickGearSubMenuFinalStep", req9 + "  option is Clicked", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickGearSubMenu", req9 + "  is not  present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickGearSubMenu", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickGearSubMenu", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: GetLikeCount()
        // Method Decs: This method gets the like count in home page
        // Created on: 05/16/2017
        // Created By: GI offShore Team		
        //****************************************************

        public int GetLikeCount()
        {
                int iCount = 0;
                if (common.CheckElement(BlogsAndCommentsOR.oLikeCount_xpath) == true)
                {
                    string sCount = Driver.FindElement(BlogsAndCommentsOR.oLikeCount_xpath).Text.Trim();
                    iCount = int.Parse(sCount);
                }
                else
                {
                    iCount = 0;
                }
                return iCount;
        }

        //******************************************************
        // Method Name: ClickOnReadMore()
        // Method Decs: This method clicks on read more link
        // Created on: 05/16/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickOnReadMore()
        {
            try
            {
                common.CallMeWait(2000);
                if (common.CheckElement(BlogsAndCommentsOR.oReadMore_xpath) == true)
                {
                    Driver.FindElement(BlogsAndCommentsOR.oReadMore_xpath).Click();
                    Report.UpdateTestLog("ClickOnReadMoreFinalStep", " Clicked on Read More link ", Status.PASS);
                    common.CallMeWait(3000);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnReadMore", " Read More link is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnReadMore", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnReadMore", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnLikeIcon()
        // Method Decs: This method clicks on LikeIcon
        // Created on: 05/16/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ClickOnLikeIcon()
        {
            try
            {
                if (common.CheckElement(BlogsAndCommentsOR.olikethumb_xpath))
                {
                    Report.UpdateTestLog("ClickOnLikeIcon", "Like option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.olikethumb_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("ClickOnLikeIconFinalStep", "Like option is clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ClickOnLikeIcon", " Article is already liked ", Status.FAIL);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnLikeIcon", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnLikeIcon", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: NavigateBackToHomePage()
        // Method Decs: This method navigatesBack To Home Page
        // Created on: 05/16/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void NavigateBackToHomePage()
        {
            Driver.Navigate().Back();
            Report.UpdateTestLog("NavigateBackToHomePageFinalStep", " Navigated back to home page", Status.PASS);
            common.CallMeWait(2000);
        }

        //******************************************************
        // Method Name: ValidateLikeCount()
        // Method Decs: This method validates the like count
        // Created on: 05/16/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void ValidateLikeCount()
        {
            try
            {
                int BeforeLikeCount = 0;
                int AfterLikeCount = 0;
                BeforeLikeCount = GetLikeCount();
                ClickOnReadMore();
                ClickOnLikeIcon();
                if (common.CheckElement(HomePageSearchOR.ohomelink_xpath) == true)
                {
                    Driver.FindElement(HomePageSearchOR.ohomelink_xpath).Click();
                    Report.UpdateTestLog("ValidateLikeCount", " Home link is Clicked: ",
                        Status.PASS);
                    common.CallMeWait(3000);
                    
                }
                else
                {
                    Report.UpdateTestLog("ValidateLikeCount", " Home link is not present ",
                                            Status.FAIL);                    
                }
                
                AfterLikeCount = GetLikeCount();
                if (AfterLikeCount > BeforeLikeCount)
                {
                    Report.UpdateTestLog("ValidateLikeCountFinalStep", " Like Count is increased, before like count was : " + BeforeLikeCount + ", After like count is : " + AfterLikeCount, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ValidateLikeCount", " Like Count is not increased, before like count was : " + BeforeLikeCount+", After like count is : "+ AfterLikeCount, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateLikeCount", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateLikeCount", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: DislikeArticle()
        // Method Decs: This method dislikes the article
        // Created on: 05/16/2017
        // Created By: GI offShore Team		
        //****************************************************

        public void DislikeArticle()
        {
            try
            {
                ClickOnReadMore();
                if (common.CheckElement(BlogsAndCommentsOR.odislikethumb_xpath))
                {
                    Report.UpdateTestLog("DislikeArticle", "Dislike option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.odislikethumb_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DislikeArticleFinalStep", "Dislike option is clicked ", Status.PASS);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DislikeArticle", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DislikeArticle", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: NewsCount()
        // Method Decs: This method displays number of news present on the News Fed page.
        // Created on: 05/16/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void NewsCount()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(BlogsAndCommentsOR.onewsblock_xpath);
                if (elms.Count == 5)
                {
                    Report.UpdateTestLog("NewsCountFinalStep", "Total news present on news feed page is 5", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("NewsCount", "Total news present on news feed page is " + elms.Count(), Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("NewsCount", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("NewsCount", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: ClickOnReadMoreArticle()
        // Method Decs: This method click on the read more option for the first article on the News Fed page.
        // Created on: 05/17/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void ClickOnReadMoreArticle()
        {
            try
            {
                ReadOnlyCollection<IWebElement> elms = Driver.FindElements(BlogsAndCommentsOR.oreadmorelink_xpath);
                if (elms.Count > 0)
                {
                    Report.UpdateTestLog("ClickOnReadMoreArticle", "Total news present on news feed page are " + elms.Count(), Status.PASS);
                    elms[0].Click();
                    Report.UpdateTestLog("ClickOnReadMoreArticleFinalStep", "Read More From First article is clicked", Status.PASS);
                    common.CallMeWait(2000);
                    string url = Driver.SwitchTo().Window(Driver.WindowHandles[1]).Url;
                }
                else
                {
                    Report.UpdateTestLog("ClickOnReadMoreArticle", "Unable to find Read More option", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickOnReadMoreArticle", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickOnReadMoreArticle", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ValidateNewArticleTitleTopicDate()
        // Method Decs: This method validated article title, article topic and article date on the News Detail page.
        // Created on: 05/17/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void ValidateNewArticleTitleTopicDate()
        {
            try
            {
                //Validate article topic
                if (common.CheckElement(BlogsAndCommentsOR.oarticletopic_xpath))
                {
                    string ateticletopic = Driver.FindElement(BlogsAndCommentsOR.oarticletopic_xpath).Text.Trim();
                    Report.UpdateTestLog("ValidateNewArticleTitleTopicDate", "Article topic is present as:  " + ateticletopic, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("ValidateNewArticleTitleTopicDate", "Article topic is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Validate article article title
                if (common.CheckElement(BlogsAndCommentsOR.oarticletitle_xpath))
                {
                    string ateticletitle = Driver.FindElement(BlogsAndCommentsOR.oarticletitle_xpath).Text.Trim();
                    Report.UpdateTestLog("ValidateNewArticleTitleTopicDate", "Article title is present as:  " + ateticletitle, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("ValidateNewArticleTitleTopicDate", "Article title is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Validate article date
                if (common.CheckElement(BlogsAndCommentsOR.odateofarticle_xpath))
                {
                    string ateticledate = Driver.FindElement(BlogsAndCommentsOR.odateofarticle_xpath).Text.Trim();
                    Report.UpdateTestLog("ValidateNewArticleTitleTopicDateFinalStep", "Article topic is present as:  " + ateticledate, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("ValidateNewArticleTitleTopicDate", "Article ateticledate is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ValidateNewArticleTitleTopicDate", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ValidateNewArticleTitleTopicDate", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: IsShareCommentLikePresent()
        // Method Decs: This method validated presence of like comment and share on the News Detail page.
        // Created on: 05/17/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void IsShareCommentLikePresent()
        {
            try
            {
                //Validate article share
                if (common.CheckElement(BlogsAndCommentsOR.oshare_id))
                {
                    Report.UpdateTestLog("IsShareCommentLikePresent", "Article share is present   ", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("IsShareCommentLikePresent", "Article share is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Validate article comment
                if (common.CheckElement(BlogsAndCommentsOR.ocommentonnew_xpath))
                {
                    string ateticletitle = Driver.FindElement(BlogsAndCommentsOR.ocomment_xpath).Text.Trim();
                    Report.UpdateTestLog("IsShareCommentLikePresent", "Article comment is present   ", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("IsShareCommentLikePresent", "Article comment is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //Validate article likes
                if (common.CheckElement(BlogsAndCommentsOR.olike_xpath)==true || common.CheckElement(BlogsAndCommentsOR.odislikethumb_xpath)==true)
                {
                    string ateticledate = Driver.FindElement(BlogsAndCommentsOR.olike_xpath).Text.Trim();
                    Report.UpdateTestLog("IsShareCommentLikePresentFinalstep", "Article like is present   ", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("IsShareCommentLikePresent", "Article like is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("IsShareCommentLikePresent", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("IsShareCommentLikePresent", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: OpenFormToCreateNewPage()
        // Method Decs: This method Click on the File option under Site Content and select cbre intranet news page
        // Created on:  19th May 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void OpenFormToCreateNewPage()
        {
            try
            {
                common.WaitForElement(SiteContentOR.ofilelink_xpath);
                Driver.FindElement(SiteContentOR.ofilelink_xpath).Click();
                Report.UpdateTestLog("OpenFormToCreateNewPage", " Clicked on File option", Status.PASS);
                common.CallMeWait(1000);
                common.WaitForElement(SiteContentOR.onewdocumentlink_xpath);
                Driver.FindElement(SiteContentOR.onewdocumentlink_xpath).Click();
                Report.UpdateTestLog("OpenFormToCreateNewPage", "Clicked on New Document option", Status.PASS);
                common.CallMeWait(1000);
                common.WaitForElement(BlogsAndCommentsOR.ocreatecbreintranews_xpath);
                Driver.FindElement(BlogsAndCommentsOR.ocreatecbreintranews_xpath).Click();
                Report.UpdateTestLog("OpenFormToCreateNewPageFinalStep", "Clicked on CBRE Intranet  ews Page option", Status.PASS);
                common.CallMeWait(1000);

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("OpenFormToCreateNewPage", "Unable to open Page form" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("OpenFormToCreateNewPage", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: EnterNewsDetail()
        // Method Decs: This method enter news detail on the page during edition of the news article page
        // Created on:  19th May 2017
        // Created by:  GI offshore Team		
        //****************************************************
        public void EnterNewsDetail()
        {
            try
            {
                string articletipoc = DataTable.GetData("General_Data_" + Env, "RequestType3").Trim();
                string subheader = DataTable.GetData("General_Data_" + Env, "RequestType4").Trim();
                DateTime today = DateTime.Today;
                string todatdate = today.ToString().Split(' ')[0];
                //enter news article topic
                if (common.CheckElement(BlogsAndCommentsOR.oarticlenewstopic_xpath))
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article topic field is present   ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.oarticlenewstopic_xpath).SendKeys(articletipoc);
                    Report.UpdateTestLog("EnterNewsDetail", "Article like is entered as: " + articletipoc, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article topic field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //enter news article sub headline
                if (common.CheckElement(BlogsAndCommentsOR.oarticlesubheader_xpath))
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article sunheadline field is present   ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.oarticlesubheader_xpath).SendKeys(subheader);
                    Report.UpdateTestLog("EnterNewsDetail", "Article sunheadline field is entered as: " + subheader, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article subheader field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //enter news article date
                if (common.CheckElement(BlogsAndCommentsOR.oarticlenewsdate_xpath))
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article date field is present   ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.oarticlenewsdate_xpath).SendKeys(todatdate);
                    Report.UpdateTestLog("EnterNewsDetail", "Article date is entered as: " + todatdate, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article date field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //enter news article publish end date
                if (common.CheckElement(BlogsAndCommentsOR.opublishenddate_xpath))
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article publish end date field is present   ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.opublishenddate_xpath).SendKeys(todatdate);
                    Report.UpdateTestLog("EnterNewsDetail", "Article publish end date is entered as: " + todatdate, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article publish end date field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //enter news article start date
                if (common.CheckElement(BlogsAndCommentsOR.opublishstartdate_xpath))
                {
                    Report.UpdateTestLog("EnterNewsDetail", "Article start date field is present   ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.opublishstartdate_xpath).SendKeys(todatdate);
                    Report.UpdateTestLog("EnterNewsDetail", "Article start date is entered as: " + todatdate, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("EnterNewsDetailFinalStep", "Article start date field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterNewsDetail", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterNewsDetail", " Problem in Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickToSaveNewsFormDetail()
        // Method Decs: This click on the save optionon the News form Detail page.
        // Created on: 05/19/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void ClickToSaveNewsFormDetail()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.osavenewsdetialform_xpath))
                {
                    Report.UpdateTestLog("ClickToSaveNewsFormDetail", "Save option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.osavenewsdetialform_xpath).Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("ClickToSaveNewsFormDetailFinalStep", "Save option is clicked ", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("ClickToSaveNewsFormDetail", "Save option  is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickToSaveNewsFormDetail", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickToSaveNewsFormDetail", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SwitchtoPageRibbon()
        // Method Decs: This methods click on the Page option on the Ribbon during page edit
        // Created on: 05/19/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void SwitchtoPageRibbon()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.oclicktopage_xpath))
                {
                    Report.UpdateTestLog("SwitchtoPageRibbon", "Page option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.oclicktopage_xpath).Click();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("SwitchtoPageRibbonFinalStep", "Page option is clicked ", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("SwitchtoPageRibbon", "Page option  is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SwitchtoPageRibbon", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SwitchtoPageRibbon", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: DeleteNewspage()
        // Method Decs: This method will  find a news page and delete the click on page 
        // Created on:  19th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************
        public void DeleteNewspage()
        {
            int flag = 0;
            try
            {
                string admin = "//*[text()='Admin']";
                string dynamicXpath = "//*[text()='Edit page']";
                Driver.FindElement(By.XPath(admin)).Click();
                Driver.FindElement(By.XPath(dynamicXpath)).Click();
                common.CallMeWait(1000);
                SwitchtoPageRibbon();
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
                    Report.UpdateTestLog("DeleteNewspageFinalStep", "Page is deleted ",
                        Status.DONE);

                }
                else
                {
                    Report.UpdateTestLog("DeleteNewspage", "Unable to delete the page",
                       Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteNewspage", " Web Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteNewspage", " Problem in  Method " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickonLoadMoreNews()
        // Method Decs: This method click on the load more news option on the news feed page
        // Created on: 05/19/2017
        // Created By: GI offShore Team		
        //****************************************************
        public void ClickonLoadMoreNews()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.oloadmorenews_xpath) == true)
                {
                    Report.UpdateTestLog("ClickonLoadMoreNews", "Load more news option is present", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.oloadmorenews_xpath).Click();
                    Report.UpdateTestLog("ClickonLoadMoreNewsFinalStep", "Load more news option is clicked", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("ClickonLoadMoreNews", "Load more news option is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickonLoadMoreNews", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickonLoadMoreNews", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: FindSite()
        // Method Decs: This method find and click the site .
        // Created on:  23rd May 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void FindSite()
        {
            try
            {
                string sitename = DataTable.GetData("General_Data_" + Env, "RequestType2");
                int flag = 0;
                common.WaitForElement(SiteContentOR.omodified_xpath);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                Driver.FindElement(SiteContentOR.omodified_xpath).Click();
                common.CallMeWait(1000);
                string dpath = "//a[contains(text(),'" + sitename + "')]";
                ReadOnlyCollection<IWebElement> elms =
                    Driver.FindElements(By.XPath(dpath));
                if (elms.Count > 0)
                {
                    elms[0].Click();
                    common.CallMeWait(2000);
                    Report.UpdateTestLog("FindSite", sitename + " is clicked ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("FindSite", " Unable to find : " + sitename, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("FindSite", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("FindSite", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SiteStatus()
        // Method Decs: This method verify the status of the newly created site
        // Created on:  23rd May 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void SiteStatus()
        {
            try
            {
                string status = DataTable.GetData("General_Data_" + Env, "RequestType6");
                string s = Driver.FindElement(BlogsAndCommentsOR.ositestatus_xpath).Text.Trim();
                if (s.Contains(status))
                {
                    Report.UpdateTestLog("FindSiteFinalStep", " Status is: " + status, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("FindSite", " Status is somethings else: " + status, Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SiteStatus", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SiteStatus", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: DeleteItem()
        // Method Decs: This method click on the Delete Item
        // Created on:  23rd May 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void DeleteItem()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.odeleteitem_xpath) == true)
                {
                    Driver.FindElement(BlogsAndCommentsOR.odeleteitem_xpath).Click();
                    common.CallMeWait(1000);
                    Driver.SwitchTo().Alert().Accept();
                    common.CallMeWait(1000);
                    Report.UpdateTestLog("DeleteItemFinalStep", " clicked on delete item", Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("DeleteItem", " unable to find delete item ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("DeleteItem", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("DeleteItem", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: ClickSecondaryLanguage()
        // Method Decs: This method click on the check box of the secodary language of site form
        // Created on:  23rd May 2017	
        // Created by:  GI offshore Team	
        //****************************************************

        public void ClickSecondaryLanguage()
        {
            try
            {
                string sl = DataTable.GetData("General_Data_" + Env, "RequestType7");
                string dpath = "//span[@title='" + sl + "']";
                By osecondarylan_xpath = By.XPath(dpath);
                if (common.CheckElement(osecondarylan_xpath) == true)
                {
                    Driver.FindElement(osecondarylan_xpath).Click();
                    Report.UpdateTestLog("ClickSecondaryLanguageFinalStep", "Secondaru language is selected as: " + sl, Status.PASS);

                }
                else
                {
                    Report.UpdateTestLog("ClickSecondaryLanguage", " unable to find secondary language ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ClickSecondaryLanguage", "Element not found" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ClickSecondaryLanguage", "Error in method" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //24th may 
        //******************************************************
        // Method Name: MoveToOtherURL()
        // Method Decs: This method navigate to URL specified as Test data
        // Created on:   24th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void MoveToOtherURL()
        {
            try
            {
                string url = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                Driver.Navigate().GoToUrl(url);
                common.CallMeWait(3000);
                Report.UpdateTestLog("MoveToOtherURLFinalStep", " Moved to  " + url, Status.PASS);
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("MoveToOtherURL", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("MoveToOtherURL", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyfieldOnEditSiteForm()
        // Method Decs: This method veriy field on the edit site form
        // Created on:   24th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyfieldOnEditSiteForm()
        {
            try
            {
                //verify CBRE Intranet Org Comments option under site content
                if (common.CheckElement(BlogsAndCommentsOR.ocbreintraorg_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "CBRE Intranet Org Comments is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "CBRE Intranet Org Comments is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Custom Links option under site content
                if (common.CheckElement(BlogsAndCommentsOR.ocustomlink_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Custom Links is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Custom Links is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Documents option under site content
                if (common.CheckElement(BlogsAndCommentsOR.odocument_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Documents is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Documents is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Images option under site content
                if (common.CheckElement(BlogsAndCommentsOR.oimages_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Images is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Images is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Pages option under site content
                if (common.CheckElement(BlogsAndCommentsOR.opages_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Pages is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Pages is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Quick Links option under site content
                if (common.CheckElement(BlogsAndCommentsOR.oquicklink_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Quick Links is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Quick Links is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Workflow Tasks option under site content
                if (common.CheckElement(BlogsAndCommentsOR.oworkflow_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Workflow Tasks is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Workflow Tasks is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Events option under site content
                if (common.CheckElement(BlogsAndCommentsOR.oevent_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Events is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Events is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Intranet Site Setup option under site content
                if (common.CheckElement(BlogsAndCommentsOR.ositesetup_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Intranet Site Setup is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Intranet Site Setup is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify People List option under site content
                if (common.CheckElement(BlogsAndCommentsOR.opeoplelist_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "People List is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "People List is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                //verify Site Contacts option under site content
                if (common.CheckElement(BlogsAndCommentsOR.ositecontents_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Site Contacts is present ", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyfieldOnEditSiteForm", "Site Contacts is not present ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyfieldOnEditSiteFormFinalStep", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyfieldOnEditSiteForm", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: TwitterBlockCount()
        // Method Decs: This method count twitter bloack on the site page
        // Created on:   26th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void TwitterBlockCount()
        {
            try
            {
                ReadOnlyCollection<IWebElement> framecoll = Driver.FindElements(By.XPath("//*[@id='twitter-widget-0']"));
                Driver.SwitchTo().Frame(framecoll[0]);
                string twittertext = Driver.FindElement(SiteContentOR.otwittertext_id).Text.Trim();
                ReadOnlyCollection<IWebElement> elmsElements1 = Driver.FindElements(BlogsAndCommentsOR.otwitterblock_xpath);
                if (elmsElements1.Count == 4)
                {
                    Report.UpdateTestLog("TwitterBlockCountFinalStep", "4 Twitter Blocks are present", Status.PASS);
                }
                else
                {
                    if (elmsElements1.Count > 4)
                    {
                        Report.UpdateTestLog("TwitterBlockCount", "More than 4 Twitter Blocks are present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }
                    else
                    {
                        Report.UpdateTestLog("TwitterBlockCount", "Less than 4 Twitter Blocks are present", Status.FAIL);
                        CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                    }

                }

                Driver.SwitchTo().DefaultContent();
            }


            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("TwitterBlockCount", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("TwitterBlockCount", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //29th may 
        //******************************************************
        // Method Name: ImagePerGrid()
        // Method Decs: select  image  per grid to be displayed in grid under image web part
        // Created on:   29th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void ImagePerGrid()
        {
            try
            {
                string val = DataTable.GetData("General_Data_" + Env, "RequestType7").Trim();
                string path = "//input[contains(@id,'ngWebPartsControl_imagesPerGridPage') and @value='" + val + "']";
                By gridvalue = By.XPath(path);
                if (common.CheckElement(gridvalue))
                {
                    Driver.FindElement(gridvalue).Click();
                    Report.UpdateTestLog("ImagePerGridFinalStep", "grid option is selected as " + val, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("ImagePerGrid", "Unable to select grid as " + val, Status.FAIL);

                }
            }


            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("ImagePerGrid", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("ImagePerGrid", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: SelectDisplayType()
        // Method Decs: select  image  display type under image web part
        // Created on:   29th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void SelectDisplayType()
        {
            try
            {
                string val = DataTable.GetData("General_Data_" + Env, "RequestType8").Trim();
                string path = "//input[@value='" + val + "']";
                By gridvalue = By.XPath(path);
                if (common.CheckElement(gridvalue))
                {
                    Driver.FindElement(gridvalue).Click();
                    Report.UpdateTestLog("SelectDisplayTypeFinalStep", "Display option is selected as " + val, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectDisplayType", "Unable to select display option as " + val, Status.FAIL);

                }
            }


            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectDisplayType", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectDisplayType", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: EnterPrimaryService()
        // Method Decs: This method enter the primary service on the event form 
        // Created on:   30th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void EnterPrimaryService()
        {
            try
            {
                string primaryservices = DataTable.GetData("General_Data_" + Env, "RequestType1").Trim();

                if (common.CheckElement(BlogsAndCommentsOR.oprimaryservices_xpath))
                {
                    Report.UpdateTestLog("EnterPrimaryService", "Primary Service option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.oprimaryservices_xpath).Click();
                    Driver.FindElement(BlogsAndCommentsOR.oprimaryservices_xpath).Clear();
                    Driver.FindElement(BlogsAndCommentsOR.oprimaryservices_xpath).SendKeys(primaryservices);
                    Report.UpdateTestLog("EnterPrimaryServiceFinalStep", "Primary service is entered as " + primaryservices, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterPrimaryService", "Primary Service option is not present  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterPrimaryService", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterPrimaryService", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: EnterTargetLocation()
        // Method Decs: This method enter the Target Location on the event form 
        // Created on:   30th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void EnterTargetLocation()
        {
            try
            {
                string targetlocation = DataTable.GetData("General_Data_" + Env, "RequestType9").Trim();

                if (common.CheckElement(BlogsAndCommentsOR.otargetlocation_xpath))
                {
                    Report.UpdateTestLog("EnterTargetLocation", "Target Location option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.otargetlocation_xpath).Click();
                    Driver.FindElement(BlogsAndCommentsOR.otargetlocation_xpath).Clear();
                    Driver.FindElement(BlogsAndCommentsOR.otargetlocation_xpath).SendKeys(targetlocation);
                    Report.UpdateTestLog("EnterTargetLocationFinalStep", "Target Location is entered as " + targetlocation, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterTargetLocation", "Target Location option is not present  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterTargetLocation", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterTargetLocation", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: EnterTargetLocationGroup()
        // Method Decs: This method enter the Target Location Group on the event form 
        // Created on:   30th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void EnterTargetLocationGroup()
        {
            try
            {
                string targetlocationGroup = DataTable.GetData("General_Data_" + Env, "RequestType10").Trim();

                if (common.CheckElement(BlogsAndCommentsOR.otargetlocationgroup_xpath))
                {
                    Report.UpdateTestLog("EnterTargetLocationGroup", "Target Location Group option is present ", Status.PASS);
                    Driver.FindElement(BlogsAndCommentsOR.otargetlocationgroup_xpath).Click();
                    Driver.FindElement(BlogsAndCommentsOR.otargetlocationgroup_xpath).Clear();
                    Driver.FindElement(BlogsAndCommentsOR.otargetlocationgroup_xpath).SendKeys(targetlocationGroup);
                    Report.UpdateTestLog("EnterTargetLocationGroupFinalStep", "Target Location Group is entered as " + targetlocationGroup, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("EnterTargetLocationGroup", "Target LocationGroup option is not present  ", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("EnterTargetLocationGroup", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("EnterTargetLocationGroup", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyMouseHover()
        // Method Decs: This method verify mouse hover on the mega menu options
        // Created on:   30th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyMouseHover()
        {
            try
            {

                ReadOnlyCollection<IWebElement> elms =
                      Driver.FindElements(SearchFromLandingPageOR.oserviceLinesTopNav_xpath);

                Actions action = new Actions(Driver);
                string value = elms[0].Text;
                action.MoveToElement(elms[0]);

                action.Perform();
                common.CallMeWait(1000);
                if (common.CheckElement(BlogsAndCommentsOR.ofterhovermegamenu_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyMouseHoverFinalStep", "The  link take you to Intranet sites is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMouseHover", "The  link take you to Intranet sites is not present", Status.FAIL);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyMouseHover", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyMouseHover", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyMegaMenuTranslation()
        // Method Decs: This method verify mega menu translation
        // Created on:   30th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyMegaMenuTranslation()
        {
            try
            {

                ReadOnlyCollection<IWebElement> elms =
                      Driver.FindElements(SearchFromLandingPageOR.oserviceLinesTopNav_xpath);

                Actions action = new Actions(Driver);
                string value = elms[0].Text;
                action.MoveToElement(elms[0]);

                action.Perform();
                common.CallMeWait(1000);
                if (common.CheckElement(BlogsAndCommentsOR.omegamenuformaxico_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyMegaMenuTranslationFinalStep", "Mega menu translated successfully", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyMegaMenuTranslation", "Maga menu is not translated", Status.FAIL);
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyMegaMenuTranslation", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyMegaMenuTranslation", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyOneMoreItemOnEvent()
        // Method Decs: This method verify that i more item text appears on the event calendar in case mor that three event created on same day
        // Created on:   31th May 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyOneMoreItemOnEvent()
        {
            try
            {
                if (common.CheckElement(BlogsAndCommentsOR.oonemoreitem_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyOneMoreItemOnEventFinalStep", "1 More item option link is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyOneMoreItemOnEvent", "1 More item option link is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyOneMoreItemOnEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyOneMoreItemOnEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

                //******************************************************
        // Method Name: SelectDocumentView()
        // Method Decs: This method select the document view option(Simple/Detailed) in edit ocument web part 
        // Created on:   1st june 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void SelectDocumentView()
        {
            try
            {
                string req9 = DataTable.GetData("General_Data_" + Env, "RequestType9").Trim();
                string path = "//input[@value='" + req9 + "']";
                By odoctitle_xpath = By.XPath(path);
                if (common.CheckElement(odoctitle_xpath) == true)
                {
                    Driver.FindElement(odoctitle_xpath).Click();
                    Report.UpdateTestLog("SelectDocumentViewFinalStep", "Document View is selected as " + req9, Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("SelectDocumentView", "Unable to select Document View", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("SelectDocumentView", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("SelectDocumentView", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyDocumentDetailedColumn()
        // Method Decs: This method verify detailed column name in the documne web part on the page
        // Created on:   1st June 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyDocumentDetailedColumn()
        {
            try
            {
                // verify document Title column
                if (common.CheckElement(BlogsAndCommentsOR.odoctitle_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyDocumentDetailedColumn", "Document Title column is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyDocumentDetailedColumn", "Document Title column is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // verify document Modified Date column
                if (common.CheckElement(BlogsAndCommentsOR.odocmodifieddate_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyDocumentDetailedColumn", "Document Modified Date column is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyDocumentDetailedColumn", "Document Modified Date column is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // verify document Modified By column
                if (common.CheckElement(BlogsAndCommentsOR.odocmodifiedby_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyDocumentDetailedColumn", "Document Modified By column is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyDocumentDetailedColumn", "Document Modified By column is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
                // verify document Title column
                if (common.CheckElement(BlogsAndCommentsOR.odoclanguage_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyDocumentDetailedColumnFinalStep", "Document Language column is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyDocumentDetailedColumn", "Document Language column is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }
            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyOneMoreItemOnEvent", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyOneMoreItemOnEvent", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

        //******************************************************
        // Method Name: VerifyBrightCoveAccountIdField()
        // Method Decs: This method verify BrightCove AccountId Field in video web part 
        // Created on:  12th June 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyBrightCoveAccountIdField()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.oBrightcoveaccount_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyBrightCoveAccountIdFieldFinalStep", "Bright Cove account id field is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyBrightCoveAccountIdField", "Bright Cove account id field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyBrightCoveAccountIdField", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyBrightCoveAccountIdField", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }
        //******************************************************
        // Method Name: VerifyPlaLitIdField()
        // Method Decs: This method verify Play List Id Field in video web part 
        // Created on:  12th June 2017	
        // Created by:  GI offshore Team	
        //****************************************************  
        public void VerifyPlaLitIdField()
        {
            try
            {

                if (common.CheckElement(BlogsAndCommentsOR.ovideoid_xpath) == true)
                {
                    Report.UpdateTestLog("VerifyPlaLitIdFieldFieldFinalStep", "Play list  id field is present", Status.PASS);
                }
                else
                {
                    Report.UpdateTestLog("VerifyPlaLitIdField", "Play list id field is not present", Status.FAIL);
                    CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
                }

            }
            catch (NoSuchElementException e)
            {
                Report.UpdateTestLog("VerifyPlaLitIdField", "Element not found " + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
            catch (Exception e)
            {
                Report.UpdateTestLog("VerifyPlaLitIdField", " Error occured" + e, Status.FAIL);
                CRAFT.SupportLibraries.WebDriverFactory.driverquitstatus = false;
            }
        }

    
    }
}

