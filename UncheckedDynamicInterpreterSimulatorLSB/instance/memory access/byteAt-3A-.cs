byteAt: byteAddress
	| lowBits |
	lowBits _ byteAddress bitAnd: 3.
	^((self longAt: byteAddress - lowBits)
		bitShift: (0 - lowBits) * 8)
		bitAnd: 16rFF