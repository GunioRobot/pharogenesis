clearBuffers
	"Clear the MIDI record buffers. This should be called at the start of recording or real-time MIDI processing."	

	received _ received species new: 5000.
	rawDataBuffer _ ByteArray new: 1000.
	sysExBuffer _ WriteStream on: (ByteArray new: 100).
	midiPort ifNotNil: [midiPort ensureOpen; flushInput].
	startTime _ Time millisecondClockValue.
	state _ #idle.
