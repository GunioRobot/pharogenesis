mouseDownEvent: event noteMorph: noteMorph pitch: midiKey

	midiPort ifNil: [^ super mouseDownEvent: event noteMorph: noteMorph pitch: midiKey - 1].
	noteMorph color: playingKeyColor.
	soundPlaying
		ifNil: [midiPort ensureOpen]
		ifNotNil: [self turnOffNote].
	self turnOnNote: midiKey + 23.
