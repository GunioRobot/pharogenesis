primitiveUpdateAdler32
	"Primitive. Update a 32bit CRC value."
	| collection stopIndex startIndex length bytePtr s1 adler32 s2 b |
	self export: true.
	self var: #adler32 declareC:'unsigned int adler32'.
	self var: #bytePtr declareC:'unsigned char *bytePtr'.
	interpreterProxy methodArgumentCount = 4
		ifFalse:[^interpreterProxy primitiveFail].
	collection _ interpreterProxy stackObjectValue: 0.
	stopIndex _ interpreterProxy stackIntegerValue: 1.
	startIndex _ interpreterProxy stackIntegerValue: 2.
	adler32 _ interpreterProxy positive32BitValueOf: (interpreterProxy stackValue: 3).
	interpreterProxy failed ifTrue:[^0].
	((interpreterProxy isBytes: collection) and:[stopIndex >= startIndex and:[startIndex > 0]])
		ifFalse:[^interpreterProxy primitiveFail].
	length _ interpreterProxy byteSizeOf: collection.
	(stopIndex <= length) ifFalse:[^interpreterProxy primitiveFail].
	bytePtr _ interpreterProxy firstIndexableField: collection.
	startIndex _ startIndex - 1.
	stopIndex _ stopIndex - 1.
	s1 := adler32 bitAnd: 16rFFFF.
	s2 := (adler32 >> 16) bitAnd: 16rFFFF.
	startIndex to: stopIndex do:[:i|
		b := bytePtr at: i.
		s1 := (s1 + b) \\ 65521.
		s2 := (s2 + s1) \\ 65521.
	].
	adler32 := (s2 bitShift: 16) + s1.
	interpreterProxy pop: 5. "args + rcvr"
	interpreterProxy push: (interpreterProxy positive32BitIntegerFor: adler32).