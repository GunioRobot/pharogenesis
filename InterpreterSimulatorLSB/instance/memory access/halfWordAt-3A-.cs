halfWordAt: byteAddress
	| lowBits |
	lowBits _ byteAddress bitAnd: 2.
	^((self longAt: byteAddress - lowBits)
		bitShift: (0 - lowBits) * 8)
		bitAnd: 16rFFFF