startRecording
	"Turn of the sound input driver and start the recording process. Initially, recording is paused."

	| semaIndex |
	CanRecordWhilePlaying ifFalse: [SoundPlayer shutDown].
	recordProcess ifNotNil: [self stopRecording].
	paused _ true.
	meteringBuffer _ SoundBuffer newMonoSampleCount: 1024.
	meterLevel _ 0.
	self allocateBuffer.
	bufferAvailableSema _ Semaphore new.
	semaIndex _ Smalltalk registerExternalObject: bufferAvailableSema.
	self primStartRecordingDesiredSampleRate: (SoundPlayer samplingRate)
		stereo: stereo
		semaIndex: semaIndex.
	samplingRate _ self primGetActualRecordingSampleRate.
	recordProcess _ [self recordLoop] newProcess.
	recordProcess priority: Processor userInterruptPriority.
	recordProcess resume.
