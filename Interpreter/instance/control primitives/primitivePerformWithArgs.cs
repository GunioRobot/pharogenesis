primitivePerformWithArgs

	| lookupClass rcvr |
	rcvr _ self stackValue: argumentCount.
	lookupClass _ self fetchClassOf: rcvr.
	self primitivePerformAt: lookupClass.
