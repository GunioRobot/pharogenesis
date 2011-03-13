initialize
	"SoundPlayer initialize"
	"Details: BufferMSecs represents a tradeoff between latency and quality. If BufferMSecs is too low, the sound will not play smoothing, especially during other activities. If it is too high, there will be an overly long time lag between when a sound buffer is submitted to be played and when that sound is actually heard. It is typically in the range 50-200."
	"SoundPlayer initialize; shutDown; startUp"

	SamplingRate _ 22050.
	BufferMSecs _ 200.
	Stereo _ true.
	UseReverb ifNil: [UseReverb _ true].
