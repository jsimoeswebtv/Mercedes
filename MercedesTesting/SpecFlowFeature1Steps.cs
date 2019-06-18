using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace MercedesTesting
{

    [Binding]
    public class SpecFlowFeature1Steps
    {
        static IWebDriver Browser;
        static WebDriverWait wait;

        

        [Then(@"we want to close the browser")]
        public void ThenWeWantToCloseTheBrowser()
        {
            DisposeDriverService.FinishHim(Browser);
        }


        [Given(@"the browser is open")]
        public void GivenTheBrowserIsOpen()
        {
            Browser = new ChromeDriver(".");
            Browser.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
            wait = new WebDriverWait(Browser, new TimeSpan(0, 0, 30));
            DisposeDriverService.TestRunStartTime = DateTime.Now;

        }

        [Given(@"We have access to mercedes website")]
        public void GivenWeHaveAccessToMercedesWebsite()
        {
            Browser.Navigate().GoToUrl("https://shop.mercedes-benz.com/en-gb/collection/");
        }

        [Then(@"We want to dismiss the cookies disclaimer")]
        public void ThenWeWantToDismissTheCookiesDisclaimer()
        {
            WaitScrollToElementAndClick(Browser.FindElement(By.Id("button-text")));
        }

        [Then(@"we want to click on ""(.*)""")]
        public void ThenWeWantToClickOn(string linktext)
        {
            WaitScrollToElementAndClick(Browser.FindElement(By.LinkText(linktext)));
        }

        [Then(@"we want to scroll and click on ""(.*)""")]
        public void ThenWeWantToScrollAndClickOn(string text)
        {
            WaitScrollToElementAndClick(Browser.FindElement(By.XPath("//*[contains(text(), '"+ text +"')]")));
        }
        [Then(@"we want to check the shopping basket")]
        public void ThenWeWantToCheckTheShoppingBasket()
        {
           // WaitScrollToElementAndClick(Browser.FindElement(By.CssSelector(".dcp-modal__cta--primary")));
           // WaitScrollToElementAndClick(Browser.FindElement(By.TagName("body")));
            WaitScrollToElementAndClick(Browser.FindElement(By.CssSelector(".dcp-modal__cta--primary")));
        }


        private void WaitScrollToElementAndClick(IWebElement element)
        {
            WaitForReady();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            Actions actions = new Actions(Browser);
            actions.MoveToElement(element);
            actions.Perform();
            element.Click();
        }

        private static void WaitForReady()
        {
            TimeSpan waitForElement = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(Browser, waitForElement);
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
        }
    }
}
