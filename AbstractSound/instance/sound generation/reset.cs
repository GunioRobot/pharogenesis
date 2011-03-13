reset
	"Reset my internal state for a replay."

	samplesUntilNextControl _ (self samplingRate // self controlRate).
