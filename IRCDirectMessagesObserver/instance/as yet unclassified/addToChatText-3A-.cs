addToChatText: aString
	chatText _ chatText, aString.
	chatText size > 1000 ifTrue: [
		chatText _ chatText copyFrom: (chatText size - 500) to: chatText size ].

	self changed: #chatText.