register: anObject
	WeakArray isFinalizationSupported ifFalse:[^anObject].
	self registry add: anObject