sustainEnd: mSecs
	"Set the ending time of the sustain phase of this envelope; the decay phase will start this point. Typically derived from a note's duration."
	"Details: to avoid a sharp transient, the decay phase is scaled so that the beginning of the decay matches the envelope's instantaneous value when the decay phase starts."

	| vIfSustaining firstVOfDecay |
	loopEndMSecs _ nil. "pretend to be sustaining"
	decayScale _ 1.0.
	nextRecomputeTime _ 0.
	vIfSustaining _ self computeValueAtMSecs: mSecs.  "get value at end of sustain phase"
	loopEndMSecs _ mSecs.
	firstVOfDecay _ (points at: loopEndIndex) y * scale.
	firstVOfDecay = 0.0
		ifTrue: [decayScale _ 1.0]
		ifFalse: [decayScale _ vIfSustaining / firstVOfDecay].
