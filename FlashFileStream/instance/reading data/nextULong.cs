nextULong
	^self nextByte + 
		(self nextByte bitShift: 8) + 
		(self nextByte bitShift: 16) + 
		(self nextByte bitShift: 24).