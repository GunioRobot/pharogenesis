recordInvalidRect: rect
	totalRepaint ifTrue:[^self].
	self updateIsNeeded ifTrue:[
		fullDamageRect _ fullDamageRect merge: rect.
	] ifFalse:[
		fullDamageRect _ rect copy.
	].
	^super recordInvalidRect: rect