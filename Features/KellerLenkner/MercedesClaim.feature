Feature: MercedesClaim


Scenario: Registration Activities
	Given I am on the KellerLenkner Mercedes client front page
	When I select 'Yes' on did you purchase finance or lease the vehicle in England or Wales
		And I select 'No' for have you joined another mercedes emission claim
		And I enter vehicle registration number 'MA16XGO'
		And I enter email address 'Joseph+klMerc', 'disputed.io'
		And I enter mobile phone number with prefix '07'
		And I Confirm recaptcha
		And I Click next button
	Then I see the following message displayed:
	| Msg                                   |
	| Please tell us more about the vehicle |
	