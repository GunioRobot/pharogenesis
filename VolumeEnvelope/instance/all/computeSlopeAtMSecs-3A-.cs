computeSlopeAtMSecs: mSecs
	"Private! Find the next inflection point of this envelope and compute its target volume and the number of milliseconds until the inflection point is reached."

	| t i |
	((loopEndMSecs ~~ nil) and: [mSecs >= loopEndMSecs]) ifTrue: [  "decay phase"
		t _ (points at: loopEndIndex) x + (mSecs - loopEndMSecs).
		i _ self indexOfPointAfterMSecs: t startingAt: loopEndIndex.
		i == nil ifTrue: [  "past end"
			i _ points size.
			nextRecomputeTime _ mSecs + 1000000].
		targetVol _ (points at: i) y * decayScale.
		mSecsForChange _ ((points at: i) x - t) max: 0.
		nextRecomputeTime _ mSecs + mSecsForChange.
		^ self].

	mSecs < loopStartMSecs ifTrue: [  "attack phase"
		i _ self indexOfPointAfterMSecs: mSecs startingAt: 1.
		targetVol _ (points at: i) y.
		mSecsForChange _ ((points at: i) x - mSecs) max: 0.
		nextRecomputeTime _ mSecs + mSecsForChange.
		^ self].

	"sustain and loop phase"
	noChangesDuringLoop ifTrue: [
		targetVol _ (points at: loopEndIndex) y.
		mSecsForChange _ 10.
		loopEndMSecs == nil
			ifTrue: [nextRecomputeTime _ mSecs + 10]  "unknown end time"
			ifFalse: [nextRecomputeTime _ loopEndMSecs].
		^ self].

	loopMSecs = 0 ifTrue: [^ (points at: loopEndIndex) y].  "looping on a single point"
	t _ loopStartMSecs + ((mSecs - loopStartMSecs) \\ loopMSecs).
	i _ self indexOfPointAfterMSecs: t startingAt: loopStartIndex.
	targetVol _ (points at: i) y.
	mSecsForChange _ ((points at: i) x - t) max: 0.
	nextRecomputeTime _ (mSecs + mSecsForChange) min: loopEndMSecs.
