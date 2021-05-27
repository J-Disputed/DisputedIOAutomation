using DisputedIOAutomation.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisputedIOAutomation.PageObject.KellerLenknerPages
{
    public class RegistrationPage
    {
        IWebDriver driver;
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement FinanceOrLeaseRadioBtn(string option) => 
            driver.FindElement(By.XPath($"//*[@name='EnglandOrWales']//parent::div//label[.='{option}']"));

        IWebElement JoinAnotherMercClaimradioBtn(string option) =>
            driver.FindElement(By.XPath("//*[@name='JoinedAnotherClaim']//parent::div//label[.='No']"));

        IWebElement Registration => driver.FindElement(By.XPath("//input[@name='Registration']"));

        IWebElement RegistrationEmailAdress => driver.FindElement(By.XPath("//input[@name='RegistrationEmailAddress']"));

        IWebElement PhoneNumber => driver.FindElement(By.XPath("//*[@id='SignupPhoneNumber']"));

        IWebElement RecaptchaChkBox =>
            driver.FindElement(
               By.XPath("//span[@role='checkbox']"));


        IWebElement RecaptchaIframe =>
             driver.FindElement(
                By.XPath("(//div[@class='recaptcha-container'])[1]//descendant::iframe"));

        IWebElement NextBtn => driver.FindElement(
            By.XPath("//*[contains(@class, 'btn-submit-registration')]"));

        IWebElement HeaderTxt(string value) => 
            driver.FindElement(
                By.XPath($"//*[@class='main-heading'][contains(text(), '{value}')]"));

        public void NavigateToMercedesClintFront() => 
            driver.Navigate().GoToUrl(Environments.DevKLMercClientFront);

        public void ClickFinanceOrLeaseOption(string option)
        {
            ConditionalWaits
            .WaitForElementToBecomeVisible(driver, FinanceOrLeaseRadioBtn(option), 30);
            FinanceOrLeaseRadioBtn(option).Click();
        }
            

        public void ClickJoinAnotherMercClaimOption(string option) => 
            JoinAnotherMercClaimradioBtn(option).Click();

        public void InputRegistration(string value) => Registration.SendKeys(value);

        public void InputEmailAddress(string email) => RegistrationEmailAdress.SendKeys(email);

        public void InputPhoneNumber(string phonenumber) => PhoneNumber.SendKeys(phonenumber);

        public void ClickRecaptchaCheckBox() =>
            CustomExtensions.SwitchToIframe(driver, RecaptchaIframe);

        public void ClickReCaptcha() => RecaptchaChkBox.Click();

        public void ClickNextBtn() => NextBtn.Click();

        public bool IsHeaderDisplayed(string value) => HeaderTxt(value).Displayed;
    }
}
