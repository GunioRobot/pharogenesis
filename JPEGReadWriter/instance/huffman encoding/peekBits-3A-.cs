peekBits: requestedBits

	requestedBits > bitsInBuffer
		ifTrue:
			[self fillBuffer.
			requestedBits > bitsInBuffer ifTrue: [^ -1]].
	^ bitBuffer >> (bitsInBuffer - requestedBits)
		