add: anObject executor: anExecutor
	"Add anObject to the receiver. Store the object as well as the associated executor."
	self protected:[
		valueDictionary at: anObject put: anExecutor.
	].
	^anObject