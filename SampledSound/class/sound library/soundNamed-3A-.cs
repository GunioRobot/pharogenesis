soundNamed: aString
	"Return a list of sound names for the sounds stored in the sound library."
	"(SampledSound soundNamed: 'shutterClick') play"

	| entry samples |
	entry _ SoundLibrary
		at: aString
		ifAbsent:
			[self inform: aString, ' not found in the Sound Library'.
			^ nil].
	entry ifNil: [^ nil].
	samples _ entry at: 1.
	samples class isBytes ifTrue: [samples _ self convert8bitSignedTo16Bit: samples].
	^ self samples: samples samplingRate: (entry at: 2)
