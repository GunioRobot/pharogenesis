primitiveSoundStartRecording
	"Start recording sound with the given parameters."

	| semaIndex stereoFlag desiredSamplesPerSec |
	semaIndex				_ self stackIntegerValue: 0.
	stereoFlag				_ self booleanValueOf: (self stackValue: 1).
	desiredSamplesPerSec	_ self stackIntegerValue: 2.
	successFlag ifTrue: [
		self cCode: 'snd_StartRecording(desiredSamplesPerSec, stereoFlag, semaIndex)'.
	].

	successFlag ifTrue: [
		self pop: 3.  "pop desiredSamplesPerSec, stereoFlag, and semaIndex; leave rcvr on stack"
	].
