primitiveSoundPlaySilence
	"Output a buffer's worth of silence. Returns the number of sample frames played."

	| framesPlayed |
	framesPlayed _ self cCode: 'snd_PlaySilence()'.  "-1 if sound output not started"
	self success: framesPlayed >= 0.
	successFlag ifTrue: [
		self pop: 1.  "rcvr"
		self push: (self positive32BitIntegerFor: framesPlayed).
	].