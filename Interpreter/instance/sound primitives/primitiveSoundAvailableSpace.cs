primitiveSoundAvailableSpace
	"Returns the number of sample frames of available sound output buffer space."

	| frames |
	frames _ self cCode: 'snd_AvailableSpace()'.  "-1 if sound output not started"
	self success: frames >= 0.
	successFlag ifTrue: [
		self pop: 1.  "rcvr"
		self push: (self positive32BitIntegerFor: frames).
	].