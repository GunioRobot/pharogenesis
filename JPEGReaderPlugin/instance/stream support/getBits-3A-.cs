getBits: requestedBits
	| value |
	requestedBits > jsBitCount ifTrue:[
		self fillBuffer.
		requestedBits > jsBitCount ifTrue:[^-1]].
	value _ jsBitBuffer bitShift: (requestedBits - jsBitCount).
	jsBitBuffer _ jsBitBuffer bitAnd: (1 bitShift: (jsBitCount - requestedBits)) -1.
	jsBitCount _ jsBitCount - requestedBits.
	^ value