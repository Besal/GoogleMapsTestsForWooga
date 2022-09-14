using GoogleMapsTestsForWooga.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.ObjectModel;

namespace GoogleMapsTestsForWooga.Pages;

public class GoogleMapsPage : SeleniumWebDriverContainer
{
    public GoogleMapsPage(IWebDriver driver) : base(driver) => PageFactory.InitElements(driver, this);

    public string CityName = "Berlin";
    public string PublicPlaceName = "Tempelhofer Feld";
    public string SearchConditionForMultipleResults = "DHL";
    public string HouseFilterButtonSelector = "div.KNfEk.siaXSd.ODcthf.ArRoUb button";
    public string UniqueAddressString = "Rohrdamm 7";
    public string InvalidSearchRequest = "https://www.google.com";
    public string GoogleSearchLinkSelector = "//*[@id='QA0Szd']//a[@href]";
    public string MissingPlaceButtonSelector = "//*[@id='QA0Szd']//button[@class='kyuRq']";
    
    //Search button
    [FindsBy(How = How.Id, Using = "searchbox-searchbutton")]
    [CacheLookup]
    public IWebElement SearchButton;

    //Search input
    [FindsBy(How = How.Id, Using = "searchboxinput")]
    [CacheLookup]
    public IWebElement SearchInput;
    
    //h1 founded item name
    [FindsBy(How = How.XPath, Using = "//*[@id='QA0Szd']//h1//span[contains(text(),'')][1]")]
    [CacheLookup]
    public IWebElement FoundedItemHeader;

    //Weather widget
    [FindsBy(How = How.CssSelector, Using = "div.Camdsb.fontBodyMedium.nNo1kd")]
    [CacheLookup]
    public IWebElement WeatherWidget;

    //Action bar
    [FindsBy(How = How.CssSelector, Using = "div.e07Vkf.kA9KIf > div > div > div:nth-child(4)")]
    [CacheLookup]
    public IWebElement ActionBarOfPlace;

    //Link to weather widget on main Google page
    [FindsBy(How = How.CssSelector, Using = "div.Camdsb.fontBodyMedium.nNo1kd a.XWQsmd")]
    [CacheLookup]
    public IWebElement SearchLinkInWeatherWidget;

    //Weather widget on main Google page
    [FindsBy(How = How.Id, Using = "wob_wc")]
    [CacheLookup]
    public IWebElement MainGooglePageWeatherWidget;

    //Ratings of the found public place
    [FindsBy(How = How.CssSelector, Using = "div.F7nice.mmu3tf")]
    [CacheLookup]
    public IWebElement PlaseRatings;

    //Information about public place
    [FindsBy(How = How.CssSelector, Using = "div.e07Vkf.kA9KIf > div > div > div:nth-child(9)")]
    [CacheLookup]
    public IWebElement PlaseInformation;

    //Button for improving information about place
    [FindsBy(How = How.XPath, Using = "//button[@jsaction='pane.place.suggestEdit;keydown:pane.place.suggestEdit']")]
    [CacheLookup]
    public IWebElement SuggestEditButton;

    //Feed results of found companies
    [FindsBy(How = How.XPath, Using = "//*[@id='QA0Szd']//div[@role='feed']")]
    [CacheLookup]
    public IWebElement FeedResults;

    //Button for filtering found organizations working hours
    [FindsBy(How = How.CssSelector, Using = "div.KNfEk.siaXSd.ODcthf.ArRoUb button")]
    [CacheLookup]
    public IWebElement HoursFilterButton;
    
    //Hours filter list
    [FindsBy(How = How.XPath, Using = "//div[@role='dialog' and @class='m6QErb WNBkOb ecceSd']")]
    [CacheLookup]
    public IWebElement HoursFilterList;

    //Expected city of unique address
    [FindsBy(How = How.XPath, Using = "//*[@class='tAiQdd']//span[contains(text(), 'Germany')]")]
    [CacheLookup]
    public IWebElement CityOfUniqueAddressString;

    //Link to main Google page if request invalid
    [FindsBy(How = How.XPath, Using = "//*[@id='QA0Szd']//a[@href]")]
    [CacheLookup]
    public IWebElement GoogleSearchLinkForInvalidMapsRequest;

    //Link for adding unknown place
    [FindsBy(How = How.XPath, Using = "//*[@id='QA0Szd']//button[@class='kyuRq']")]
    [CacheLookup]
    public IWebElement MissingPlaceButtonForAddingUnknownPlace;


    public List<IWebElement> ActionBarButtons()
    {
        var actionButtons = Driver.FindElements(By.CssSelector("div.e07Vkf.kA9KIf > div > div > div:nth-child(4) button")).ToList();
        return actionButtons;
    }
    public void SearchFor(string searchCondition)
    {
        //SearchInput.Clear();
        SearchInput.SendKeys(searchCondition);
        SearchButton.Click();
    }
}
