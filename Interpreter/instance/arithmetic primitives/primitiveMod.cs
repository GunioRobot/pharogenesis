primitiveMod
	| mod |
	mod _ self doPrimitiveMod: (self stackValue: 1) by: (self stackTop).
	self pop2AndPushIntegerIfOK: mod