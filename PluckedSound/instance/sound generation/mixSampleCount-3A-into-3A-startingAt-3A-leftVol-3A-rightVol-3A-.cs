mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"The Karplus-Strong plucked string algorithm: start with a buffer full of random noise and repeatedly play the contents of that buffer while averaging adjacent samples. High harmonics damp out more quickly, transfering their energy to lower ones. The length of the buffer corresponds to the length of the string."
	"(PluckedSound pitch: 220.0 dur: 6.0 loudness: 0.8) play"

	| lastIndex scaledThisIndex scaledNextIndex average sample i s |
	<primitive:'primitiveMixPluckedSound' module:'SoundGenerationPlugin'>
	self var: #aSoundBuffer declareC: 'short int *aSoundBuffer'.
	self var: #ring declareC: 'short int *ring'.

	lastIndex _ (startIndex + n) - 1.
	scaledThisIndex _ scaledNextIndex _ scaledIndex.
	startIndex to: lastIndex do: [:sliceIndex |
		scaledNextIndex _ scaledThisIndex + scaledIndexIncr.
		scaledNextIndex >= scaledIndexLimit
			ifTrue: [scaledNextIndex _ ScaleFactor + (scaledNextIndex - scaledIndexLimit)].
		average _
			((ring at: scaledThisIndex // ScaleFactor) +
			 (ring at: scaledNextIndex // ScaleFactor)) // 2.
		ring at: scaledThisIndex // ScaleFactor put: average.
		sample _ (average * scaledVol) // ScaleFactor.  "scale by volume"
		scaledThisIndex _ scaledNextIndex.

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

	scaledIndex _ scaledNextIndex.
	count _ count - n.
