primitiveResolverNameLookupResult

	| addr |
	self primitive: 'primitiveResolverNameLookupResult'.
	addr _ self sqResolverNameLookupResult.
	^self intToNetAddress: addr