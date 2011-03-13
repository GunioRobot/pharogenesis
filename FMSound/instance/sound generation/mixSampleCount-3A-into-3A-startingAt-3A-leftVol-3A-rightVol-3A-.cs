mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Play samples from a wave table by stepping a fixed amount through the table on every sample. The table index and increment are scaled to allow fractional increments for greater pitch accuracy."
	"(FMSound pitch: 440.0 dur: 1.0 loudness: 0.5) play"

	| doingFM lastIndex sample offset i s |
	<primitive:'primitiveMixFMSound' module:'SoundGenerationPlugin'>
	self var: #aSoundBuffer declareC: 'short int *aSoundBuffer'.
	self var: #waveTable declareC: 'short int *waveTable'.

	doingFM _ (normalizedModulation ~= 0) and: [scaledOffsetIndexIncr ~= 0].
	lastIndex _ (startIndex + n) - 1.
	startIndex to: lastIndex do: [:sliceIndex |
		sample _ (scaledVol * (waveTable at: (scaledIndex // ScaleFactor) + 1)) // ScaleFactor.
		doingFM
			ifTrue: [
				offset _ normalizedModulation * (waveTable at: (scaledOffsetIndex // ScaleFactor) + 1).
				scaledOffsetIndex _ (scaledOffsetIndex + scaledOffsetIndexIncr) \\ scaledWaveTableSize.
				scaledOffsetIndex < 0
					ifTrue: [scaledOffsetIndex _ scaledOffsetIndex + scaledWaveTableSize].
				scaledIndex _ (scaledIndex + scaledIndexIncr + offset) \\ scaledWaveTableSize.
				scaledIndex < 0
					ifTrue: [scaledIndex _ scaledIndex + scaledWaveTableSize]]
			ifFalse: [
				scaledIndex _ (scaledIndex + scaledIndexIncr) \\ scaledWaveTableSize].

		leftVol > 0 ifTrue: [
			i _ (2 * sliceIndex) - 1.
			s _ (aSoundBuffer at: i) + ((sample * leftVol) // ScaleFactor).
			s >  32767 ifTrue: [s _  32767].  "clipping!"
			s < -32767 ifTrue: [s _ -32767].  "clipping!"
			aSoundBuffer at: i put: s].
		rightVol > 0 ifTrue: [
			i _ 2 * sliceIndex.
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
					scaledVolIncr _ 0]]].

	count _ count - n.
