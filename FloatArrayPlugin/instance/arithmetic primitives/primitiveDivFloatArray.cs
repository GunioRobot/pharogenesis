primitiveDivFloatArray
	"Primitive. Add the receiver and the argument, both FloatArrays and store the result into the receiver."
	| rcvr arg rcvrPtr argPtr length |
	self export: true.
	self var: #rcvrPtr declareC:'float *rcvrPtr'.
	self var: #argPtr declareC:'float *argPtr'.
	arg _ interpreterProxy stackObjectValue: 0.
	rcvr _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy success: (interpreterProxy isWords: arg).
	interpreterProxy success: (interpreterProxy isWords: rcvr).
	interpreterProxy failed ifTrue:[^nil].
	length _ interpreterProxy stSizeOf: arg.
	interpreterProxy success: (length = (interpreterProxy stSizeOf: rcvr)).
	interpreterProxy failed ifTrue:[^nil].
	rcvrPtr _ self cCoerce: (interpreterProxy firstIndexableField: rcvr) to: 'float *'.
	argPtr _ self cCoerce: (interpreterProxy firstIndexableField: arg) to: 'float *'.
	"Check if any of the argument's values is zero"
	0 to: length-1 do:[:i|
		(interpreterProxy longAt: (argPtr + i)) = 0 ifTrue:[^interpreterProxy primitiveFail]].
	0 to: length-1 do:[:i|
		rcvrPtr at: i put: (rcvrPtr at: i) / (argPtr at: i).
	].
	interpreterProxy pop: 1. "Leave rcvr on stack"