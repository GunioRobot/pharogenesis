extractCallModuleNames: aMethodRef 
	^ (self existsCompiledCallIn: aMethodRef)
		ifTrue: [self extractCallModuleNamesFromLiterals: aMethodRef]
		ifFalse: [| src | 
			"try source"
			"higher priority to avoid source file accessing errors"
			[src := aMethodRef sourceString]
				valueAt: self higherPriority.
			self extractCallNamesFromPrimString: ((self extractDisabledPrimStringFrom: src)
					ifNil: ["no disabled prim string found"
						^ nil]) first]