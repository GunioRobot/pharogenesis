isIncompleteMethodArgName: aString 
	"Answer true if aString is the start of the name of a method argument, false otherwise.
    Does not check whether aString is also a blockArgName"

	^(arguments at: 0 ifAbsent: [#()]) anySatisfy: [:each | each beginsWith: aString]