using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CRAFT.Uimap
{
    class HomePageSearchOR
    {
        //public static  readonly By osearchtextbox_id = By.Id("ctl00_ctl58_g_300ab37e_89c1_4caa_a458_257048133ad6_csr_sbox");
        public static readonly By osearchtextbox_id =By.XPath("//*[@class='cbre-srch-sb-input ms-srch-sb-prompt ms-helperText']");
        public static readonly By osearchtextbox_id1 =By.XPath("//*[@class='cbre-srch-sb-input']"); 
        public static readonly By oallContentlink_link = By.LinkText("All Content");
	    public  static readonly By oresultypewebelement_xpath= By.XPath("//*[@id='unselShortList']");
	    public  static readonly By oresultypetextwebelement_xpath = By.TagName("a");
       // public static readonly By oresultypetextwebelement_xpath = By.TagName("label");
	    public  static readonly By oresultypetextwebelement2_xpath = By.XPath("//*[@id='RefinementName']");
        public static readonly By oapacnavlink_xpath = By.XPath("//*[@id='RefinementName']");
        public static readonly By onewslink_xpath = By.XPath("//a[contains(text(),'News')]");
        //public static readonly By resultcountwebelement_xpath = By.XPath("//*[@id='ctl00_ctl58_g_4278737b_9fb8_4254_acee_9e2dd9939cae_csr1_groupContent']/div[@name='Item']");
        public static readonly By oloadmorebtn_xpath = By.XPath("//*[@id='CustomPagingButton']");
        public static readonly By ohomelink_xpath = By.XPath("//*[@id='cbre-topnav']/div[1]/ul/li[1]/a[1]");
        public static readonly By ojustinnewsfirstnews_xpath = By.XPath("//*[@class='tji-article']");
        public static readonly By ojustinnewslabel_xpath = By.XPath("//*[@id='tji-wrapper']/h4");
        public static readonly By odocumentlink_xapth = By.XPath("//*[@class='ms-srchnav-list']");
	    public  static readonly By odocumentlinktext_xapth = By.TagName("li");
        public static readonly By odocumentsearchlink_xapth = By.XPath("//*[@class='srch-row']");
        public static readonly By osharelink_xapth = By.XPath("//*[@id='cbre-share-article']");
        public static readonly By osearchlisttextbox_xpath = By.XPath("//*[@class='ms-qSuggest-listItem']");
       // public static readonly By searchdropdown = By.XPath("//*[@class='glyphicon glyphicon-menu-down']");
        public static readonly By resultcountwebelement_xpath = By.XPath("//div[contains(@id,'groupContent')]/child::*");
        public static readonly By downloadcontactlink_xpath = By.XPath("//*[text() =' Download Contact']");
        public static readonly By searchdropdown = By.XPath("//*[@class='cbre-search-nav-icon' and @title='Navigation']/span");
        public static readonly By oselctSitedropdown = By.XPath("//*[@id='DeltaPlaceHolderPageTitleInTitleArea']/global-site-switcher/div/a");

        public static readonly By oPublishDate_xpath = By.XPath("//*[@id='pageContainer']/div[3]/div/span[1]");
        public static readonly By oPublishedBy_xpath = By.XPath("//*[@id='pageContainer']/div[3]/div/span[2]");
        public static readonly By oPageHeader_xpath = By.XPath("//*[@id='Page Headline']");

        //9th Feb
        public static readonly By oFilterRemoveLink = By.XPath("//*[contains(text(),'click here to remove this filter')]");
        public static readonly By oAmericasIT_xpath = By.XPath("//div[contains(@id,'groupContent')]/child::*[1]/div/div/div/div/div/a");
        public static readonly By oPageTitle_xpath = By.XPath("//*[@id='ctl00_PlaceHolderPageTitleInTitleArea_onetidProjectPropertyTitleGraphic']/div");

        //18th Feb
        public static readonly By oJobTitleList_xpath = By.XPath("//div[contains(@id,'groupContent')]/child::*/div/div/div[2]/div[2]/div[1]");
        public static readonly By oNameList_xpath = By.XPath("//div[contains(@id,'groupContent')]/child::*/div/div/div[2]/div[1]/div/a");
    
    //21st Feb

        public static readonly By oAssetServicesChilds_xpath = By.XPath("//*[@class='ms-rte-embedcode ms-rte-embedwp']/nav-links-preview/div[2]/div[2]/div[1]/div[2]/child::*");
    // 27th Feb

        public static readonly By oDepartmentLinks_xpath = By.XPath("//*[@class='navLinksContainer']/div[2]/child::*/div/div[1]/a[1]");
        public static readonly By oDepartmentsTopNav_xpath = By.XPath("//*[@class='collapse navbar-collapse']/div[1]/ul/li[9]/a[1]");
        public static readonly By oDepartmentsPageTitle_id = By.XPath("//*[@id='DeltaPlaceHolderPageTitleInTitleArea']");
        public static readonly By oDepartmentsColumns_XPath = By.XPath("//*[@class='navLinksContainer']/div[2]/child::*");
        public static readonly By oChildLinks_class = By.XPath("//*[@class='link-tag child-link-tag ng-binding']");

        public static readonly By oafterhover_xpath = By.XPath("//*[contains(text(),'The following links take you to Intranet sites.')]");
        public static readonly By odepartmentTopNav_xpath = By.XPath("//*[@class='collapse navbar-collapse']/div[1]/ul/li[9]/a[1]");
        public static readonly By oresourcesTopNav_xpath = By.XPath("//*[@class='collapse navbar-collapse']/div[1]/ul/li[5]/a[1]");
        public static readonly By onewslink1_xpath = By.XPath("//*[@id='cbre-topnav']/div[1]/ul/li[3]/a[1]");
        public static readonly By osignout_xpath = By.XPath("//*[@id='hpnavsignout']");
        public static readonly By omegamenurightside_xpath = By.XPath("//*[@class='nav navbar-nav pull-right']");

        public static readonly By oApply_xpath = By.XPath("//*[@id='submit']/a[1]");
        public static readonly By oClear_xpath = By.XPath("//*[@id='submit']/a[2]");

        public static readonly By oApplyClear_xpath = By.TagName("a");

        //14th March

        public static readonly By oSelectSite_xpath = By.XPath("//*[@id='DeltaPlaceHolderPageTitleInTitleArea']/global-site-switcher/div/a");
        public static readonly By oSelectSiteDropDown_xpath = By.XPath("//*[@id='DeltaPlaceHolderPageTitleInTitleArea']/global-site-switcher/div/div[1]/a/div[1]");
        public static readonly By oSelectSiteFlyOut_xpath = By.XPath("//*[@id='DeltaPlaceHolderPageTitleInTitleArea']/global-site-switcher/div/div[2]");

        public static readonly By ochilds_xpath = By.XPath("//*[text()='Asset Services']/parent::*/child::*");
        public static readonly By prefilter_xpath = By.XPath("//span[@id='RemoveRefinerLink']");

        //10th April

        public static readonly By oSearchScope_xpath = By.XPath("//*[@id='MSOZoneCell_WebPartWPQ2']/div/div/div/ul/li/h2/a");
        public static readonly By oRefinerCategories_xpath = By.XPath("//*[@id='Refinement']/div/div/a/div[1]");

        public static readonly By osearchdropdownarrow_xpath = By.XPath("//*[@class='cbre-search-nav-icon']/span");
        public static readonly By ojustInImagestextheader_xpath = By.XPath("//ul[@id='bxslider']/li/div/h5/a");

        public static readonly By oNewsWebPart_xpath = By.XPath("//div[@class='news-wp']");
        public static readonly By oNewsAuthor_xpath = By.XPath("//div[@class='news-wp']/div/div[2]/div[2]/a");
        public static readonly By oNewsDate_xpath = By.XPath("//div[@class='news-wp']/div/div[2]/div[2]/span");

        
        public static readonly By oSearchResults = By.XPath("//div[contains(@id,'groupContent')]/div/div[1]");

        public static readonly By oshowmore = By.XPath("//div[text()='SHOW MORE']");
        public static readonly By olocationlistafterclickonshowmore = By.XPath("//div[@id='unselLongList']");

        public static readonly By oClearAll_xpath = By.XPath("//*[contains(text(),'Clear All')]");

        public static readonly By oWorkSchedule_id = By.XPath("//div[@id='workSchedule']");
        public static readonly By oWorkScheduleSubsections_xpath = By.XPath("//div[@id='workSchedule']/div/div[2]/div/div[1]");
        public static readonly By oWorkScheduleSubsectionsValue_xpath = By.XPath("//div[@id='workSchedule']/div/div[2]/div/div[2]");
    }
}
