fileAll
	"File all visible messages in the current category in some other category as well."

	| newCatName msgList |
	newCatName _ self getCategoryNameIfNone: [^self].
	msgList _ self filteredMessagesIn: currentCategory.
	mailDB fileAll: msgList inCategory: newCatName.
	self updateTOC.