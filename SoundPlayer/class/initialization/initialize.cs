initialize
	"SoundPlayer initialize; shutDown; startUp"
	"Details: BufferMSecs represents a tradeoff between latency and quality. If BufferMSecs is too low, the sound will not play smoothly, especially during long-running primitives such as large BitBlts. If BufferMSecs is too high, there will be a long time lag between when a sound buffer is submitted to be played and when that sound is actually heard. BufferMSecs is typically in the range 50-200."

	SamplingRate _ 22050.
	BufferMSecs _ 120.
	Stereo _ true.
	UseReverb ifNil: [UseReverb _ true].
