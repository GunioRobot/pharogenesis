primitiveSoundInsertSamples
	"Insert a buffer's worth of sound samples into the currently playing buffer. Used to make a sound start playing as quickly as possible. The new sound is mixed with the previously buffered sampled."
	"Details: Unlike primitiveSoundPlaySamples, this primitive always starts with the first sample the given sample buffer. Its third argument specifies the number of samples past the estimated sound output buffer position the inserted sound should start. If successful, it returns the number of samples inserted."

	| leadTime buf frameCount framesPlayed |
	leadTime _ self stackIntegerValue: 0.
	buf _ self stackValue: 1.
	frameCount _ self stackIntegerValue: 2.
	self success: (self isWords: buf).
	self success: (frameCount <= (self lengthOf: buf)).

	successFlag ifTrue: [
		framesPlayed _
			self cCode: 'snd_InsertSamplesFromLeadTime(frameCount, buf + 4, leadTime)'.
		self success: framesPlayed >= 0].

	successFlag ifTrue: [
		self pop: 4.  "pop frameCount, buf, leadTime, rcvr"
		self push: (self positive32BitIntegerFor: framesPlayed)].
