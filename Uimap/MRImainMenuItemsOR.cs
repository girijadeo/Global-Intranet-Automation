using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CRAFT.Uimap
{
    class MRImainMenuItemsOR
    {
        public static readonly By oAccountsPayable_linkText = By.LinkText("Accounts Payable");
        public static readonly By oCommercialManagement_xpath = By.XPath("//div[text()='Commercial Management']");
        public static readonly By oCorporateAR = By.LinkText("Corporate AR");
        public static readonly By oGeneralLedger_linkText = By.LinkText("General Ledger");
        public static readonly By oJobCost_linkText = By.LinkText("JobCost");
    }
}
