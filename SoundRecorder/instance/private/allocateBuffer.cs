allocateBuffer
	"Allocate a new buffer and reset nextIndex."

	currentBuffer _ SoundBuffer newMonoSampleCount: 20000.
	nextIndex _ 1.
