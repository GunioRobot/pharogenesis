startRecording
	"Start the sound input process."

	recordProcess ifNotNil: [self stopRecording].
	recordedBuffers _ OrderedCollection new: 100.
	mutex _ Semaphore forMutualExclusion.
	super startRecording.
	paused _ false.
