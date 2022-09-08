using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MarsAdvancedProject.Global
{
    class WaitHelper
    {
        public static void WaitClickble(IWebDriver driver, IWebElement element)
        {
            Thread.Sleep(2000);
            try
            {
                var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                Wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception error)
            {
                Assert.Fail("Time out to find element: " + error);
            }


        }
        public static void WaitClickble(IWebDriver driver, By locator, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("The element is not clickable, time out, " + ex.Message);
            }
        }

        public static bool CheckClickable(IWebElement element)
        {
            try
            {
                element.Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void LongWait()
        {
            //Waits for a long time to allow Manage Request Elements to load without aborting test
            Thread.Sleep(60000);
        }
        public static bool WaitVisible(IWebDriver webDriver, By locator, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("The element is not visible, time out, " + ex.Message);
                return false;
            }
        }

        public static IWebElement FindElement(IWebDriver webDriver, By by)
        {
            try
            {
                var webElement = webDriver.FindElement(by);
                return webElement;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Did not find the element." + ex.Message);
                return null;
            }
        }

        public static void ElementIsVisible(IWebDriver driver, string locator, string locatorValue, int seconds)
        {
            try
            {
                if (locator == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                }
                if (locator == "CssSelector")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
                }
                if (locator == "ClassName")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));
                }

            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed waiting for element to be visible", msg.Message);
            }
        }
    }
}
