primitiveDivScalar
	"Primitive. Add the argument, a scalar value to the receiver, a FloatArray"
	| rcvr rcvrPtr value inverse length |
	self export: true.
	self var: #value declareC:'double value'.
	self var: #inverse declareC:'double inverse'.
	self var: #rcvrPtr declareC:'float *rcvrPtr'.
	value _ interpreterProxy stackFloatValue: 0.
	rcvr _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	value = 0.0 ifTrue:[^interpreterProxy primitiveFail].
	interpreterProxy success: (interpreterProxy isWords: rcvr).
	interpreterProxy failed ifTrue:[^nil].
	length _ interpreterProxy stSizeOf: rcvr.
	rcvrPtr _ self cCoerce: (interpreterProxy firstIndexableField: rcvr) to: 'float *'.
	inverse _ 1.0 / value.
	0 to: length-1 do:[:i|
		rcvrPtr at: i put: (rcvrPtr at: i) * inverse.
	].
	interpreterProxy pop: 1. "Leave rcvr on stack"