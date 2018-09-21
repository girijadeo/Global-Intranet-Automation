using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CRAFT.Uimap
{
    class SiteContentOR
    {
       
        public static readonly By oadminlink_xapth = By.XPath("//*[@id='zz5_SiteActionsMenu']");
        public static readonly By oclickingtositecontent = By.XPath("//*[@id='zz3_MenuItem_ViewAllSiteContents']/span[1]");
        public static readonly By oclicktoimagefolder_xpath = By.XPath("//*[@id='viewlistea9991c8-a8c5-4e46-8bb6-d33a549bee5a']");
        public static readonly By oclicktonewitem_xpath = By.XPath("//*[@id='idHomePageNewItem']/span[2]");
        public static readonly By oclicktoupload_xpath = By.XPath("//*[@id='ctl00_PlaceHolderMain_UploadDocumentSection_ctl05_InputFile']");
        public static readonly By oclickokbutton_xpath = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl03_RptControls_btnOK']");
        public static readonly By Oselectframe_id = By.XPath("//iframe[contains(@id,'Dlg')]");
        public static readonly By Oclicktosave_xpath = By.XPath("//*[@id='Ribbon.DocLibListForm.Edit.Commit.Publish-Large']/span[1]");
        public static readonly By Opeoplelistlabel_xpath =By.XPath("//h4[contains(text(),'People - Smoke Test November')]");
        public static readonly By Opeoplelistcontainer_xpath = By.XPath("//*[@class='row portrait-row ng-scope']/child::*");
        public static readonly By OshowMorePeopleLink_xpath =
            By.XPath("//*[@class='wp-listview-controls people-show-more']/child::*");
        public static readonly By ositecontentspagelist_xapth = By.XPath("//*[@id='applist']/child::*");
        public static readonly By oaddwebpartwebelement_xpath = By.XPath("//*[@id='MSOZone']/div[1]/div");
        public static readonly By oaddwebpartwebelementaddbtn_xpath = By.XPath("//*[contains(@id,'_WebPartAdder_tbl')]/tbody/child::*[last()]//button[1]");
        public static readonly By oaddwebpartwebelementsavebtn_xpath = By.XPath("//*[@id='Ribbon.WikiPageTab.EditAndCheckout.SaveEdit-SelectedItem']/span[2]");
        public static readonly By owebpartcountwebelemets_xpath =By.XPath("//div[@class='main-wp-zone-sm']/child::*/child::*");
        public static readonly By owebpartdeletetwebelemets_xpath =By.XPath("//*[@class='main-wp-zone-sm']/child::*[2]/div[2]/child::*/child::*[1]/child::*[2]/div/a");
        public static readonly By ovideowebpartlist_id = By.Id("ngWebPartsControl_videoSource");
        public static readonly By ovideowebpartlinktextbox_id = By.Id("ngWebPartsControl_videoLink");
        public static readonly By ovideowebpartapplybtn_xpath = By.XPath("//*[@value='Apply']");
        public static readonly By ovideowebpartokbtn_xpath = By.XPath("//*[@value='OK']");
        public static readonly By oyoutubestatuscheck_xpath = By.XPath("//*[@class='ytp-play-button ytp-button']");
        public static readonly By oyoutubeplaybtn_xpath = By.XPath("//*[contains(@aria-label,'YouTube Video Player')]");
        public static readonly By osavenewcheckinribbon_xpath = By.XPath("//span[@class='ms-cui-ctl-largeIconContainer']");
        public static readonly By ochecincontinuebtn_xpath = By.XPath("//*[@value='Continue']");
        public static readonly By oeditlink_xpath = By.XPath("//*[text()='edit']");
        public static readonly By ointernetcatagorywebelement_xpath = By.XPath("//*[@id='spgridcontainer_WPQ2_leftpane_mainTable']/tbody/tr[1]/th");
        public static readonly By ofilelink_xpath = By.XPath("//*[text()='Files']");
        public static readonly By onewdocumentlink_xpath = By.XPath("//*[@id='Ribbon.Documents.New.NewDocument-Large']/a[2]/span");
        public static readonly By ocreatecbreintrapage_xpath = By.XPath("//*[@id='Ribbon.Document.All.NewDocument.Menu.ContentTypes.0-Menu32']/span[4]");
        public static readonly By otitleTextBox_xpath = By.XPath("//input[contains(@id,'titleTextBox')]");
        public static readonly By ovideolayout_xpath = By.XPath("//*[contains(@id,'pageTemplatePicker')]/option[10]");
        public static readonly By ocreatepage_xpath = By.XPath("//*[contains(@id,'buttonCreatePage')]");
        public static readonly By oselectimageoption = By.XPath("//*[@id='ngWebPartsControl_targetImageFolder_modal_treeview']/ul/li");
        public static readonly By oselectafolderlocation = By.XPath("//*[@id='ngWebPartsControl_targetImageFolder_button']");
        public static readonly By oclicktoeditgallerywebpart = By.XPath("//img[@alt='Image Gallery Web Part Menu']/parent::*");
        public static readonly By odeletegallerywebpart = By.XPath("//*[text()='Delete']");
        public static readonly By ocloseoption = By.XPath("//*[@id='ngWebPartsControl_targetImageFolder_modal']/div[2]/div/div[3]/button");
        public static readonly By ogridrediobutton = By.XPath("//*[@id='ngWebPartsControl_displayView_1']");
        public static readonly By opergridimagesix = By.XPath("//*[@id='ngWebPartsControl_imagesPerGridPage_row']/div[1]/input[1]");
        public static readonly By opergridimagenine = By.XPath("//*[@id='ngWebPartsControl_imagesPerGridPage_row']/div[1]/input[2]");
        public static readonly By opergridimagetwelve = By.XPath("//*[@id='ngWebPartsControl_imagesPerGridPage_row']/div[1]/input[3]");
        public static readonly By oresourcelink = By.XPath("//*[@class='collapse navbar-collapse']/div[1]/ul/li[3]/a[1]");
        public static readonly By oresourcetext = By.XPath("//top-nav/div/div/ul/li[5]/a[1]");
        public static readonly By oaccordionpage_xpath = By.XPath("//*[text()='(CBRE Intranet Accordion Page) PageLayouts/Accordion Page']");
        public static readonly By oleastViewed = By.XPath("//*[@id='leastViewed']/div/div[1]/div");
        public static readonly By oleastViewedoption = By.XPath("//*[@id='leastViewed']/div/div[2]/div[1]/div/child::*");
        public static readonly By omostViewed = By.XPath("//*[@id='mostViewed']/div/div[1]/div");
        public static readonly By omostViewedoption = By.XPath("//*[@id='mostViewed']/div/div[2]/div[1]/div/child::*");
        public static readonly By omostRecentlyModified = By.XPath("//*[@id='mostRecentlyModified']/div/div[1]/div");
        public static readonly By oleastRecentlyModified = By.XPath(" //*[@id='leastRecentlyModified']/div/div[1]/div");
        public static readonly By o3coloumn_xpath = By.XPath("//*[text()='(CBRE Intranet Page) PageLayouts/3 Column']");
        // add people OR 3rd Feb
        public static readonly By oitemsheader_xpath = By.XPath("//*[text()='Items']");
        public static readonly By odeleteitemsheader_xpath = By.XPath("//*[@id='Ribbon.ListItem.Manage.Delete-Medium']");
        public static readonly By oaddnewpeopleplusbtn_xpath = By.XPath("//*[@title='Add a new item to this list or library.']/span[1]");
        public static readonly By o2coloumn_xpath = By.XPath("//*[text()='(CBRE Intranet Page) PageLayouts/2 Column']");
        public static readonly By olandingpage_xpath = By.XPath("//*[text()='(CBRE Intranet Page) PageLayouts/Landing Page']");
        public static readonly By oheaderbrowse_xpath = By.XPath("//*[text()='Browse']");
        public static readonly By ocbrehome_id = By.XPath("//*[contains(@id, 'onetidHeadbnnr')]");

        public static readonly By onewitemlink_xpath = By.XPath("//*[@title='Add a new item to this list or library.']/span[1]");
        //public static readonly By otitle_xpath = By.XPath("//*[@title='Title']");
        public static readonly By otitle_xpath = By.XPath("//*[@title='Title Required Field']");
        //public static readonly By ourl_xpath = By.XPath("//*[@title='URL']");
        public static readonly By ourl_xpath = By.XPath("//*[@title='URL Required Field']");
        public static readonly By oIntOrgCategory_xpath = By.XPath("//*[@id='IntOrgCategory_$containereditableRegion']");
        public static readonly By oribbonsaveoption_xpath = By.XPath("//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']/span[2]");
        public static readonly By omodified_xpath = By.XPath("//*[text()='Modified']");
        public static readonly By ostopedit_xpath = By.XPath("//*[text()='Stop']");
        public static readonly By opicture_xpath = By.XPath("//input[contains(@title,'Picture')]");
        //public static readonly By opicture_xpath = By.XPath("//*[@title='Picture Required Field']");
        public static readonly By odeletepage_xpath = By.XPath("//*[contains(@id,'Ribbon.WikiPageTab.Manage.Delete')]/span[2]");
        public static readonly By opagelayout_xpath = By.XPath("//*[@id='Ribbon.WikiPageTab.PubPageActions.ChangePageLayout-Large']/span[2]");
        public static readonly By osave_xpath = By.XPath("//*[@id='Ribbon.WikiPageTab.EditAndCheckout.SaveEdit-SelectedItem']/span[2]");

        //9th Feb
        public static readonly By oorgchart_xpath = By.XPath("//*[text()='Org Chart Section']");
        //10th feb
        public static readonly By oleftContentColumn_id = By.XPath("//*[@id='leftContentColumn']");
        public static readonly By omainContentColumn_id = By.XPath("//*[@id='mainContentColumn']");
        public static readonly By orightContentColumn_id = By.XPath("//*[@id='rightContentColumn']");
        public static readonly By owebpartmenuArrow_class = By.XPath("//*[@class='ms-webpart-menuArrowSpan']");
        public static readonly By odisplaytype_id = By.XPath("//*[@id='ngWebPartsControl_displayview']");
        public static readonly By otile_xpath = By.XPath("//*[text()='Tiles']");

        public static readonly By olocation_id = By.XPath("//*[@id='ngWebPartsControl_locationTerm']");
        public static readonly By oprimaryService_id = By.XPath("//*[@id='ngWebPartsControl_primaryServiceTerm']");
        
        // 13th Feb - Manik
        public static readonly By oTopNavNews_xpath = By.XPath("//*[@id='cbre-topnav']/div[1]/ul/li[3]/a[1]");
        public static readonly By oNewsFeedPageTitle_id = By.XPath("//*[@id='DeltaPlaceHolderPageTitleInTitleArea']");
        public static readonly By oNavBar_id = By.XPath("//*[@id='cbre-navbar']");
        public static readonly By oBodyContainer_id = By.XPath("//*[@id='s4-bodyContainer']");
        public static readonly By oFooter_id = By.XPath("//*[@id='cbre-footer']");
        public static readonly By oNewsArticleList_XPath = By.XPath("//*[@class='search-main-zone ng-scope']/child::*/div/div/div/div/a");
        public static readonly By oLoadMore_id = By.XPath("//*[@id='newsfeedmore']");
        public static readonly By oDropDown_id = By.XPath("//*[@id='selectedFilter']");
        public static readonly By oOption1_XPath = By.XPath("//*[@id='selectedFilter']/option[1]");
        public static readonly By oArticlePageTitle_id = By.XPath("//*[@id='ga-article-title']");

        public static readonly By oReadMore_XPath = By.XPath("//*[@class='search-main-zone ng-scope']/child::*/div/div/div[2]/a");
        public static readonly By oBodyContainerColumns_id = By.XPath("//*[@id='s4-bodyContainer']/div/div[2]/child::*");
        public static readonly By oCommentsList_XPath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[3]/div[2]");
        public static readonly By oDeleteComment_XPath = By.XPath("//*[@id='comments']/div/div[2]/ul/li[1]/div/div/div[2]/div[2]/a[2]");
        public static readonly By oCommentTextField_XPath = By.XPath("//*[@id='comments']/div/div[2]/div[1]/div[2]/div/textarea");
        public static readonly By oPostCommentButton_XPath = By.XPath("//*[@class='social-comments']/div[2]/div/div[2]/input");
        public static readonly By oLikeButton_class = By.XPath("//*[@class='cbre-icon cbre-thumbs-o-up']");
        public static readonly By oLiked_class = By.XPath("//*[@class='cbre-icon cbre-thumbs-up']");
        public static readonly By oLikeCount_class = By.XPath("//*[@class='like-count ng-binding']");
        public static readonly By oShare_id = By.XPath("//*[@id='cbre-share-article']");
        public static readonly By oDeleteYes_XPath = By.XPath("//*[@class='ui-dialog-buttonset']/button[1]");

        public static readonly By onewitem_xpath = By.XPath("//*[@title='Add a new item to this list or library.']/span[1]");
        public static readonly By oCategorydropdown_id = By.XPath("//*[@id='ngWebPartsControl_category']");
        public static readonly By osortingweight_xpath = By.XPath("//*[@title='Sorting Weight']");
        public static readonly By oshowmore_xpath = By.XPath("//*[text()='SHOW MORE']");

        //20th Feb

        public static readonly By oLeftNav_id = By.XPath("//*[@id='leftNavColumn']");

        //21st Feb

        public static readonly By oBlogLayout_xpath = By.XPath("//*[text()='(CBRE Intranet Org Blog) PageLayouts/Organization Blog Page']");
        public static readonly By oCreateIntBlogPage_xpath = By.XPath("//*[@id='Ribbon.Document.All.NewDocument.Menu.ContentTypes.2-Menu32']/span[4]");
        public static readonly By oPageTab_xpath = By.XPath("//*[@id='Ribbon.WikiPageTab-title']/a/span[1]");

        public static readonly By odeletedoc_xpath = By.XPath("//*[text()='Delete Document']");
        public static readonly By oshownewsform_id = By.XPath("//*[@id='ngWebPartsControl_showNewsFrom']");
        public static readonly By oprimaryServiceTerm_id = By.XPath("//*[@id='ngWebPartsControl_primaryServiceTerm']");
        public static readonly By olocationTerm_id = By.XPath("//*[@id='ngWebPartsControl_locationTerm']");
        public static readonly By olocationgroup_id = By.XPath("//*[@id='ngWebPartsControl_lmaTerm']");
        //17th Feb                                              
        public static readonly By oprimaryServicebutton_id = By.XPath("//*[@id='ngWebPartsControl_primaryServiceTerm_button']");
        public static readonly By oprimaryServicelabel_id = By.XPath("//*[@id='ngWebPartsControl_primaryServiceTerm_modal_label']");
        public static readonly By oprimaryServiceclosebutton_id = By.XPath("//*[@id='ngWebPartsControl_primaryServiceTerm_modal']/div[2]/div/div[3]/button");

        public static readonly By olocationbutton_id = By.XPath("//*[@id='ngWebPartsControl_locationTerm_button']");
        public static readonly By olocationlabel_id = By.XPath("//*[@id='ngWebPartsControl_locationTerm_modal_label']");
        public static readonly By olocationclosebutton_id = By.XPath("//*[@id='ngWebPartsControl_locationTerm_modal']/div[2]/div/div[3]/button");

        public static readonly By olocationgroupbutton_id = By.XPath("//*[@id='ngWebPartsControl_lmaTerm_button']");
        public static readonly By olocationgrouplabel_id = By.XPath("//*[@id='ngWebPartsControl_lmaTerm_modal_label']");
        public static readonly By olocationgroupclosebutton_id = By.XPath("//*[@id='ngWebPartsControl_lmaTerm_modal']/div[2]/div/div[3]/button");
        public static readonly By ocustomlinktitle_id = By.XPath("//*[@id='ngWebPartsControl_title']");
        public static readonly By odisplayimagecheckbox_id = By.XPath("//*[@id='ngWebPartsControl_displayImages']");
        public static readonly By otwitterlinksonpage_class = By.XPath("//*[@class='timeline-Tweet  u-cf js-tweetIdInfo']/div[2]/div/a");
        public static readonly By otwittertext_id = By.XPath("//*[text()='Tweets ']");
    
    // 22nd Feb

        public static readonly By oBlog_XPath = By.XPath("//*[@id='mainContentColumn']/div[2]/div/div/div/div/div/div/child::*/child::*/div/div/div[1]/div/h4");
    //23rd Feb

        public static readonly By oBlogArticleTopic_XPath = By.XPath("//*[contains(@title,'Article Topic')]");
        public static readonly By oBlogArticleAuthor_XPath = By.XPath("//*[contains(@name,'upLevelDiv')]");
        public static readonly By oBlogArticleDate_XPath = By.XPath("//*[contains(@title,'Article Date')]");
        public static readonly By oBlogContent_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl02_ctl11_RichHtmlField']");
        public static readonly By oBlogPageContent_XPath = By.XPath("//div[contains(@id,'RichHtmlField_displayContent')]");
        public static readonly By oBlogArticleSubHeadline_XPath = By.XPath("//*[contains(@title,'Article Sub headline')]");
        public static readonly By oBlogPublishStartDate_XPath = By.XPath("//*[contains(@title,'Publish Start Date')]");
        public static readonly By oBlogPublishEndDate_XPath = By.XPath("//*[contains(@title,'Publish End Date')]");
        public static readonly By oBlogAllowCommenting_XPath = By.XPath("//*[contains(@id,'BooleanField')]");
        public static readonly By oBlogSave_XPath = By.XPath("//*[contains(@id,'PageStateActionButton')]/span[2]");

        public static readonly By oBlogCommentCount_XPath = By.XPath("//*[@class='cbre-comment ng-binding ng-scope']");
        public static readonly By oBlogCommentArea_XPath = By.XPath("//*[@id='comments']/div/div[2]/div[1]/div[2]/div/textarea");
        public static readonly By oBlogPostCommentButton_XPath = By.XPath("//*[@id='cbre-comment-button']");
        public static readonly By oBlogLikeCount_XPath = By.XPath("//*[@class='like-count ng-binding']");
        public static readonly By oBlogLike_XPath = By.XPath("//*[@class='cbre-icon cbre-thumbs-o-up']");

        public static readonly By oBackToSite_XPath = By.XPath("//*[contains(text(),'Go back to site')]");
    
        //24th Feb
        public static readonly By oAddName_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_nameInput']");
        public static readonly By oCreateButton_value = By.XPath("//*[@value='Create']");
        public static readonly By oPageColumns_XPath = By.XPath("//*[@id='pageContainer']/div[2]/child::*");

        public static readonly By oaddevent_xpath = By.XPath("//*[text()='Add']");
        public static readonly By oeventtitle_xpath = By.XPath("//*[@id='part1']/table[2]/tbody/tr[1]/td[2]/span/input");
        //public static readonly By oeventstartdate_xpath = By.XPath("//*[@id='part1']/table[2]/tbody/tr[3]/td[2]/span/table/tbody/tr/td[1]/input");
        //public static readonly By oeventenddate_xpath = By.XPath("//*[@id='part1']/table[2]/tbody/tr[4]/td[2]/span/table/tbody/tr/td[1]/input");
        public static readonly By oeventstartdate_xpath = By.XPath("//input[contains(@title,'Start Date')]");
        public static readonly By oeventenddate_xpath = By.XPath("//input[contains(@title,'End Date')]");
        //public static readonly By ocalenderdesc_xpath = By.XPath("//*[@id='part1']/table[2]/tbody/tr[7]/td[2]/span/span[1]/textarea");
        public static readonly By ocalenderdesc_xpath = By.XPath("//textarea[@title='Calendar Description']");
        public static readonly By osavebutton_id = By.XPath("//input[contains(@id, 'SaveItem')]");
        public static readonly By oapprove_xpath = By.XPath("//*[text()='Approve/Reject']");
        public static readonly By oallaprroveradio_xpath = By.XPath("//*[contains(@id, 'RadioBtnApproval') and @type='radio']");

        public static readonly By oapprovecomment_xpath = By.XPath("//*[@title='Approval Comments']");
        public static readonly By oapproveok_xpath = By.XPath("//input[@type='button' and @value='OK']");
        public static readonly By odeleteevent_xpath = By.XPath("//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]");
        //24 feb 
        public static readonly By oviewall_xpath = By.XPath("//a[text()='View All']");
        public static readonly By oshoweventform_id = By.XPath("//*[@id='ngWebPartsControl_showEventsFrom']");
        public static readonly By oeventtitle_id = By.XPath("//*[@class='event-title ng-binding']");
    
    //27th Feb

        public static readonly By oBlogform_id = By.XPath("//*[@id='ngWebPartsControl_showBlogsFrom']");

        public static readonly By ocustomlinklist_xpath = By.XPath("//h4[text()='Custom Links']/parent::*/table/tbody/tr/td[2]/a");
        public static readonly By ocustomlinktext_xpath = By.XPath("//h4[text()='Custom Links']");

        //8th March

        public static readonly By oSiteContentLink_xpath = By.XPath("//span[contains(text(),'Site Contents')]");

        public static readonly By oBestBetTitle_xpath = By.XPath("//input[@title='Title Required Field']");
        public static readonly By oBestBetDescription_xpath = By.XPath("//*[contains(@aria-labelledby,'IntranetBestBetDescription')]");
        public static readonly By oBestBetType_xpath = By.XPath("//*[@title='Best Bets Type Required Field']");
        public static readonly By oBestBetURL_xpath = By.XPath("//input[@title='URL Required Field']");
        public static readonly By oBestBetKeyword1_xpath = By.XPath("//input[@title='Best Bets Keyword1 Required Field']");
        public static readonly By oBestBetTargetGeography_xpath = By.XPath("//*[contains(@id,'IntranetLocations_$containereditableRegion')]");
        public static readonly By oTargetGeographyMand_xpath = By.XPath("//*[@id='part1']/table[2]/tbody/tr[15]/td[1]/h3/nobr/span");
        public static readonly By oBestBetSave_xpath = By.XPath("//span[contains(text(),'Save')]");

        public static readonly By oApprovalStatus_xpath = By.XPath("//a[contains(text(),'Approval Status')]");
        public static readonly By oBestBetsTitles_xpath = By.XPath("//*[@class='ms-listviewtable']/tbody/tr/td[2]");

        public static readonly By oBestBetItems_xpath = By.XPath("//span[contains(text(),'Items')]");
        public static readonly By oBestBetDelete_xpath = By.XPath("//span[contains(text(),'Delete Item')]");

        //10th March

        public static readonly By oFrameBlog_xpath = By.XPath("//iframe[contains(@id,'DlgFrame')]");
        public static readonly By oGoBackToSite_xpath = By.XPath("//a[contains(text(),'Go back to site')]");

        public static readonly By ooverridetitle_xpath = By.XPath("//input[contains(@id,'OverrideTitle') and contains(@title,'Override Title')]");
        public static readonly By ocardtitle_xpath = By.XPath("//span[contains(@class,'contact-card-title')]");
        public static readonly By opeopleshowmore_xpath = By.XPath("//div[contains(@class,'people-show-more')]/a");
        public static readonly By ocardcontainer_xpath = By.XPath("//div[contains(@class,'contact-card-row')]");
        public static readonly By opersonmandatory_xpath = By.XPath("//*[text()='Person']/span");
        public static readonly By opersonformfield_xpath = By.XPath("//h3[contains(@class,'ms-standardheader')]/nobr");
        public static readonly By opeoplelist_xpath = By.XPath("//*[text()='People List']");
        public static readonly By olinkdropdown_id = By.XPath("//select[contains(@id,'numberOfLinksDisplayed')]");
        //10th mar
        public static readonly By oquicklinktext_xpath = By.XPath("//h4[text()='Quick Links']");
        public static readonly By oquicklinklist_xpath = By.XPath("//h4[text()='Quick Links']/parent::*/table/tbody/tr/td[2]/a");

        public static readonly By ocardname_xpath = By.XPath("//span[contains(@class,'contact-card-name')]");
        public static readonly By ooverridename_xpath = By.XPath("//input[contains(@id,'OverrideName') and contains(@title,'Override Name')]");

        public static readonly By videotitle_xpath = By.XPath("//div[contains(@class,'dock-title')]");
        public static readonly By obrightcoveplaylist_id = By.XPath("//input[@id='ngWebPartsControl_bcPlaylist']");
        public static readonly By oplaylistdisable_id = By.XPath("//input[contains(@id, 'ngWebPartsControl_bcPlaylist') and @disabled ]");
        public static readonly By oaccountdisable_id = By.XPath("//input[contains(@id, 'ngWebPartsControl_bcAccount') and @disabled ]");

        public static readonly By ocustomlinktextname_xpath = By.XPath("//h4[text()='Custom Links']/parent::*/table/tbody/tr/td[2]/a/span");
        public static readonly By ocheckbox_xpath = By.XPath("//input[@type='checkbox']");
        public static readonly By olinebreakeintile_xpath = By.XPath("//*[@class='tiles-row']/div/a/div/div/span/span/span/span");

        public static readonly By oweight_xpath = By.XPath("//*[@title='Sorting Weight']");
        //27 march
        public static readonly By onews_xpath = By.XPath("//h4[text()='News']");
        public static readonly By onewsrow_xpath = By.XPath("//div[@class='row news-row ng-scope']");

        public static readonly By oeventcategory_xpath = By.XPath("//*[@title='Intranet Category']/div");
        public static readonly By oeventprimariservice_xpath = By.XPath("//*[@title='Primary Service']/div");
        public static readonly By oeventpicture_xpath = By.XPath("//*[@title='Picture']");
        public static readonly By oevenrcategorywebpart_id = By.XPath("//*[@id='ngWebPartsControl_categories']");

        public static readonly By oDocIntranetCategory_xpath = By.XPath("//*[@title='Intranet Category']/div");
        public static readonly By oDocTitles_xpath = By.XPath("//*[@class='data-table']/tbody/tr/td[2]/a");
        public static readonly By oWebParts_xpath = By.XPath("//*[@class='ms-webpart-zone ms-fullWidth']/div/div/div/div[1]/div[1]/wp-documents/div/h4");
        //3rd april
        public static readonly By oAccordionSection1Title_id = By.XPath("//input[@id='AccordionSection1Title']");
        public static readonly By oclickaccordionwebpart_xpath = By.XPath("//div[@zonetitle='Accordion Section 1']/div/div/a");
        public static readonly By oAccordionpagearrow_xpath = By.XPath("//i[@class='glyphicon glyphicon-chevron-down pull-right accordion-icon']");
        public static readonly By oaccordionModeSelect_id = By.XPath("//*[@id='accordionModeSelect']");
        public static readonly By oaccordionsection_xpath = By.XPath("//div[contains(@zoneid,'AccordionSection')]");

        public static readonly By oDocHeaders_xpath = By.XPath("//*[@class='ms-webpart-zone ms-fullWidth']/div[1]/div/div/div[1]/div[1]/wp-documents/div/div/table/tbody/tr[1]/child::*");
        public static readonly By oicon_xpath = By.XPath("//*[@class='ms-webpart-zone ms-fullWidth']/div[1]/div/div/div[1]/div[1]/wp-documents/div/div/table/tbody/tr[1]/th[1]/img");

        public static readonly By DetailedView_id = By.XPath("//*[@id='ngWebPartsControl_view_1']");

        public static readonly By oNewFolder_xpath = By.XPath("//*[@id='Ribbon.Documents.New.NewFolder-Large']/span[2]");
        //public static readonly By oNameField_xpath = By.XPath("//input[@title='Name']");
        public static readonly By oNameField_xpath = By.XPath("//input[@title='Name Required Field']");
        public static readonly By oSaveButton_xpath = By.XPath("//input[@type='submit']");
        //4 April
        public static readonly By oclickTabwebpart_id = By.XPath("//div[@zoneid='TabSection1']/div/div/a");
        public static readonly By oTabSection1Title_id = By.XPath("//input[@id='TabSection1Title']");
        public static readonly By otabsection_id = By.XPath("//div[contains(@zoneid,'TabSection')]");

        public static readonly By oSubFolderChkBox_id = By.XPath("//input[@id='ngWebPartsControl_includeSubfolders']");
        public static readonly By oTabs_xpath = By.XPath("//*[@class='nav nav-tabs']/li");
        public static readonly By oGraprhHeaders_xpath = By.XPath("//*[@class='tab-pane fade active in']/div/div/div/div/div/div/div/org-ga-dashboard/div/div/h4");

        //13th April

        public static readonly By oNewsPage_xpath = By.XPath("//*[text()='(Intranet News) News Page']");
        public static readonly By oLanguageSwitcher_class = By.XPath("//div[@class='language-switcher']");
        public static readonly By oSaveRibbon_xpath = By.XPath("//*[@id='Ribbon.WikiPageTab-title']/a/span[1]");

        public static readonly By oBlogCheckIn_id = By.XPath("//*[@id='Ribbon.DocLibListForm.Edit.Commit.CheckIn-Large']");

        public static readonly By owebpartadd_xpath = By.XPath("//button[contains(text(),'Add')]");
        public static readonly By owebpartcancle_xpath = By.XPath("//button[contains(text(),'Cancel')]");

        public static readonly By oNextMonth_xpath = By.XPath("//a[@title='Next Month']");
        public static readonly By oPreviousMonth_xpath = By.XPath("//a[@title='Previous Month']");
        public static readonly By oCurrentMonth_id = By.XPath("//span[@id='WPQ2_nav_header']");
    }
}
