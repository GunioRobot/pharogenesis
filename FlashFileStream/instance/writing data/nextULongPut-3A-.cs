nextULongPut: long
	self nextBytePut: (long bitAnd: 255).
	self nextBytePut: ((long bitShift: -8) bitAnd: 255).
	self nextBytePut: ((long bitShift: -16) bitAnd: 255).
	self nextBytePut: ((long bitShift: -24) bitAnd: 255).