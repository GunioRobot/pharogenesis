isMethodArgName: aString 
	"Answer true if aString is the name of a method argument, false otherwise.
    Does not check whether aString is also a blockArgName"

	^(arguments at: 0 ifAbsent: [#()]) includes: aString