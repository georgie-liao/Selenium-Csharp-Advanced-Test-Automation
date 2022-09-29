Feature: ManageListings

As a seller, I would like the feature to manage skill listings 
So I can edit and delete skill listings.

@Edit
Scenario: 1 Edit a skill listing
	Given I go to Manage Listings page
	And I click the edit icon
	When I edit the skill listing
	Then The skill listing should be edited successfully


@Delete
Scenario: 2 Delete a skill listing
	Given I go to Manage Listings page
	When I delete a skill listing
	Then The skill listing should be deleted successfully
