computeSpaceUsage

	| entry c instanceCount |
	1 to: results size do: [:i |
		entry := results at: i.
		c := self class environment at: entry analyzedClassName.
		instanceCount _ c instanceCount.
		entry codeSize: c spaceUsed.
		entry instanceCount: instanceCount.
		entry spaceForInstances: (self spaceForInstancesOf: c withInstanceCount: instanceCount).
		Smalltalk garbageCollectMost].
	
