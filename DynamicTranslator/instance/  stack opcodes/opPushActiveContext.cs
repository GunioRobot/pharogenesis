opPushActiveContext
	(self initOp: PushActiveContext) ifFalse: [
	self beginOp: PushActiveContext.

		self skip: 1.
		self externalizeIPandSP.
		self push: (self pseudoContextFor: activeCachedContext).
		self internalizeIPandSP.

	self endOp: PushActiveContext
	]