deleteAll
	"Move all visible messages in the current category to '.trash.'."

	| msgList |

	self requiredCategory: '.trash.'.

	msgList _ self filteredMessagesIn: currentCategory.
	mailDB removeAll: msgList fromCategory: currentCategory.
	mailDB fileAll: msgList inCategory: '.trash.'.

	currentMsgID _ nil.
	self updateTOC.