reset
	"Reset my internal state for a replay. Methods that override this method should do super reset."

	mSecsSinceStart _ 0.
	samplesUntilNextControl _ self samplingRate // self controlRate.
	envelopes size > 0 ifTrue: [
		1 to: envelopes size do: [:i | (envelopes at: i) reset]].
