nextLongPut: value

	value < 0 
		ifTrue:[self nextULongPut: 16r100000000 - value]
		ifFalse:[self nextULongPut: value]