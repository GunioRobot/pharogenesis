getBits: requestedBits

	| value |
	requestedBits > bitsInBuffer
		ifTrue:
			[self fillBuffer.
			requestedBits > bitsInBuffer
				ifTrue:
					[self error: 'not enough bits available to decode']].
	value _ bitBuffer >> (bitsInBuffer - requestedBits).
	bitBuffer _ bitBuffer bitAnd: (1 << (bitsInBuffer - requestedBits) -1).
	bitsInBuffer _ bitsInBuffer - requestedBits.
	^ value
		