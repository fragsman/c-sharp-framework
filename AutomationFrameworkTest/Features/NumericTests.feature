Feature: Numeric Tests

  #The following test won't trigger Web Browser as it is not tagged as @web.
  #Steps will be separated into ShortStepsA and ShortStepsB to demonstrate variable sharing among different files.
  @non_web_tests
  Scenario Outline: Age restriction upon login
    Given the user "<name>" inputs its <age>
    Then user is allowed to log into the website
    Examples:
    | name | age |
    | Cedric | 16 |
    | Anna | 34 |