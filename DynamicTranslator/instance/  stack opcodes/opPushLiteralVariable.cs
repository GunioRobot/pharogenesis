opPushLiteralVariable

	(self initOp: PushLiteralVariable) ifFalse: [
	self beginOp: PushLiteralVariable.

		self internalPush: (self fetchPointer: ValueIndex ofObject: (self fetchLiteralVariable)).

	self endOp: PushLiteralVariable
	]