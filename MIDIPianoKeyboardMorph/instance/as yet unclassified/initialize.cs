initialize

	super initialize.
	SimpleMIDIPort midiIsSupported
		ifTrue: [midiPort _ SimpleMIDIPort openDefault].
	channel _ 1.
	velocity _ 100.
