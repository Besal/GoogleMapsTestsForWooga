using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GoogleMapsTestsForWooga.Base;

public class SeleniumWebDriverContainer
{
    protected IWebDriver Driver { get; }

    //Initializing driver here
    protected SeleniumWebDriverContainer(IWebDriver driver)
    {
        Driver = driver;
    }

    public void TabsManager(int tab)
    {
        var tabs = Driver.WindowHandles;
        Driver.SwitchTo().Window(tabs[tab]);
    }

    public void WaitForElement(By by)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementIsVisible(by));
    }
}