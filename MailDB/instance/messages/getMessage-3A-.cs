getMessage: msgID
	"Answer the MailMessage with the given ID."

	^MailMessage from: (self getText: msgID)