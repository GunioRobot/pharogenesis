mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Repeatedly play my sounds."

	| i count samplesNeeded |
	i _ startIndex.
	samplesNeeded _ n.
	[samplesNeeded > 0] whileTrue: [
		count _ seqSound samplesRemaining min: samplesNeeded.
		count = 0 ifTrue: [
			self reset.
			count _ seqSound samplesRemaining min: samplesNeeded.
			count = 0 ifTrue: [^ self]].  "zero length sound"
		seqSound mixSampleCount: count into: aSoundBuffer startingAt: i leftVol: leftVol rightVol: rightVol.
		i _ i + count.
		samplesNeeded _ samplesNeeded - count].
