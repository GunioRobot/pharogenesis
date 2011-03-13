toggleMessageListIndex: anInteger 
	"If the currently selected message index is anInteger, deselect the message 
	selector. Otherwise select the message selector whose index is anInteger."

	self messageListIndex: 
		(messageListIndex = anInteger
			ifTrue: [0]
			ifFalse: [anInteger])