update: messageText at: oldMessagePosition id: msgID
	"Atomically update the message having the old location and ID with the given new text (e.g. when the user has edited a message). Answer the new location of the message."

	| newLocation |
	newLocation _ self append: messageText id: msgID.
	self deleteMessageAt: oldMessagePosition id: msgID.
	^newLocation