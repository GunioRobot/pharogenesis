toggleTargetSolidFill

	self targetHasSolidFill ifTrue: [
		self makeTargetGradientFill
	] ifFalse: [
		self makeTargetSolidFill
	].
	self doEnables