selectedMessageName
	"Answer the message selector of the currently selected message, if any. 
	Answer nil otherwise."

	messageListIndex = 0 ifTrue: [^nil].
	^self messageList at: messageListIndex