appendMessages: msgBuffer messageFile: msgFile indexFile: idxFile
	"Append the given collection of messages to the message file. msgBuffer is a collection of (message ID, message text) pairs."

	| id msgText location entry |
	msgBuffer do:
		[: idAndText |
		 id _ idAndText at: 1.
		 msgText _ idAndText at: 2.
		 location _ msgFile basicAppend: msgText id: id.
		 entry _ indexFile
			at: id
			ifAbsent:
				[IndexFileEntry
					message: (MailMessage from: msgText)
					location: location
					messageFile: msgFile
					msgID: id].
		 entry _ (entry copy) location: location; textLength: msgText size.
		 idxFile at: id put: entry].