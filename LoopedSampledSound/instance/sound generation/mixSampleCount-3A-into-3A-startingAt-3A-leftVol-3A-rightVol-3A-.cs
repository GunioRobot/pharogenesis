mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Play samples from a wave table by stepping a fixed amount through the table on every sample. The table index and increment are scaled to allow fractional increments for greater pitch accuracy.  If a loop length is specified, then the index is looped back when the loopEnd index is reached until count drops below releaseCount. This allows a short sampled sound to be sustained indefinitely."
	"(LoopedSampledSound pitch: 440.0 dur: 5.0 loudness: 0.5) play"

	| lastIndex sampleIndex i s compositeLeftVol compositeRightVol nextSampleIndex m isInStereo rightVal leftVal |
	<primitive:'primitiveMixLoopedSampledSound' module:'SoundGenerationPlugin'>
	self var: #aSoundBuffer declareC: 'short int *aSoundBuffer'.
	self var: #leftSamples declareC: 'short int *leftSamples'.
	self var: #rightSamples declareC: 'short int *rightSamples'.

	isInStereo _ leftSamples ~~ rightSamples.
	compositeLeftVol _ (leftVol * scaledVol) // ScaleFactor.
	compositeRightVol _  (rightVol * scaledVol) // ScaleFactor.

	i _ (2 * startIndex) - 1.
	lastIndex _ (startIndex + n) - 1.
	startIndex to: lastIndex do: [:sliceIndex |
		sampleIndex _ (scaledIndex _ scaledIndex + scaledIndexIncr) // LoopIndexScaleFactor.
		((sampleIndex > loopEnd) and: [count > releaseCount]) ifTrue: [
			"loop back if not within releaseCount of the note end"
			"note: unlooped sounds will have loopEnd = lastSample"
			sampleIndex _ (scaledIndex _ scaledIndex - scaledLoopLength) // LoopIndexScaleFactor].
		(nextSampleIndex _ sampleIndex + 1) > lastSample ifTrue: [
			sampleIndex > lastSample ifTrue: [count _ 0. ^ nil].  "done!"
			scaledLoopLength = 0
				ifTrue: [nextSampleIndex _ sampleIndex]
				ifFalse: [nextSampleIndex _ ((scaledIndex - scaledLoopLength) // LoopIndexScaleFactor) + 1]].

		m _ scaledIndex bitAnd: LoopIndexFractionMask.
		rightVal _ leftVal _
			(((leftSamples at: sampleIndex) * (LoopIndexScaleFactor - m)) +
			 ((leftSamples at: nextSampleIndex) * m)) // LoopIndexScaleFactor.
		isInStereo ifTrue: [
			rightVal _
				(((rightSamples at: sampleIndex) * (LoopIndexScaleFactor - m)) +
				 ((rightSamples at: nextSampleIndex) * m)) // LoopIndexScaleFactor].

		leftVol > 0 ifTrue: [
			s _ (aSoundBuffer at: i) + ((compositeLeftVol * leftVal) // ScaleFactor).
			s >  32767 ifTrue: [s _  32767].  "clipping!"
			s < -32767 ifTrue: [s _ -32767].  "clipping!"
			aSoundBuffer at: i put: s].
		i _ i + 1.
		rightVol > 0 ifTrue: [
			s _ (aSoundBuffer at: i) + ((compositeRightVol * rightVal) // ScaleFactor).
			s >  32767 ifTrue: [s _  32767].  "clipping!"
			s < -32767 ifTrue: [s _ -32767].  "clipping!"
			aSoundBuffer at: i put: s].
		i _ i + 1.

		scaledVolIncr ~= 0 ifTrue: [  "update volume envelope if it is changing"
			scaledVol _ scaledVol + scaledVolIncr.
			((scaledVolIncr > 0 and: [scaledVol >= scaledVolLimit]) or:
			 [scaledVolIncr < 0 and: [scaledVol <= scaledVolLimit]])
				ifTrue: [  "reached the limit; stop incrementing"
					scaledVol _ scaledVolLimit.
					scaledVolIncr _ 0].
			compositeLeftVol _ (leftVol * scaledVol) // ScaleFactor.
			compositeRightVol _  (rightVol * scaledVol) // ScaleFactor]].

	count _ count - n.
