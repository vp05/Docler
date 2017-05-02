Feature: Form page

# REQ-UI-05
# REQ-UI-06
# REQ-UI-11
@uiTest
Scenario: Form button
Given I have entered to the home page "http://uitest.duodecadits.com/"
When I navigate to the Form page
Then I should see one input box
And I should see one submit button

# REQ-UI-12
@uiTest
Scenario Outline: Form page submit text box data
Given I have entered to the home page "http://uitest.duodecadits.com/"
When I navigate to the Form page
And I type <value> into the input box
And I click on submit button
Then I should be redirected to the Hello page
And I should see the <result> text on it
Examples: 
	|value|result|
	|John|Hello John!|
	|Sophia|Hello Sophia!|
	|Charlie|Hello Charlie!|
	|Emily|Hello Emily!|