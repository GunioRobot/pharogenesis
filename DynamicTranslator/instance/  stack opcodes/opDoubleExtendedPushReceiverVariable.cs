opDoubleExtendedPushReceiverVariable

	(self initOp: DoubleExtendedPushReceiverVariable) ifFalse: [
	self beginOp: DoubleExtendedPushReceiverVariable.

		self pushReceiverVariable: (self fetchInteger).
		self skip: 4.

	self endOp: DoubleExtendedPushReceiverVariable
	]
"
	self skip: 1.
	self pushReceiverVariable: (currentBytecode bitAnd: 16rF).
"