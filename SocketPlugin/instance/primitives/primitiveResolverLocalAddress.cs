primitiveResolverLocalAddress

	| addr |
	self primitive: 'primitiveResolverLocalAddress'.
	addr _ self sqResolverLocalAddress.
	^self intToNetAddress: addr