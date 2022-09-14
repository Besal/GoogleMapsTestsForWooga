using GoogleMapsTestsForWooga.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GoogleMapsTestsForWooga.Tests
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    [Parallelizable]
    public class NegativeScenarios : SeleniumWebDriverOptions
    {
        public NegativeScenarios(BrowserType browser)
            : base(browser)
        {
        }

        [Test, Description("Check of visibility of the search link for invalid search request")]
        public void VisibilityOfGoogleSearchLinkIfRequestIsInvalid()
        {
            GoogleMapsPage.SearchFor(GoogleMapsPage.InvalidSearchRequest);
            WaitForElement(By.XPath(GoogleMapsPage.GoogleSearchLinkSelector));
            Assert.That(GoogleMapsPage.GoogleSearchLinkForInvalidMapsRequest.Displayed, Is.True);
        }

        [Test, Description("Check of visibility of the adding link for invalid search request")]
        public void VisibilityOfLinkForAddingMissingPlace()
        {
            GoogleMapsPage.SearchFor(GoogleMapsPage.InvalidSearchRequest);
            WaitForElement(By.XPath(GoogleMapsPage.MissingPlaceButtonSelector));
            Assert.That(GoogleMapsPage.MissingPlaceButtonForAddingUnknownPlace.Displayed, Is.True);
        }
    }
}
