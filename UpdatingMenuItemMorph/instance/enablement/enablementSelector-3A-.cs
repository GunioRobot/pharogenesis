enablementSelector: aSelector 
	enablementSelector := (aSelector isKindOf: BlockContext) 
				ifTrue: [aSelector copyForSaving]
				ifFalse: [aSelector] 