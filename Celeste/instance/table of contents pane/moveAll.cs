moveAll
	"Move all visible messages in the current category to another category."

	| newCatName msgList |
	newCatName _ self getCategoryNameIfNone: [^self].
	msgList _ self filteredMessagesIn: currentCategory.
	mailDB removeAll: msgList fromCategory: currentCategory.
	mailDB fileAll: msgList inCategory: newCatName.
	currentMsgID _ nil.
	self updateTOC.