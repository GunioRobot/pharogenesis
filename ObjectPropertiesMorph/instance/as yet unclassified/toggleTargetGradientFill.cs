toggleTargetGradientFill

	self targetHasGradientFill ifTrue: [
		self makeTargetSolidFill
	] ifFalse: [
		self makeTargetGradientFill
	].
	self doEnables