halfWordAt: byteAddress put: halfWord
	| longWord shift lowBits |
	lowBits _ byteAddress bitAnd: 2.
	longWord _ self longAt: byteAddress - lowBits.
	shift _ lowBits * 8.
	longWord _ longWord - (longWord bitAnd: (16rFFFF bitShift: shift)) +
(halfWord bitShift: shift).
	self longAt: byteAddress - lowBits put: longWord
