getTOCstring: msgID
	"Answer the table-of-contents string for the message with the given ID."

	^(indexFile at: msgID) tocString