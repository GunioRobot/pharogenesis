primitiveAt

	| index rcvr floatValue floatPtr |
	self export: true.
	self var: #floatValue declareC:'double floatValue'.
	self var: #floatPtr declareC:'float *floatPtr'.
	index _ interpreterProxy stackIntegerValue: 0.
	rcvr _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy success: (interpreterProxy isWords: rcvr).
	interpreterProxy success: (index > 0 and:[index <= (interpreterProxy slotSizeOf: rcvr)]).
	interpreterProxy failed ifTrue:[^nil].
	floatPtr _ interpreterProxy firstIndexableField: rcvr.
	floatValue _ (floatPtr at: index-1) asFloat.
	interpreterProxy pop: 2.
	interpreterProxy pushFloat: floatValue.