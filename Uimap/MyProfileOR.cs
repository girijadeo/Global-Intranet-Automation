using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CRAFT.Uimap
{
    class MyProfileOR
    {

        public static readonly By oProfile_xpath = By.XPath("//*[@id='DeltaPlaceHolderPageTitleInTitleArea']");
        public static readonly By oExpService_xpath = By.XPath("//div[contains(text(),'Experience & Services')]");
        public static readonly By oExpServiceEdit_xpath = By.XPath("//*[@id='experienceServices']/div/div[1]/a");
        public static readonly By oSkillsLabel_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div[1]/div[1]");
        public static readonly By oPastProjectLabel_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div[2]/div[1]");

        public static readonly By oSkillsInputField_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[1]/enterprise-keywords-input/tags-input/div/div/input");
        public static readonly By oPastprojectInputField_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[2]/enterprise-keywords-input/tags-input/div/div/input");

        public static readonly By oSkillAutoComplete_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[1]/enterprise-keywords-input/tags-input/div/auto-complete/div/ul/li/ti-autocomplete-match/ng-include/span/em");
        public static readonly By oSelectedSkill_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[1]/enterprise-keywords-input/tags-input/div/div/ul/li/ti-tag-item/ng-include/span");
        public static readonly By oSave_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[4]/a[2]");

        public static readonly By oSkillUpdateOnProfilePage_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div[1]/div[2]/span");

        public static readonly By oSkillRemoveCross_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[1]/enterprise-keywords-input/tags-input/div/div/ul/li/ti-tag-item/ng-include/a");

        public static readonly By oPastProjectsInputField_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[2]/enterprise-keywords-input/tags-input/div/div/input");

        public static readonly By oPastProjectUpdateOnProfilePage_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div[2]/div[2]/span");

        public static readonly By oPastProjectRemoveCross_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[2]/enterprise-keywords-input/tags-input/div/div/ul/li/ti-tag-item/ng-include/a");

        public static readonly By oPastProjectAutoComplete_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[2]/enterprise-keywords-input/tags-input/div/auto-complete/div/ul/li[1]/ti-autocomplete-match/ng-include/span/em");

        public static readonly By oSelectedPastProject_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[2]/enterprise-keywords-input/tags-input/div/div/ul/li/ti-tag-item/ng-include/span");

        public static readonly By oErrorMessage_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/p");

        public static readonly By oCancelButton_xpath = By.XPath("//*[@id='experienceServices']/div/div[2]/div/div[4]/a[1]");

        public static readonly By oOrgChartLabel_xpath = By.XPath("//div[contains(text(),'Org Chart')]");
        public static readonly By oOrgChart_xpath = By.XPath("//*[@class='org-chart']");
        public static readonly By oImagePlaceHolder_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[3]/div/div[2]/ul/li/div/img");
        public static readonly By oOrgChartName_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[3]/div/div[2]/ul/li/div/div/div[1]/a");
        public static readonly By oOrgChartTitle_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[3]/div/div[2]/ul/li/div/div/div[2]");
        public static readonly By oOrgChartPeoplelist_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[3]/div/div[2]/ul/li/child::*");
        public static readonly By oSupervisorName_xpath = By.XPath("//*[@id='profile']/div[1]/div/div[1]/div/div[2]/span");


        public static readonly By oFootercontent_xpath = By.XPath("//*[@id='cbre-footer']/div/footer/div[3]/div[2]/div/div[2]/child::*");

        public static readonly By oCorporateInformationFooter_xpath = By.XPath("//*[@id='cbre-footer']/div/footer/div[3]/div[2]/div/div[3]/child::*");

        public static readonly By oAccountManagementFooter_xpath = By.XPath("//*[@id='cbre-footer']/div/footer/div[3]/div[2]/div/div[4]/child::*");

        public static readonly By oCollaborationToolsFooter_xpath = By.XPath("//*[@id='cbre-footer']/div/footer/div[3]/div[2]/div/div[5]/child::*");

        public static readonly By oAboutUsFooter_xpath = By.XPath("//*[@id='cbre-footer']/div/footer/div[3]/div[2]/div/div[3]/a[2]");
        public static readonly By oCorporateResponsibility_xpath = By.XPath("//*[@id='cbre-footer']/div/footer/div[3]/div[2]/div/div[3]/a[4]");
        public static readonly By oResources_xpath = By.XPath("//*[@id='cbre-footer']/div/footer/div[3]/div[2]/div/div[2]/a[3]");

        //6th Feb 2017

        public static readonly By oEditContactInformation_xpath = By.XPath("//*[@id='contactInfo']/div/div[1]/a");
        public static readonly By oContactInformationcontents_xpath = By.XPath("//*[@id='contactInfo']/div/div[3]/div/child::*/label");
        public static readonly By oEditInHRcontents_xpath = By.XPath("//*[@id='edit-in-my-hr']");
        public static readonly By oReadOnlycontents_xpath = By.XPath("//*[@id='contactInfo']/div/div[3]/div/div[*]/div");
        public static readonly By oSaveContactInformation_xpath = By.XPath("//*[@id='contactInfo']/div/div[3]/div/div[7]/a[2]");
        public static readonly By OManager_xpath = By.XPath("//*[@id='contactInfo']/div/div[3]/div/div[5]/div/a");
        public static readonly By OAssistantInputField_xpath = By.XPath("//*[@id='assistantPeoplePicker_TopSpan']");
        public static readonly By OAssistantInput_xpath = By.XPath("//*[@id='assistantPeoplePicker_TopSpan_EditorInput']");
        public static readonly By OAssistantAutoPopulate_xpath = By.XPath("//*[@id='assistantPeoplePicker_TopSpan_AutoFillDiv_MenuList']/li[1]/a/div[1]");
        public static readonly By OAssistantNameSelected_xpath =By.XPath("//span[contains(text(),'DHAR, MANIK @ CBRE Contractor')]");
        public static readonly By OAssistantDeleteIcon_xpath = By.XPath("//a[@class = 'sp-peoplepicker-delImage']");
        public static readonly By OAssistantName_xpath = By.XPath("//*[@id='contactInfo']/div/div[2]/div[3]/div/div[2]/div[2]/a");
        public static readonly By OBlankAssistantName_xpath = By.XPath("//*[@id='contactInfo']/div/div[2]/div[3]/div/div[2]/div[2]");
        public static readonly By OProfile_xpath = By.XPath("//*[@id='profile']/child::*");
        public static readonly By OProfileDetails_xpath = By.XPath("//*[@id='profile']/div[1]/div/child::*");
        public static readonly By OProfileImage_xpath = By.XPath("//*[@id='profile']/div[1]/div/div[1]/div/div[1]/img");

        //7th Feb

        public static readonly By OMyProfileRightSection_xpath = By.XPath("//*[@id='workSchedule']/parent::*/child::*/div/div[1]");
        public static readonly By oOfficeLocationEdit_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[1]/a");
        public static readonly By oSaveOfficeLocation_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[4]/a[2]");

        public static readonly By oOfficeLocationContents_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[*]/label");
        public static readonly By oAddress_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[1]/div[2]");
        public static readonly By oFloor_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[2]/input");
        public static readonly By oLocationCode_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[3]/div");

        public static readonly By oFloorNumberInMyProfile_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[2]/div[2]/div[2]/div");
        //public static readonly By oDownloadContact_xpath = By.XPath("//*[contains(text(),'Download Contact')]");
        public static readonly By oDownloadContact_xpath = By.XPath("//*[@class='col-sm-5 hidden-sm hidden-xs']");

        //14th Feb

        public static readonly By oEmailID_xpath = By.XPath("//*[@id='contactInfo']/div/div[2]/div[2]/div/div[1]/div[2]/a");

        public static readonly By oAddressList_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[2]/div[2]/div[2]/child::*");

    //27th Feb

        public static readonly By oGoogleMap_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[2]/div[1]/profile-map");
    
    //5th April

        public static readonly By oContactRegions_xpath = By.XPath("//*[@class='ms-rteTable-0']/tbody/tr[1]/child::*");

        public static readonly By oLinkedinUrl_xpath = By.XPath("//div[contains(text(),'LinkedIn')]/parent::*/div[2]/a");
        public static readonly By oTwitterUrl_xpath = By.XPath("//div[contains(text(),'Twitter')]/parent::*/div[2]/a");
        public static readonly By oWebsiteUrl_xpath = By.XPath("//div[contains(text(),'Website')]/parent::*/div[2]/a");
    }
}
