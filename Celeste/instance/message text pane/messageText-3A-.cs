messageText: aStringOrText

	currentCategory isNil | currentMsgID isNil ifTrue: [^ false].
	mailDB newText: aStringOrText asString for: currentMsgID.
	self updateTOC.  "in case the message header was changed"
	messageTextView hasUnacceptedEdits: false.
	self changed: #messageText.
	^ true
