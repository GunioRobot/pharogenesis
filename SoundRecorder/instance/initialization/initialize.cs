initialize
	"SoundRecorder new"

	stereo _ false.
	samplingRate _ SoundPlayer samplingRate.
	recordedBuffers _ OrderedCollection new: 1000.
	meteringBuffer _ SoundBuffer newMonoSampleCount: 1024.
	self initializeRecordingState.
