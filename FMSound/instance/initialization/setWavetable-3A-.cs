setWavetable: anArray
	"(AbstractSound lowMajorScaleOn: (FMSound new setWavetable: AA)) play"

	| samples p dur vol |
	"copy the array into a SoundBuffer if necessary"
	anArray class isPointers
		ifTrue: [samples _ SoundBuffer fromArray: anArray]
		ifFalse: [samples _ anArray].

	p _ self pitch.
	dur _ self duration.
	vol _ self loudness.
	waveTable _ samples.
	scaledWaveTableSize _ waveTable size * ScaleFactor.
	self setPitch: p dur: dur loudness: vol.
