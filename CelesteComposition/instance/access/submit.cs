submit
	"submit the message"
	textEditor
		ifNotNil: [self hasUnacceptedEdits ifTrue: [textEditor accept]].
	celeste queueMessageWithText: (MailMessage from: messageText asString) asSendableText.
	morphicWindow ifNotNil: [morphicWindow delete].
	mvcWindow ifNotNil: [mvcWindow controller close]