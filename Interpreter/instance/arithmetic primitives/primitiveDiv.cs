primitiveDiv
	| quotient |
	quotient _ self doPrimitiveDiv: (self stackValue: 1) by: (self stackTop).
	self pop2AndPushIntegerIfOK: quotient