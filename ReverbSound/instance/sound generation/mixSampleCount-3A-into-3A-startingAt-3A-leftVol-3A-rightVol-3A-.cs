mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Play my sound with reberberation."

	sound mixSampleCount: n
		into: aSoundBuffer
		startingAt: startIndex
		leftVol: leftVol
		rightVol: rightVol.
	self applyReverbTo: aSoundBuffer startingAt: startIndex count: n.
