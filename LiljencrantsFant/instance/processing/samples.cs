samples
	| answer |
	answer := FloatArray new: n0.
	self computeSamplesInto: answer.
	^ answer