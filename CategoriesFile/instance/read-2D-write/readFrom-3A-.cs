readFrom: aFileStream 
	"Read the categories from the given FileStream."
	| name categorySize messageIDs |
	categories _ Dictionary new: 64.
	aFileStream binary; position: 0.
	[aFileStream atEnd]
		whileFalse: 
			[name _ aFileStream ascii; nextString.
			categorySize _ aFileStream binary; nextWord.
			messageIDs _ PluggableSet integerSet.
			categorySize timesRepeat: [messageIDs add: aFileStream nextInt32].
			categories at: name put: messageIDs]