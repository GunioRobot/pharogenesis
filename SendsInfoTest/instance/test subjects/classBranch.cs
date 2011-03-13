classBranch
	self
		shouldnt: [state isNil
				ifTrue: [self tell]
				ifFalse: [self class tell]]
		raise: MessageNotUnderstood