Feature: DataDriven
	In order to to test several browsers
	As an automation engineer
	I want to data drive a scenario across many browsers

Scenario Outline: Cross browser
	Given I have an OS <os> with browser <browser> and browser version <version> opened
	When I open the SauceDemo home page
	Then it loads successfully
	
	Examples: 
	| os          | browser | version  |
	| macOS 10.13 | chrome  | latest   |
	| macOS 10.13 | chrome  | latest-1 |

Scenario Outline: Cross browser 2
	Given I have an OS <os> with browser <browser> and browser version <version> opened
	When I open the SauceDemo home page
	Then it loads successfully
	
	Examples: 
	| os          | browser | version  |
	| macOS 10.13 | chrome  | latest   |
	| macOS 10.13 | chrome  | latest-1 |