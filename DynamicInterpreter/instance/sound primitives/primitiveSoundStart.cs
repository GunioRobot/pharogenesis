primitiveSoundStart
	"Start the double-buffered sound output with the given buffer size, sample rate, and stereo flag."

	| stereoFlag samplesPerSec bufFrames |
	stereoFlag		_ self booleanValueOf: (self stackValue: 0).
	samplesPerSec	_ self stackIntegerValue: 1.
	bufFrames		_ self stackIntegerValue: 2.
	successFlag ifTrue: [
		self success: (self cCode: 'snd_Start(bufFrames, samplesPerSec, stereoFlag, 0)').
	].
	successFlag ifTrue: [
		self pop: 3.  "pop bufFrames, samplesPerSec, stereoFlag; leave rcvr on stack"
	].