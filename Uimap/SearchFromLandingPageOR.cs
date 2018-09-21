using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CRAFT.Uimap
{
    class SearchFromLandingPageOR
    {
        public static readonly By lnkSignOff = By.LinkText("Sign Out");
        public static readonly By searchdropdown = By.XPath("//a[@id='ctl00_PlaceHolderSearchArea_SearchBoxScriptWebPart_csr_NavButton']");
        //public static readonly By searchicon = By.XPath("//a[@id='ctl00_PlaceHolderSearchArea_SearchBoxScriptWebPart_csr_SearchLink']");
        public static readonly By searchicon = By.XPath("//*[@title='Search']");
        public static readonly By searchtext = By.XPath("//input[@id='ctl00_PlaceHolderSearchArea_SearchBoxScriptWebPart_csr_sbox']");
        public static readonly By event1 = By.XPath("//div[contains(text(),'Events')]");
        public static readonly By eventresult = By.XPath("//span[contains(text(),'Events Search Results')]");
        public static readonly By logoutlink = By.LinkText("Sign Out");
        public static readonly By osearchpagefilterwithAmerica_xpath = By.XPath("//div[contains(text(),'Americas')]");
        public static readonly By osearchpagefiltercountwithAmerica_xpath = By.XPath("//*[@id='RefinementCount']");
        public static readonly By oresultFilterAmericacountwebelement_xpath = By.XPath("//div[contains(@id,'groupContent')]/div[@name='Item']");
        public static readonly By osearchresultcount_xpath = By.XPath("//*[@id='ResultCount']");
        public static readonly By oclosefilter =
                By.XPath("//*[text()='Clear All']/parent::*/parent::*/parent::*/following-sibling::*/div/a/div[2]");
        public static readonly By oserviceLinesTopNav_xpath = By.XPath("//*[@class='collapse navbar-collapse']/div[1]/ul/li[7]/a[1]");
        public static readonly By odatemodifier_xpath = By.XPath("//div[contains(@id,'HistogramActiveBar1')]");
        public static readonly By oeventstabinsearchresultpage_xpath = By.XPath("//*[@class='ms-srchnav-link-selected']");
        public static readonly By oSkills_xpath = By.XPath("//div[contains(text(),'Skills')]");
        public static readonly By oAboutMe_xpath = By.XPath("//*[@id='aboutMe']/div/div[2]/div[1]/div[1]");
        public static readonly By oInterests_xpath = By.XPath("//div[contains(text(),'Interests')]");
        public static readonly By oSchools_xpath = By.XPath("//div[contains(text(),'Schools')]");
        public static readonly By oPastProjects_xpath = By.XPath("//div[contains(text(),'Past Projects')]");
        public static readonly By oAskMeAbout_xpath = By.XPath("//div[contains(text(),'Ask Me About')]");
        public static readonly By oEnglishTag_xpath = By.XPath("//*[contains(@id,'itembody')]/div/child::*[last()]");
        //9th Feb
        public static readonly By oAmericaTag_xpath = By.XPath("//*[contains(@id,'itembody')]/div[*]/span[1]");
        //10th Feb
        public static readonly By oIntranetPageLink_xpath = By.XPath("//div[contains(@id,'groupContent')]/child::*/div/div/div/div/div/a");
       
        //7th March

        public static readonly By oSearchScopes_xpath = By.XPath("//*[@id='MSOZoneCell_WebPartWPQ2']/div/div/div/ul/child::*/h2/a");
        public static readonly By oLocale_xpath = By.XPath("//*[@id='locale']/a");
        public static readonly By oLocaleDropDown_xpath = By.XPath("//div[@id='settings-menu']/select");

        // 8th March

        public static readonly By oSecondaryLanguages_xpath = By.XPath("//*[contains(@id,'MultiChoiceTable')]/tbody/tr/td/span/label");
        public static readonly By oSecondaryLanguageLabel_xpath = By.XPath("//*[contains(@id,'MultiChoiceTable')]/parent::*/parent::*/parent::*/td[1]/h3/nobr");
        public static readonly By oAddNewProvisioningList_class = By.XPath("//*[@class='ms-list-addnew-imgSpan20']");

        // 13th April

        public static readonly By oCzech_xpath = By.XPath("//a[text()='[Czech]']");
        public static readonly By oDansk_xpath = By.XPath("//a[text()='[Dansk]']");
        public static readonly By oDeutsch_xpath = By.XPath("//a[text()='[Deutsch]']");
        public static readonly By oEspanol_xpath = By.XPath("//a[text()='[Español]']");

        public static readonly By oHoverClose_class = By.XPath("//div[@class='ms-srch-hover-close']");
        public static readonly By oHoverTitle_class = By.XPath("//*[@class='ms-srch-hover-title ms-dlg-heading ms-srch-ellipsis']");
        public static readonly By oHoverView_class = By.XPath("//a[contains(text(),'view')]");

        public static readonly By oSearchError_class = By.XPath("//*[contains(@class,'ms-srch-error-header')]");

        public static readonly By oFeaturedNews_class = By.XPath("//*[@class='featured-news-title ng-binding']");

        public static readonly By oSiteTitleInput_title = By.XPath("//*[@title='Site Title Required Field']");
        public static readonly By oSiteContentOwnerDiv_title = By.XPath("//div[@title='Content Owners Required Field']");
        public static readonly By oSiteContentOwner_title = By.XPath("//input[contains(@title,'Content Owners Required Field')]");
        public static readonly By oSitePrimaryLanguage_title = By.XPath("//*[@title='Primary Language Required Field']");
        public static readonly By oRibbonItems_id = By.XPath("//*[@id='Ribbon.ListItem-title']/a/span[1]");
        public static readonly By oNewSiteLocation_title = By.XPath("//input[@title='New Site Location']");


    }
}
