primitiveSoundSetRecordLevel
	"Set the sound input recording level."

	| level |
	level _ self stackIntegerValue: 0.
	successFlag ifTrue: [
		self cCode: 'snd_SetRecordLevel(level)'.
	].
	successFlag ifTrue: [
		self pop: 1.  "pop level; leave rcvr on stack"
	].
