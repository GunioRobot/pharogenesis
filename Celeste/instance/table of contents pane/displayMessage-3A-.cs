displayMessage: msgID
	"If the message is in our displayed category, show it"

	(currentMessages notNil and: [currentMessages includes: msgID])
		ifTrue: [currentMsgID _ msgID]
		ifFalse: [currentMsgID _ nil].


	self changed: #tocIndex.
	self changed: #messageText.


	"Celeste someInstance displayMessage: 671458061"