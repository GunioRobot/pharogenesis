sampleCount
	"Return the number of 32-bit sound samples that fit in this sound buffer. For stereo, 16-bit left and right channel samples are packed into each 32-bit word. For mono, samples are still 32-bits, but only the low-order 16 bits of each sample are played."

	^ super size