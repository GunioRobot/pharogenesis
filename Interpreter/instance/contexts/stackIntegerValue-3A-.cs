stackIntegerValue: offset
	| integerPointer |
	integerPointer _ self longAt: stackPointer - (offset*4).
	(self isIntegerObject: integerPointer)
		ifTrue: [ ^self integerValueOf: integerPointer ]
		ifFalse: [ self primitiveFail. ^0 ]