importMailFrom: inboxFileName intoCategory: category
	"Append the messages from the given mail file to this mail database, and store them in the given category. Answer the number of messages imported."

	| inbox nextID count msg location |
	inbox _ MailInboxFile openOn: inboxFileName.
	nextID _ self nextUnusedID.
	count _ 0.
	messageFile beginAppend.
	inbox mailMessagesDo: [:msgText |
		 msg _ MailMessage from: msgText.
		 location _ messageFile basicAppend: msg text id: nextID.
		 indexFile
			at: nextID
			put: (IndexFileEntry
					message: msg
					location: location
					messageFile: messageFile
					msgID: nextID).
		 categoriesFile file: nextID inCategory: category.
		 nextID _ nextID + 1.
		 count _ count + 1].
	messageFile endAppend.
	LastID _ nextID.
	self saveDB.
	^ count
