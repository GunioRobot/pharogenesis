primitiveDiv
	| quotient |
	quotient _ self doPrimitiveDiv: (self stackValue: 1) by: (self stackValue: 0).
	self pop2AndPushIntegerIfOK: quotient