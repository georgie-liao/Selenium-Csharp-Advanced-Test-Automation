Feature: Chat
As a user, I would like I want the feature to manage my chats
So I am able to send chat message to a seller,
and find the chat history

@New
Scenario: 1 Send a chat to another user
	Given I navigate to Search Skill page
	Then I find a seller
	When I send a chat message to the seller
	Then The chat message should be sent to the user successfully

@History
Scenario: 2 Find chat history
	Given I go to Chat Room
	When I search for a chat history under a user name
	Then I should be able to find chat history successfully