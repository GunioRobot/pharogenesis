primitiveResolverStatus

	| status |
	self primitive: 'primitiveResolverStatus'.
	status _ self sqResolverStatus.
	^status asSmallIntegerObj