stopMIDITracking

	process ifNotNil: [
		process terminate.
		process _ nil].
	SoundPlayer shutDown; initialize.  "revert to normal buffer size"
