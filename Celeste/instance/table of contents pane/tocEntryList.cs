tocEntryList
	"Answer a collection of table-of-contents entries for the currently selected category or an empty collection if no category is selected."

	currentCategory
		ifNil: [^ #()]
		ifNotNil: [^ currentTOC].
