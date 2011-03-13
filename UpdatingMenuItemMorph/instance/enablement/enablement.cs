enablement

	(enablementSelector isKindOf: BlockContext)
		ifTrue: [^ enablementSelector value]
		ifFalse: [^ wordingProvider perform: enablementSelector]