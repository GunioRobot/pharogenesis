initialize

	super initialize.
	color _ (Color r:0.937 g: 0.937 b: 0.937).
	hands _ Array new.
	self addDefaultHand.
	viewBox _ canvas _ nil.
	damageRecorder _ DamageRecorder new.
	stepList _ OrderedCollection new.
	lastStepTime _ 0.
	model _ nil.
