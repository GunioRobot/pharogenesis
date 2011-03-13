requirements
	^ requirements isNil
		ifTrue: [self newRequirementsObject]
		ifFalse: [requirements].