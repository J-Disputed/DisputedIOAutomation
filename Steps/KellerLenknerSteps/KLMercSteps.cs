using BoDi;
using DisputedIOAutomation.Extensions;
using DisputedIOAutomation.PageObject.KellerLenknerPages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Faker.Extensions;
using NUnit.Framework;

namespace DisputedIOAutomation.Steps.KellerLenknerSteps
{
    [Binding]
    public class KLMercSteps
    {
        ScenarioContext scenarioContext;
        RegistrationPage registrationPage;
        public KLMercSteps(IObjectContainer objectContainer)
        {
            scenarioContext = objectContainer.Resolve<ScenarioContext>();
            registrationPage = objectContainer.Resolve<RegistrationPage>();
        }

        [Given(@"I am on the KellerLenkner Mercedes client front page")]
        public void GivenIAmOnTheKellerLenknerMercedesClientFrontPage()
        {
            registrationPage.NavigateToMercedesClintFront();
        }

        [When(@"I select '(Yes|No)' on did you purchase finance or lease the vehicle in England or Wales")]
        public void WhenISelectOnDidYouPurchaseFinanceOrLeaseTheVehicleInEnglandOrWales(string optionAlias)
        {
            registrationPage.ClickFinanceOrLeaseOption(optionAlias);
        }

        [When(@"I select '(Yes|No)' for have you joined another mercedes emission claim")]
        public void WhenISelectForHaveYouJoinedAnotherMercedesEmissionClaim(string optionAlias)
        {
            registrationPage.ClickJoinAnotherMercClaimOption(optionAlias);
        }

        [When(@"I enter vehicle registration number '(.*)'")]
        public void WhenIEnterVehicleRegistrationNumber(string regAlias)
        {
            registrationPage.InputRegistration(regAlias);
        }

        [When(@"I enter email address '(.*)', '(.*)'")]
        public void WhenIEnterEmailAddress(string emailalias, string emailSubfixAlias)
        {
            registrationPage
                .InputEmailAddress(
                CustomExtensions.AddTimeStamp2(emailalias) + "@" + emailSubfixAlias);
        }

        [When(@"I enter mobile phone number with prefix '(.*)'")]
        public void WhenIEnterMobilePhone(string phonePrefix)
        {
            registrationPage.InputPhoneNumber(phonePrefix +
            CustomExtensions.RandomDigits(9)); 
        }

        [When(@"I Confirm recaptcha")]
        public void WhenIConfirmRecaptcha()
        {
            registrationPage.ClickRecaptchaCheckBox();
            registrationPage.ClickReCaptcha();
        }

        [When(@"I Click next button")]
        public void WhenIClickNextButton()
        {
            registrationPage.ClickNextBtn();
        }

        [Then(@"I see the following message displayed:")]
        public void ThenISeeTheFollowingMessageDisplayed(Table table)
        {
            Assert.IsTrue(
                registrationPage.IsHeaderDisplayed(table.Rows[0]["Msg"]), 
                $"{table.Rows[0]["Msg"]} header Not displayed");
        }

    }
}
