reset

	super reset.
	self createMixer.
	mpegFile audioSetSample: 0 stream: mpegStreamIndex.
	lastBufferMSecs _ 0.
	mutex _ Semaphore forMutualExclusion.
