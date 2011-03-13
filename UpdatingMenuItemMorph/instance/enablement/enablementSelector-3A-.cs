enablementSelector: aSelector

	(aSelector isKindOf: BlockContext)
		ifTrue: [enablementSelector _ aSelector copyForSaving]
		ifFalse: [enablementSelector _ aSelector]