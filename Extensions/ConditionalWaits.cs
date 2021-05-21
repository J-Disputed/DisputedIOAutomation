using DisputedIOAutomation.Extensions.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisputedIOAutomation.Extensions
{
    public static class ConditionalWaits
    {
        public static void WaitForElementToBecomeVisible(IWebDriver driver, IWebElement element, int timeout)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ElementIsVisible(element));
        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver => {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public static void WaitForElement(IWebDriver driver, IWebElement element, int timeout = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until<bool>(driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public static void WaitAndClick(IWebElement element, int timeout = 30)
        {
            var wait = new DefaultWait<IWebElement>(element);
            wait.IgnoreExceptionTypes(typeof(WebDriverException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(10);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.Until<bool>(drv => {
                element.Click();
                return true;
            });
        }

        public static DefaultWait<IWebDriver> DefaultWait(
            IWebDriver driver, string element, propertyType type)
        {
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(20),
                PollingInterval = TimeSpan.FromMilliseconds(250),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(InvalidOperationException));

            wait.Until(_ =>
            {
                if (type == propertyType.Id)
                     _.FindElement(By.Id(element));
                switch (type)
                {
                    case propertyType.Id:
                         _.FindElement(By.Id(element));
                        break;
                    case propertyType.Name:
                        _.FindElement(By.Name(element));
                        break;
                    case propertyType.XPath:
                         _.FindElement(By.XPath(element));
                        break;
                    case propertyType.Css:
                        _.FindElement(By.CssSelector(element));
                        break;
                    default:
                        break;
                }
                return true;
            });
            return wait;
        }

        public static void ExplicitWait(IWebDriver driver, string element, propertyType type)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver driver) => 
            {
                if (type == propertyType.Id)
                    driver.FindElement(By.Id(element));
                if (type == propertyType.Name)
                    driver.FindElement(By.Name(element));
                if (type == propertyType.XPath)
                    driver.FindElement(By.XPath(element));
                return true;
            });
            wait.Until(waitForElement);
        }
    }
}
