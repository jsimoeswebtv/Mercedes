using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace MercedesTesting
{

    [Binding]
    public class SpecFlowFeature1Steps
    {
        IWebDriver Browser ;
      

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
           

            var driver = new ChromeDriver(".");
            Browser = driver;
            Browser.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);

            Browser.Navigate().GoToUrl("https://shop.mercedes-benz.com/en-gb/collection/");

            Browser.FindElement(By.Id("button-text")).Click();
            Browser.FindElement(By.LinkText("Collection & accessories")).Click();
            Browser.FindElement(By.LinkText("Model cars")).Click();
            Browser.FindElement(By.CssSelector(".col-xs-6:nth-child(1) > .utils-content-carousel-tile-container .dcp-ar3")).Click();
            Browser.FindElement(By.CssSelector(".col-xs-6:nth-child(6) .responsive-image")).Click();
            Browser.FindElement(By.CssSelector(".wb-e-btn-1:nth-child(3)")).Click();
            {
                IWebElement element = Browser.FindElement(By.CssSelector(".dcp-modal__cta--primary"));
                Actions builder = new Actions(Browser);
                builder.MoveToElement(element).Perform();
            }
            {
                IWebElement element = Browser.FindElement(By.TagName("body"));
                Actions builder = new Actions(Browser);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            Browser.FindElement(By.CssSelector(".dcp-modal__cta--primary")).Click();

        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
           
        }
    }
}
