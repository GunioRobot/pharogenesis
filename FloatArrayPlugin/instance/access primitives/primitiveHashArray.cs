primitiveHashArray

	| rcvr rcvrPtr length result |
	self export: true.
	self var: #rcvrPtr declareC:'int *rcvrPtr'.
	rcvr _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy success: (interpreterProxy isWords: rcvr).
	interpreterProxy failed ifTrue:[^nil].
	length _ interpreterProxy stSizeOf: rcvr.
	rcvrPtr _ self cCoerce: (interpreterProxy firstIndexableField: rcvr) to: 'int *'.
	result _ 0.
	0 to: length-1 do:[:i|
		result _ result + (rcvrPtr at: i).
	].
	interpreterProxy pop: 1.
	^interpreterProxy pushInteger: (result bitAnd: 16r1FFFFFFF)