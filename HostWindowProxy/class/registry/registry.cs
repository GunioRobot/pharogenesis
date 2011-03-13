registry
"boilerplate WeakRegistry usage"
	WeakArray isFinalizationSupported ifFalse:[^nil].
	^Registry isNil
		ifTrue:[Registry := WeakRegistry new]
		ifFalse:[Registry].