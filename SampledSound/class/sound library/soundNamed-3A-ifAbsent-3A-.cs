soundNamed: aString ifAbsent: aBlock
	"Answer the sound of the given name, or if there is no sound of that name, answer the result of evaluating aBlock"
	"(SampledSound soundNamed: 'shutterClick') play"

	| entry samples |
	entry _ SoundLibrary
		at: aString
		ifAbsent:
			[^ aBlock value].
	entry ifNil: [^ aBlock value].
	samples _ entry at: 1.
	samples class isBytes ifTrue: [samples _ self convert8bitSignedTo16Bit: samples].
	^ self samples: samples samplingRate: (entry at: 2)
