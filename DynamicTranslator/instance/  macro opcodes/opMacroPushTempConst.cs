opMacroPushTempConst
	"0:PushTemp		1:index1
	 2:PushConst	3:literal"

	| index literal |
	(self initOp: MacroPushTempConst) ifFalse: [
	self beginOp: MacroPushTempConst.

		index _ self peekInteger: 1.
		self pushTemporaryVariable: index.
		literal _ self peekLiteral: 3.
		self internalPush: literal.
		self skip: 3.

	self endOp: MacroPushTempConst
	]