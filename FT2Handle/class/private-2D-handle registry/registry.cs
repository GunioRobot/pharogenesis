registry
	WeakArray isFinalizationSupported ifFalse:[^nil].
	^Registry ifNil: [ Registry := FT2HandleRegistry new]