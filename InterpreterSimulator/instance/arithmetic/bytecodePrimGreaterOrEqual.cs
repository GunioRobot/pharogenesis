bytecodePrimGreaterOrEqual
	"Must be overridden from Interpreter because simulator doesn't have
		32-bit signed ints to work with"
	| rcvr arg |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	(self areIntegers: rcvr and: arg)
		ifTrue: [ ^ self booleanCheat:
			(self integerValueOf: rcvr) >= (self integerValueOf: arg)].
	^ super bytecodePrimGreaterOrEqual