startRecording
	"Turn of the sound input driver and start the recording process. Initially, recording is paused."

	| semaIndex |
	recordLevel ifNil: [recordLevel _ 0.5].  "lazy initialization"
	CanRecordWhilePlaying ifFalse: [SoundPlayer shutDown].
	recordProcess ifNotNil: [self stopRecording].
	paused _ true.
	meteringBuffer _ SoundBuffer newMonoSampleCount: 1024.
	meterLevel _ 0.
	self allocateBuffer.
	bufferAvailableSema _ Semaphore new.
	semaIndex _ Smalltalk registerExternalObject: bufferAvailableSema.
	self primStartRecordingDesiredSampleRate: samplingRate asInteger
		stereo: stereo
		semaIndex: semaIndex.
	samplingRate _ self primGetActualRecordingSampleRate.
	self primSetRecordLevel: (1000.0 * recordLevel) asInteger.
	recordProcess _ [self recordLoop] newProcess.
	recordProcess priority: Processor userInterruptPriority.
	recordProcess resume.
