messageText: aStringOrText

	currentMsgID isNil ifTrue: [^ self].
	mailDB newText: aStringOrText asString squeakToIso for: currentMsgID.
	self updateTOC.  "in case the message header was changed"
	messageTextView hasUnacceptedEdits: false.
	self changed: #messageText.
	^ true
