doControl
	"Update the control parameters of this sound using its envelopes, if any."
	"Note: This is only called at a small fraction of the sampling rate."

	| pitchModOrRatioChange |
	mSecsSinceStart _ mSecsSinceStart + (1000 // self controlRate).
	envelopes size > 0 ifTrue: [
		pitchModOrRatioChange _ false.
		1 to: envelopes size do: [:i |
			((envelopes at: i) updateTargetAt: mSecsSinceStart)
				ifTrue: [pitchModOrRatioChange _ true]].
		pitchModOrRatioChange ifTrue: [self internalizeModulationAndRatio]].
