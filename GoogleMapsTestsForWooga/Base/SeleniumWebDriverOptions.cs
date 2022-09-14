using GoogleMapsTestsForWooga.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace GoogleMapsTestsForWooga.Base
{
    public abstract class SeleniumWebDriverOptions : SeleniumWebDriverContainer
    {
        public BrowserType Browser;
        protected readonly GoogleMapsPage GoogleMapsPage;

        protected SeleniumWebDriverOptions(BrowserType type) : base(CreateWebDriver(type))
        {
            Browser = type;
            GoogleMapsPage = new GoogleMapsPage(Driver);
        }

        //Creating WebDriver here depends on browser
        private protected static IWebDriver CreateWebDriver(BrowserType type)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    driver = ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = FirefoxDriver();
                    break;
            }

            return driver;
        }

        //Firefox preferences
        private static IWebDriver FirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("cssSelectorsEnabled", true);
            options.SetPreference("intl.accept_languages", "en-GB");
            IWebDriver driver = new FirefoxDriver(options);
            return driver;
        }

        //Chrome preferences
        private static IWebDriver ChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=en-EN");
            IWebDriver driver = new ChromeDriver(options);
            
            return driver;
        }

        //Browsers
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        [OneTimeSetUp]
        public virtual void Setup()
        {
            const string baseUrl = "https://maps.google.com";
            Driver.Navigate().GoToUrl(baseUrl);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public virtual void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
