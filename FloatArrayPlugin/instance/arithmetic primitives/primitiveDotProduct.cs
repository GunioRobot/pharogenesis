primitiveDotProduct
	"Primitive. Compute the dot product of the receiver and the argument.
	The dot product is defined as the sum of the products of the individual elements."
	| rcvr arg rcvrPtr argPtr length result |
	self export: true.
	self var: #rcvrPtr declareC:'float *rcvrPtr'.
	self var: #argPtr declareC:'float *argPtr'.
	self var: #result declareC:'double result'.
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
	result _ 0.0.
	0 to: length-1 do:[:i|
		result _ result + ((rcvrPtr at: i) * (argPtr at: i)).
	].
	interpreterProxy pop: 2. "Pop args + rcvr"
	interpreterProxy pushFloat: result. "Return result"