primitiveResolverError

	| err |
	err _ self sqResolverError.
	successFlag ifTrue: [
		self pop: 1 thenPush: (self integerObjectOf: err).
	].
