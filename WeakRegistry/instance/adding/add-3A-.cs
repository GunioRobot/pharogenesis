add: anObject
	"Add anObject to the receiver. Store the object as well as the associated executor."
	| executor |
	executor := anObject executor.
	self protected:[
		valueDictionary at: anObject put: executor.
	].
	^anObject