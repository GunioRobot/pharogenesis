opPushReceiver

	(self initOp: PushReceiver) ifFalse: [
	self beginOp: PushReceiver.

		self internalPush: self internalReceiver.
		self skip: 1.

	self endOp: PushReceiver
	]