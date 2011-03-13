invalidRect: rect from: aMorph
	damageRecorder isNil ifTrue:[
		super invalidRect: rect from: aMorph
	] ifFalse:[
		damageRecorder recordInvalidRect: rect.
	].