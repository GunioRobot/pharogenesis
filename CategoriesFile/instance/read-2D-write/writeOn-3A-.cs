writeOn: aStream
	"Write the categories to the given Stream. The categories data is stored in binary (as opposed to a human-readable form) to save space."

	aStream binary; position: 0.
	categorizer writeOn: aStream elementWriter: [:s :messageID | s nextInt32Put: messageID].