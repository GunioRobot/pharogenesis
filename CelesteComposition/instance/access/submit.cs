submit
	| message msgID |
	"submit the message"
	textEditor
		ifNotNil: [self hasUnacceptedEdits ifTrue: [textEditor accept]].
	message := MailMessage from: messageText asString.
	self breakLinesInMessage: message.
	msgID _ (celeste isActive ifTrue: [celeste] ifFalse: [Celeste current])
				queueMessageWithText: message text.
	msgID ifNil: [^self].		"There was an error, so do not close"

	morphicWindow ifNotNil: [morphicWindow delete].
	mvcWindow ifNotNil: [mvcWindow controller close]