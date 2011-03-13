superBranch
	self
		should: [state isNil
				ifTrue: [super tell]
				ifFalse: [self tell]]
		raise: MessageNotUnderstood