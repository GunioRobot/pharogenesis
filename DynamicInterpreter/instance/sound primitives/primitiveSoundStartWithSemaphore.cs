primitiveSoundStartWithSemaphore
	"Start the double-buffered sound output with the given buffer size, sample rate, stereo flag, and semaphore index."

	| semaIndex stereoFlag samplesPerSec bufFrames |
	semaIndex		_ self stackIntegerValue: 0.
	stereoFlag		_ self booleanValueOf: (self stackValue: 1).
	samplesPerSec	_ self stackIntegerValue: 2.
	bufFrames		_ self stackIntegerValue: 3.
	successFlag ifTrue: [
		self success: (self cCode: 'snd_Start(bufFrames, samplesPerSec, stereoFlag, semaIndex)').
	].
	successFlag ifTrue: [
		self pop: 4.  "pop bufFrames, samplesPerSec, stereoFlag, semaIndex; leave rcvr on stack"
	].