bytecodePrimEquivalent

	| rcvr arg |
	rcvr _ self internalStackValue: 1.
	arg _ self internalStackValue: 0.
	self booleanCheat: rcvr = arg.