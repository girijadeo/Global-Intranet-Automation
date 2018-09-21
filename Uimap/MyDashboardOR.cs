using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CRAFT.Uimap
{
    class MyDashboardOR
    {

        public static readonly By oMyDashboard_xpath = By.XPath("//a[contains(text(),'My Dashboard')]");
        public static readonly By oMyDashboardonMyDashboardPage_xpath = By.XPath("//span[contains(text(),'My Dashboard')]");
        public static readonly By oAdministerComments_xpath = By.XPath("//a[contains(text(),'Administer Comments')]");
        public static readonly By o30days_xpath = By.XPath("//*[@id='report-dashboard']/div[1]/div[1]/div/div[1]/div[1]/label[3]");

        //14th Feb

        public static readonly By oContentAuthAmericanSite_xpath = By.XPath("//*[@id='WebPartWPQ2']/div[2]/ul/li[1]/div/div/a");
        
        public static readonly By oCreateArticle_xpath = By.XPath("//*[@id='WebPartWPQ2']/div[1]/div[4]/ul/li[1]/a");
        
        public static readonly By oCreatePageTitle_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_pageTitleSection_ctl01_titleTextBox']");
        public static readonly By oCreatePageDesc_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_pageTitleSection_ctl02_descriptionTextBox']");
        public static readonly By oCreateButton_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_RptControls_buttonCreatePage']");

        //public static readonly By oNewsDetail_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl00_ctl00_TextField']");
        public static readonly By oNewsDetail_id = By.XPath("//*[@title='Article Topic Required Field']");
        public static readonly By oArticleAuthor_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl07_ctl00_UserField_upLevelDiv']");
        //public static readonly By oArticleDate_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl10_ctl00_DateTimeField_DateTimeFieldDate']");
        public static readonly By oArticleDate_id = By.XPath("//*[@title='Article Date Required Field']");
        public static readonly By oPageContent_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl12_RichHtmlField_displayContent']");
        public static readonly By oPageContentField_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl12_RichHtmlField']");
        public static readonly By oArticleSubHeadLine_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl15_ctl00_TextField']");
        public static readonly By oPublishStartDate_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl18_ctl00_DateTimeField_DateTimeFieldDate']");
        public static readonly By oPublishEndDate_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl21_ctl00_DateTimeField_DateTimeFieldDate']");
        public static readonly By oPageExpirationDate_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl24_ctl00_DateTimeField_DateTimeFieldDate']");
        public static readonly By oTargetGeography_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl27_ctl02editableRegion']");
        public static readonly By oLocationGroup_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl30_ctl02editableRegion']");
        public static readonly By oTargetService_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl33_ctl02editableRegion']");
        public static readonly By oPriorityCheckbox_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl36_ctl00_BooleanField']");
        public static readonly By oAllowCommentCheckbox_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl00_ctl39_ctl00_BooleanField']");
        public static readonly By oCheckItIn_id = By.XPath("//a[contains(text(),'Check it in')]");

        public static readonly By oCommentCheckinPopUp_id = By.XPath("//*[@id='checkincomments']");
        public static readonly By oCheckinPopUpContinueButton_id = By.XPath("//*[@id='statechangedialog_okbutton']");

        public static readonly By oPublishIt_id = By.XPath("//a[contains(text(),'Publish it')]");

        public static readonly By oStart_id = By.XPath("//*[@id='ctl00_PlaceHolderMain_XmlFormControl_V1_I1_B7']");

        public static readonly By oApproveIt_id = By.XPath("//a[contains(text(),'Approve it')]");

        public static readonly By oLike_XPath = By.XPath("//*[@class='cbre-icon cbre-thumbs-o-up']");
        public static readonly By oCommentFlag_XPath = By.XPath("//*[@id='ctl00_PlaceHolderMain_ctl01_SPSecurityTrimmedControl1']/div/ul/li[10]");

        public static readonly By oSettings_XPath = By.XPath("//*[@id='suiteBarButtons']/span/span[2]");
        public static readonly By oPageTopNav_XPath = By.XPath("//*[@id='Ribbon.WikiPageTab-title']/a/span[1]");
        public static readonly By oDeletePage_XPath = By.XPath("//*[contains(text(),'Delete Page')]");
        
        //20th Feb

        public static readonly By oCreateNavLink_xpath = By.XPath("//*[contains(text(),'Create Nav Link')]");
        public static readonly By oNavLinkTitle_xpath = By.XPath("//*[@class='ms-formtable']/tbody/tr[1]/td[2]/span/input");
        public static readonly By oNavLinkURL_xpath = By.XPath("//*[@class='ms-formtable']/tbody/tr[2]/td[2]/span[1]/input");
        public static readonly By oShowInNavigationCheckbox_xpath = By.XPath("//input[contains(@title,'Show In Navigation')]");
        public static readonly By oNavLinkTargetGeography_xpath = By.XPath("//*[@id='IntranetLocations_$containereditableRegion']");
        public static readonly By oNavLinkType_xpath = By.XPath("//*[contains(@title,'Link Type')]");
        public static readonly By osaveButtonList_xpath = By.XPath("//input[contains(@value,'Save')]");
        public static readonly By oNavLinkApprovalStatus_xpath = By.XPath("//*[@id='js-listviewthead-WPQ2']/tr/th[4]/div/a");
        public static readonly By oNavLinkList_xpath = By.XPath("//table[@class='ms-listviewtable']/tbody/tr/td[2]/div/a");
        public static readonly By oApproveRejectNavLink_xpath = By.XPath("//*[contains(text(),'Approve/Reject')]");
        public static readonly By oApproveRadioButton_xpath = By.XPath("//input[contains(@id,'RadioBtnApprovalStatus_0')]");
        public static readonly By oOKButton_xpath = By.XPath("//input[contains(@value,'OK')]");

        public static readonly By oViewNavLink_xpath = By.XPath("//*[contains(text(),'View Nav Links')]");
        public static readonly By oTitleSort_xpath = By.XPath("//*[@id='js-listviewthead-WPQ2']/tr/th[2]/div/a");
        public static readonly By oDeleteItem_xpath = By.XPath("//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]");

        public static readonly By oCommentAuthor_xpath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[1]/div/h4/a");
        public static readonly By oCommentReply_xpath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[2]/div[2]/a[3]");
        public static readonly By oCommentArea_xpath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[4]/div/div[2]/div/textarea");
        public static readonly By oPostReplyButton_xpath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[4]/div/div[2]/input");
        public static readonly By oCommentCount_class = By.XPath("//*[@class='cbre-comment ng-binding']");
        public static readonly By oCommentDelete_xpath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[2]/div[2]/a[2]");
        public static readonly By oCommentReport_xpath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[2]/div[2]/a[1]");
        public static readonly By oSignOut_id = By.XPath("//*[@id='hpnavsignout']");
        public static readonly By oComments_xpath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[3]/div[2]");
        public static readonly By olinks_xpath = By.XPath("//*[@class='comment-list']/child::*/div/div/div[2]/div[2]/a");
        public static readonly By odialogBox_class = By.XPath("//*[@class='ui-dialog-buttonset']");
        public static readonly By oYes_xpath = By.XPath("//button[text()='Yes']");


        public static readonly By oNewsPageLayouts_xpath = By.XPath("//select[@title='Page Layout']/child::*");
        public static readonly By oAlternateLink_xpath = By.XPath("//*[@title='Alternate Link']");
        public static readonly By oAlternateType_xpath = By.XPath("//*[contains(@title,'Alternate Type')]");

        public static readonly By oLocationSelect_xpath = By.XPath("//nobr[contains(text(),'Location Group')]/parent::*/span/span/div[1]/div[1]/img");
        public static readonly By oAmerica_xpath = By.XPath("//span[contains(text(),'Americas')]");
        public static readonly By oAsiaPacific_xpath = By.XPath("//span[contains(text(),'Asia Pacific')]");
        public static readonly By oEMEA_xpath = By.XPath("//span[contains(text(),'EMEA')]");
        public static readonly By oCancelButton_xpath = By.XPath("//*[@id='CancelButton']");
        public static readonly By oLocationGroup_xpath = By.XPath("//*[@title='Location Group']");
    }
}
