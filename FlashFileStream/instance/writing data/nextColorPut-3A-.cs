nextColorPut: aColor
	self nextBytePut: (aColor red * 255) rounded.
	self nextBytePut: (aColor green * 255) rounded.
	self nextBytePut: (aColor blue * 255) rounded.
	hasAlpha ifTrue:[self nextBytePut: (aColor alpha * 255) rounded].
