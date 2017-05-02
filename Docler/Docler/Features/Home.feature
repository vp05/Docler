Feature: Home page

# REQ-UI-03
# REQ-UI-04
@uiTest
Scenario: Home button
Given I have entered to the home page "http://uitest.duodecadits.com/"
When I navigate to the Form page
And I click on the "Home" button
Then I should be navigated to the Home page
And the Home button has to turn into active status

# REQ-UI-09
# REQ-UI-10
@uiTest
Scenario: Home page content
Given I have entered to the home page "http://uitest.duodecadits.com/"
When I navigate to the Home page
Then I should see in a h1 tag containing "Welcome to the Docler Holding QA Department" text
And I should see in a p tag containing "This site is dedicated to perform some exercises and demonstrate automated web testing." text

