primitiveSoundPlaySamples
	"Output a buffer's worth of sound samples."

	| startIndex buf frameCount framesPlayed |
	startIndex _ self stackIntegerValue: 0.
	buf _ self stackValue: 1.
	frameCount _ self stackIntegerValue: 2.
	self success: (self isWords: buf).
	self success: (
		(startIndex >= 1) and:
		[(startIndex + frameCount - 1) <= (self lengthOf: buf)]).

	successFlag ifTrue: [
		framesPlayed _
			self cCode: 'snd_PlaySamplesFromAtLength(frameCount, buf + 4, startIndex - 1)'.
		self success: framesPlayed >= 0.
	].
	successFlag ifTrue: [
		self pop: 4.  "pop frameCount, buf, startIndex, rcvr"
		self push: (self positive32BitIntegerFor: framesPlayed).
	].