allocateBuffer
	"Allocate a new buffer and reset nextIndex. This message is sent by the sound input process."

	currentBuffer _ SoundBuffer newMonoSampleCount: bufferSize.
	nextIndex _ 1.
