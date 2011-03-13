contentStream
	semaphore wait.
	fileStream == nil ifFalse:[^fileStream].
	^content == nil
		ifTrue:[nil]
		ifFalse:[
			(content isKindOf: String)
				ifTrue: [self error: 'Error loading ' , self url printString]
				ifFalse: [content contentStream]]