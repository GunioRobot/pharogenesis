mutex
	"Lazily initialize the Semaphore."

	^mutex ifNil: [mutex _ Semaphore forMutualExclusion]