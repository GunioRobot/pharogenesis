primitiveAtPut

	| value floatValue index rcvr floatPtr |
	self export: true.
	self var: #floatValue declareC: 'double floatValue'.
	self var: #floatPtr declareC:'float *floatPtr'.
	value _ interpreterProxy stackValue: 0.
	(interpreterProxy isIntegerObject: value)
		ifTrue:[floatValue _ (interpreterProxy integerValueOf: value) asFloat]
		ifFalse:[floatValue _ interpreterProxy floatValueOf: value].
	index _ interpreterProxy stackIntegerValue: 1.
	rcvr _ interpreterProxy stackObjectValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy success: (interpreterProxy isWords: rcvr).
	interpreterProxy success: (index > 0 and:[index <= (interpreterProxy slotSizeOf: rcvr)]).
	interpreterProxy failed ifTrue:[^nil].
	floatPtr _ interpreterProxy firstIndexableField: rcvr.
	floatPtr at: index-1 put: (self cCoerce: floatValue to:'float').
	interpreterProxy failed ifFalse:[interpreterProxy pop: 3 thenPush: value].