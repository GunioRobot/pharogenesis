setPoints: pointList loopStart: startIndex loopEnd: endIndex

	| lastVal |
	points _ pointList asArray collect: [:p | p x asInteger @ p y asFloat].
	loopStartIndex _ startIndex.
	loopEndIndex _ endIndex.
	self checkParameters.
	loopStartMSecs _ (points at: loopStartIndex) x.
	loopMSecs _ (points at: loopEndIndex) x - (points at: loopStartIndex) x.
	loopEndMSecs _ nil.  "unknown end time; sustain until end time is known"
	scale ifNil: [scale _ 1.0].
	decayScale ifNil: [decayScale _ 1.0].

	"note if there are no changes during the loop phase"
	noChangesDuringLoop _ true.
	lastVal _ (points at: loopStartIndex) y.
	loopStartIndex to: loopEndIndex do: [:i | 
		(points at: i) y ~= lastVal ifTrue: [
			noChangesDuringLoop _ false.
			^ self]].
