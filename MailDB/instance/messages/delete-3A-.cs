delete: msgID
	"Delete the messages with the given ID from the message file. In contrast to simply removing a message from a category, this is permanent!"

	messageFile
		deleteMessageAt: (indexFile at: msgID) location
		id: msgID.
	indexFile remove: msgID.
	self cleanUpCategories.