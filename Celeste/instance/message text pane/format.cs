format
	mailDB ifNil: [ ^self ].
	messageTextView
		editString: self formattedMessageText;
		hasUnacceptedEdits: true.
