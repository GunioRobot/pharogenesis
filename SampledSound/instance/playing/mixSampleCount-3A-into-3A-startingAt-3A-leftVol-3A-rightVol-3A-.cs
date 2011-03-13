mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Mix the given number of samples with the samples already in the given buffer starting at the given index. Assume that the buffer size is at least (index + count) - 1."

	| lastIndex outIndex sampleIndex sample i s overflow |
	<primitive:'primitiveMixSampledSound' module:'SoundGenerationPlugin'>
	self var: #aSoundBuffer declareC: 'short int *aSoundBuffer'.
	self var: #samples declareC: 'short int *samples'.

	lastIndex _ (startIndex + n) - 1.
	outIndex _ startIndex.    "index of next stereo output sample pair"
	sampleIndex _ indexHighBits + (scaledIndex >> IncrementFractionBits).
	[(sampleIndex <= samplesSize) and: [outIndex <= lastIndex]] whileTrue: [
		sample _ ((samples at: sampleIndex) * scaledVol) // ScaleFactor.
		leftVol > 0 ifTrue: [
			i _ (2 * outIndex) - 1.
			s _ (aSoundBuffer at: i) + ((sample * leftVol) // ScaleFactor).
			s >  32767 ifTrue: [s _  32767].  "clipping!"
			s < -32767 ifTrue: [s _ -32767].  "clipping!"
			aSoundBuffer at: i put: s].
		rightVol > 0 ifTrue: [
			i _ 2 * outIndex.
			s _ (aSoundBuffer at: i) + ((sample * rightVol) // ScaleFactor).
			s >  32767 ifTrue: [s _  32767].  "clipping!"
			s < -32767 ifTrue: [s _ -32767].  "clipping!"
			aSoundBuffer at: i put: s].

		scaledVolIncr ~= 0 ifTrue: [
			scaledVol _ scaledVol + scaledVolIncr.
			((scaledVolIncr > 0 and: [scaledVol >= scaledVolLimit]) or:
			 [scaledVolIncr < 0 and: [scaledVol <= scaledVolLimit]])
				ifTrue: [  "reached the limit; stop incrementing"
					scaledVol _ scaledVolLimit.
					scaledVolIncr _ 0]].

		scaledIndex _ scaledIndex + scaledIncrement.
		scaledIndex >= ScaledIndexOverflow ifTrue: [
			overflow _ scaledIndex >> IncrementFractionBits.
			indexHighBits _ indexHighBits + overflow.
			scaledIndex _ scaledIndex - (overflow << IncrementFractionBits)].

		sampleIndex _ indexHighBits + (scaledIndex >> IncrementFractionBits).
		outIndex _ outIndex + 1].
	count _ count - n.
