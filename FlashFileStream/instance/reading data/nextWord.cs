nextWord
	^self nextByte + (self nextByte bitShift: 8)