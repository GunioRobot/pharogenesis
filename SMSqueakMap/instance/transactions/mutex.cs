mutex
	"Lazily initialize the Semaphore."

	^mutex ifNil: [mutex := Semaphore forMutualExclusion]