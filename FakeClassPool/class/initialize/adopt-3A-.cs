adopt: classOrNil
	"Temporarily use the classPool and sharedPools of another class"
	classOrNil isBehavior
		ifFalse: [classPool _ nil.
				sharedPools _ nil]
		ifTrue: [classPool _ classOrNil classPool.
				sharedPools _ classOrNil sharedPools]
