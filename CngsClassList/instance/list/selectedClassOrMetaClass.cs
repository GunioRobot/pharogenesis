selectedClassOrMetaClass
	| sel |
	^ listIndex = 0
		ifFalse: [Smalltalk classNamed: (list at: listIndex)]
		ifTrue: [nil]