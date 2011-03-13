adopt: classOrNil
	"Temporarily use the classPool and sharedPools of another class"
	classOrNil == nil
		ifTrue: [classPool _ nil.
				sharedPools _ nil]
		ifFalse: [classPool _ classOrNil classPool.
				sharedPools _ classOrNil sharedPools]
