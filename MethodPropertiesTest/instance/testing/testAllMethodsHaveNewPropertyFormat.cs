testAllMethodsHaveNewPropertyFormat
	Smalltalk garbageCollect.
	self assert: (CompiledMethod allInstances
			reject: [:cm | cm hasNewPropertyFormat]) isEmpty
		description: 'CompiledMethods must have new property format'