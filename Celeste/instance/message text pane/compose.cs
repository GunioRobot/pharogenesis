compose
	"Make a MailSendTool for composing a new message."
	mailDB ifNil: [ ^self ].
	self openSender: self composeText.