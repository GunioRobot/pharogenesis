registry
	WeakArray isFinalizationSupported ifFalse:[^nil].
	^Registry isNil
		ifTrue:[Registry := WeakRegistry new]
		ifFalse:[Registry].