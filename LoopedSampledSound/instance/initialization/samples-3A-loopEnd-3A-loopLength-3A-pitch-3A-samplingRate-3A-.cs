samples: aSoundBuffer loopEnd: loopEndIndex loopLength: loopSampleCount pitch: perceivedPitchInHz samplingRate: samplingRateInHz
	"Make this sound use the given samples array with a loop of the given length starting at the given index. The loop length may have a fractional part; this is necessary to achieve pitch accuracy for short loops."

	| loopStartIndex |
	super initialize.
	loopStartIndex _ (loopEndIndex - loopSampleCount) truncated + 1.
	((1 <= loopStartIndex) and:
	 [loopStartIndex < loopEndIndex and:
	 [loopEndIndex <= aSoundBuffer size]])
		ifFalse: [self error: 'bad loop parameters'].

	leftSamples _ rightSamples _ aSoundBuffer.
	originalSamplingRate _ samplingRateInHz asFloat.
	perceivedPitch _ perceivedPitchInHz asFloat.
	gain _ 1.0.
	firstSample _ 1.
	lastSample _ leftSamples size.
	lastSample >= (SmallInteger maxVal // LoopIndexScaleFactor) ifTrue: [
		self error: 'cannot handle more than ',
			(SmallInteger maxVal // LoopIndexScaleFactor) printString, ' samples'].
	loopEnd _ loopEndIndex.
	scaledLoopLength _ (loopSampleCount * LoopIndexScaleFactor) asInteger.
	scaledIndexIncr _ (samplingRateInHz * LoopIndexScaleFactor) // self samplingRate.
	self computeSampleCountForRelease.
