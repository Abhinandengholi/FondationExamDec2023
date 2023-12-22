Feature: UserRegisteration

A short summary of the feature

Background: User will be on Homepage
@E2E-Add_User
Scenario: Adding the User Details
	#Given
	When User will click on the Register Button
	Then  Registrtion Page is loaded in the same page
	When Selecting gender option
	And Fills the User Details '<firstname>','<lastname>','<day>','<month>','<year>','<email>','<passwrd>','<cnfrmpwd>'
	And Clicks the Register user
	Then Customer details added successfully
	
 
Examples:
	| firstname | lastname | day | month | year | email               | passwrd  | cnfrmpwd |
	| Levin     | Leo      | 8   | 2     | 1998 | levinleo0@gmail.com | levi@123 | levi@123 | 