using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
namespace CRAFT.Uimap
{
    class LinksOR
    {

        public static readonly By oeditlink = By.XPath("//*[text()='Edit Links']");
        public static readonly By oaddlink = By.XPath("//*[contains(@id, 'AddLink')]");
        public static readonly By otexttobedisplayed = By.XPath("//label[text()='Text to display']/parent::*/input");
        public static readonly By oaddress = By.XPath("//label[text()='Address']/parent::*/input");
        public static readonly By ookbutton = By.XPath("//*[@id='OKButton']");
        public static readonly By osavebutton = By.XPath("//*[contains(@id, 'SaveButton')]");
        public static readonly By oallQuickLaunchMenuitemname = By.XPath("//*[contains(@id, 'QuickLaunchMenu')]/table/tr/td[1]/a/span/span");
        public static readonly By oallQuickLaunchMenuitemcross = By.XPath("//*[contains(@id, 'QuickLaunchMenu')]/table/tr/td[2]/a");
        public static readonly By oiframe = By.XPath("//iframe");
        public static readonly By oalllinkname = By.XPath("//*[@class='menu-item-text']");
        public static readonly By oalllink = By.XPath("//*[@class='menu-item-text']/parent::*/parent::*");
        public static readonly By opublishedInfo = By.XPath("//*[@class='publishedInfo']");
        public static readonly By opublishedAuthor = By.XPath("//*[@class='publishedAuthor editor-name']");
        //27 feb
        public static readonly By oleftnav_id = By.XPath("//*[@id='leftNavColumn']");
        public static readonly By omobileview_id = By.XPath("//a[@data-original-title='Mobile Preview']");
        public static readonly By otabletlandscape_id = By.XPath("//a[@data-original-title='Tablet Landscape Preview']");
        public static readonly By otabletportrait_id = By.XPath("//a[@data-original-title='Tablet Portrait Preview']");
        public static readonly By ofooter_id = By.XPath("//*[@id='cbre-footer']");
        public static readonly By otopnavitems_id = By.XPath("//*[@class='nav navbar-nav']/li/a");
        public static readonly By omegamenuitems_id = By.XPath("//*[@class='nav navbar-nav pull-right']/li/a");
        public static readonly By oeditpage_xpath = By.XPath("//*[text()='Edit page']");
        public static readonly By oadmin_xpath = By.XPath("//*[text()='Admin']");
        public static readonly By odeletepage_xpath = By.XPath("//*[@id='Ribbon.WikiPageTab.Manage.DeletePage-Medium']/span[2]");
        //28th Feb
        public static readonly By orefinesearchtext_xpath = By.XPath("//*[contains(text(),'Refine your search')]");

        //29th March
        public static readonly By oPageTitle_xpath = By.XPath("//*[@id='DeltaPlaceHolderPageTitleInTitleArea']/span/span/a");
        public static readonly By oSelectLinks_xpath = By.XPath("//*[@id='scriptWPQ2']/table/tbody/tr/td[1]");
        public static readonly By oSiteTitles_xpath = By.XPath("//*[@id='scriptWPQ2']/table/tbody/tr/td[3]/div/a");
        public static readonly By oSiteTitleHeader_xpath = By.XPath("//*[@id='scriptWPQ2']/table/thead/tr/th[3]/div[1]/a");
        public static readonly By oItems_xpath = By.XPath("//li[@title='Items']");
        public static readonly By oEditItems_id = By.XPath("//*[@id='Ribbon.ListItem.Manage.EditProperties-Large']");
        public static readonly By oActionDropDown_xpath = By.XPath("//select[@title='Action']");
        //6th april
        public static readonly By omegamenu_Xpath = By.XPath("//*[@class='nav navbar-nav pull-right']/li/a[1]");
        public static readonly By ojshare_xpath = By.XPath("//a[text()=' シェア']");
        public static readonly By ojcomment_xpath = By.XPath("//li[contains(text(),'コメント')]");
        public static readonly By oreadmore_xpath = By.XPath("//a[text()='詳細を見る']");
        //12th april
        public static readonly By oprevslider_xpath = By.XPath("//a[@class='prev']");
        public static readonly By onextslider_xpath = By.XPath("//a[@class='next']");
        public static readonly By oreadmoreslider_xpath = By.XPath("//div[@class='slider-viewport']/ul/li/featured-news-item/p/a");
        public static readonly By oslidernumber_xpath = By.XPath("//div[@class='page ng-binding']");
        public static readonly By oblogpost_id = By.XPath("//*[@id='ngWebPartsControl_numberOfArticlesDisplayed']");
        public static readonly By oblogtimeperiod_id = By.XPath("//*[@id='ngWebPartsControl_blogDateRange']");

        public static readonly By oblogdisplaytype_id = By.XPath("//*[@id='ngWebPartsControl_displayview']");
        public static readonly By oblogcategoryfilter_id = By.XPath("//*[@id='ngWebPartsControl_categories']");
        public static readonly By onewsbannercomment_id = By.XPath("//div[@class='featured-news-slider']//a[contains(text(),'Comments')]");
        public static readonly By onewscarouselcomment_xpath = By.XPath("//div[@class='bx-wrapper']//a[contains(text(),'Comments')]");
        public static readonly By oviewallnews_xpath = By.XPath("//a[contains(text(),'View All News')]");
        public static readonly By onewtitleonNewsFeedpage_xpath = By.XPath("//div[@class='ms-srch-ellipsis']/a");
        public static readonly By ocommenttextarea_xpath = By.XPath("//textarea[@class='comment-area ng-pristine ng-valid ng-touched']");

        public static readonly By onewscarouselreadmore_xpath = By.XPath("//a[@class='text-uppercase ng-binding']");

        public static readonly By oNewSiteLocation_xpath = By.XPath("//*[@id='scriptWPQ2']/table/tbody/tr/td[2]/a");

        public static readonly By oProvisionSiteRows_xpath = By.XPath("//*[@class='ms-listviewtable']/tbody/tr");
    }
}
