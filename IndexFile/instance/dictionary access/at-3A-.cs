at: msgID
	"Answer the IndexFileEntry for the message with the given ID."

	^msgDictionary at: msgID ifAbsent: [self reportInconsistency]