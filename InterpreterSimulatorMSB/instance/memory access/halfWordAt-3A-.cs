halfWordAt: byteAddress
    "Return the half-word at byteAddress which must be even."
	| lowBits |
	lowBits _ byteAddress bitAnd: 2.
	^((self longAt: byteAddress - lowBits)
		bitShift: (lowBits - 2) * 8)
		bitAnd: 16rFFFF
