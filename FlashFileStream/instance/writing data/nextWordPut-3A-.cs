nextWordPut: value
	self nextBytePut: (value bitAnd: 255).
	self nextBytePut: ((value bitShift: -8) bitAnd: 255).