halfWordAt: byteAddress
    "Return the half-word at byteAddress which must be even."
	| lowBits long |
	lowBits _ byteAddress bitAnd: 2.
	long _ self longAt: byteAddress - lowBits.
	^lowBits = 2
		ifTrue: [ long bitShift: -16 ]
		ifFalse: [ long bitAnd: 16rFFFF ].
