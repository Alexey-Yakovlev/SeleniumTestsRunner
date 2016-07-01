﻿using NUnit.Framework;
using PageObjects.Google;
using SeleniumFramework.SeleniumInfrastructure.Runner;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps : ExtentBase
    {
        private readonly SeleniumDriverRunner _runner = SeleniumDriverRunner.Instance;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _runner.SetBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _runner.Browser.Quit();
        }

        [When(@"I type (.*) in the Search field")]
        public void WhenITypeToSearchTextField(string textToSearch)
        {
            var googleManiPage = new GoogleMainPage();
            googleManiPage.Search(textToSearch);
        }

        [Then(@"I should see (.*) on the webpage")]
        public void ThenInTextResultsIShouldSee(string results)
        {
            var googleManiPage = new GoogleMainPage();
            googleManiPage.CheckLinkPresence(results);
        }

        [When(@"I click (.*) link")]
        public void WhenIClickLink(string link)
        {
            var googleManiPage = new GoogleMainPage();
            googleManiPage.ClickSearchResultLink(link);
        }

        [When(@"I trying to translate (.*)")]
        public void WhenITryingToTranslate(string textToTranslate)
        {
            var googleTranslatePage = new GoogleTranslatePage();
            googleTranslatePage.TransalteText(textToTranslate);
        }

        [Then(@"I should see (.*)")]
        public void ThenIShouldSee(string translationResult)
        {
            var googleTranslatePage = new GoogleTranslatePage();
            Assert.AreEqual(googleTranslatePage.GetTranslationsResult(), translationResult);
        }

    }
}