Feature: Credit Card Validation
    
@mytag
Scenario: credit card number too short
    Given I open the application
    And I input the credit card number with "1234567890"
    When I press "Validate Credit Card" button
    Then the error message should be showing up "Credit card number is too short."

Scenario: credit card number too long
    Given I open the application
    And I input the credit card number with "12345678901234567890"
    When I press "Validate Credit Card" button
    Then the error message should be showing up "Credit card number is too long."

Scenario: credit card number not credit card
    Given I open the application
    And I input the credit card number with "          qwerty"
    When I press "Validate Credit Card" button
    Then the error message should be showing up "This is not a credit card number."

Scenario: credit card number with valid number
    Given I open the application
    And I input the credit card number with "1234567890123456"
    When I press "Validate Credit Card" button
    Then the success message should be showing up 