PROTOqueueMessageWithText: aStringOrText
	"Queue a message to be sent later. The message is added to the database and filed in the '.tosend.' category."

	| messageText id |
	messageText _
		'X-Mailer: ', Celeste versionString, String cr,
		'Date: ', MailMessage dateStampNow, String cr.

	messageText _ messageText,
		aStringOrText asString.
	
	self requiredCategory: '.tosend.'.

	"queue the message"
	id _ mailDB addNewMessage: (MailMessage from: messageText).
	mailDB file: id inCategory: '.tosend.'.

	(self category = '.tosend.') ifTrue: [self updateTOC].
	^id
