nextBitsPut: anInteger
	| integer writeBitCount shiftCount |
	shiftCount _ 0.
	remainBitCount = 0
		ifTrue:
			[writeBitCount _ 8.
			integer _ anInteger]
		ifFalse:
			[writeBitCount _ remainBitCount.
			integer _ bufByte + (anInteger bitShift: 8 - remainBitCount)].
	[writeBitCount < codeSize]
		whileTrue:
			[self nextBytePut: ((integer bitShift: shiftCount) bitAnd: 255).
			shiftCount _ shiftCount - 8.
			writeBitCount _ writeBitCount + 8].
	(remainBitCount _ writeBitCount - codeSize) = 0
		ifTrue: [self nextBytePut: (integer bitShift: shiftCount)]
		ifFalse: [bufByte _ integer bitShift: shiftCount].
	^anInteger