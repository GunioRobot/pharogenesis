primitiveFFIDoubleAtPut
	"Return a (signed or unsigned) n byte integer from the given byte offset."
	| byteOffset rcvr addr floatValue floatOop |
	self export: true.
	self inline: false.
	self var: #floatValue declareC:'double floatValue'.
	floatOop _ interpreterProxy stackValue: 0.
	(interpreterProxy isIntegerObject: floatOop)
		ifTrue:[floatValue _ self cCoerce: (interpreterProxy integerValueOf: floatOop) to:'double']
		ifFalse:[floatValue _ self cCoerce: (interpreterProxy floatValueOf: floatOop) to:'double'].
	byteOffset _ interpreterProxy stackIntegerValue: 1.
	rcvr _ interpreterProxy stackObjectValue: 2.
	interpreterProxy failed ifTrue:[^0].
	addr _ self addressOf: rcvr startingAt: byteOffset size: 8.
	interpreterProxy failed ifTrue:[^0].
	self cCode:'((int*)addr)[0] = ((int*)(&floatValue))[0]'.
	self cCode:'((int*)addr)[1] = ((int*)(&floatValue))[1]'.
	interpreterProxy pop: 3.
	^interpreterProxy push: floatOop