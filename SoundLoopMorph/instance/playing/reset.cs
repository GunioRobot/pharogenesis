reset
	"Reset my internal state for a replay."

	seqSound _ self buildSound reset.
	samplesUntilNextControl _ (self samplingRate // self controlRate).
	controlIndex _ 0.
	self positionCursor