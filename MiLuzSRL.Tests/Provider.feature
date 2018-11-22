Feature: Provider Maintainance
	As the storehouse manager I need to be able to manage Providers 
	
Scenario: Register Provider
	Given after login onto the app
	When 	I click the Providers link
	And 	then click the button New Provider
	And 	on the new screen write on the Name field the value of "Coca Cola Company"
	And 	on the new screen write on the PhoneNumber field the value of "123456789"
	And     on the new screen select the Currency radiobutton with the value "Dollars"
	And     on the new screen do not check the Exists any debt checkbox
	And 	press the Save button
	Then 	the system redirects me to the list of providers 
	
Scenario: Update Provider
	Given after login onto the app
	When 	I click the Providers link
	And 	then click the edit button from the first provider
	And 	on the new screen write on the Name field the value of "Pepsi Company"
	And 	on the new screen write on the PhoneNumber field the value of "123456789"
	And 	on the new screen select the Currency radiobutton with the value "Bolivianos"
	And  	on the new screen check the Exists any debt checkbox
	And 	press the Save button
	Then 	the system redirects me to the list of providers 

Scenario: Delete Provider
	Given after login onto the app
	When 	I click the Providers link
	And 	then click the delete button from the second provider
	Then 	the system redirects me to the list of providers 