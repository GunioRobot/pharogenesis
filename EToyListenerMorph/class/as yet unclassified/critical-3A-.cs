critical: aBlock

	QueueSemaphore ifNil: [QueueSemaphore _ Semaphore forMutualExclusion].
	^QueueSemaphore critical: aBlock
