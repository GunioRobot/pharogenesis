playSilentlyUntil: startTime
	"Used to fast foward to a particular starting time.
	Overridden to be instant for sampled sounds."

"true ifTrue: [^ super playSilentlyUntil: startTime]."
	indexHighBits _ (startTime * originalSamplingRate) asInteger.
	scaledIndex _ IncrementScaleFactor.
	count _ initialCount - (startTime * self samplingRate).
	mSecsSinceStart _ (startTime * 1000) asInteger.

