setOperator: opSymbol type: opType rcvrType: rcvrType

	opSymbol numArgs <= 0 ifFalse:
		["Obscure:  numArgs comes back -1 for upper-case symbol, such as OnTicks"
		self error: 'you must specify the type of the operand'].
	self setOperator: opSymbol type: opType rcvrType: rcvrType argType: nil.
