primitiveFloatGreater: rcvrOop thanArg: argOop
	| rcvr arg |
	self var: #rcvr declareC: 'double rcvr'.
	self var: #arg declareC: 'double arg'.

	rcvr _ self loadFloatOrIntFrom: rcvrOop.
	arg _ self loadFloatOrIntFrom: argOop.
	successFlag ifTrue: [^ rcvr > arg].
