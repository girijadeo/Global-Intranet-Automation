using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CRAFT.Uimap
{
    class VisitorProfileOR
    {

        public static readonly By Omyprofilelink_xpath = By.XPath("//*[@id='cbre-suitebar']/div/ul/li[3]/a");
        public static readonly By Osomeoneelslink_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[3]/div/div[2]/ul/li/div/div/div[1]/a");
        public static readonly By Oeditlink_xpath = By.XPath("//*[@id='aboutMe']/div/div[1]/a");
        public static readonly By OworkScheduleeditlink_xpath = By.XPath("//*[@id='workSchedule']/div/div[1]/a");
        public static readonly By Oweekrow1_xpath = By.XPath("//*[@id='workSchedule']/div/div[3]/div/div[1]/div/div[1]/div");
        public static readonly By Oweekrow2_xpath = By.XPath("//*[@id='workSchedule']/div/div[3]/div/div[1]/div/div[2]/div");
        public static readonly By Ostarttimelabel_xpath = By.XPath("//*[@id='workSchedule']/div/div[3]/div/div[2]/div/div[1]/div[1]");
        public static readonly By Oendtimelabel_xpath = By.XPath("//*[@id='workSchedule']/div/div[3]/div/div[2]/div/div[2]/div[1]");
        public static readonly By Ostarttimedropdownvalues_xpath = By.XPath("//*[text()='Start time:']/../child::*[last()]/select");
        public static readonly By Oendtimedropdownvalues_xpath = By.XPath("//*[text()='End time:']/../child::*[last()]/select");
        public static readonly By Otimezonelabel_xpath = By.XPath("//*[@id='workSchedule']/div/div[3]/div/div[3]/div[1]");
        public static readonly By Otimezonedropdownvalue_xpath = By.XPath("//*[@id='timezone']");
        public static readonly By Olocationeditlink_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[1]/a");
        public static readonly By Oaddress_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[1]/div[1]");
        public static readonly By Ofloortextarea_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[2]/input");
        public static readonly By OSavelocation_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[4]/a[2]");
        public static readonly By Olocatiocodelabel_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[3]/label");
        public static readonly By Olocatiocodevalue_xpath = By.XPath("//*[@id='profile']/div[2]/div/div[1]/div/div[3]/div/div[3]/label/following-sibling::*");
        public static readonly By Oworkshedulesavelink_xpath = By.XPath("//*[@id='workSchedule']/div/div[3]/div/div[4]/a[2]");
        public static readonly By Oblankworkingday_xpath = By.XPath("//*[@id='workSchedule']/div/div[2]/div[1]/div[2]");
        public static readonly By Ohavequestion_xpath = By.XPath("//*[@id='footerContact']/div/div/div/span");
        public static readonly By Ohavequestionlinksvalue_xpath = By.XPath("//*[@id='footerContact']/div/div/div/a");
        public static readonly By Ocannotfinlink = By.XPath("//*[@id='cbre-footer']/div[2]/footer/div[3]/div[2]/div/div[3]/a");
        public static readonly By Opageheadlineheader_xpath = By.XPath(" //*[@id='Page Headline']");
        public static readonly By Ovideotitlle_xpath = By.XPath("//*[contains(@id,'player_uid')]/div[3]/div[1]/div/a");
        public static readonly By Ocbreheader_xpath = By.XPath("//*[@id='full-size-brand']/img");
        public static readonly By oexperienceServiceseditlink_xpath = By.XPath(" //*[@id='experienceServices']/child::*/child::*/a");
        public static readonly By oexperienceServicesskill_xpath = By.XPath("//*[text()='Skills']/parent::*/child::*[3]//input");
        public static readonly By oexperienceServicessavebtn_xpath = By.XPath("//*[text()='Skills']/parent::*/following-sibling::*[last()]/a[last()]");
        public static readonly By oexperienceServicesskilltext_xpath = By.XPath("//*[text()='Skills']/following-sibling::*/span");
        //public static readonly By oexperienceServicesskillremove_xpath = By.XPath("//*[@class='remove-button ng-binding ng-scope']");
        public static readonly By oexperienceServicesskillremove_xpath = By.XPath("//*[text()='Skills']/parent::*/child::*[3]//input/parent::*/ul/child::*[1]/child::*/child::*[1]/a");

        public static readonly By Owhatisnew_xpath = By.XPath("//div/web-part/wp-whats-new");
        public static readonly By Owhatisnewoption_xpath = By.XPath("//div/web-part/wp-whats-new/list-view/div/table/tbody/tr");

        public static readonly By Oquicklinks_xpath = By.XPath("//*[@id='rightContentColumn']/wp-quick-links/list-view/div/h4");
        public static readonly By Oquicklinksoption_xpath = By.XPath("//*[@id='rightContentColumn']/wp-quick-links/list-view/div/h4/parent::*/table/tbody/tr");
        public static readonly By Opopular_text = By.XPath("//h4[text()='Popular Items']");
        public static readonly By Oducuments_text = By.XPath("//*[text()='Documents']");

        public static readonly By Ofooter_id = By.XPath("//*[@id='cbre-footer']");

    }
}
