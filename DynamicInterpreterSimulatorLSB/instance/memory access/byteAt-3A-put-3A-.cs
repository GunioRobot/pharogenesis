byteAt: byteAddress put: byte
	| longWord shift lowBits |
	lowBits _ byteAddress bitAnd: 3.
	longWord _ self longAt: byteAddress - lowBits.
	shift _ lowBits * 8.
	longWord _ longWord - (longWord bitAnd: (16rFF bitShift: shift)) + (byte bitShift: shift).
	self longAt: byteAddress - lowBits put: longWord