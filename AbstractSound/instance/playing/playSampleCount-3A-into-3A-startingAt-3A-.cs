playSampleCount: n into: aSoundBuffer startingAt: startIndex
	"Mix the next n samples of this sound into the given buffer starting at the given index. Update the receiver's control parameters periodically."

	| fullVol samplesBetweenControlUpdates pastEnd i remainingSamples count |
	fullVol _ AbstractSound scaleFactor.
	samplesBetweenControlUpdates _ self samplingRate // self controlRate.
	pastEnd _ startIndex + n.  "index just after the last sample"
	i _ startIndex.
	[i < pastEnd] whileTrue: [
		remainingSamples _ self samplesRemaining.
		remainingSamples <= 0 ifTrue: [^ self].
		count _ pastEnd - i.
		samplesUntilNextControl < count ifTrue: [count _ samplesUntilNextControl].
		remainingSamples < count ifTrue: [count _ remainingSamples].
		self mixSampleCount: count into: aSoundBuffer startingAt: i leftVol: fullVol rightVol: fullVol.
		samplesUntilNextControl _ samplesUntilNextControl - count.
		samplesUntilNextControl <= 0 ifTrue: [
			self doControl.
			samplesUntilNextControl _ samplesBetweenControlUpdates].
		i _ i + count].
