nextBits: n
	"Return the next n bits"
	| shift value remaining |
	n = 0 ifTrue:[^0].
	(n between: 1 and: 32) ifFalse:[^self error:'Bad number of bits'].
	value := 0.
	remaining := n.
	[true] whileTrue:[
		shift := remaining - bitPosition.
		value := value bitOr: (bitBuffer bitShift: shift).
		shift > 0 ifTrue:["Consumes entire buffer"
			remaining := remaining - bitPosition.
			"And get next byte"
			bitBuffer := self nextByteForBits.
			bitPosition := 8.
		] ifFalse:["Consumes a portion of the buffer"
			bitPosition := bitPosition - remaining.
			"Mask off the consumed bits"
			bitBuffer := bitBuffer bitAnd: (255 bitShift: (bitPosition - 8)).
			^value]].