Feature: Error page

# REQ-UI-07
@uiTest
Scenario: Error page content
Given I have entered to the home page "http://uitest.duodecadits.com/"
When I navigate to the Error page
Then I should get a 404 HTTP response code