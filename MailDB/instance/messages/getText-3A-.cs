getText: msgID
	"Answer the text for the message with the given ID."

	| entry |
	entry _ indexFile at: msgID.
	^messageFile
		getMessage: msgID
		at: entry location
		textLength: entry textLength