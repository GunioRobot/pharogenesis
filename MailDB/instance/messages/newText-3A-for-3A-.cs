newText: newText for: msgID
	"Replace the text for the message with the given ID."

	| oldLocation newLocation newEntry |
	oldLocation _ (indexFile at: msgID) location.
	newLocation _ messageFile update: newText at: oldLocation id: msgID.
	newEntry _ IndexFileEntry
		message: (MailMessage from: newText)
		location: newLocation
		messageFile: messageFile
		msgID: msgID.
	indexFile at: msgID put: newEntry.