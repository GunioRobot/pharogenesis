actualClass
	^Smalltalk at: className
		ifPresent: [:class | classIsMeta ifTrue: [class classSide] ifFalse: [class]]