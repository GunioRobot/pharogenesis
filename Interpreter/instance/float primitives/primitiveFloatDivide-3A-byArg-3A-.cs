primitiveFloatDivide: rcvrOop byArg: argOop
	| rcvr arg |
	self var: #rcvr declareC: 'double rcvr'.
	self var: #arg declareC: 'double arg'.

	rcvr _ self loadFloatOrIntFrom: rcvrOop.
	arg _ self loadFloatOrIntFrom: argOop.
	successFlag ifTrue: [
		self success: arg ~= 0.0.
		successFlag ifTrue: [
			self pop: 2.
			self pushFloat: (self cCode: 'rcvr / arg' inSmalltalk: [rcvr / arg])]].