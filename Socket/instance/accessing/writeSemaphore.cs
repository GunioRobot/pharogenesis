writeSemaphore
	primitiveOnlySupportsOneSemaphore ifTrue: [^semaphore].
	^writeSemaphore