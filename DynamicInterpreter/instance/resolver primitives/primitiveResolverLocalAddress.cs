primitiveResolverLocalAddress

	| addr |
	addr _ self sqResolverLocalAddress.
	successFlag ifTrue: [
		self pop: 1 thenPush: (self intToNetAddress: addr).
	].
