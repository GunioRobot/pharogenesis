primitiveMod
	| mod |
	mod _ self doPrimitiveMod: (self stackValue: 1) by: (self stackValue: 0).
	self pop2AndPushIntegerIfOK: mod