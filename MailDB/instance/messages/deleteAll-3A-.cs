deleteAll: msgIDList
	"Delete all the messages with ID's in the given list from the message file. This is permanent!"

	msgIDList do:
		[: msgID |
		 messageFile
			deleteMessageAt: (indexFile at: msgID) location
			id: msgID.
		 indexFile remove: msgID].
	self cleanUpCategories.