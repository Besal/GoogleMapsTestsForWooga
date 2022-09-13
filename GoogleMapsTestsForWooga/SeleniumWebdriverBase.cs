using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GoogleMapsTestsForWooga
{
    public abstract class SeleniumWebdriverBase
    {
        public BrowserType Browser;

        protected SeleniumWebdriverBase(BrowserType type)
        {
            Browser = type;
        }

        private static IWebDriver CreateWebDriver(BrowserType type)
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

        private static IWebDriver FirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("pageLoadStrategy", "eager");
            options.SetPreference("acceptSslCerts", true);
            options.SetPreference("cssSelectorsEnabled", true);
            IWebDriver driver = new FirefoxDriver(options);
            return driver;
        }

        private static IWebDriver ChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            IWebDriver driver = new ChromeDriver(options);
            return driver;
        }

        public enum BrowserType
        {
            Chrome,
            Firefox
        }
    }
}