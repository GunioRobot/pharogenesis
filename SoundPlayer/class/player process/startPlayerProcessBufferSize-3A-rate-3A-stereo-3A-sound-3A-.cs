startPlayerProcessBufferSize: bufferSize rate: samplesPerSecond stereo: stereoFlag sound: aSound
	"Start the sound player process. Terminate the old process, if any."
	"SoundPlayer startPlayerProcessBufferSize: 1000 rate: 11025 stereo: false"

	self stopPlayerProcess.
	aSound
		ifNil:[ActiveSounds _ OrderedCollection new]
		ifNotNil:[ActiveSounds _ OrderedCollection with: aSound].
	Buffer _ SoundBuffer newStereoSampleCount: (bufferSize // 4) * 4.
	LastBuffer ifNotNil:[LastBuffer _ SoundBuffer basicNew: Buffer basicSize].
	PlayerSemaphore _ Semaphore forMutualExclusion.
	SamplingRate _ samplesPerSecond.
	Stereo _ stereoFlag.
	ReadyForBuffer _ Semaphore new.
	SoundSupported _ true. "Assume so"
	UseReadySemaphore _ true.  "set to false if ready semaphore not supported by VM"
	self primSoundStartBufferSize: Buffer stereoSampleCount
		rate: samplesPerSecond
		stereo: Stereo
		semaIndex: (Smalltalk registerExternalObject: ReadyForBuffer).
	"Check if sound start prim was successful"
	SoundSupported ifFalse:[^self].
	UseReadySemaphore
		ifTrue: [PlayerProcess _ [SoundPlayer playLoop] newProcess]
		ifFalse: [PlayerProcess _ [SoundPlayer oldStylePlayLoop] newProcess].
	UseReverb ifTrue: [self startReverb].

	PlayerProcess priority: Processor userInterruptPriority.
	PlayerProcess resume.