mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Play a collection of sounds in sequence."
	"PluckedSound chromaticScale play"

	| finalIndex i snd remaining count |
	currentIndex = 0 ifTrue: [^ self].  "already done"
	finalIndex _ (startIndex + n) - 1.
	i _ startIndex.
	[i <= finalIndex] whileTrue: [
		snd _ (sounds at: currentIndex).
		[(remaining _ snd samplesRemaining) <= 0] whileTrue: [
			"find next undone sound"
			currentIndex < sounds size
				ifTrue: [
					currentIndex _ currentIndex + 1.
					snd _ (sounds at: currentIndex)]
				ifFalse: [
					currentIndex _ 0.
					^ self]].  "no more sounds"
		count _ (finalIndex - i) + 1.
		remaining < count ifTrue: [count _ remaining].
		snd mixSampleCount: count into: aSoundBuffer startingAt: i leftVol: leftVol rightVol: rightVol.
		i _ i + count].
