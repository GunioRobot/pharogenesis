at: msgID ifAbsent: aBlock
	"Answer the IndexFileEntry for the message with the given ID. Evaluate the given block if there is no entry for the given ID."

	^msgDictionary at: msgID ifAbsent: aBlock