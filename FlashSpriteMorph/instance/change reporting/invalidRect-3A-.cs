invalidRect: rect
	damageRecorder isNil ifTrue:[
		super invalidRect: rect.
	] ifFalse:[
		damageRecorder recordInvalidRect: rect.
	].