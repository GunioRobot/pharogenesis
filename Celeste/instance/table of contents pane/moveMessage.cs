moveMessage
	"Move the current message to another category."

	| newCatName |
	newCatName _ self getCategoryNameIfNone: [^self].
	mailDB remove: currentMsgID fromCategory: currentCategory.
	mailDB file: currentMsgID inCategory: newCatName.
	self updateTOC.