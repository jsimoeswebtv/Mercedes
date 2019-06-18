Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers
Background: 
	Given the browser is open
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
	Then we want to check the shopping basket
	Then we want to close the browser

