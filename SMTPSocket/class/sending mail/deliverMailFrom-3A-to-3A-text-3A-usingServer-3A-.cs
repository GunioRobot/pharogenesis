deliverMailFrom: fromAddress to: recipientList text: messageText usingServer: serverName
	"Deliver a single email to a list of users and then close the connection.  For delivering multiple messages, it is best to create a single connection and send all mail over it.  NOTE: the recipient list should be a collection of simple internet style addresses -- no '<>' or '()' stuff"

	| sock |
	sock _ self usingServer: serverName.
	sock mailFrom: fromAddress to: recipientList text: messageText.
	sock quit.
	sock close.
	^true
