nextBits: n
	"Return the next n bits"
	| shift value remaining |
	n = 0 ifTrue:[^0].
	(n between: 1 and: 32) ifFalse:[^self error:'Bad number of bits'].
	value _ 0.
	remaining _ n.
	[true] whileTrue:[
		shift _ remaining - bitPosition.
		value _ value bitOr: (bitBuffer bitShift: shift).
		shift > 0 ifTrue:["Consumes entire buffer"
			remaining _ remaining - bitPosition.
			"And get next byte"
			bitBuffer _ self nextByteForBits.
			bitPosition _ 8.
		] ifFalse:["Consumes a portion of the buffer"
			bitPosition _ bitPosition - remaining.
			"Mask off the consumed bits"
			bitBuffer _ bitBuffer bitAnd: (255 bitShift: (bitPosition - 8)).
			^value]].