splitStereo
	"Answer an array of two SoundBuffers half the size of the receiver consisting of the left and right channels of the receiver (which is assumed to contain stereo sound data)."

	| n leftBuf rightBuf leftIndex rightIndex |
	n _ self monoSampleCount.
	leftBuf _ SoundBuffer newMonoSampleCount: n // 2.
	rightBuf _ SoundBuffer newMonoSampleCount: n // 2.
	leftIndex _ rightIndex _ 0.
	1 to: n by: 2 do: [:i |
		leftBuf at: (leftIndex _ leftIndex + 1) put: (self at: i).
		rightBuf at: (rightIndex _ rightIndex + 1) put: (self at: i + 1)].
	^ Array with: leftBuf with: rightBuf
