writeOn: aFileStream
	"Write the categories to the given FileStream. The categories data is stored in binary (as opposed to a human-readable form) to save space."

	aFileStream binary; position: 0.
	categories associationsDo:
		[: category |
		 "(category key) is the category name"
		 "(category value) is the set of message ID's in that category"
		 aFileStream nextStringPut: (category key).
		 aFileStream nextWordPut: (category value) size.
		 (category value) do:
			[: messageID |
			 aFileStream nextInt32Put: messageID]].