isIncompleteBlockArgName: aString 
	"Answer true if aString is the start of the name of a block argument, false otherwise"
	|  arg |
	blockDepth to: 1 by: -1 do: [:level | 
		arg := (arguments at: level ifAbsent: [#()]) anySatisfy: [:each | each beginsWith: aString].
		arg ifTrue: [^true]].
	^false