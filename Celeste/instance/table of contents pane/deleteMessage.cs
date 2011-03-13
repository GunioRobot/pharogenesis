deleteMessage
	"Move the current message to the '.trash.' category and select the next  
	message. Deleted messages can later purged by the 'empty trash' menu  
	item"
	currentMsgID isNil
		ifTrue: [^ self].
	self requiredCategory: '.trash.'.
	mailDB file: currentMsgID inCategory: '.trash.'.
	self removeMessage