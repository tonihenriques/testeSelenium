using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace TesteSafra.Utils
{
    public static class WebDriverExtensions
    {
        public static void LoadPages(this IWebDriver webDriver, TimeSpan timeTowait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeTowait;
            webDriver.Navigate().GoToUrl(url);
            //webDriver.Manage().Timeouts().ImplicitWait.TotalSeconds.Equals(5);

        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
           
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text.ToString();

            string result = webDriver.FindElement(By.Id("textOK")).GetAttribute("value");

            

        }
        public static void SetText(this IWebDriver webDriver, By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);

        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
          

            IWebElement webElement = webDriver.FindElement(by);
            if (!(webDriver is InternetExplorerDriver))
                webElement.Submit();
            else
                webElement.SendKeys(Keys.Enter);
        }


    }
}
