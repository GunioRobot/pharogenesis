primitiveResolverNameLookupResult

	| addr |
	addr _ self sqResolverNameLookupResult.
	successFlag ifTrue: [
		self pop: 1 thenPush: (self intToNetAddress: addr).
	].
