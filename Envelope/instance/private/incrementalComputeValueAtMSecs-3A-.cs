incrementalComputeValueAtMSecs: mSecs
	"Compute the current value, per-step increment, and the time of the next inflection point."
	"Note: This method is part of faster, but less general, way of computing envelope values. It depends on a known, fixed control updating rate."

	| t i |
	((loopEndMSecs ~~ nil) and: [mSecs >= loopEndMSecs]) ifTrue: [  "decay phase"
		t _ (points at: loopEndIndex) x + (mSecs - loopEndMSecs).
		i _ self indexOfPointAfterMSecs: t startingAt: loopEndIndex.
		i == nil ifTrue: [  "past end"
			currValue _ points last y * scale * decayScale.
			valueIncr _ 0.0.
			nextRecomputeTime _ mSecs + 1000000.
			^ currValue].
		nextRecomputeTime _ mSecs + ((points at: i) x - t).
		^ self computeIncrementAt: t
			between: (points at: i - 1)
			and: (points at: i)
			scale: scale * decayScale].

	mSecs < loopStartMSecs
		ifTrue: [  "attack phase"
			t _ mSecs.
			i _ self indexOfPointAfterMSecs: t startingAt: 1.
			nextRecomputeTime _ mSecs + ((points at: i) x - t)]
		ifFalse: [  "sustain (looping) phase"
			noChangesDuringLoop ifTrue: [
				currValue _ (points at: loopEndIndex) y * scale.
				valueIncr _ 0.0.
				loopEndMSecs == nil
					ifTrue: [nextRecomputeTime _ mSecs + 10]  "unknown end time"
					ifFalse: [nextRecomputeTime _ loopEndMSecs].
				^ currValue].
			t _ loopStartMSecs + ((mSecs - loopStartMSecs) \\ loopMSecs).
			i _ self indexOfPointAfterMSecs: t startingAt: loopStartIndex.
			nextRecomputeTime _ (mSecs + ((points at: i) x - t)) min: loopEndMSecs].

	^ self computeIncrementAt: t
		between: (points at: i - 1)
		and: (points at: i)
		scale: scale.
