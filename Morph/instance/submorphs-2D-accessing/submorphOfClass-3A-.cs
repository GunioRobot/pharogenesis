submorphOfClass: aClass
	^ self submorphs detect: [:p | p isKindOf: aClass] ifNone: [nil]