Feature: Common page

# REQ-UI-01
# REQ-UI-02
@uiTest
Scenario Outline: UI Testing Site
Given I have entered to the home page "http://uitest.duodecadits.com/"
When I navigate to the <pages> page
Then I should see the title "UI Testing Site"
And I should see the Logo
Examples:
	|pages|
	|Home|
	|Form|
	|Error|

# REQ-UI-08
@uiTest
Scenario Outline: UI Testing button
Given I have entered to the home page "http://uitest.duodecadits.com/"
When I navigate to the <pages> page
And I click on the "UI Testing" button
Then I should be navigated to the Home page
Examples:
	|pages|
	|Home|
	|Form|
	#|Error|