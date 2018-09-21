using System;
using System.Configuration;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework_Core;
using CRAFT.SupportLibraries;

namespace CRAFT.TestScripts
{
    [TestClass]
    public class GI_Automation : TestCase
    {
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyResultTypeRefiner_111800()
        {
            testParameters.CurrentTestDescription = "Verify 'Result type' refiner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyNumberOfResultsPerPage_111841()
        {
            testParameters.CurrentTestDescription = "Verify number of results per page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLanguagerefiner_111820()
        {
            testParameters.CurrentTestDescription = "Verifying Language refiner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLocationrefiner_111819()
        {
            testParameters.CurrentTestDescription = "Verifying Location refiner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySearchResultsPagewise_111826()
        {
            testParameters.CurrentTestDescription = "Verify that Search results are displayed page wise";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI"), TestCategory("GI2")]
        public void VerifyServicesandDepartmentRefiners_111713()
        {
            testParameters.CurrentTestDescription = "Verify Services and  Department refiners";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyShareNewArticlefunctionality_111801()
        {
            testParameters.CurrentTestDescription = "Verify 'Share' New Article functionality";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SearchBySelectingOption_98522()
        {
            testParameters.CurrentTestDescription = "Verify that the user is able to search by selecting an option in the dropdown on the search field and verify the results of that search on the search page in its own scope tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]

        public void UtilizeFilterOnSearchPage_98524()
        {
            testParameters.CurrentTestDescription = "Verify that the user is able to utilize the filters on the search page to further refine the search result";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyRefinerFunc_111709()
        {
            testParameters.CurrentTestDescription = "Verify Close refiner functionality";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyDocumentSearch_111703()
        {
            testParameters.CurrentTestDescription = "Verify that user is able to perform search by documents ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddComponentsIn3ColumnSecondaryPage_102192()
        {
            testParameters.CurrentTestDescription = " Verify different web parts can be added in the  '3 Column' Secondary layout page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddVideoComponentYoutube_102217()
        {
            testParameters.CurrentTestDescription = "Verify that Author is able to Configure the Videos from YouTube";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddVideoComponentYoutubeandconfigure_102216()
        {
            testParameters.CurrentTestDescription = "Verify that Author is able to Configure the Video Player-Web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyUploadImage_104188()
        {
            testParameters.CurrentTestDescription = "Verify uploading image in site content";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyShowMoreAndUserProfile_102177()
        {
            testParameters.CurrentTestDescription = "Verify that Show more link is available on the web part when more than 12 people are in the list and on clicking their name or photo user is navigated to the profile page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySomeOneElseProfile_106510()
        {
            testParameters.CurrentTestDescription = "Verify User is able to navigates to someone else's profile page and does not see edit links on the About Me section";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyWorkScheduleFieldsOnMyPrifile_106547()
        {
            testParameters.CurrentTestDescription = "UserStory#101662_Verify Work Schedule all the fields during edit/modify the sections";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyProfileEditlink_106511()
        {
            testParameters.CurrentTestDescription = "Verify User is able to navigates to user's profile page and  edit links on the About Me section is present";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMyOfficeLocation_106522()
        {
            testParameters.CurrentTestDescription = "Verify that 'My Office Location' section will include the following fields-";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyWorkScheduleWithDataUnavailable_106545()
        {
            testParameters.CurrentTestDescription = "Verify once user navigates to My Profile>> Work Schedule then system displays data under following category in case data not present then system will display ' - '/dash 1) Remote Work Schedule 2) Work hours";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyModifyWorkSchedule_106542()
        {
            testParameters.CurrentTestDescription = "Verify user can modify their own Work  Schedule details";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySearchRefinerOnEvents_111675()
        {
            testParameters.CurrentTestDescription = "Verify that search refiners show on the events tab and that you can select them";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyShowMoreResultsWithRefinerSelected_111676()
        {
            testParameters.CurrentTestDescription = "Verify that the Show more results works with a refiner selected";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyProfileOpenClinkOnImage_111840()
        {
            testParameters.CurrentTestDescription = "Verify Clicking on a profile photo will redirect the user to the correct profile page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyProfileOpenClinkOnName_111837()
        {
            testParameters.CurrentTestDescription = "Verify Clicking the name on People search will redirect the user to the correct profile page.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyShowMoreFunc_111625()
        {
            testParameters.CurrentTestDescription = "Verify the functionality of Load More";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyOtherContentTypeSearchInPagesTab_113197()
        {
            testParameters.CurrentTestDescription = "Verify that other content types do not appear in the pages tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyResultScopeTab_93518()
        {
            testParameters.CurrentTestDescription = "Verify that the user is able to search by selecting an option in the dropdown on the search field and verify the results of that search on the search page in its own scope tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyHaveQuestionslinks_89708()
        {
            testParameters.CurrentTestDescription = "Verify that Visitor is able to see the following link at the bottom of the page 'Have Questions?  Contact <Content Owner(s)>'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCanNotFindSomethingLink_89708()
        {
            testParameters.CurrentTestDescription = " Verify that Visitor is able to click on the name provided to request for new content *";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }


        //7th feb
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyIntranetCategoriesInQuickLinks_127099()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing a Quick links, the author sees a new 'Intranet Categories'field ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyIntranetCategoriesInCustomLinks_127100()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing a Custom links, the author sees a new Intranet Categories' field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyIntranetCategoriesInPeopleList_1127101()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing People content, the author sees a new Intranet Categories field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyStatusOfVideo_98395()
        {
            testParameters.CurrentTestDescription = " Verify visitor should be able to play the videos";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyGlobalIntranetDefaultpage_101128()
        {
            testParameters.CurrentTestDescription = "101128 Verify user is able to navigate to the Global Intranet Default page by clicking on the title of sub-site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyShowMoreWorksWithRefiner_113237()
        {
            testParameters.CurrentTestDescription = "Verify that the Show more results works with a refiner selected";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySearchRefinerWithDateModifier_113236()
        {
            testParameters.CurrentTestDescription = "Verify that search refiners show on the events tab and that you can select them";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUserProfilePage_111835()
        {
            testParameters.CurrentTestDescription = "Verify Search should index the following new fields: ◦Company ◦Skills ◦About Me ◦Interests ◦Schools ◦Past Projects ◦Ask Me About";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }       
        [TestMethod]
        [TestCategory("GI")]
        public void EditIntranetCategoriesInCustomLinks_127103()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing Custom links, when an Author begins to type the name of an intranet category, they see a type-a-head field ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void EditntranetCategoriesInPeopleList_1127104()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing  People content, when an Author begins to type the name of an intranet category, they see a type-a-head field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySiteContentTypes_105621()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To verify that the Site Content Types for the Default page.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAdministerCommentsAsAuthor_121536()
        {
            testParameters.CurrentTestDescription = "Login as an author and verify the Administer Comments Tab is visible.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAdministerCommentsAsSiteOwner_121537()
        {
            testParameters.CurrentTestDescription = "Login as a content owner and verify the Administer Comments Tab is visible.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAdministerCommentsDefaultDate_121552()
        {
            testParameters.CurrentTestDescription = "Login as an author and verify the article date is defaulted to 30 days.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateArticleUsingEnglishTag_126924()
        {
            testParameters.CurrentTestDescription = "Verify Global Intranet User is able to find an article using language tag";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyProfileSkillAcceptInterger_106661()
        {
            testParameters.CurrentTestDescription = "Verify whether the SKILLS field will accept integers";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUpdateSkillsWithAutoComplete_106656()
        {
            testParameters.CurrentTestDescription = "Verify after selecting the SKILLS field the user can enter in relevant information and the field auto-completes";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUpdateSkillsWithoutAutoComplete_106657()
        {
            testParameters.CurrentTestDescription = "Verify after selecting the SKILLS field the user can enter in a new field that is not part of the autocomplete lookup";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAddImageCarousel_102228()
        {
            testParameters.CurrentTestDescription = "93891 Verify the content author can select either GRID or CAROUSEL when selecting the way the images will be dislayed.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ConfigureGalleryWebPart_102227()
        {
            testParameters.CurrentTestDescription = "93891 Verify that Author is able to Configure the Image Gallery-Web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUpdateMultipleSkills_106658()
        {
            testParameters.CurrentTestDescription = "Verify after selecting the SKILLS field the user can enter in multiple new skills";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyRefinerSortingOrder_111707()
        {
            testParameters.CurrentTestDescription = "Verify the sort order in refiner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUpdatePastProjectsWithoutAutoComplete_106664()
        {
            testParameters.CurrentTestDescription = "Verify after selecting the PAST PROJECTS field the user can enter in a new field that is part of the autocomplete lookup";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUpdateMultiplePastProjects_106665()
        {
            testParameters.CurrentTestDescription = "Verify after selecting the PAST PROJECTS field the user can enter in multiple new PAST PROJECTS";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSpecialCharacterInPastProject_106666()
        {
            testParameters.CurrentTestDescription = "Add special characters to the PAST PROJECTS field such as $#@!.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSkillsFieldAcceptsBothStringAndInteger_106662()
        {
            testParameters.CurrentTestDescription = "Verify whether the SKILLS field will accept both integers and strings";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUpdatePastProjectsWithAutoComplete_106663()
        {
            testParameters.CurrentTestDescription = "Verify after selecting the PAST PROJECTS field the user can enter in relevant information and the field auto-completes";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMyOfficeLinkAndResources_94727()
        {
            testParameters.CurrentTestDescription = "91758 Verify that user is able to access  Resources and MyOffice links, along with the global menu section for service lines and departments";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreatePageWithAccordionLayout_102179()
        {
            testParameters.CurrentTestDescription = "98392 Verify that the Author is able to create page with Accordion Layout";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAnalyticsDashboard_102213()
        {
            testParameters.CurrentTestDescription = "94662 Verify that user is able to see the data from the Analytics Dashboard.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreatePageWith3ColumnSecondaryLayout_102191()
        {
            testParameters.CurrentTestDescription = "98398 Verify that the  Author is able to create page with '3 Column' Secondary Layout";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AuthorConfigurePeopleWebPart_102176()
        {
            testParameters.CurrentTestDescription = "Verify that Author is able to Configure the People List-Web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePastProjectFieldAcceptsInteger_106668()
        {
            testParameters.CurrentTestDescription = "Verify whether the PAST PROJECTS field will accept integers";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEmptySkill_106678()
        {
            testParameters.CurrentTestDescription = "In the SKILLS field do not add any text or info and SAVE IT. Validate the field is displayed as a '-' when viewing your profile as an Author";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEmptyPastProject_106679()
        {
            testParameters.CurrentTestDescription = "In the PAST PROJECTS field do not add any text or info and SAVE IT. Validate the field is displayed as a '-' when viewing your profile as an Author";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyEditQuicklinks_127105()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing a Quick links, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors.  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPageLayout_105650()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_Verify that the following new categories are present in the layout menu ◦Landing Page Layouts ◦Secondary Page Layouts ◦Custom Page Layouts";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyManageNewsLink_105651()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To verify that an Author is able to see Manage News Link within the Admin menu.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateAccordionLayoutPage_105657()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_Verify that the Content Author is able to create page with Accordion Layout";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyWhatisNew_98510()
        {
            testParameters.CurrentTestDescription = "93888 Verify that the functionality of the What's New web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyQuicklinks_98521()
        {
            testParameters.CurrentTestDescription = "93885 Verify that the user is able to view the quick links on a page and is able to redirect to a link's destination by clicking on it.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEditLink_106681()
        {
            testParameters.CurrentTestDescription = "Verify when logging as an author the Expertise & Service section has the EDIT link next to section header EXPERTISE & SERVICE";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUserCanModifySkillsField_106682()
        {
            testParameters.CurrentTestDescription = "Verify logging in as an author the EDIT link works for the SKILLS field. Select the EDIT link and modify the text in the SKILLS field by editing the existing field(s).";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUserCanModifyPastProjectField_106683()
        {
            testParameters.CurrentTestDescription = "Verify logging in as an author the EDIT link works for the PAST PROJECTS field. Select the EDIT link and modify the text in the PAST PROJECTS field by editing the existing field(s).";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateMaximumLengthInPastProject_106667()
        {
            testParameters.CurrentTestDescription = "Verify the maximum length of the PAST PROJECTS field by adding a long string value";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AdjustTimeFrameforMostviewedandLeastviewed_105654()
        {
            testParameters.CurrentTestDescription = "";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ConfigurePeopleWebPart_105652()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_Verify that Author is able to Configure the People List-Web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddWebPartsIn3ColumnSecondarylayoutPage_105659()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_Verify different web parts can be added in the  '3 Column' Secondary layout page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddWebPartsIn2ColumnSecondarylayoutPage_105660()
        {
            testParameters.CurrentTestDescription = "UserStory#101572_Verify that user is able to see contact link in their respective profile page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateOrgChartAsAuthor_106865()
        {
            testParameters.CurrentTestDescription = "Verify logging in as an author and viewing org chart on own and other person's profile";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateOrgChartAsVisitor_106869()
        {
            testParameters.CurrentTestDescription = "Verify logging in as a visitor and viewing org chart on own and other person's profile";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePublishPageDetails_97280()
        {
            testParameters.CurrentTestDescription = "Verify that content author's name and content's Publish date are visible on the page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateFooterAsAuthor_107125()
        {
            testParameters.CurrentTestDescription = "Verify footer displays correctly as content author";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateFooterAsVisitor_107130()
        {
            testParameters.CurrentTestDescription = "Verify footer displays correctly as a visitor";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateContactLinksInMyProfile_106490()
        {
            testParameters.CurrentTestDescription = "UserStory#101572_Verify that user is able to see contact link in their respective profile page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAssistantInContactInformation_106491()
        {
            testParameters.CurrentTestDescription = "UserStory#101572_Verify that when user clicks on ' Assistant'  link on the profile page, it should open that person s profile in new window";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateMyProfileColumns_106506()
        {
            testParameters.CurrentTestDescription = "UserStory#101560_Verify that the profile page is divided into two columns, where in the left column there are- Profile photo along with the information about the employee";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void NavigateToEmployeeProfile_106503()
        {
            testParameters.CurrentTestDescription = "101560 Verify User is able to navigate to the employee's profile by clicking on the My Profile";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyEditCustomlinks_127106()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing a Custom links, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors.  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPeopleIntranetCategory_127107()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing a  People content, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors.  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateMyProfileRightColumn_106508()
        {
            testParameters.CurrentTestDescription = "UserStory#101560_Verify that the profile page is divided into two columns, where in the right column there are- Office location information Employee's remote work schedule An org branch that shows the employee's direct report and their subordinates";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEditOfficeLocationInMyProfile_106523()
        {
            testParameters.CurrentTestDescription = "UserStory#101573_Verify that an Edit link is present next to the section header and the user is able to edit a section at a time.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
           // testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEditContactInformation_106534()
        {
            testParameters.CurrentTestDescription = "UserStory#101572_Verify that edit link is displayed for 'Contact Information' next to section header";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateContactDownload_106536()
        {
            testParameters.CurrentTestDescription = "UserStory#101572_Verify that when the user clicks on a edit on contact link page, it should open in new tab and download is triggered";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyQuickLinkIntranetCategory_127102()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing a Quick links,  when an Author begins to type the name of an intranet category, they see a type-a-head field ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateACustomListOfContact_102169()
        {
            testParameters.CurrentTestDescription = "89708 Verify that the user is able to build a custom list of contacts for the site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPopularLinks_98513()
        {
            testParameters.CurrentTestDescription = "93887 Verify that the functionality of the Popular Links web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyDocumentLinks_98515()
        {
            testParameters.CurrentTestDescription = "93889 Verify that the user is able to view the list of documents and is able to redirect to that page by clicking on a document";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //8th Feb
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateReportToInContactInformation_106551()
        {
            testParameters.CurrentTestDescription = "Verify that when user clicks on 'Report to' link on the profile page it should open that person's profile page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEditExpAndServiceAsAuthor_106653()
        {
            testParameters.CurrentTestDescription = "User Story 101570 Login as an author and select the My Profile page and verify the profile is visible with the EDIT link  and the section for EXPERTISE  & SERVICE is visible";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateMaximumLengthInSkill_106660()
        {
            testParameters.CurrentTestDescription = "101570 Verify the maximum length of the SKILLS field by adding a long string value";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateVisitorMyProfilePage_106654()
        {
            testParameters.CurrentTestDescription = "101570 Login as a visitor and navigate to a site- select the My Profile page and verify the EDIT link AND TARGET SERVICES is not present";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMyOfficePage_94726()
        {
            testParameters.CurrentTestDescription = "91758 Verify the functionality of the MyOffice section.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateLandingPage_105627()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To verify that user is able to create the landing page and left nav is fixed in place on the page layout.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ChangePageLayOut_105628()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To verify that user is able to edit the Landing page and is able to see the applied changes on the Publishing site.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchInPageTab_113196()
        {
            testParameters.CurrentTestDescription = "Verify that the page tab shows up when doing a search";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchPageBasedOnMultipleField_113199()
        {
            testParameters.CurrentTestDescription = "Verify that you can search for pages based on multiple fields";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchOnEvents_113231()
        {
            testParameters.CurrentTestDescription = "Verify that the events tab shows when doing a search";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchEventsTabBasedOnMultipleField_113233()
        {
            testParameters.CurrentTestDescription = "Verify that you can search for events based on multiple fields";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAuthorModifyPastProjectField_106727()
        {
            testParameters.CurrentTestDescription = "Verify logging in as an author the EDIT link works for the PAST PROJECTS field. Select the EDIT link and modify the text in the PAST PROJECTS field by editing the existing field(s).";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAccordionTabVideoLayOut_105647()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_Verify that the following new categories are present under Custom Page layout menu- Accordion Tab  Video";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyImageGalleryWebPartByOwner_105653()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_Verify that Author is able to Configure the Image Gallery-Web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyOrgChartSelection_105655()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To verify that an Author sees label saying Org Chart selection when editing a page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddWebPartAndChangeLayOut_105661()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_Verify different web parts can be added in the  '3 Column' Secondary layout page - w/o quick links";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMyProfilefieldsForOwner_106540()
        {
            testParameters.CurrentTestDescription = "UserStory#101569_Verify once user navigates to My Profile and able to see following fields 1) Office Floor - text/ Editable 2) Targeting Service/ Drop-Down 3) Company - text/ Not Editable";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLandingPage_97291()
        {
            testParameters.CurrentTestDescription = "Verify the landing page is in accordance in desktop";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCustomLinkTileFormate_98504()
        {
            testParameters.CurrentTestDescription = "93892 Verify that the user is able to see the list of tiles on the page and click on a tile and browse to the hyperlinked page or document";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewsFeedPageTitle_113257()
        {
            testParameters.CurrentTestDescription = "Verify News Feed Page  •Title: News Feed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewsFeedPageLayout_113258()
        {
            testParameters.CurrentTestDescription = "Verify News Feed Page  •Layout: Same as the web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLoadMoreOnNewsFeedPage_113260()
        {
            testParameters.CurrentTestDescription = "Verify News Feed Page  •Display up to 15 articles and include a Load More Articles button";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateViewAllOnNewsFeedPage_113255()
        {
            testParameters.CurrentTestDescription = "Verify Web Part Display  •View All: Redirects to the News Feed page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLocationInWhatisNewWebPart_98508()
        {
            testParameters.CurrentTestDescription = "93888 Verify that the content author is able to add the 'what's new' web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void ChangeDefaultSelectionInWhatisNew_98509()
        {
            testParameters.CurrentTestDescription = "93888 Verify that the content author is able to Change the defaults to select another site from which to display new content";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLocationInPopularWebPart_98511()
        {
            testParameters.CurrentTestDescription = "93887 Verify that the content author is able to add the 'popular pages' or documents web part **";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void ChangeLocationInPopularWebPart_98512()
        {
            testParameters.CurrentTestDescription = "93887 Verify that the content author is able to select another site to display popular content from.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddAndVerifyDocumentWebPart_136673()
        {
            testParameters.CurrentTestDescription = "QATEST Verify user can add the documents web part and edit it to show certain categories";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewsArticlePageLayout_113261()
        {
            testParameters.CurrentTestDescription = "Verify News Detail Page  •Display the news article with the same layout as news from the home page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewsDetailPage_113264()
        {
            testParameters.CurrentTestDescription = "Verify News Detail Page  ◦Comments •Buttons (Same functionality as news from the home page)  ◦Share ◦Comment ◦Like";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEmailOnMyProfile_106537()
        {
            testParameters.CurrentTestDescription = "UserStory#101572_Verify that when user clicks on the email field on page, the email app will be launched with a new email on the address clicked";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAuthorCanModifySkillsField_106726()
        {
            testParameters.CurrentTestDescription = "101570 Verify logging in as an author the EDIT link works for the SKILLS field. Select the EDIT link and modify the text in the SKILLS field by editing the existing field(s).";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCommentOnNewsArticle_126925()
        {
            testParameters.CurrentTestDescription = "Verify Given that the Allow comments check box is checked, when a global intranet user is viewing the news article, they should see both the comments and like functionality";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCommentNotAvailableOnNewsArticle_126926()
        {
            testParameters.CurrentTestDescription = "Verify Given that the Allow comments check box is unchecked, when a global intranet user is viewing the new article, they should not see comments functionality, but should see the like functionality";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAuthorBlankSkill_106721()
        {
            testParameters.CurrentTestDescription = "101570 In the SKILLS field do not add any text or info and SAVE IT. Validate the field is displayed as a '-' when viewing your profile as an Author";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateMultipleCustomLinks_98516()
        {
            testParameters.CurrentTestDescription = "93886 Verify that the content author is able to add links to a list and provide a category for each";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectCategoryInCustomLinkWebpart_98517()
        {
            testParameters.CurrentTestDescription = "96591 Verify that the content author is able to add an author defined list of links, set the title of the web part, and set the category to pull links from";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyExpectedWebPart_98531()
        {
            testParameters.CurrentTestDescription = "89699 Verify that an author is able to see the expected web page displayed in the web part.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ShowMoreInQuicklinkWebPart_98519()
        {
            testParameters.CurrentTestDescription = "93885 Verify that the content author is able to add links to the quick links list";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyDisplayOrderForlinks_98520()
        {
            testParameters.CurrentTestDescription = "93885 Verify that the content author is able to set the display order for each link";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void UploadHighResolutionImage_98526()
        {
            testParameters.CurrentTestDescription = "89702 Verify that the author is able to upload a high resolution image and select the desired rendition for the image as to add it to a page.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateProfileClickOnName_113266()
        {
            testParameters.CurrentTestDescription = "Verify Clicking the name on People search will redirect the user to the correct profile page.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateProfileClickOnProfileImage_113269()
        {
            testParameters.CurrentTestDescription = "Verify Clicking on a profile photo will redirect the user to the correct profile page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateProfilePageAsAuthor_113270()
        {
            testParameters.CurrentTestDescription = "Verify Search should index the following new fields: ◦Company ◦Skills ◦About Me ◦Interests ◦Schools ◦Past Projects ◦Ask Me About";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateOfficeDataAsAuthor_113275()
        {
            testParameters.CurrentTestDescription = "Verify  Office ◦Data: Office Street ◦Type: multi-select ◦Sort: count of matching results, descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNameAndJobTitle_113277()
        {
            testParameters.CurrentTestDescription = "Verify  Job Title (already exists) ◦Type: single-select ◦Sort: count of matching results, descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCountrySortOrder_113265()
        {
            testParameters.CurrentTestDescription = "Verify Update the search type so that it includes those fields and they are set as searchable.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCompanySortOrder_113282()
        {
            testParameters.CurrentTestDescription = "Verify  Company ◦Type: single-select ◦Sort: count of matching results, descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNavLinkForResources_94725()
        {
            testParameters.CurrentTestDescription = "91758 Verify that user is able to Create Nav Links for Resources.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUserCanDeleteNavLink_94728()
        {
            testParameters.CurrentTestDescription = "91758 Verify that user is able to Delete links present in the Resources section";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }      
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateParentLinkInOverLay_127073()
        {
            testParameters.CurrentTestDescription = "Verify the hover action and order in which links appear under service lines";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateBlogFolderInPages_119048()
        {
            testParameters.CurrentTestDescription = "116188 Verify that blog folder is available under 'Pages' folder by default";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreatePageWithBlogLayout_119050()
        {
            testParameters.CurrentTestDescription = "116188  Verify that author, content owner  is able to create new document Blog folder under pages";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateUpdateSearchAndSortOrder_111836()
        {
            testParameters.CurrentTestDescription = "Verify Update the search type so that it includes those fields and they are set as searchable.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void UploadDocument_98514()
        {
            testParameters.CurrentTestDescription = "93889 Verify that the content author is able to create a list of documents in Site Contents.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBehaviorforThisSite_113248()
        {
            testParameters.CurrentTestDescription = "Verify Web Part Configurations •Behavior ◦If 'Just this site' is selected, disable and clear values in Location, Location Group, and Service";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //17th Feb
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBehaviorforAnotherSite_113249()
        {
            testParameters.CurrentTestDescription = "Verify Web Part Configurations •Behavior ◦If 'Another site' or 'Both' is selected, enable Location, Location Group, and Service";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }


        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCustomLinkTilesandTitle_98503()
        {
            testParameters.CurrentTestDescription = "93892 Verify that the content author is able to add an author defined list to a page, set the title and set the category";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void SelectLocationInNewWebPart_113250()
        {
            testParameters.CurrentTestDescription = "Verify Web Part Configurations •Behavior ◦If user enters value into Location Group, this value will be chosen over the Location field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddSocialMediaWebPart_98505()
        {
            testParameters.CurrentTestDescription = "93894 Verify that the content author is able to add a Twitter stream in a page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyDisplayEmbededImages_98506()
        {
            testParameters.CurrentTestDescription = "93894 Verify that the content author is able to decide whether to show multimedia in the tweets displayed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void TwitterStreamFunctionality_98507()
        {
            testParameters.CurrentTestDescription = "93894 Verify that a functionality of the Twitter stream on the publishing site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAddAndModifyBlogWebPart_119051()
        {
            testParameters.CurrentTestDescription = "116188  Verify that user is able to modify blog";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePastProjectAsAuthor_106723()
        {
            testParameters.CurrentTestDescription = "101570 In the PAST PROJECTS field do not add any text or info and SAVE IT. Validate the field is displayed as a '-' when viewing your profile as an Author";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCommentsLikeInBlog_119057()
        {
            testParameters.CurrentTestDescription = "116188  Verify comments / likes functionality";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void UploadBlogAndDelete_120328()
        {
            testParameters.CurrentTestDescription = "116188 Verify that user is able to delete a blog";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAddBlogWebPartInPage_120335()
        {
            testParameters.CurrentTestDescription = "116188 Verify the author can add blog web part to an existing page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyHaveQuestionslinksAsVisitor_102206()
        {
            testParameters.CurrentTestDescription = "89708 Verify that Visitor sees the following link at the footer when there is no Content Owner-Have Question? Click Here";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEditPageLayout_94736()
        {
            testParameters.CurrentTestDescription = "89688 Verify that user is able to edit the Landing page and is able to see the applied changes on the Publishing site.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyQuickLinkCategaryInWebPart_127108()
        {
            testParameters.CurrentTestDescription = "Verify given that an Author is editing a QL, CL, or PC, when an Author adds multiple categ. to a content item, then that cont item should be pulled into web parts that are config to show cnt with any of the multiple categ. assigned to the item. ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCustomLinkCategaryInWebPart_127109()
        {
            testParameters.CurrentTestDescription = "Verify  testing with a People, Quick Links, or Custom Links web part that was already configured before other change was applied. verify web parts are still working and have been updated to use the new intranet category.  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ApproveUpcomingEvents_113203()
        {
            testParameters.CurrentTestDescription = "Verify that as an author, events that are upcoming show on the site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CheckthedeletedEvents_113205()
        {
            testParameters.CurrentTestDescription = "Verify that if an event is deleted, it does not show up on the web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyEventDetail_113204()
        {
            testParameters.CurrentTestDescription = "Verify that the event details page shows properly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ShowEventfromOtherSite_113207()
        {
            testParameters.CurrentTestDescription = "Verify that when selecting both under show events from, it displays events properly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void EventFeedPageDisplaysProperly_113210()
        {
            testParameters.CurrentTestDescription = "Verify that the event feed page displays properly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBehaviorforBlogWebPart_119055()
        {
            testParameters.CurrentTestDescription = "116188  Verify that author is able to source the blogs from Global Intranet sites and Other sites (available in Edit Page)";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDepartmentsPage_127074()
        {
            testParameters.CurrentTestDescription = "Verify the click action on departments takes user to page with all links sorted into two columns, alphabetically";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateArticleLanguageTag_126923()
        {
            testParameters.CurrentTestDescription = "Verify news articles have a language tag ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateGoogleMapOnMyProfile_106519()
        {
            testParameters.CurrentTestDescription = "UserStory#101573_Verify User is able to add a Google map at the 'My Office Location' showing the user's office address.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }     
        [TestMethod]
        [TestCategory("GI")]
        public void CreatePageWithNavisFixed_94732()
        {
            testParameters.CurrentTestDescription = "89687 Verify that user is able to create the landing page and left nav is fixed in place on the page layout.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAuthotNameAndPublishDate_94401()
        {
            testParameters.CurrentTestDescription = "89689 Verify that  content author's name and content's Publish date are visible on the page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void DeleteALink_94741()
        {
            testParameters.CurrentTestDescription = "91977 Verify that user is able to delete the links";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLinkCurrentNavigation_94739()
        {
            testParameters.CurrentTestDescription = "91977 Verify that user is able to create the links to be displayed in the current navigation";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLeftNav_94738()
        {
            testParameters.CurrentTestDescription = "91977 Verify that the current navigation (left nav) is integrated to the master page's style so that users are able to effectively navigate to the site created";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }

        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMobileTabletoption_105648()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_Verify that user is able to see that the image respond and change size according to the user's screen size";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMasterPage_94421()
        {
            testParameters.CurrentTestDescription = "89686 Verify the responsive nature of the master page for org site on the desktop.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //28th Feb
        [TestMethod]
        [TestCategory("GI")]
        public void CurrentNavigationOfLink_105631()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To verify that user is able to create the links to be displayed in the current navigation.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateandDeleteLink_105632()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To Verify that user is able to delete the links";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SearchByServiceLine_111621()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To Verify that user is able to delete the links";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCreateNavLinkForResources_105629()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To verify that user is able to Create NavLinks for Resources.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDeleteNavLinkForResources_105630()
        {
            testParameters.CurrentTestDescription = "UserStory#96591_To verify that user is able to Delete links present in the Resources section.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyExperienceServicesEditMode_106492()
        {
            testParameters.CurrentTestDescription = "UserStory#101572_Verify that user should not be able to edit more that one section at a time";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void UploadPdf_102231()
        {
            testParameters.CurrentTestDescription = "QATEST 93891 Verify if the image gallery will allow the uploading of documents or pdf files";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCustomlinkNavigation_102171()
        {
            testParameters.CurrentTestDescription = "QATEST 89708 Verify that the custom list links works properly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SuiteBarLinkFunctionality_94730()
        {
            testParameters.CurrentTestDescription = "QATEST 89690 Verify the functionality of links present in the Suite Bar";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMegaMenu_94731()
        {
            testParameters.CurrentTestDescription = "QATEST 89690 Verify the functionality of links present in Mega menu section";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAccordanceOfMegaMenu_94729()
        {
            testParameters.CurrentTestDescription = "QATESTQATEST 89690 Verify that Mega menu and suite bar are in accordance with Phase 1 publishing site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateServiceOnSiteScope_142749()
        {
            testParameters.CurrentTestDescription = "QATEST 125578 Verify that Primary 'Service' tag is added as a refiner on site scoped search tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateServiceNotAvailableOnSiteScope_142796()
        {
            testParameters.CurrentTestDescription = "QATEST 125578 Verify that when a user has executed a site scoped search such that results do have primary and secondary tag refiners";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSecondaryServiceOnSiteScope_142754()
        {
            testParameters.CurrentTestDescription = "QATEST 125578 Verify that Secondary 'Department tag' is added as refiner on the site scoped search tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLocaleInNewsAndHomePage_143149()
        {
            testParameters.CurrentTestDescription = "QATEST 134409 Verify that a user with english language set will see the news and home pages in english";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePortugalLocaleAsAuthor_142606()
        {
            testParameters.CurrentTestDescription = "QATEST 128042 Language - Remove/Hide Portugal (en-GB) as an author";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePortugalLocaleAsSiteOwner_142607()
        {
            testParameters.CurrentTestDescription = "QATEST 128042 Language - Remove/Hide Portugal (en-GB) as a content owner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSecondaryLanguage_143265()
        {
            testParameters.CurrentTestDescription = "QATEST 131968 INT : NorweGIn needs to be added to LanguageLocales file and provisioning list";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateFieldOnBestBetForm_143732()
        {
            testParameters.CurrentTestDescription = "QATEST 136164 Verify the fields when creating a best bet";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyOverridetitleinPeopleWebPart_137328()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that user able to disable the profile links for the user listed in people web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void IsPersonMandatoryField_137332()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that person link field is not a mandatory field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyOverrideProfileLink_137333()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that new field is added for profile link override";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyOverrideUserProfileLink_137555()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that a new field is added 'Profile Link Override'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyControlOfCustomLink_137567()
        {
            testParameters.CurrentTestDescription = "QATEST 121942 Verify that author can control number of links displayed on Custom Link Web Part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyexistingSettingCustomLink_137569()
        {
            testParameters.CurrentTestDescription = "QATEST 121942 Verify that existing settings in custom web part are working";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //10th march 
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCustomLinkCountField_139106()
        {
            testParameters.CurrentTestDescription = "QATEST 121942 Verify that new field is added to display custom links 10, 20, 30 or Show all";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyQuickLinkDefaultCountOnPage_145637()
        {
            testParameters.CurrentTestDescription = "QATEST 125804 Verify that quick links show as a list by default";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNoSiteSwitcher_135961()
        {
            testParameters.CurrentTestDescription = "QATEST 108089 Verify Given that a user is on an organization site, when the service/department/resource the site is for only has a Global site, when the user visits the site they do not see the site switcher next to the site title";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSiteSwitcher_135962()
        {
            testParameters.CurrentTestDescription = "QATEST 108089 Verify given that a user is on an organization site, when the service/department/resource the site is for has more than a Global site, when the user visits the site they see the site switcher next to the site title";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateFlyOutMenuOnSiteSwitcher_135963()
        {
            testParameters.CurrentTestDescription = "QATEST 108089 Verify Given that a user has opened the site switcher, when they hover over the Select Site option then the user see a fly out menu showing all available regional and country sites that match to the service/department/resource tag";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDropDownOnSiteSwitcher_135964()
        {
            testParameters.CurrentTestDescription = "Verify given that a user is on an organization site where the SS is shown, when the user clicks on the SS, then a drop down menu is shown reflecting the Global, Regional, and Country sites that are available for that service/department/resource tag";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //16 march
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMaxTenQuickLink_145639()
        {
            testParameters.CurrentTestDescription = "QATEST 125804 Verify that list shows properly with less than 10 links";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyTwentyCustomLink_140103()
        {
            testParameters.CurrentTestDescription = "QATEST 121942 Verify the display of 20 Custom Links";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyThirtyCustomLink_140104()
        {
            testParameters.CurrentTestDescription = "QATEST 121942 Verify the display of 30 Custom Links";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPersonfield_137547()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that person field is not madatory on content type";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPageAuthorForVisitor_138775()
        {
            testParameters.CurrentTestDescription = "QATEST 134511 Verify given that a Global Intranet Visitor is viewing a published and approved page on an organization site, when they scroll to the bottom of the center section, the Visitor does not see the account the page was last modified by";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void Verifyfootertextcolor_138783()
        {
            testParameters.CurrentTestDescription = "QATEST 134511 Verify GI Vis. is viewing a pub. & apprvd pg on an org site, scroll to the footer of the pg, the Vis sees the CB bg has been upd to white, FC  upd to the CC, the txt  upd to read Cannot find what you are looking for? Clk here for help";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyOverrideNameinPeopleWebPart_140303()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that Global Intranet user is able to override the profile link";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddBrightcoveVideoWebPart_133752()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify that user is able to load Brightcove Videos into Video Web Part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddRegionVideoWebPart_133754()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify that user is able to add Brightcove Playlists into Video Web Part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyRegionInVideoWebPart_136133()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify that Video Web part has new field 'Region' - 333";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyEnableDisableFuntionaityPlaylist_133762()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify that enable , disable functionality of playlist field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyInputForVideoIDPlaylistID_135759()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that Web Part property allows user to input Video ID or Playlist ID -11";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void FreeFromTextForRegionOther_136132()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify that new Web part has freeform text field when Region is selected as Other";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewsURLAsMexicoEnglish_139162()
        {
            testParameters.CurrentTestDescription = "QATEST - Footer list queries need to use current site URL instead of currentUIculture";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyJapaneseCharacters_133334()
        {
            testParameters.CurrentTestDescription = "QATEST 115580 Verify Given that a Global Intranet User is logged into the Intranet, when the user navigates to the Japanese variation of a site, then they see the Japanese characters displayed using the correct font.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBreakLine_135312()
        {
            testParameters.CurrentTestDescription = "Verify that there is a line break between top level links and global/regional links in the megamenu";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomLinkWithSpecialCharacter_133335()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds '@@@' into their custom link title and saves their custom link, then the custom link saves correctly.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //23 march 
        [TestMethod]
        [TestCategory("GI")]
        public void CustomlinkTitleNotDisplay_133336()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 User is viewing a page with a custom links web part on the page that is configured for the list view, when a custom link with @@@ in the title is displayed in the web part , then the user should not see @@@ in the title.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomLinkSpecialCharacterAtEnd_135722()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds @@@ to the ending of their custom link title and saves their custom link, then the custom link saves correctly.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomLinkNameformate_135723()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds @@ into their custom link title and saves their custom link, then the custom link saves correctly.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBreakInTitleName_133337()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Viewing a page with a CL WP on the page that is configured for the tile view, when a CL with @@@ in the title is displayed in the web part , then the user should see a line break where the @@@ would be in the title.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateReplyToOtherCommentsAsAuthor_129475()
        {
            testParameters.CurrentTestDescription = "Verify that user can reply to others comments";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateReplyCommentsAsContentOwner_129476()
        {
            testParameters.CurrentTestDescription = "Verify that content owner can reply to others comments";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddfourSpecialCharInTitle_135724()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds @@@@ into their custom link title and saves their custom link, then the custom link saves correctly.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void OnlyfourSpecialCharInTitle_135725()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds ONLY @@@ into their custom link title and saves their custom link, then the custom link saves correctly.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomLinkSpecialCharacterAtBeginnigg_135726()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds @@@ in the beginning of their custom link title and saves their custom link, then the custom link saves correctly.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //27 mar
        [TestMethod]
        [TestCategory("GI")]
        public void NewsDisplayonthePage_132898()
        {
            testParameters.CurrentTestDescription = "QATEST 112862 Create a news web part and verify if is appearing on the home page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void NewsArticleAppearOnSameSite_132899()
        {
            testParameters.CurrentTestDescription = "QATEST 112862 Verify that news article is appearing on the same site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyShowNewsFormOptions_132902()
        {
            testParameters.CurrentTestDescription = "QATEST 112862 Verify that 'Show News' has additional options";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //28 march
        [TestMethod]
        [TestCategory("GI")]
        public void SelectThisandAnotherSiteNewsForm_132956()
        {
            testParameters.CurrentTestDescription = "QATEST 112862 Create a news webpart with 'This  Site & Another' site and verify the display";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectNewSFormThreeTimes_132966()
        {
            testParameters.CurrentTestDescription = "QATEST 112862 Create a scenario to add 'Show news' from all 3 options in the drop down and verify the display";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLocationGroupPrimaryServices_132999()
        {
            testParameters.CurrentTestDescription = "QATEST 112862  Verify that News section is added to Web Part properties window called ' News Portal'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void NewsArticleAppearOnAnotherSite_133519()
        {
            testParameters.CurrentTestDescription = "QATEST 112862 Verify that news article is appearing on the different site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateRemoveOtherComments_129478()
        {
            testParameters.CurrentTestDescription = "Verify that article owner can remove others comments with replys";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDeleteTopLevelComment_129477()
        {
            testParameters.CurrentTestDescription = "Verify that if a top level comment is deleted, others comments below it are removed as well";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDeleteTopLevelCommentAsCO_129484()
        {
            testParameters.CurrentTestDescription = "Verify that if a top level comment is deleted, others comments below it are removed as well";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateActionOptionsAsSO_126119()
        {
            testParameters.CurrentTestDescription = "QATEST 123239 Verify given that a user has access to the provisioning list, when the user goes to the provisioning list, then there is an Action column with an option for Delete Site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEditActionAsSO_126121()
        {
            testParameters.CurrentTestDescription = "QATEST 123239 Verify given  that a user has set the Action column on an item in the list to Delete, when the user clicks to save the item, then the item saves correctly and the list shows the Action column updated with the new value";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddIntranetCategoryToEvent_129327()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given that the Intranet Category field has been added to the Event content type, When I log in as an author and create an event, Then I can add an intranet category to my new event.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddMultipleIntranetCategoryToEvent_129328()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given that the Intranet Category field has been added to the Event content type, When I log in as an author and create an event, Then I can add multiple intranet categories to my new event.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
           // testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectEventCategoryInWebPart_129329()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put a page into edit mode, When they add an events web part to the page, Then I can select an Intranet Category in the web part properties to filter events displayed in the web part.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDocumentCategory_127065()
        {
            testParameters.CurrentTestDescription = "QATEST Verify user can add the web part and edit it to show certain categories";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void Validate2DocumentWebPart_127067()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that clicking on a document name from the web part redirects user to document in new tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectMultipleEventCategoryInWebPart_129330()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put a page into edit mode, When they add an events web part to the page, Then they can select multiple Intranet Categories in the web part properties to filter events displayed in the web part.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectThisSiteEventWithMultipleCategory_129331()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given  an Author has put an events web part onto a page, configured it to show events from the This Site source";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectAnotherSiteEventWithMultipleCategory_129332()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put an events web part onto a page, configured it to show events from the Another Site source";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectBothSiteEventWithMultipleCategory_129333()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put an events web part onto a page, configured it to show events from the Both Site source";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //31  march 
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyManageNewsUnderAdmin_102165()
        {
            testParameters.CurrentTestDescription = "QATEST 93519 Verify that an Author is able to see Manage News Link within the Admin menu.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyManageNewsNavigation_102166()
        {
            testParameters.CurrentTestDescription = "QATEST 93519 Verify that Author is navigated to the Authoring (Admin) Dashboard page on clicking Manage News Link.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLayoutOptionOnLandingPage_102173()
        {
            testParameters.CurrentTestDescription = "QATEST 91859 Verify that the following new categories are present under Landing Page layout menu- 3 column with quick links";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLayoutOptionOnSecondaryPage_102174()
        {
            testParameters.CurrentTestDescription = "QATEST 91859 Verify that the following new categories are present under Secondary Page layout menu- 3 column without quick links 2 column split 3 column split";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //3rd april
        [TestMethod]
        [TestCategory("GI")]
        public void AddSubheaderAndContentInAccordionPage_102180()
        {
            testParameters.CurrentTestDescription = "QATEST 98392 Verify  Author can add an accordion subheader and content to the content section and publish the page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPresentOfAccordionModeOptions_102181()
        {
            testParameters.CurrentTestDescription = "QATEST 98392 Verify that the Author is able to add maximum 15 accordions and set the accordion display property to first open, all open, all closed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateTabLayOutPage_102183()
        {
            testParameters.CurrentTestDescription = "QATEST 98393 Verify that the Author is able to create page with Tab Layout";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewAndOldDocWebPart_127066()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that the old documents web part still functions";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateViewInDocumentWebPart_127068()
        {
            testParameters.CurrentTestDescription = "QATEST Verify the properties that are shown depending on view type for document web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateFolderSubFolderInWebPart_127880()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that folders and sub folders work in the documents web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //4th april
        [TestMethod]
        [TestCategory("GI")]
        public void AddSubheaderAndContentInTabPage_102184()
        {
            testParameters.CurrentTestDescription = "QATEST 98393 Verify Author can add an Tab subheader and content to the content section and publish the page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMaxTabInTabPageLayout_102185()
        {
            testParameters.CurrentTestDescription = "QATEST 98393 Verify that the Author is able to add maximum 5 tabs in a page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateVideoLayOutPage_102186()
        {
            testParameters.CurrentTestDescription = "QATEST 98395 Verify that the  Author is able to create page with Video Layout";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddWebPartInVideoLayOutPage_102187()
        {
            testParameters.CurrentTestDescription = "QATEST 98395 Verify different webparts can be added/deleted/edited in the video layout page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDocsInListInWebPart_127893()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that if the 'show sub folders' check box is unchecked, documents from all subfolders display in a single list";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCannotFindSomethingAsVisitor_102204()
        {
            testParameters.CurrentTestDescription = "QATEST 89708 Verify that Visitor is able to click on the name provided to request for new content";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateContactsOfRegions_102207()
        {
            testParameters.CurrentTestDescription = "QATEST 89708 Verify that when Visitor clicks on 'Click Here' link he/she is navigated to detail page having contacts for the Global Intranet grouped by Region";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddYoutubeInfoInVideoLayOutPage_102188()
        {
            testParameters.CurrentTestDescription = "QATEST 98395 Verify that the  Author is able to add videos from YouTube in the video layout page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddYoukuInfoInVideoLayOutPage_102189()
        {
            testParameters.CurrentTestDescription = "QATEST 98395 Verify that the  Author is able to add videos from Youku in the video layout page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddBrightcoveInfoInVideoLayOutPage_102190()
        {
            testParameters.CurrentTestDescription = "QATEST 98395 Verify that the  Author is able to add videos from Brightcove in the video layout page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyArticleLanguangeInJapaneseNewsPage_143150()
        {
            testParameters.CurrentTestDescription = "QATEST 134409 Verify that a user with english language set will see the news  page in Japanese when navigating from a Japanese site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void NavigateFromJapanesToEnglish_143151()
        {
            testParameters.CurrentTestDescription = "QATEST 134409 Verify that a user with english language set will see the home page in english when navigating from a Japanese site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPreFilterOnSearchResultPage_143133()
        {
            testParameters.CurrentTestDescription = "QATEST 105676 Verify that results are pre filtered for user based on location in users profile";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ClearPreFilterOnSearchResultPage_143134()
        {
            testParameters.CurrentTestDescription = "QATEST 105676 Verify that user is able to clear the prefiltered message and filters";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPreFilterOnNoResult_143135()
        {
            testParameters.CurrentTestDescription = "QATEST 105676 Verify that a search with no results will not be filtered automatically";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateHomeLinkAsFRCAVisitor_140727()
        {
            testParameters.CurrentTestDescription = "QATEST 138795 Verify Given that a French Canadian Global Intranet Visitor is logged in, when they navigate to the home page, then they see 'Accueil' used instead of 'Maison' to denote the Home link in the mega menu";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePeopleSearchOptionAsFRCAVisitor_140728()
        {
            testParameters.CurrentTestDescription = "QATEST 138975 Verify given that a French Canadian Global Intranet Visitor is logged in, when they view the search bar on an organization site, then they see 'Employés' used to denote the People search option on the search bar";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEventsSearchOptionAsFRCAVisitor_140729()
        {
            testParameters.CurrentTestDescription = "QATEST 138795 Verify given that a French Canadian Global Intranet Visitor is logged in, when they view the search bar on an organization site, then they see 'Événements' used to denote the Event search option on the search bar";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePrimaryAndSecondaryService_142741()
        {
            testParameters.CurrentTestDescription = "QATEST 125578 Verify that user is able to refine search based on the primary and secondary tags";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPreFilterOnJapaneseSite_143136()
        {
            testParameters.CurrentTestDescription = "QATEST 105676 Verify search results filter by users profile location when outside the US";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyNoPreFilterJapaneseSite_143137()
        {
            testParameters.CurrentTestDescription = "QATEST 105676 Verify that a search by a user with no location set in profile will have results from all locations";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ClickJustInimageHeaderText_141315()
        {
            testParameters.CurrentTestDescription = "QATEST 136002 Navigation - Make Quick Links and This Just In Clickable - Chrome";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewsArticleFormat_143259()
        {
            testParameters.CurrentTestDescription = "QATEST 136948 Verify that the news web part was updated to new format that rearranged author and date";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyforwardAndbackwardFeatureInNewSlider_147207()
        {
            testParameters.CurrentTestDescription = "QATEST 125613 Verify the forward and backward features of new slider";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyReadMoreForSlider_147209()
        {
            testParameters.CurrentTestDescription = "QATEST 125613 Verify read more functionality on articles on the new slider";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAnalyticsInSharepoint_148783()
        {
            testParameters.CurrentTestDescription = "QATEST 132315 Verify analytics information is displayed on Sharepoint tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateGoogleAnalytics_148782()
        {
            testParameters.CurrentTestDescription = "QATEST 132315 Verify Google analytics is displayed on Site Analytics on Org sites";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEspanolInMyTeam_149273()
        {
            testParameters.CurrentTestDescription = "QATEST 140477 Translations - Teams Selectors Page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLanguagesInOrgSite_149270()
        {
            testParameters.CurrentTestDescription = "QATEST 140530 Language - Select Language from Org Site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLanguageInNewPage_149271()
        {
            testParameters.CurrentTestDescription = "QATEST 140530 Create New Page and verify there are no language options";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyFeatureForSlider_147210()
        {
            testParameters.CurrentTestDescription = "125613 QATEST Verify UI features of new slider on the home page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddBrightCoveVideosforAuthoringSites_146936()
        {
            testParameters.CurrentTestDescription = "QATEST 125187 Verify that user is able to add Bright Cove Vedios to News Articles for Authoring Sites";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddYouTubesforAuthoringSites_152833()
        {
            testParameters.CurrentTestDescription = "QATEST 125187 Verify that user is able to add YouTube Vedios to News Articles-11";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddYoukuVideosforAuthoringSites_152834()
        {
            testParameters.CurrentTestDescription = "QATEST 125187 Verify that user is able to add YouKu Vedios to News Articles 22";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyVideoSourceType_152835()
        {
            testParameters.CurrentTestDescription = "QATEST 125187 Verify the UI of ribbon control-33";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAllTimeInAnalyticsDashboard_148482()
        {
            testParameters.CurrentTestDescription = "QATEST 141467 Verify 'all time' column is added to each widget";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySlidingFarwardFeature_147212()
        {
            testParameters.CurrentTestDescription = "QATEST 125613 Verify the advancing of postion on the new slider";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySlidingBackwardFeature_147213()
        {
            testParameters.CurrentTestDescription = "QATEST 125613 Verify when user scrolls back, the slider advances to last article in rotation";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBlogPostsOptionInWebPart_148788()
        {
            testParameters.CurrentTestDescription = "QATEST 135345 Verify the ability to display blogs by 3, 5, 10 and All";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBlogTimePeriodInWebPart_148789()
        {
            testParameters.CurrentTestDescription = "QATEST 135345 Verify the Ability to filter by This Year or This Month or None";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCommentsLikeCountInBlog_148795()
        {
            testParameters.CurrentTestDescription = "QATEST 135370 Verify the ablity to show / hide likes and comments  count on Blog Web Part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCommentsHideInBlog_148796()
        {
            testParameters.CurrentTestDescription = "QATEST 135370 Verify the ablity to show / hide comments on Blog Web Part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAlternateLinkInGlobalSpotNews_153472()
        {
            testParameters.CurrentTestDescription = "Alernate link is available when creating/editing global spot news";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBlogDisplayType_148790()
        {
            testParameters.CurrentTestDescription = "QATEST 135345 Verify the abilty to display blogs by additional options";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBlogDisplayTypeCategoryFilter_148791()
        {
            testParameters.CurrentTestDescription = "QATEST 135345 Verify the ablity to filter blogs by Intrannet Category";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCommentOnFeaturedNews_148121()
        {
            testParameters.CurrentTestDescription = "QATEST 136019 Verify the comments on the featured news banner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCommentOnNewscarousel_148123()
        {
            testParameters.CurrentTestDescription = "QATEST 136019 Verify the Comments link for an article in the this just in news carousel -feature news and Just in news";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAlternateTypeInGlobalSpotNews_153473()
        {
            testParameters.CurrentTestDescription = "Alternate type is available when creating/editing global spot news";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySearchByRelevance_111825()
        {
            testParameters.CurrentTestDescription = "QATEST 102101: Verify that results are by relevance";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDocumentOnHover_111828()
        {
            testParameters.CurrentTestDescription = "QATEST 102101: Verify the document display on hover over";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyfunctionalityNewSliderHomePage_147206()
        {
            testParameters.CurrentTestDescription = "QATEST 125613 Verify the functionality of New Slider on Home Page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyReadMoreOnNewscarousel_147214()
        {
            testParameters.CurrentTestDescription = "QATEST 125613 Verify read more functionality on articles on the new slider";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBlogPageFormField_119049()
        {
            testParameters.CurrentTestDescription = "QATEST 116188 Verify the the field validation of new blog type content";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectBlogPostsOptionInWebPart_119053()
        {
            testParameters.CurrentTestDescription = "QATEST 116188  Verify the functionality for 'View All' for Blog feeds";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchWithSpecialCharacter_111830()
        {
            testParameters.CurrentTestDescription = "QATEST 102101: Enter special characters ' #@!$%^&*()+=`{ }|,.;'' in Description field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyResultsAndShowMoreFunc_111711()
        {
            testParameters.CurrentTestDescription = "QATEST 102109: Verify 'Show More' functionality";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchWithInputString_111704()
        {
            testParameters.CurrentTestDescription = "QATEST 102019: Verify that value listed in the refiner matches the result";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchWithoutData_111706()
        {
            testParameters.CurrentTestDescription = "QATEST 102109: Verify the condition when there is no data on refiner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEnglishTag_124734()
        {
            testParameters.CurrentTestDescription = "QATEST Verify news articles have a langauge tag ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void FindArticleUsingLanguageTag_124735()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Global Intranet User is able to find an article using language tag";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectBlogPostsOptionAsThreeOrFive_119052()
        {
            testParameters.CurrentTestDescription = "QATEST 116188  Verify that user is able to set the number of blogs web parts for display to 3 or 5  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyActivityFeedTab_119899()
        {
            testParameters.CurrentTestDescription = "QATEST Verify My dashboard page defaults to the Activity Feed tab ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyTabOnMyDashboardPage_119898()
        {
            testParameters.CurrentTestDescription = "QATEST Verify My dashboard page is split into two tabs ◦Activity Feed ◦Administer Comments ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySubTabOfActivityFeedTab_119900()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Activity Feed tab contains the existing following widgets ◦My Articles by Article Date ◦Today ◦Yesterday ◦Recent Activity Last 7 Days";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyUrlWithParameter_119901()
        {
            testParameters.CurrentTestDescription = "QATEST Verify My dashboard continues to work with url parameter accountname";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNorwayInProvisionList_124596()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that user can see Norway has been added to country list through use of the provisioned site list";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLanguageInProvisionSite_124597()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that user can see norweGIn has been added to language list through use of the provisioned site list";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyHoverPanelOfArticle_124827()
        {
            testParameters.CurrentTestDescription = "QATEST 115188 Verify that title of article has hover over panel";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCommentsFeed_125611()
        {
            testParameters.CurrentTestDescription = "QATEST 111110  Verify the display of comments feed in the recent activity last 7 days widget";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAdministerCommentsAsVisitor_121567()
        {
            testParameters.CurrentTestDescription = "QATEST 113211 Login as a visitor and verify the Administer Comments Tab is not visible.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLikesCommentsOnActivityFeed_120303()
        {
            testParameters.CurrentTestDescription = "QATEST 111110  Verify the display of comments feed in the recent activity last 7 days widget";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateRecentActivityOnActivityFeed_120304()
        {
            testParameters.CurrentTestDescription = "QATEST 111110 Verify the UI on the comments feed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyHoverOnComments_120305()
        {
            testParameters.CurrentTestDescription = "QATEST 111110 Verify the hover over on the comments";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI"), TestCategory("Smoke")]
        public void AddCommentBlogAsContentOwner_119842()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that Content Owner is able to add comments to blogs";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddCommentBlogAsAuthor_119843()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that author is able to add comments to the blogs";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLikeCountIncrease_121278()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that if a user likes an article, the like count goes up by one";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateActivityOf7Days_125610()
        {
            testParameters.CurrentTestDescription = "QATEST 111110  Verify the display of comments feed in the recent activity last 7 days widget";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateArticlesSortOrder_120269()
        {
            testParameters.CurrentTestDescription = "QATEST 111111 Verify that top 10 articles are displayed by order of comments received, Latest on the top (date wise) descending order";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateShowMoreInArticleSection_120270()
        {
            testParameters.CurrentTestDescription = "QATEST 111111  Verify the display of 'More' button if there are more than 10 articles for display";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddCommentAsVisitor_119844()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that visitor is able to add comments to the blog";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void LikeABlog_119845()
        {
            testParameters.CurrentTestDescription = " QATEST 113549 Verify that any user is able to like a blog";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void DeleteCommentAsContentOwner_119850()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify content owner is able to delete comments";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CountComment_119853()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that the count of 'comments' are displayed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLikeCommentCount_120281()
        {
            testParameters.CurrentTestDescription = "QATEST 111111   Verify that display of count next to the article title - likes and comments";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCountAfterDeleteComment_119855()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that count of changes when user add or deletes a comment";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCountsOfLike_119856()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that the count of 'likes' changes when user adds or deletes a 'like'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateDeleteComment_119857()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that user cannot view a deleted comment";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateMostRecentCommentDisplay_119858()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that most recent version of the comments are displayed for a user";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateProvisionSiteHighlighted_119874()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Given that an Admin user is on the provisioning list, when they edit an item on the list, they should see a new status for re-tagging a site.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CountLike_119854()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify that count of 'likes'is displayed for all users";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyIncreamentDecrementOfLike_119859()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify increment , decrement functionality for a 'like'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyIncreamentDecrementOfComment_119860()
        {
            testParameters.CurrentTestDescription = "QATEST 113549 Verify the increment and decrement functionality for a 'comment'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyIntranetCategoriesEditQuickLinks_122105()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Quick links, the author sees a new Intranet Categories field ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyIntranetCategoriesEditCustomLinks_122106()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Custom links, the author sees a new Intranet Categories field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyIntranetCategoriesEditPeopleLinks_122107()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing People content, the author sees a new Intranet Categories field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateTypeAHeadInQL_122108()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Quick links,  when an Author begins to type the name of an intranet category, they see a type-a-head field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateTypeAHeadinCL_122109()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing Custom links, when an Author begins to type the name of an intranet category, they see a type-a-head field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateTypeAHeadInPeopleContent_122110()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing  People content, when an Author begins to type the name of an intranet category, they see a type-a-head field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSiteEditHighlight_119875()
        {
            testParameters.CurrentTestDescription = "QATEST Verify  Given that a site has been set to be retagged, when the re-tagging script is run, then the sites content should have their tags updated to the new tags";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void EditingAQuicklinksCategory_122111()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Quick links, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors.  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void EditIntranetCategoriesCustomLinks_122112()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Custom links, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void EditntranetCategoriesPeopleList_122113()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a  People content, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyQuickLinkCategaryWebPart_122114()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a QL, CL, or PC, when an Author adds multiple categ. to a content item, then that cont item should be pulled into web parts that are config to show cnt with any of the multiple categ. assigned to the item.  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCustomLinkCategaryWebPart_122115()
        {
            testParameters.CurrentTestDescription = "QATEST Verify  testing with a People, Quick Links, or Custom Links web part that was already configured before other change was applied. verify web parts are still working and have been updated to use the new intranet category.  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SwitchingTabAfterSearch_121039()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that switching between tabs on the search page does not return an error";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePageTab_110054()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that the page tab shows up when doing a search";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateOtherContentTypeInPagesTab_110055()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that other content types do not appear in the pages tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateTagsInSearchResult_110609()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that pages do not show more than 10 tags";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAndSetTomorrowEvent_121280()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that user has the ability to add calendar view";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCalenderMonthView_121362()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that the calendar view has only month view enabled";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCalenderViewEditability_121363()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that the calendar web part is read only";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCalenderWeekDays_121364()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that the calendar web part displays Sunday-Saturday";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAmericaTagInPagesTab_110610()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that you can search for pages based on multiple fields";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatedServiceAndDepartmentSort_110420()
        {
            testParameters.CurrentTestDescription = "QATEST Verify  Page search refiners (listed in order): •Services & Departments  ◦Data: Primary & Secondary Service ◦Type: single select ◦Sort: count of matching results, descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateRegionSortInPagesTab_110421()
        {
            testParameters.CurrentTestDescription = "QATEST Verify  Page search refiners (listed in order): •Region ◦Data: Region ◦Type: single select ◦Sort: count of matching results, descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyTodayAndTomorrowEvent_121356()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that user is able to open the calendar overlay and create an event";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateTwoEventOnSameDay_121357()
        {
            testParameters.CurrentTestDescription = "QATEST Verify user is able to create an event on a day that already has an event";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAddNewEventButtonEnabled_121358()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that if the Add new event button is enabled, user is able to click it to open the event creation overlay";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //8 may
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyRefinerForVisitor_110413()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 Verify that refiners listed in search results are based on the search string entered by user";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCloseIconForRefiner_110418()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 Verify a close icon will only be displayed next to a selected refiner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyNoResult_110419()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 Verify the condition for nothing matching the search criteria";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //9th may
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyClearAllOption_110446()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 Verify the 'Clear All' link is appearing on refiners";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyFuntionalityOfClearAllOption_110447()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 Verify that when user clicks on 'Clear All' all the refiners are cleared";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCountrySortInPagesTab_110422()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Page Search refiners (listed in order) •Country ◦Data: Country ◦Type: single select ◦Sort: count of matching results, descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLocationSortInPagesTab_110423()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Page Search refiners (listed in order) •Location ◦Data: Target Location, Target Location Group ◦Type: single select ◦Sort: count of matching results, descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLanguageSortInPagesTab_110424()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Page Search refiners (listed in order) •Language ◦Type: multi-select ◦Sort: count of matching results, descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyFuntionalityOfShowmoreOption_110443()
        {
            testParameters.CurrentTestDescription = "QATEST 102115  System will show the first 5 refiners then give a 'show more' button for the refiners to show up to the top 20 refiners";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySearchResult_110445()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 Verify that results matching the filter are displayed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SearchAndClickPPT_110448()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 Verify when user clicks on ppt, only MS power point files are displayed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateClearAllFunctionality_110426()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Refiner Functionality •Clear All ◦Label: Clear All ◦On click, clear all selected refiner ◦Position: top of the refiner cell";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCloseRefinerIcon_110427()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Refiner Functionality •Clear ◦Display: Icon with circle and X e.g. (X) ◦On click, clear the selected refiner ◦Position: right of the refiner label";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateNewsArticle_109749()
        {
            testParameters.CurrentTestDescription = "QATEST 89721 Verify that user is able to create a 'News' article";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddNewsDetail_109761()
        {
            testParameters.CurrentTestDescription = "QATEST 89721 : Verify that user is able to add News details";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyNewsArticleWorkFlow_109783()
        {
            testParameters.CurrentTestDescription = "QATEST 89721: Verify the work flow for News article created";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateRefinerFunctionality_110428()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Refiner Functionality •Number of results for refiner ◦Display the number of results for the refiner  ◦Position: right of the refiner label";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateShowMoreInRefiners_110429()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Refiner Functionality •Show More ◦On click, show more refiners ◦Position: at the bottom of the refiner cell";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateShowMoreDisplayed_110430()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Functional Criteria: •A 'Show More' link will be displayed if more than 5 refiners are displayed in a refiner category";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateAvailableRefiners_110431()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Functional Criteria: •Clicking 'Show More' will expand the refiner category section and show all available refiners";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateNewsPage_110059()
        {
            testParameters.CurrentTestDescription = "QATEST 89721: Verify the news articles by adding to different categories";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddServiceLineInNewsArticle_110060()
        {
            testParameters.CurrentTestDescription = "QATEST 89721: Verify that the user is able to create 'News' article for a  service line 'Capital Markets'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddServiceLineASHotelInNewsArticle_110061()
        {
            testParameters.CurrentTestDescription = "QATEST 89721: Verify that the user is able to create 'News' article for a  service line 'CBRE Hotels'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateRefinerCount_110432()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Functional Criteria: •Include the number of results that match a particular refiner in parenthesis next to the refiner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchResultBasedOnRefiner_110433()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Functional Criteria: •An 'x' will be included next to a selected refiner, when clicked the refiner will be cleared and the results will adjust accordingly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchTextBox_110442()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Functional Criteria: Search Refiner Column Mapping: Service, Region, Country, Location, Language & Date Modified";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddServiceLineAsAssetServicesInNewsArticle_110062()
        {
            testParameters.CurrentTestDescription = "QATEST 89721: Verify that the user is able to create 'News' create for a  service line 'Asset Services'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyURLCreatedForNewsArticle_110065()
        {
            testParameters.CurrentTestDescription = "QATEST 89721: Verify that URL is created by system for New articles";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void NewsArticleWithNoPriority_110287()
        {
            testParameters.CurrentTestDescription = "QATEST 89721: Verify priority news articles are displayed first versus articles for which priority is not set";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLikeCountIncreasedAsAuthor_110004()
        {
            testParameters.CurrentTestDescription = "QATEST 106016 Login as an author and verify the LIKE works";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLikeCountIncreasedAsVisitor_110010()
        {
            testParameters.CurrentTestDescription = "QATEST 106016 Login as an visitor and verify the LIKE works";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBehaviorforThisSiteInNewWebPart_111466()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Web Part Configurations •Behavior ◦If 'Just this site' is selected, disable and clear values in Location, Location Group, and Service";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyBehaviorforAnotherSiteInNewsWebPart_111467()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Web Part Configurations •Behavior ◦If 'Another site' or 'Both' is selected, enable Location, Location Group, and Service";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SetLocationInNewWebPart_111468()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Web Part Configurations •Behavior ◦If user enters value into Location Group, this value will be chosen over the Location field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewsCountOnNewsFeedPage_111469()
        {
            testParameters.CurrentTestDescription = "QATEST Verify  Web Part Display  •Limit: 5 articles, sorted by article date descending";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateRefinersListedNotBasedOnSearch_110415()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that refiners listed in search results are NOT  based on the search string entered by user";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchResultsinPagesTab_110491()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 - Verify pages link , when user clicks on this link pages should be displayed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSearchForPeople_110492()
        {
            testParameters.CurrentTestDescription = "QATEST 102115 Verify serch refiner for 'people' link";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCountOfRefiners_110632()
        {
            testParameters.CurrentTestDescription = "QATEST Verify the number of results per refiners are displayed for each refiner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLocationGroupValues_110379()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that Location group values";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateReadMoreOnNewsFeedPage_111470()
        {
            testParameters.CurrentTestDescription = "QATEST Verify  Web Part Display  •View All: Redirects to the News Feed page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateNewsDetailPage_111477()
        {
            testParameters.CurrentTestDescription = "QATEST Verify News Detail Page  •Display  ◦Article Topic (Category) ◦Article Title ◦Article Date ◦Article Author ◦# of Likes ◦# of Comments ◦Article content";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CommentOnNewsDetailPage_111478()
        {
            testParameters.CurrentTestDescription = "QATEST Verify News Detail Page  ◦Comments •Buttons (Same functionality as news from the home page)  ◦Share ◦Comment ◦Like";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //18th may
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyWebPartConfiguration_111479()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Web Part Configurations: Fields";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyEditWebPart_111471()
        {
            testParameters.CurrentTestDescription = "QATEST Verify  Web Part Display: Fields";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyNewsFeedPageTitle_111472()
        {
            testParameters.CurrentTestDescription = "QATEST Verify News Feed Page Title: News Feed";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateLinkedinUrlAsVisitor_106512()
        {
            testParameters.CurrentTestDescription = "QATEST 101571 Verify User navigates to a profile page and on clicking the LinkedIn URL navigates to that LinkedIn page in a new tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateTwitterUrlAsVisitor_106514()
        {
            testParameters.CurrentTestDescription = "QATEST 101571 Verify User navigates to a profile page and on clicking the Twitter URL navigates to that Twitter page in a new tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateWebsiteUrlAsVisitor_106516()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#101571_Verify User navigates to a profile page and on clicking the site URL navigates to that site in a new tab";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateNewsPage_111462()
        {
            testParameters.CurrentTestDescription = "QATEST Verify List Settings  •Same behavior as the Pages Library •News articles must be created in the News sub folder of the Pages Library";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyNewsArticlefields_111463()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Content Type: Fields  ◦Inherit from existing news article content type used by the news publishing sites";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLoadMoreNewsOption_111475()
        {
            testParameters.CurrentTestDescription = "QATEST Verify News Feed Page  •Display up to 15 articles and include a Load More Articles button";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateOtherWorkScheduleAsVisitor_106543()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#101662_Verify user can view others Work  Schedule details";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateWorkScheduleSubsections_106544()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#101662_Verify once user navigates to My Profile>> Work Schedule then system displays data under following category provided user has already updated these information 1) Remote Work Schedule 2) Work hours";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateSpecialCharacterInSkill_106659()
        {
            testParameters.CurrentTestDescription = "QATEST 101570 Add special characters to the SKILLS field such as $#@!.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifySiteStatus_105618()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#96591_To verify user is able to create the provisioned site.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void DeleteASite_105623()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#96591_To verify that user is able to delete a provisioned  site.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateASite_105624()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#96591_To verify user is able to create the provisioned site.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void EditASite_105625()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#96591_To verify user is able to edit & approve the provisioned site.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //24th may
        [TestMethod]
        [TestCategory("GI")]
        public void AddPageInSite_94619()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#96591_To verify user is able to create a Page inside the provisioning site and verify  the default tags are set to match what was entered in the provisioning list.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void QuickLinkDisplayOrder_105633()
        {
            testParameters.CurrentTestDescription = "QATEST DUP:UserStory#96591_To verify that the content author is able to set the display order for each link";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //25th may
        [TestMethod]
        [TestCategory("GI")]
        public void AddPopularWebPartAsContentOwner_105634()
        {
            testParameters.CurrentTestDescription = "QATEST DUP: UserStory#96591_To verify that the content author is able to add the popular pages or documents web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddWhatNewsWebPartAsContentOwner_105642()
        {
            testParameters.CurrentTestDescription = "QATEST DUP: 96591 Verify that the content author is able to add the what's new web part.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void UploadDocumentAsContentOwner_105643()
        {
            testParameters.CurrentTestDescription = "QATEST DUP: UserStory#96591_To verify that the content author is able to create a list of documents in Site Contents.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddCustomLinkAsContentOwner_105644()
        {
            testParameters.CurrentTestDescription = "QATEST DUP: UserStory#96591_To verify that the content author is able to add an author defined list to a page, set the title and set the category";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateACustomLinkAsContentOwner_105645()
        {
            testParameters.CurrentTestDescription = "QATEST DUP: UserStory#96591_To verify that the content author is able to add links to a list and provide a title, description, and category for each";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEventCalendarMonthView_159162()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify that new calendar event web part has only month view";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEventCalendarDays_159167()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify that calender days in new event web part is from Sun - Sat";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void TwitterStreamFunctionalityOnSite_105646()
        {
            testParameters.CurrentTestDescription = "QATEST DUP: 96591_To verify that a functionality of the Twitter stream on the publishing site.";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AdjustTimeFrameOnAnalyticsDashboard_105656()
        {
            testParameters.CurrentTestDescription = " QATEST DUPLICATE: UserStory#96591_To verify that user is able to adjust the timeframe for the Most viewed and Least viewed lists";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMaxTabInTabPageLayoutAsContentOwner_105658()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#96591_Verify that the Content Author is able to add maximum 5 tabs in a page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void Create2ColumnSecondaryPageAsAuthor_102195()
        {
            testParameters.CurrentTestDescription = "QATEST 98399 Verify that the Author is able to create page with 2 Column Secondary Layout";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //29th May
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyHaveQuestionslinksAsVisitor_102203()
        {
            testParameters.CurrentTestDescription = "QATEST 89708 Verify that Visitor is able to see the following link at the bottom of the page Have Questions?  Contact <Content Owner(s)>";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void Configure12ImagePerGrid_102232()
        {
            testParameters.CurrentTestDescription = "QATESTQATEST 93891 Verify if user can configure more than 12 images per grid";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyfieldsOfMyProfileForOwner_106538()
        {
            testParameters.CurrentTestDescription = "QATEST UserStory#101569_Verify once user navigates to My Profile and able to see following fields - for Author 1) Office Floor - text/ Editable 2) Targeting Service/ Drop-Down 3) Company - text/ Not Editable";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateEventCalendarfromSite_159164()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify that new calender event web part will display events from site it is on";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidatePrimaryServiceInEvent_159338()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify that multi select for Primary Service in Events Web Part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateMonthsInEvent_159343()
        {
            testParameters.CurrentTestDescription = "QATEST 104430  Verify the Test Next, Prev and Current Month on Events";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void MultipleSelectInEventTargettingProperty_159471()
        {
            testParameters.CurrentTestDescription = "QATEST 161170 Events - Calender View - Allow mutli select on targetting properties";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void MegaMenuTranslationsUpdates_161285()
        {
            testParameters.CurrentTestDescription = "QATEST 158977 Verify the Mega Menu Translations updates";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void MultiSelectLocationGroupInEvent_159504()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify Multi Select for Location Group";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //31 may
        [TestMethod]
        [TestCategory("GI")]
        public void MultiSelectLocationInEvent_159503()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify Multi select for Location";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyCreatedEvent_159176()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify that user is able to see all org site events";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreatedEventDisplayedOnPage_159160()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify that user is able to create events using calendar component so that site visitors can see them";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyOneMoreOptionOnEvent_159172()
        {
            testParameters.CurrentTestDescription = "QATEST 104430 Verify that two events are shown per day in the calendar month view, if more than 2 show ...";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ViewDocumentInDetail_156189()
        {
            testParameters.CurrentTestDescription = "153750 Prod : Documents Web Part Detailed View Columns Spill - existing site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyMyOfficeLocationOnPage_106518()
        {
            testParameters.CurrentTestDescription = "QATEST 101573 ** Verify User is able to navigate to My Profile page and see add My Office Location section on the top right corner";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void EditLinkNextToEXPERTISESERVICE_106725()
        {
            testParameters.CurrentTestDescription = "QATEST 101570 Verify when logging as an author the Expertise & Service section has the EDIT link next to section header EXPERTISE & SERVICE";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectEventFromBothSite_136392()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put an events web part onto a page, configured it to show events from the Both source...";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectEventFromAnotherSite_136393()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put an events web part onto a page, configured it to show events from the Another source... ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectEventFromThisSite_136390()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put an events web part onto a page, configured it to show events from the This site source... ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyJapaneseCharactersDisplayed_136395()
        {
            testParameters.CurrentTestDescription = "QATEST 115580 Verify Given that a Global Intranet User is logged into the Intranet, when the user navigates to the Japanese variation of a site, then they see the Japanese characters displayed using the correct font";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SpecialCharacterCustomLink_136396()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds '@@@' into their custom link title and saves their custom link, then the custom link saves correctly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomlinkTitleNotDisplaySpecialChar_136397()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 User is viewing a page with a custom links web part on the page that is configured for the list view, when a custom link with @@@ in the title is displayed in the web part , then the user should not see '@@@' in the title";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void BreakInCLTitleName_136398()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Viewing a page with a CL WP on the page that is configured for the tile view, when a CL with @@@ in the title is displayed in the web part , then the user should see a line break where the @@@ would be in the title";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void DeleteoptionUnderProvisionSite_136383()
        {
            testParameters.CurrentTestDescription = "QATEST 123239 Verify given that a user has access to the provisioning list, when the user goes to the provisioning list, then there is an Action column with an option for Delete Site. Test Case Singh, Jeena @ CBRE Contractor Design  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void IntranetCategoryToEvent_136386()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given that the Intranet Category field has been added to the Event content type, When I log in as an author and create an event, Then I can add an intranet category to my new event. Test Case Singh, Jeena @ CBRE Contractor Design ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void MultipleIntranetCategoryToEvent_136387()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given that the Intranet Category field has been added to the Event content type, When I log in as an author and create an event, Then I can add multiple intranet categories to my new event. Test Case Singh, Jeena @ CBRE Contractor Design  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void InWebPartSelectEventCategory_136388()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put a page into edit mode, When they add an events web part to the page, Then I can select an Intranet Category in the web part properties to filter events displayed in the web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void MultipleEventCategoryInWebPart_136389()
        {
            testParameters.CurrentTestDescription = "QATEST 116129 Verify given an Author has put a page into edit mode, When they add an events web part to the page, Then they can select multiple Intranet Categories in the web part properties to filter events displayed in the web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomLinkSpecialCharacterInTitle_136399()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds '@@@' to the ending of their custom link title and saves their custom link, then the custom link saves correctly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomLinkTwoSpecialCharacterInTitle_136400()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds '@@' into their custom link title and saves their custom link, then the custom link saves correctly. Test Case Singh, Jeena @ CBRE Contractor Design";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void FourSpecialCharacterInTitle_136401()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds '@@@@' into their custom link title and saves their custom link, then the custom link saves correctly  ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void OnlyfourSpecialCharInCustomeLinkTitle_136402()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds ONLY @@@ into their custom link title and saves their custom link, then the custom link saves correctly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SpecialCharacterAtBeginningInCustomLink_136403()
        {
            testParameters.CurrentTestDescription = "QATEST 128896 Verify Given that a Global Intranet Author is adding/editing custom links to their site, when the Author adds '@@@' in the beginning of their custom link title and saves their custom link, then the custom link saves correctly";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void NewStatusForRetaggingASite_136525()
        {
            testParameters.CurrentTestDescription = "QATEST Verify Given that an Admin user is on the provisioning list, when they edit an item on the list, they should see a new status for re-tagging a site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void QuickLinksIntranetCategoryVerification_136529()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Quick links, the author sees a new Intranet Categories field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomeLinksIntranetCategoryVerification_136530()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Custom links, the author sees a new Intranet Categories field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void PeopleLinksIntranetCategoryVerification_136531()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing People content, the author sees a new Intranet Categories field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void QuickLinkCategorySuggestion_136532()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Quick links, when an Author begins to type the name of an intranet category, they see a type-a-head field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomeLinkCategorySuggestion_136533()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing Custom links, when an Author begins to type the name of an intranet category, they see a type-a-head field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void PeopleLinkCategorySuggestion_136534()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing Custom links, when an Author begins to type the name of an intranet category, they see a type-a-head field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyEditQuicklinksCategoryByOthers_136535()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Quick links, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors. ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyEditQuicklinksCategoryByOthers_136536()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a Custom links, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyEditPeopleCategoryByOthers_136537()
        {
            testParameters.CurrentTestDescription = "QATEST Verify given that an Author is editing a People content, when an Author adds a new Intranet Category that has never been used for that site, then that intranet category will be seen in the type-a-head by other authors";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateFolderSubFolderInDocumentWebPart_136675()
        {
            testParameters.CurrentTestDescription = "Verify that folders and sub folders work in the documents web part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }      
        [TestMethod]
        [TestCategory("GI")]
        public void InWebPartValidateDocsInList_136676()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that if the show sub folders check box is unchecked, documents from all subfolders display in a single list";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AuthorReplyToOtherComments_136677()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that user can reply to others comments";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void DeleteTopLevelComment_136678()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that if a top level comment is deleted, others comments below it are removed as well";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void RemoveOtherComments_136679()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that article owner can remove others comments with replys";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateArticleInAmericanSite_139075()
        {
            testParameters.CurrentTestDescription = "QATEST 116546 Create an article in the America site";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateFooterList_139163()
        {
            testParameters.CurrentTestDescription = "QATEST - Footer list queries need to use current site URL instead of currentUIculture-IOS";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void NotMandatoryPersonLink_145684()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that person link field is not a mandatory field";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void AddNewFieldForProfileLink_145686()
        {
            testParameters.CurrentTestDescription = " QATEST 121896 Verify that new field is added for profile link override";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void PersonFieldNotMandetory_145687()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that person field is not madatory on content type";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyFileLinkOverride_145689()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify that a new field is added 'Profile Link Override'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ControlLinkToBeDisplayed_145695()
        {
            testParameters.CurrentTestDescription = "QATEST 121942 Verify that author can control number of links displayed on Custom Link Web Part";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CustomLinkExistingSetting_145696()
        {
            testParameters.CurrentTestDescription = "QATEST 121942 Verify that existing settings in custom web part are working";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ClickOnDocumentTitle_111829()
        {
            testParameters.CurrentTestDescription = "QATEST 102101: Verify if the Title on a Document or the Document URL is clicked, the user should be taken to that page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateCommentsVisibility_120266()
        {
            testParameters.CurrentTestDescription = "QATEST 115118 Verify that author is able to see the comments for the articles created";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void PlaylistInVideoWebPart_134419()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify the display functionality of new Video Web part & Playlist";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SelectRegionInVideoWebPart_135091()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify that Web Part has Option for Region selection -1";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyFuntionaityOfPlaylist_136003()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify the display functionality of new Video Web part & Playlist";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyAccountIDInVideoWebPart_136134()
        {
            testParameters.CurrentTestDescription = "  QATEST 124512 Verify that Video Web part has new field 'Account ID'";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyPlayListIDInVideoWebPart_136137()
        {
            testParameters.CurrentTestDescription = "QATEST 124512 Verify that Video Web part has new field 'PlayList ID";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //13th june
        [TestMethod]
        [TestCategory("GI")]
        public void SetIntranetCategoryInEvent_136391()
        {
            testParameters.CurrentTestDescription = "QATEST 12136391  QATEST 116129 Verify given that the Intranet Category field has been added to the Event content type, When I log in as an author and create an event, ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ShowPeopleResultsAsAuthor_149254()
        {
            testParameters.CurrentTestDescription = "QATEST 120593 Search - Show People Results on All Content Tab as an Author";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ShowPeopleResultsAsVisitor_149269()
        {
            testParameters.CurrentTestDescription = "QATEST 120593 Search - Show People Results on All Content Tab as a Visitor";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void OpenLinkinSearchResultAsVisitor_145705()
        {
            testParameters.CurrentTestDescription = "QATEST 117380 Verify that Global Intranet Visitor is on the search page with results, when the user navigates to a link that references a tab/accordion title";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyLinkInSearchResult_145703()
        {
            testParameters.CurrentTestDescription = "QATEST 117380 Verify that visitor is able to search results to open the tab/accordion";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyNewsArticle_129846()
        {
            testParameters.CurrentTestDescription = "QATEST 122160 Create a news article with new intranet category field, enter all mandatory fields and save it ";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        //15june 
        [TestMethod]
        [TestCategory("GI")]
        public void ValidateOverrideLink_140736()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify the functionality of Override Profile Link";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void EnableDisableProfileLink_140556()
        {
            testParameters.CurrentTestDescription = "QATEST 121896 Verify the enable & disable functionality profile link";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void DocumentWebPartFuntionality_136674()
        {
            testParameters.CurrentTestDescription = "QATEST Verify that the old documents web part still function";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateEventWithPrimaryServices_163261()
        {
            testParameters.CurrentTestDescription = "QATEST 107809 Create Calender Event on an authoring site and Org site with the same Primary Service and search on this";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateEventWithTragetLocation_163262()
        {
            testParameters.CurrentTestDescription = "QATEST 107809 Create Calender Event on an authoring site and Org site with the same Target Location and search on this";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateEventWithLocationGroup_163263()
        {
            testParameters.CurrentTestDescription = "QATEST 107809 Create Calender Event on an authoring site and Org site with the same Location Group and search on this";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void CreateEventWithDifferentLocation_163264()
        {
            testParameters.CurrentTestDescription = "QATEST 107809 Create Calender Event on an authoring site and Org site with the different Location Groups";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void SearchAsVisitor_145704()
        {
            testParameters.CurrentTestDescription = "QATEST 117380 Verify that a Global Intranet Visitor is on the search page with results, when the user navigates to a link that references content in a tab/accordion that doesn't exist";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void TwoIntranetCategoryInNewsWebPart_129848()
        {
            testParameters.CurrentTestDescription = "QATEST 122160 Verify that author is able to select two intranet categories";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void ConfigureNewArticle_129854()
        {
            testParameters.CurrentTestDescription = "QATEST 122160 Cofigure a news article to appear on home page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
        [TestMethod]
        [TestCategory("GI")]
        public void VerifyNewsDetailPage_129855()
        {
            testParameters.CurrentTestDescription = "QATEST 122160 Verify that news article created with new intranet category is displayed on News details page";
            testParameters.IterationMode = IterationOptions.RunOneIterationOnly;
            testParameters.Browser = Browser.chrome;
            driverScript = new DriverScript(testParameters);
            driverScript.DriveTestExecution();
        }
       


    }

}
