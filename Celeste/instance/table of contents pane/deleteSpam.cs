deleteSpam
	"Move the current message to the '.spam.' category and select the next  
	message. Deleted messages can later purged by the 'empty trash' menu  
	item.  If we are currently in the .spam. category, undelete this as spam by
	moving to the 'new'category"

	currentMsgID isNil
		ifTrue: [^ self].
	self requiredCategory: '.spam.'.
	self category = '.spam.'
		ifTrue:
			[mailDB file: currentMsgID inCategory: 'new'.
			self spamFilter ifNotNilDo: [:f | f reclassifyAsNotSpam: self currentMessage]]
		ifFalse:
			[mailDB file: currentMsgID inCategory: '.spam.'.
			self spamFilter ifNotNilDo: [:f | f reclassifyAsSpam: self currentMessage]].
	self removeMessage