extractCallModuleNames: aMethodRef 
	^ (self existsCallIn: aMethodRef)
		ifTrue: [self extractCallModuleNamesFromLiterals: aMethodRef]