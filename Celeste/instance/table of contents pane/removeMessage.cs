removeMessage
	"Remove the current message from the current category."

	mailDB remove: currentMsgID fromCategory: currentCategory.
	self updateTOC.