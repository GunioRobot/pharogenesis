addNewMessage: message
	"Add the given message to the database, and answer its message id."

	| id location |
	id _ self nextUnusedID.
	location _ messageFile append: message text id: id.
	indexFile
		at: id
		put: (IndexFileEntry
				message: message
				location: location
				messageFile: messageFile
				msgID: id).
	^ id
