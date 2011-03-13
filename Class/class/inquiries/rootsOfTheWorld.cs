rootsOfTheWorld
	"return all classes that have a nil superclass"
	
	^(Smalltalk select: [:each | each isBehavior and: [each superclass isNil]]) asOrderedCollection