primitiveSoundGetRecordingSampleRate
	"Return a float representing the actual sampling rate during recording. Fail if not currently recording."

	| rate |
	self var: #rate declareC: 'double rate'.
	rate _ self cCode: 'snd_GetRecordingSampleRate()'.  "fail if not recording"
	successFlag ifTrue: [
		self pop: 1.  "rcvr"
		self pushFloat: rate.
	].
