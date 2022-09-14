using GoogleMapsTestsForWooga.Base;
using GoogleMapsTestsForWooga.Pages;
using NUnit.Framework;
using static GoogleMapsTestsForWooga.Base.SeleniumWebDriverOptions;

namespace GoogleMapsTestsForWooga.Tests;

[TestFixture(BrowserType.Chrome)]
[TestFixture(BrowserType.Firefox)]
[Parallelizable]
public class PlaceSearchTests : SeleniumWebDriverOptions
{
    public PlaceSearchTests(BrowserType browser)
        : base(browser)
    {
    }

    [Test, Description("Check that header matches with search condition")]
    public void HeaderVisibilityOfFoundedPlace()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.PublicPlaceName);
        Assert.That(GoogleMapsPage.FoundedItemHeader.Text, Is.EqualTo(GoogleMapsPage.PublicPlaceName));
    }

    [Test, Description("Check visibility of public place ratings")]
    public void VisibilityOfPlaceRating()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.PublicPlaceName);
        Assert.That(GoogleMapsPage.PlaseRatings.Displayed);
    }

    [Test, Description("Check visibility of public place's contact information")]
    public void VisibilityOfContactInformation()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.PublicPlaceName);
        Assert.That(GoogleMapsPage.PlaseInformation.Displayed);
    }

    [Test, Description("Check of visibility action bar buttons")]
    public void ActionBarOfFoundedCity()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.PublicPlaceName); ;
        Assert.That(GoogleMapsPage.ActionBarOfPlace.Displayed, Is.True);
        foreach (var button in GoogleMapsPage.ActionBarButtons())
        {
            Assert.That(button.Displayed, Is.True);
        }
    }

    [Test, Description("Check of visibility suggest edit button")]
    public void VisibilityOfSuggestEditButton()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.PublicPlaceName);
        Assert.That(GoogleMapsPage.SuggestEditButton.Displayed, Is.True);
    }
}