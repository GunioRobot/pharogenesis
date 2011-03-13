startPlayerProcessBufferSize: bufferSize rate: samplesPerSecond stereo: stereoFlag
	"Start the sound player process. Terminate the old process, if any."
	"SoundPlayer startPlayerProcessBufferSize: 1000 rate: 11025 stereo: false"

	self stopPlayerProcess.
	ActiveSounds _ OrderedCollection new.
	Buffer _ SoundBuffer sampleCount: bufferSize.
	BufferReady _ false.
	PlayerProcess _ [SoundPlayer playLoop] newProcess.
	PlayerProcess priority: Processor userInterruptPriority.
	PlayerSemaphore _ Semaphore forMutualExclusion.
	SamplingRate _ samplesPerSecond.
	Stereo _ stereoFlag.
	self primSoundStartBufferSize: Buffer sampleCount rate: samplesPerSecond stereo: Stereo.
	PlayerProcess resume.
