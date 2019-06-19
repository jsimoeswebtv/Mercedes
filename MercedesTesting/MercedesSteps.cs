using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace MercedesTesting
{

    [Binding]
    public class MercedesSteps
    {
        static IWebDriver Browser;
        static WebDriverWait wait;



        [Then(@"we want to close the browser")]
        public void ThenWeWantToCloseTheBrowser()
        {
            Browser.Quit();
            Browser = null;
        }


        [Given(@"the browser is open")]
        public void GivenTheBrowserIsOpen()
        {
            Browser = new ChromeDriver(".");
            Browser.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
            wait = new WebDriverWait(Browser, new TimeSpan(0, 0, 30));


        }

        [Given(@"the browser  ""(.*)"" is open")]
        public void GivenTheBrowserIsOpen(string browserType)
        {
            switch (browserType)
            {
                case "Chrome":
                    Browser = new ChromeDriver(".");
                    break;
                case "Firefox":
                    Browser = new FirefoxDriver(".");
                    break;

                default:
                    Browser = new ChromeDriver(".");
                    break;
            }
            Browser.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            wait = new WebDriverWait(Browser, new TimeSpan(0, 0, 5));
        }


        [Given(@"We have access to mercedes website")]
        public void GivenWeHaveAccessToMercedesWebsite()
        {
            Browser.Navigate().GoToUrl("https://shop.mercedes-benz.com/en-gb/collection/");
        }

        [Then(@"We want to dismiss the cookies disclaimer")]
        public void ThenWeWantToDismissTheCookiesDisclaimer()
        {
            WaitScrollToElementAndClick(GetElementById("button-text"));
        }

        [Then(@"we want to click on ""(.*)""")]
        public void ThenWeWantToClickOn(string linktext)
        {
            WaitScrollToElementAndClick(GetElementByLink(linktext));
        }

        [Then(@"we want to scroll and click on ""(.*)""")]
        public void ThenWeWantToScrollAndClickOn(string text)
        {
            WaitScrollToElementAndClick(GetElementByText(text));
        }


        [Then(@"we want to check the shopping basket and find ""(.*)""")]
        public void ThenWeWantToCheckTheShoppingBasketAndFind(string item)
        {
            WaitScrollToElement(GetElementByText("You have saved the following item in your shopping basket."));
            WaitScrollToElementAndClick(GetElementByCss(".dcp-modal__cta--primary"));
            WaitScrollToElement(GetElementByText("Your shopping basket"));
            WaitScrollToElement(GetElementByText(item));
        }

        [Then(@"we want to scroll and send ""(.*)"" on input ""(.*)""")]
        public void ThenWeWantToScrollAndSendOnInput(string keys, string inputBox)
        {
            WaitScrollToElementAndSend(GetElementById(inputBox), keys);
        }

        [Then(@"we want to scroll and click on object with id ""(.*)""")]
        public void ThenWeWantToScrollAndClickOnObjectWithId(string id)
        {
            WaitScrollToElementAndClick(GetElementById(id));
        }

        [Then(@"we want to scroll and click on object with attribute ""(.*)"" and value ""(.*)""")]
        public void ThenWeWantToScrollAndClickOnObjectWithAttributeAndValue(string attrib, string value)
        {
            WaitScrollToElementAndClick(GetElementByAttribute(attrib,value));
        }


        private IWebElement GetElementById(string text)
        {
            IWebElement we;
            we = GetElement(By.Id(text));
            return we;
        }
        private IWebElement GetElementByText(string text)
        {
            IWebElement we;
            we = GetElement(By.XPath("//*[contains(text(), '" + text + "')]"));
            return we;

        }


        private IWebElement GetElementByLink(string text)
        {
            IWebElement we;
            we = GetElement((By.LinkText(text)));
            return we;

        }
        private IWebElement GetElementByCss(string text)
        {
            IWebElement we;
            we = GetElement(By.CssSelector(text));
            return we;

        }
        private IWebElement GetElementByAttribute(string attrib, string value)
        {
            IWebElement we;
            we = GetElement(By.XPath("//*[@"+attrib+"='"+value+"']"));
            return we;

        }
        //data-ng-click
        // loginGuest(email)
        private By currentLocator;
        private IWebElement GetElement(By by)
        {
            IWebElement we;
            currentLocator = by;
            we = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return we;
        }

        private void WaitScrollToElement(IWebElement webElement)
        {
            try
            {
                WaitForReady();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(currentLocator));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(webElement);
                actions.Perform();

            }
            catch (StaleElementReferenceException staleExcep)
            {
                webElement = GetElement(currentLocator);
                WaitForReady();
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(currentLocator));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(webElement);
                actions.Perform();
               
            }
            catch (Exception)
            {
                webElement = GetElement(currentLocator);
                WaitForReady();
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(currentLocator));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(webElement);
                actions.Perform();

            }
        }

        private void WaitScrollToElementAndSelect(IWebElement element)
        {
            try
            {
                WaitForReady();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.SendKeys(" ");
            }
            catch (StaleElementReferenceException staleExcep)
            {
                element = GetElement(currentLocator);
                WaitForReady();
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.SendKeys(" ");
            }
            catch (Exception ex)
            {
                element = GetElement(currentLocator);
                WaitForReady();
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.SendKeys(" ");
            }

        }

        private void WaitScrollToElementAndClick(IWebElement element)
        {
            try
            {
                WaitForReady();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.Click();
            }
            catch (StaleElementReferenceException staleExcep)
            {
                element = GetElement(currentLocator);
                WaitForReady();
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.Click();
            }
            catch (Exception ex)
            {
                element = GetElement(currentLocator);
                WaitForReady();
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.Click();
            }

        }

        private void WaitScrollToElementAndSend(IWebElement element,string keys)
        {
            try
            {
                WaitForReady();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.SendKeys(keys);
            }
            catch (StaleElementReferenceException staleExcep)
            {
                element = GetElement(currentLocator);
                WaitForReady();
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.SendKeys(keys);
            }
            catch (Exception ex)
            {
                element = GetElement(currentLocator);
                WaitForReady();
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                Actions actions = new Actions(Browser);
                actions.MoveToElement(element);
                actions.Perform();
                element.SendKeys(keys);
            }

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
