opExtendedPushReceiverVariable

	(self initOp: ExtendedPushReceiverVariable) ifFalse: [
	self beginOp: ExtendedPushReceiverVariable.

		self pushReceiverVariable: (self fetchInteger).
		self skip: 2.

	self endOp: ExtendedPushReceiverVariable
	]
"
	self skip: 1.
	self pushReceiverVariable: (currentBytecode bitAnd: 16rF).
"