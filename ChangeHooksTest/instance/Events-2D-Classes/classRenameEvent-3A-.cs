classRenameEvent: event 

	| renamedClass |
	self addSingleEvent: event.
	renamedClass := Smalltalk classNamed: self renamedTestClassName.
	self assert: renamedClass notNil.
	self assert: (Smalltalk classNamed: self generatedTestClassName) isNil.
	self 
		checkEvent: event
		kind: #Renamed
		item: renamedClass
		itemKind: AbstractEvent classKind.
	self assert: event oldName = self generatedTestClassName