startMIDITracking

	midiParser ifNil: [^ self].
	midiParser midiPort ifNil: [^ self].
	midiParser midiPort ensureOpen.
	self stopMIDITracking.
	SoundPlayer useShortBuffer.
	process _ [self midiTrackingLoop] newProcess.
	process priority: Processor userInterruptPriority.
	process resume.
