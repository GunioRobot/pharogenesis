categoryForNewMessage: msg
	^ (self spamFilter notNil and: [self spamFilter isNewMessageSpam: msg]) ifTrue: ['.spam.'] ifFalse: ['new']