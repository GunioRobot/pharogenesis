removeAll
	"Remove all messages from the current category."

	| msgList |
	msgList _ self filteredMessagesIn: currentCategory.
	mailDB removeAll: msgList fromCategory: currentCategory.
	currentMsgID _ nil.
	self updateTOC.