unregister: anObject
	WeakArray isFinalizationSupported ifFalse:[^anObject].
	self registry remove: anObject ifAbsent:[]