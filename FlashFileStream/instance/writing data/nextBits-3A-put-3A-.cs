nextBits: n put: aNumber
	"Write the next n bits"
	| value remaining shift |
	value _ aNumber. "Do not round - this is a sanity check"
	value isInteger ifFalse:[^self error:'Not an integer number'].
	value < 0 ifTrue:[^self error:'Not a positive number'].
	n = 0 ifTrue:[^0].
	(n between: 1 and: 32) ifFalse:[^self error:'Bad number of bits'].
	value < (1 bitShift: n) ifFalse:[^self error:'Unable to represent number'].
	remaining _ n.
	[true] whileTrue:[
		shift _ 8 - bitPosition - remaining.
		bitBuffer _ bitBuffer + (value bitShift: shift).
		"Mask out consumed bits"
		value _ value bitAnd: (1 bitShift: 0-shift) - 1.
		shift < 0 ifTrue:["Buffer overflow"
			remaining _ remaining - (8 - bitPosition).
			"Store next byte"
			self nextByteForBitsPut: bitBuffer.
			bitBuffer _ 0.
			bitPosition _ 0.
		] ifFalse:["Store only portion of the buffer"
			bitPosition _ bitPosition + remaining.
			^self
		].
	].