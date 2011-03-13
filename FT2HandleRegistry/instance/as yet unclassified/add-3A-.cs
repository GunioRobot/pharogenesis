add: anObject
	"Add anObject to the receiver. Store the object as well as the associated executor."
	| executor dup |
	executor := anObject executor.
	dup := nil.
	self protected:[
		dup := valueDictionary detect: [ :v | v handle = executor handle ] ifNone: [ ].
		valueDictionary at: anObject put: executor.
	].
	dup ifNotNil: [ self error: 'Duplicate object added!'. self remove: anObject ].
	^anObject