using GoogleMapsTestsForWooga.Base;
using NUnit.Framework;

namespace GoogleMapsTestsForWooga.Tests
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    [Parallelizable]
    public class SearchByAddressTests : SeleniumWebDriverOptions
    {
        public SearchByAddressTests(BrowserType browser)
            : base(browser)
        {
        }

        [Test, Description("Check header and action bar buttons of unique address")]
        public void VisibilityOfUniqueAddress()
        {
            GoogleMapsPage.SearchFor(GoogleMapsPage.UniqueAddressString);
            Assert.That(GoogleMapsPage.CityOfUniqueAddressString.Displayed, Is.True);
            Assert.That(GoogleMapsPage.ActionBarOfPlace.Displayed, Is.True);
            foreach (var button in GoogleMapsPage.ActionBarButtons())
            {
                Assert.That(button.Displayed, Is.True);
            }
        }
    }
}
