primitiveSoundRecordSamples
	"Record a buffer's worth of 16-bit sound samples."

	| startWordIndex buf bufSizeInBytes samplesRecorded |
	startWordIndex _ self stackIntegerValue: 0.
	buf _ self stackValue: 1.
	self success: (self isWords: buf).
	successFlag ifTrue: [
		bufSizeInBytes _ (self lengthOf: buf) * 4.
		self success: ((startWordIndex >= 1) and: [((startWordIndex - 1) * 2) < bufSizeInBytes]).
	].
	successFlag ifTrue: [
		samplesRecorded _
			self cCode: 'snd_RecordSamplesIntoAtLength(buf + 4, startWordIndex - 1, bufSizeInBytes)'.
	].
	successFlag ifTrue: [
		self pop: 3.  "pop rcvr, startWordIndex, buf"
		self push: (self integerObjectOf: samplesRecorded).
	].
