primitiveSubScalar
	"Primitive. Add the argument, a scalar value to the receiver, a FloatArray"
	| rcvr rcvrPtr value length |
	self export: true.
	self var: #value declareC:'double value'.
	self var: #rcvrPtr declareC:'float *rcvrPtr'.
	value _ interpreterProxy stackFloatValue: 0.
	rcvr _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy success: (interpreterProxy isWords: rcvr).
	interpreterProxy failed ifTrue:[^nil].
	length _ interpreterProxy stSizeOf: rcvr.
	rcvrPtr _ self cCoerce: (interpreterProxy firstIndexableField: rcvr) to: 'float *'.
	0 to: length-1 do:[:i|
		rcvrPtr at: i put: (rcvrPtr at: i) - value.
	].
	interpreterProxy pop: 1. "Leave rcvr on stack"