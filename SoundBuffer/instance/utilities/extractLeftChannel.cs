extractLeftChannel
	"Answer a new SoundBuffer half the size of the receiver consisting of only the left channel of the receiver, which is assumed to contain stereo sound data."

	| n resultBuf j |
	n _ self monoSampleCount.
	resultBuf _ SoundBuffer newMonoSampleCount: n // 2.
	j _ 0.
	1 to: n by: 2 do: [:i | resultBuf at: (j _ j + 1) put: (self at: i)].
	^ resultBuf