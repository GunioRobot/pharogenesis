register: anObject
"boilerplate WeakRegistry usage"
	WeakArray isFinalizationSupported ifFalse:[^anObject].
	self registry add: anObject