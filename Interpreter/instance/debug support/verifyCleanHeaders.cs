verifyCleanHeaders
	| oop |
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue:
		[(self isFreeObject: oop)
			ifTrue: ["There should only be one free block at end of memory."
					(self objectAfter: oop) = endOfMemory
						ifFalse: [self error: 'Invalid obj with HeaderTypeBits = Free.']]
			ifFalse: [((self longAt: oop) bitAnd: MarkBit) = 0
						ifFalse: [self error: 'Invalid obj with MarkBit set.']].
		oop _ self objectAfter: oop]