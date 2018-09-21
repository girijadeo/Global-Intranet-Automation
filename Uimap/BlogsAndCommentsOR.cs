using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
namespace CRAFT.Uimap
{
    class BlogsAndCommentsOR
    {

        public static readonly By ocreatecbreintrablog_id = By.XPath("//*[@id='Ribbon.Document.All.NewDocument.Menu.ContentTypes.2-Menu32']");
        public static readonly By opagedesc_xpath = By.XPath("//textarea[contains(@name,'descriptionTextBox')]");
        public static readonly By opageurl_xpath = By.XPath("//input[contains(@name,'urlNameTextBox')]");
        public static readonly By opagelayout_xpath = By.XPath("//span[@title='Page Layout']");
        public static readonly By opagetitle_xpath = By.XPath("//input[contains(@name,'titleTextBox')]");

        public static readonly By oactivityfeed_xpath = By.XPath("//li[@role='presentation' and @class='active']/a");
        public static readonly By omyarticla_xpath = By.XPath("//div[@class='news-widget-title']//h3[text()='My Articles by Article Date ']");
        public static readonly By oadmincomment_xpath = By.XPath("//a[@aria-controls='Agengda']");
        public static readonly By otoday_xpath = By.XPath("//div[@class='news-widget-title']//h3[text()='Today']");
        public static readonly By oyesterday_xpath = By.XPath("//div[@class='news-widget-title']//h3[text()='Yesterday']");
        public static readonly By orescentactivity_xpath = By.XPath("//div[@class='news-widget-title']//h3[text()='Recent Activity Last 7 Days']");

        public static readonly By omostlikearticle_xpath = By.XPath("//span[@class='most-like-article-title']/a");
        public static readonly By oeditarticle_xpath = By.XPath("//b[text()='Edit Article: ']");
        public static readonly By oarticledate_xpath = By.XPath("//b[text()='Article Date: ']");
        public static readonly By oviewaticle_xpath = By.XPath("//b[text()='View Article: ']");
        public static readonly By oarticletype_xpath = By.XPath("//b[text()='Article Type: ']");
        public static readonly By ocreator_xpath = By.XPath("//b[text()='Creator: ']");
        public static readonly By olastmodified_xpath = By.XPath("//b[text()='Last Modified Date: ']");
        public static readonly By onewsfeedupdate_xpath = By.XPath("//ul[@class='news-widget-content news-feed-update']");
        public static readonly By oRecentActivity7Days_xpath = By.XPath("//*[contains(text(),'Recent Activity Last 7 Days')]");

        public static readonly By oArticleLikeCounts_xpath = By.XPath("//*[@class='complete-dashboard-container']/div[1]/div[1]/div[3]/ul/li/div");
        public static readonly By oArticleShowMore_xpath = By.XPath("//*[@class='complete-dashboard-container']/div[1]/div[1]/div[3]/div/button[1]");

        public static readonly By ocommenttextarea_xpath = By.XPath("//textarea[@data-ng-model='newComment']");
        public static readonly By opostcomment_xpath = By.XPath("//input[@value='Post Comment']");
        public static readonly By olikethumb_xpath = By.XPath("//span[@class='cbre-icon cbre-thumbs-o-up']");
        public static readonly By olikecount_xpath = By.XPath("//span[@class='like-count ng-binding']");
        public static readonly By odislikethumb_xpath = By.XPath("//span[@class='cbre-icon cbre-thumbs-up']");
        public static readonly By odeletecomment_xpath = By.XPath("//a[@class='delete']");
        public static readonly By odeletepopup_xpath = By.XPath("//div[@class='ui-dialog-buttonset']/button");
        public static readonly By ocomment_xpath = By.XPath("//a[@class='cbre-comment ng-binding']");

        public static readonly By oArticleComments_xpath = By.XPath("//ul[@class='comment-list']/li/div[1]/div[1]/div[3]/div[2]");

        public static readonly By oselectedmonth_xpath = By.XPath("//td[@class='ms-picker-monthselected']/a");
        public static readonly By omonths_xpath = By.XPath("//td[@class='ms-picker-monthcenter']/a");
        public static readonly By oweekdays_xpath = By.XPath("//th[@class='ms-acal-month-top']/nobr/span");
        //8th may
        public static readonly By onoresult_xpath = By.XPath("//div[text()='Nothing here matches your search']");
        //9th may 
        public static readonly By oclearrefiner_xpath = By.XPath("//div[@dataga='All' and @id='RefinementName']");
        public static readonly By oresultcount_xpath = By.XPath("//div[@id='ResultCount']");

        public static readonly By resultrow_xpath = By.XPath("//div[@class='ms-srch-ellipsis']");

        public static readonly By rserviceline_xpath = By.XPath("//div[@title='Target Service Line/Department']/div");

        public static readonly By ogearicon_xpath = By.XPath("//a[contains(@id,'SiteActionsMenu')]");

        public static readonly By oarticlepriority_xpath = By.XPath("//nobr[text()='Priority']/parent::li/span[1]");
        public static readonly By oclicktosave_xpath = By.XPath("//span[@class='ms-promotedActionButton-text' and text()='Save']");

        public static readonly By oLikeCount_xpath = By.XPath("//*[@id='bxslider']/li[5]/div/ul/li[2]");
        public static readonly By oReadMore_xpath = By.XPath("//*[@id='bxslider']/li[5]/div/a");

        public static readonly By onewsblock_xpath = By.XPath("//div[@class='srch-table ng-scope']");

        public static readonly By oreadmorelink_xpath = By.XPath("//a[text()='Read More']");
        public static readonly By oarticletopic_xpath = By.XPath("//h4[@id='ga-article-category']");
        public static readonly By oarticletitle_xpath = By.XPath("//h1[@id='ga-article-title']");
        public static readonly By odateofarticle_xpath = By.XPath("//a[@class='article-author-greentxt ng-binding']//parent::*[a]/parent::*[span]");
        public static readonly By oshare_id = By.XPath("//a[@id='cbre-share-article']");
        public static readonly By ocommentonnew_xpath = By.XPath("//a[@class='cbre-comment ng-binding']");
        public static readonly By olike_xpath = By.XPath("//span[@class='cbre-icon cbre-thumbs-o-up']");

        public static readonly By ocreatecbreintranews_xpath = By.XPath("//*[@id='Ribbon.Document.All.NewDocument.Menu.ContentTypes.1-Menu32']/span[4]");
        public static readonly By oarticlenewstopic_xpath = By.XPath("//input[contains(@title,'Article Topic')]");
        public static readonly By oarticlesubheader_xpath = By.XPath("//input[contains(@title,'Article Sub headline')]");
        public static readonly By oarticlenewsdate_xpath = By.XPath("//input[contains(@title,'Article Date')]");
        public static readonly By opublishenddate_xpath = By.XPath("//input[contains(@title,'Publish End Date')]");
        public static readonly By opublishstartdate_xpath = By.XPath("//input[contains(@title,'Publish Start Date')]");
        public static readonly By osavenewsdetialform_xpath = By.XPath("//span[@class='ms-promotedActionButton-text' and text()='Save']");
        public static readonly By oclicktopage_xpath = By.XPath("//span[@class='ms-cui-tt-span' and text()='Page']");
        public static readonly By oloadmorenews_xpath = By.XPath("//input[@value='Load More News']");

        public static readonly By ositestatus_xpath = By.XPath("//h3[text()='Status']/parent::*/parent::*/td[2]");
        public static readonly By odeleteitem_xpath = By.XPath("//span[text()='Delete Item']");
        //24th may
        public static readonly By ocbreintraorg_xpath = By.XPath("//a[@title='CBRE Intranet Org Comments']");
        public static readonly By ocustomlink_xpath = By.XPath("//a[@title='Custom Links']");
        public static readonly By odocument_xpath = By.XPath("//a[@title='Documents']");
        public static readonly By oimages_xpath = By.XPath("//a[@title='Images']");
        public static readonly By opages_xpath = By.XPath("//a[@title='Pages']");
        public static readonly By oquicklink_xpath = By.XPath("//a[@title='Quick Links']");
        public static readonly By oworkflow_xpath = By.XPath("//a[@title='Workflow Tasks']");
        public static readonly By oevent_xpath = By.XPath("//a[@title='Events']");
        public static readonly By ositesetup_xpath = By.XPath("//a[@title='Intranet Site Setup']");
        public static readonly By opeoplelist_xpath = By.XPath("//a[@title='People List']");
        public static readonly By ositecontents_xpath = By.XPath("//a[@title='Site Contacts']");

        public static readonly By otwitterblock_xpath = By.XPath("//li[@class='timeline-TweetList-tweet customisable-border']");

        public static readonly By oprimaryservices_xpath = By.XPath("//div[@title='Primary Service']/div");
        public static readonly By otargetlocation_xpath = By.XPath("//div[@title='Target Location']/div");
        public static readonly By otargetlocationgroup_xpath = By.XPath("//div[@title='Target Location Group']/div");
        public static readonly By ofterhovermegamenu_xpath = By.XPath("//*[contains(text(),'The following links take you to Intranet sites.')]");
        public static readonly By omegamenuformaxico_xpath = By.XPath("//*[contains(text(),'Los siguientes enlaces lo llevan a sitios de Intranet')]");
        //31 may 
        public static readonly By oonemoreitem_xpath = By.XPath("//a[text()='1 more item']");

        public static readonly By odoctitle_xpath = By.XPath("//th[text()='Title']");
        public static readonly By odocmodifieddate_xpath = By.XPath("//th[text()='Modified Date']");
        public static readonly By odocmodifiedby_xpath = By.XPath("//th[text()='Modified By']");
        public static readonly By odoclanguage_xpath = By.XPath("//th[text()='Language']");

        public static readonly By oBrightcoveaccount_xpath = By.XPath("//label[contains(text(),'Brightcove Account')]");
        public static readonly By ovideoid_xpath = By.XPath("//label[contains(@title,'Video ID')]");

    }
}
