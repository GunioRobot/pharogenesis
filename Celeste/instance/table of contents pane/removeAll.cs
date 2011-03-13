removeAll
	"Remove all messages from the current category."
	mailDB removeAll: currentMessages fromCategory: currentCategory.
	currentMsgID _ nil.
	currentMessages _ #().
	currentTOC _ #().
	self initializeTocLists.
	self changed: #tocEntryList.
	self changed: #tocEntry.
	self changed: #messageText
