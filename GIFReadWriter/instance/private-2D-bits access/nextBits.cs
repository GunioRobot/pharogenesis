nextBits
	| integer readBitCount shiftCount byte |
	integer _ 0.
	remainBitCount = 0
		ifTrue:
			[readBitCount _ 8.
			shiftCount _ 0]
		ifFalse:
			[readBitCount _ remainBitCount.
			shiftCount _ remainBitCount - 8].
	[readBitCount < codeSize]
		whileTrue:
			[byte _ self nextByte.
			byte == nil ifTrue: [^eoiCode].
			integer _ integer + (byte bitShift: shiftCount).
			shiftCount _ shiftCount + 8.
			readBitCount _ readBitCount + 8].
	(remainBitCount _ readBitCount - codeSize) = 0
		ifTrue:	[byte _ self nextByte]
		ifFalse:	[byte _ self peekByte].
	byte == nil ifTrue: [^eoiCode].
	^(integer + (byte bitShift: shiftCount)) bitAnd: maxCode