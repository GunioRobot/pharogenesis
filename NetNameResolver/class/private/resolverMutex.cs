resolverMutex
	ResolverMutex ifNil: [ResolverMutex _ Semaphore forMutualExclusion].
	^ResolverMutex