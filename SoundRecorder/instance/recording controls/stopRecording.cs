stopRecording
	"Stop the recording process and turn of the sound input driver."

	recordProcess ifNotNil: [recordProcess terminate].
	recordProcess _ nil.
	self primStopRecording.
	Smalltalk unregisterExternalObject: bufferAvailableSema.
	((currentBuffer ~~ nil) and: [nextIndex > 1])
		ifTrue: [
			recordedBuffers addLast: (currentBuffer copyFrom: 1 to: nextIndex - 1)].
	self initializeRecordingState.
