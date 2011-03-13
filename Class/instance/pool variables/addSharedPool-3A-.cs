addSharedPool: aSharedPool 
	"Add the argument, aSharedPool, as one of the receiver's shared pools. 
	Create an error if the shared pool is already one of the pools.
	This method will work with shared pools that are plain Dictionaries or thenewer SharedPool subclasses"

	(self sharedPools includes: aSharedPool)
		ifTrue: [^self error: 'This is already in my shared pool list'].
	sharedPools == nil
		ifTrue: [sharedPools := OrderedCollection with: aSharedPool]
		ifFalse: [sharedPools add: aSharedPool]