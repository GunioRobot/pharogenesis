opPushReceiverVariable

	(self initOp: PushReceiverVariable) ifFalse: [
	self beginOp: PushReceiverVariable.

		self pushReceiverVariable: (self fetchInteger).

	self endOp: PushReceiverVariable
	]
"
	self skip: 1.
	self pushReceiverVariable: (currentBytecode bitAnd: 16rF).
"