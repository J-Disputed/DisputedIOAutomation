using BoDi;
using DisputedIOAutomation.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DisputedIOAutomation.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        
        private readonly IObjectContainer objectContainer;
        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            if (UtilPath.IsHeadLess.Equals("true")) options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            driver = null;
        }
    }
}
