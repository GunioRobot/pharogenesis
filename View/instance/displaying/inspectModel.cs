inspectModel
	model notNil
		ifTrue: [^ model inspect]
		ifFalse: [self flash]