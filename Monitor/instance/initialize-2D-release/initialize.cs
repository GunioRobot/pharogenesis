initialize
	mutex _ Semaphore forMutualExclusion.
	queuesMutex _ Semaphore forMutualExclusion.
	nestingLevel _ 0.