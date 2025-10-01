Feature: Long Selenium Tests for AskOmCdh page

  @web
  Scenario: Buying a product
    Given user selects the "Store" link
    And user selects the first available product
    And user adds the product to the cart
    And user enters to cart details
    And user selects proceed to checkout
    When user sets the billing address
    And user places the order
    Then checkout notice should display "Thank you. Your order has been received."

  @web
  Scenario: Enter invalid coupon
    Given user selects the "Store" link
    And user selects the first available product
    And user adds the product to the cart
    And user enters to cart details
    When user enters an invalid coupon code "invalid"
    Then coupon error should display 'Coupon "invalid" does not exist!'

  @web
  Scenario: Picking a random country for checkout
    Given user selects the "Store" link
    And user selects the first available product
    And user adds the product to the cart
    And user enters to cart details
    And user selects proceed to checkout
    When user selects the country in position 3
    Then country selected in checkout should be "Algeria"