deleteMessage
	"Move the current message to the '.trash.' category and select the next message. Deleted messages can later purged by invoking the 'deleteAll' command in the '.trash.' category."

	currentMsgID isNil ifTrue: [^ self].
	self requiredCategory: '.trash.'.

	mailDB remove: currentMsgID fromCategory: currentCategory.
	mailDB file: currentMsgID inCategory: '.trash.'.

	self updateTOC.