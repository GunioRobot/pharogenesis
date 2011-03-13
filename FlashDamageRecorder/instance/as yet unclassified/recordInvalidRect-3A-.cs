recordInvalidRect: rect
	totalRepaint ifTrue:[^self].
	self updateIsNeeded ifTrue:[
		fullDamageRect := fullDamageRect merge: rect.
	] ifFalse:[
		fullDamageRect := rect copy.
	].
	^super recordInvalidRect: rect