readSemaphore
	primitiveOnlySupportsOneSemaphore ifTrue: [^semaphore].
	^readSemaphore