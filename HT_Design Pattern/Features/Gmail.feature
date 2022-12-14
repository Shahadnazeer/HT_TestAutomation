Feature: Gmail

Background: login
    Given user in the login page to sign in
	When user enter username 'shahadnaz807@gmail.com' and password 'Epaam1234'
	Then user will login to the gmail account


@tag1
Scenario: verify user can send a mail
	Given user clicks the compose button
	When user enters sender mail, subject, and compose text
	    | Mail                   | Subject   | Text |
	    | shas8571@gmail.com | Sample Subject | Shahad Mail |
	When user clicks the close and save button
	Then navigate to draft page and open the draft mail
	When user clicks the send button 
	Then navigate to sent page and verify the mail has been sent
	When user clicks the reply button and send the mail
	| Text |
	|   Updated   |
	Then user will drag and drop the mail in the trash folder
	When user clicks the account button and clicks the Sign out button
	Then user will be navigated to login page

