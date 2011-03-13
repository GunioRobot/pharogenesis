new: anInteger
	"Return a SoundBuffer large enough to hold the given number of 16-bit values. (That is, an array of 32-bit words half the requested size)."

	^ self basicNew: (anInteger // 2)