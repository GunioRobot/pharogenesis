primitiveSum
	"Primitive. Find the sum of each float in the receiver, a FloatArray, and stash the result into the argument Float."
	| rcvr rcvrPtr length sum |
	self export: true.
	self var: #sum declareC:'double sum'.
	self var: #rcvrPtr declareC:'float *rcvrPtr'.
	rcvr _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy success: (interpreterProxy isWords: rcvr).
	interpreterProxy failed ifTrue:[^nil].
	length _ interpreterProxy stSizeOf: rcvr.
	rcvrPtr _ self cCoerce: (interpreterProxy firstIndexableField: rcvr) to: 'float *'.
	sum _ 0.0.
	0 to: length-1 do:[:i|
		sum _ sum + (rcvrPtr at: i).
	].
	interpreterProxy pop: 1 thenPush: (interpreterProxy floatObjectOf: sum)