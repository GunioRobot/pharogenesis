getBits: requestedBits
	| value |
	requestedBits > bitsInBuffer ifTrue:[
		self fillBuffer.
		requestedBits > bitsInBuffer ifTrue:[
			self error: 'not enough bits available to decode']].
	value _ bitBuffer bitShift: (requestedBits - bitsInBuffer).
	bitBuffer _ bitBuffer bitAnd: (1 bitShift: (bitsInBuffer - requestedBits)) -1.
	bitsInBuffer _ bitsInBuffer - requestedBits.
	^ value