byteAt: byteAddress
	| lowBits |
	lowBits _ byteAddress bitAnd: 3.
	^((self longAt: byteAddress - lowBits)
		bitShift: (lowBits - 3) * 8)
		bitAnd: 16rFF