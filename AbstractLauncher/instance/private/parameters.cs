parameters
	parameters == nil
		ifTrue: [parameters _ self class extractParameters].
	^parameters