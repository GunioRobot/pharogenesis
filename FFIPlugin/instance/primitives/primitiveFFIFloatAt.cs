primitiveFFIFloatAt
	"Return a (signed or unsigned) n byte integer from the given byte offset."
	| byteOffset rcvr addr floatValue |
	self export: true.
	self inline: false.
	self var: #floatValue declareC:'float floatValue'.
	byteOffset _ interpreterProxy stackIntegerValue: 0.
	rcvr _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^0].
	addr _ self addressOf: rcvr startingAt: byteOffset size: 4.
	interpreterProxy failed ifTrue:[^0].
	self cCode:'((int*)(&floatValue))[0] = ((int*)addr)[0]'.
	interpreterProxy pop: 2.
	^interpreterProxy pushFloat: floatValue