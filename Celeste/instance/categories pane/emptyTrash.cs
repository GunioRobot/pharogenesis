emptyTrash
	"Delete all messages in the '.trash.' category.
	WARNING: The messages will be completely removed from the database."

	| msgList |
	self requiredCategory: '.trash.'.
	msgList _ self filteredMessagesIn: '.trash.'.
	mailDB removeAll: msgList fromCategory: currentCategory.
	mailDB deleteAll: msgList.
	self updateTOC.