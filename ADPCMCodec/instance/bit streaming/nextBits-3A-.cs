nextBits: n
	"Answer the next n bits of my bit stream as an unsigned integer."

	| result remaining shift |
	self inline: true.

	result _ 0.
	remaining _ n.
	[true] whileTrue: [
		shift _ remaining - bitPosition.
		result _ result + (currentByte bitShift: shift).
		shift > 0
			ifTrue: [  "consumed currentByte buffer; fetch next byte"
				remaining _ remaining - bitPosition.			
				currentByte _ (encodedBytes at: (byteIndex _ byteIndex + 1)).
				bitPosition _ 8]
			ifFalse: [  "still some bits left in currentByte buffer"
				bitPosition _ bitPosition - remaining.
				"mask out the consumed bits:"
				currentByte _ currentByte bitAnd: (255 bitShift: (bitPosition - 8)).
				^ result]].
