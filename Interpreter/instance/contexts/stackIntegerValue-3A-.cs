stackIntegerValue: offset
	| integerPointer |
	integerPointer _ self longAt: stackPointer - (offset*4).
	^self checkedIntegerValueOf: integerPointer