using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Remote;
using Framework_Core;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;
using System.IO;

namespace CRAFT.SupportLibraries
{
    /// <summary>
    /// Factory for creating the Driver object based on the required browser
    /// </summary>
    public class WebDriverFactory
    {
        public static bool driverquitstatus = true;
        /// <summary>
        ///  Function to return the appropriate RemoteWebDriver object based on the Browser passed
        /// </summary>
        /// <param name="browser">The Browser to be used for the test execution</param>
        /// <returns>The RemoteWebDriver object corresponding to the Browser specified</returns>
        public static RemoteWebDriver GetDriver(Browser browser)
        {
            RemoteWebDriver driver = null;
           
            switch (browser)
            {
                case Browser.chrome:
                    System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", ConfigurationManager.AppSettings["ChromeDriverPath"]);
                    string chrome = ConfigurationManager.AppSettings["ChromeDriverPath"];
                    //DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                    //ChromeOptions options = new ChromeOptions();
                    //capabilities.SetCapability(CapabilityType.Version, "56");
                   // capabilities.SetCapability(ChromeOptions.Capability, options);
                   // options.AddAdditionalCapability(CapabilityType.Version, "44");
                   // ChromeOptions options = new ChromeOptions();
                   // options.AddArgument("incognito");
                   // var capabilities = options.ToCapabilities();
                    driver = new ChromeDriver(Path.GetDirectoryName(chrome));
                    break;
                case Browser.firefox:
                    driver = new FirefoxDriver();
                    break;
                case Browser.htmlunit:
                    driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnit());
                    break;
                case Browser.iexplore:


                   
                    System.Environment.SetEnvironmentVariable("webdriver.ie.driver", ConfigurationManager.AppSettings["InternetExplorerDriverPath"]);
                    string ie = ConfigurationManager.AppSettings["InternetExplorerDriverPath"];
                    
                    driver = new InternetExplorerDriver(Path.GetDirectoryName(ie));
                    break;
                case Browser.opera:
                    driver = new RemoteWebDriver(DesiredCapabilities.Opera());
                    break;
            }

            return (RemoteWebDriver)driver;
        }
    }
}
