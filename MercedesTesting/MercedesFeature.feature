Feature: MercedesFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers
Background: 
	Given the browser  "Chrome" is open
@mytag
Scenario: Add miniature to shopping basket
	Given We have access to mercedes website
	Then We want to dismiss the cookies disclaimer
	Then we want to click on "Collection & accessories"
	Then we want to click on "Model cars"
	Then we want to click on "Passenger car models"
	Then we want to click on "1:18"
	Then we want to scroll and click on "GL-Class"
	Then we want to scroll and click on " Add to basket"
	Then we want to check the shopping basket and find "GL-Class"
	Then we want to scroll and click on "Continue to address and delivery"
	Then we want to scroll and send "jsimoes@netcabo.pt" on input "dcp-login-guest-user-email"
	Then we want to scroll and click on object with attribute "data-ng-click" and value "loginGuest(email)"
	Then we want to scroll and click on object with attribute "for" and value "co_payment_address-salutationCode-radio-id-0"
	Then we want to scroll and send "Joao" on input "co_payment_address-firstName"
	Then we want to scroll and send "Simoes" on input "co_payment_address-lastName"
	Then we want to scroll and send "123" on input "co_payment_address-line2"
	Then we want to scroll and send "My Street address" on input "co_payment_address-line1"
	Then we want to scroll and send "Lisbon Portugal" on input "co_payment_address-town"
	Then we want to scroll and send "SP2 0FL" on input "co_payment_address-postalCode"
	Then we want to scroll and click on object with attribute "data-ng-click" and value "gotoNextStep()"
	Then we want to close the browser
	

