editSound: aSound

	| p |
	sound _ aSound.
	sound envelopes isEmpty ifTrue: [
		"provide a default volume envelope"
		p _ OrderedCollection new.
		p add: 0@0.0; add: 10@1.0; add: 100@1.0; add: 120@0.0.
		sound addEnvelope: (VolumeEnvelope points: p loopStart: 2 loopEnd: 3)].

	self editEnvelope: sound envelopes first.
	keyboard soundPrototype: sound.
