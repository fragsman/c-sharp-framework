Feature: Short Selenium Tests for AskOmCdh page

  #I will make it fail on purpose just to see a failure on the report
  @web
  Scenario: Store link functionality
    Given user selects the "Store" link
    Then user should see in the store search title "ShoeXXX"

  @web
  Scenario: Men link functionality
    Given user selects the "Men" link
    Then user should see in the men search title "Men"

  @web
  Scenario: Search functionality using Selenium Actions
    Given user selects the "Men" link
    And user performs a special search for "Shoes"
    Then user should see in the search results '“Shoes”'

  @web
  #This is test is meant to show soft assert, where one assertion passes and the other fails
  Scenario: Women link functionality
    Given user selects the "Women" link
    Then user should see in "W1men" in page title and "Women" in current navigation page
