startOver
	"Jump back to the first sample."

	stream reopen; binary.
	self readHeader.
	stream position: audioDataStart.
	leftoverSamples _ SoundBuffer new.
	lastBufferMSecs _ 0.
	mutex _ Semaphore forMutualExclusion.
