playSampleCount: n into: aSoundBuffer startingAt: startIndex stereo: stereoFlag
	"Mixes the next count samples of this sound into the given buffer starting at the given index, updating the receiver's control parameters at periodic intervals."

	| pastEnd i leftRightPan remainingSamples count |
	stereoFlag ifTrue: [leftRightPan _ 500] ifFalse: [leftRightPan _ 1000].
	pastEnd _ startIndex + n.  "index just index of after last sample"
	i _ startIndex.
	[i < pastEnd] whileTrue: [
		remainingSamples _ self samplesRemaining.
		remainingSamples <= 0 ifTrue: [ ^ self ].
		count _ ((pastEnd - i) min: samplesUntilNextControl) min: remainingSamples.
		self mixSampleCount: count into: aSoundBuffer startingAt: i pan: leftRightPan.
		samplesUntilNextControl _ samplesUntilNextControl - count.
		samplesUntilNextControl <= 0 ifTrue: [
			self doControl.
			samplesUntilNextControl _ (self samplingRate // self controlRate).
		].
		i _ i + count.
	].
