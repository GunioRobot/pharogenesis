opPushConstantTrue

	(self initOp: PushConstantTrue) ifFalse: [
	self beginOp: PushConstantTrue.

		self internalPush: trueObj.
		self skip: 1.

	self endOp: PushConstantTrue
	]