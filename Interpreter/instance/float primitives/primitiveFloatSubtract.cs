primitiveFloatSubtract

	| rcvr rcvrOop arg argOop result resultOop |
	self var: #rcvr declareC: 'double rcvr'.
	self var: #arg declareC: 'double arg'.
	self var: #result declareC: 'double result'.

	rcvrOop _ self stackValue: 1.
	argOop _ self stackTop.
	self assertFloat: rcvrOop and: argOop.
	successFlag ifTrue: [
		self fetchFloatAt: rcvrOop + BaseHeaderSize into: rcvr.
		self fetchFloatAt: argOop + BaseHeaderSize into: arg.
		result _ rcvr - arg.
		resultOop _ self clone: rcvrOop.
		self storeFloatAt: resultOop + BaseHeaderSize from: result.
		self pop: 2 thenPush: resultOop].