primitiveEqual

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
	interpreterProxy pop: 2.
	length _ interpreterProxy stSizeOf: arg.
	length = (interpreterProxy stSizeOf: rcvr) ifFalse:[^interpreterProxy pushBool: false].

	rcvrPtr _ self cCoerce: (interpreterProxy firstIndexableField: rcvr) to: 'float *'.
	argPtr _ self cCoerce: (interpreterProxy firstIndexableField: arg) to: 'float *'.
	0 to: length-1 do:[:i|
		(rcvrPtr at: i) = (argPtr at: i) ifFalse:[^interpreterProxy pushBool: false].
	].
	^interpreterProxy pushBool: true