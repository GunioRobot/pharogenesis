soundNamed: aString
	"Answer the sound of the given name, or nil if there is no sound of that name."
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
