Feature: CreateUser

Scenario: Create a new user
	Given I input name "Mike"
	And I input job "Dev"
	When I send request to create user
	Then validate user is created
