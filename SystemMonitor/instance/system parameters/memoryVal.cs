memoryVal
	"If youngStart is below the highWaterMark then a full collection has happened."
	| youngStart |
	youngStart _ vmParameters at: 1.
	youngStart < gcHighWaterMark ifTrue: [gcLowWaterMark _ gcHighWaterMark _ youngStart].
	youngStart > gcHighWaterMark ifTrue: [gcHighWaterMark _ youngStart].
	^Array
		with: gcLowWaterMark
		with: gcHighWaterMark
		with: (vmParameters at: 2)