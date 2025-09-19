Feature: Numeric Tests

  #These tests won't run in Web Browser or using selenium. However they should be able to run too

  @non_web_tests
  Scenario Outline: Age restriction upon login
    Given the user "<name>" inputs its <age>
    Then user is allowed to log into the website
    Examples:
    | name | age |
    | Cedric | 16 |
    | Anna | 34 |