unregister: anObject
"boilerplate WeakRegistry usage"
	WeakArray isFinalizationSupported ifFalse:[^anObject].
	self registry remove: anObject ifAbsent:[]