primitiveResolverStatus

	| status |
	status _ self sqResolverStatus.
	successFlag ifTrue: [
		self pop: 1 thenPush: (self integerObjectOf: status).
	].
