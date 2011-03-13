mixSampleCount: n into: aSoundBuffer startingAt: startIndex pan: pan
	"Play a collection of sounds in sequence."
	"PluckedSound chromaticScale play"

	| finalIndex thisIndex snd cnt |
	currentIndex = 0 ifTrue: [ ^ self ].  "already done"
	finalIndex _ (startIndex + n) - 1.
	thisIndex _ startIndex.
	[thisIndex <= finalIndex] whileTrue: [
		snd _ (sounds at: currentIndex).
		[snd samplesRemaining <= 0] whileTrue: [
			"find next undone sound"
			currentIndex < sounds size ifTrue: [
				currentIndex _ currentIndex + 1.
				snd _ (sounds at: currentIndex).
			] ifFalse: [
				currentIndex _ 0.
				^ self  "no more sounds"
			].
		].
		cnt _ snd samplesRemaining min: (finalIndex - thisIndex) + 1.
		snd mixSampleCount: cnt into: aSoundBuffer startingAt: thisIndex pan: pan.
		thisIndex _ thisIndex + cnt.
	].
