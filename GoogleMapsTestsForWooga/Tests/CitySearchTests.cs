using GoogleMapsTestsForWooga.Base;
using GoogleMapsTestsForWooga.Pages;
using NUnit.Framework;

namespace GoogleMapsTestsForWooga.Tests;

[TestFixture(BrowserType.Chrome)]
[TestFixture(BrowserType.Firefox)]
//[Parallelizable(ParallelScope.Fixtures)]
public class CitySearchTests : SeleniumWebDriverOptions
{

    public CitySearchTests(BrowserType browser)
        : base(browser)
    {
    }

    [Test, Description("Check of header of founded city matching with search condition")]
    public void HeaderOfFoundedCityMatchesWithSearchCondition()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.CityName);
        Assert.That(GoogleMapsPage.FoundedItemHeader.Text, Is.EqualTo(GoogleMapsPage.CityName));
    }

    [Test, Description("Check of weather widget of founded city")]
    public void VisibilityOfWeatherWidgetOfFoundedCity()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.CityName);
        Assert.That(GoogleMapsPage.WeatherWidget.Displayed, Is.True);
        GoogleMapsPage.SearchLinkInWeatherWidget.Click();
        TabsManager(1);
        Assert.That(GoogleMapsPage.MainGooglePageWeatherWidget.Displayed);

    }

    [Test, Description("Check of visibility action bar buttons")]
    public void VisibilityOfActionBarOfFoundedCity()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.CityName);
        Assert.That(GoogleMapsPage.ActionBarOfPlace.Displayed, Is.True);
        foreach (var button in GoogleMapsPage.ActionBarButtons())
        {
            Assert.That(button.Displayed, Is.True);
        }
    }
}