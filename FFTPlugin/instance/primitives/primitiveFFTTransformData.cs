primitiveFFTTransformData
	| rcvr forward |
	self export: true.
	forward _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 0).
	rcvr _ interpreterProxy stackObjectValue: 1.
	(self loadFFTFrom: rcvr) ifFalse:[^nil].
	self transformData: forward.
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 1. "Leave rcvr on stack"
	].