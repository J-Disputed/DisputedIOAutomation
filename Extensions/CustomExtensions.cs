using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisputedIOAutomation.Extensions
{
    public static class CustomExtensions
    {
        /// <summary>
        /// Custom extensions to click element
        /// </summary>
        /// <param name="element"></param>
        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Custom extension to Enter text
        /// </summary>
        /// <param name="element"></param>
        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Custom extensions to add timestamp
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AddTimeStamp(this string text)
        {
            return text + DateTime.Now.TimeOfDay;
        }

        /// <summary>
        /// Custom extensions to add timestamp
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AddTimeStamp2(this string text)
        {
            return text + DateTime.Now.ToString("ddMMyyyyhhMMssfff");
        }

        /// <summary>
        /// Custom extension to add random digit
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        /// <summary>
        /// Custom extension to switch to iframe and click element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="element2"></param>
        public static void SwitchToIframe(
            IWebDriver driver, IWebElement element)
        {
            driver.SwitchTo().Frame(element);
        }

        /// <summary>
        /// Custom extension to highlight element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        public static void HighLightElement(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].style.border = '3px dotted blue'", element);
        }

        /// <summary>
        /// Custom extension to ScrollIntoView and Enter text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="text"></param>
        public static void ScrollIntoViewandEnterText(this IWebElement element, 
            IWebDriver driver, string text)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.EnterText(text);
        }

        /// <summary>
        /// Custom extension to ScrollIntoView and Enter text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        /// <param name="text"></param>
        public static void ScrollIntoViewandClick(this IWebElement element,
            IWebDriver driver, string text)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
    }
}
