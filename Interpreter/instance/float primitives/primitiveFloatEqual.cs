primitiveFloatEqual

	| rcvr rcvrOop arg argOop |
	self var: #rcvr declareC: 'double rcvr'.
	self var: #arg declareC: 'double arg'.

	rcvrOop _ self stackValue: 1.
	argOop _ self stackTop.
	self assertFloat: rcvrOop and: argOop.
	successFlag ifTrue: [
		self fetchFloatAt: rcvrOop + BaseHeaderSize into: rcvr.
		self fetchFloatAt: argOop + BaseHeaderSize into: arg.
		self pop: 2.
		self pushBool: rcvr = arg].
