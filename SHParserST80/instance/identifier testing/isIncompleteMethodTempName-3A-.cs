isIncompleteMethodTempName: aString 
	"Answer true if aString is the start of then name of a method temporary, false otherwise."

	^(temporaries at: 0 ifAbsent: [#()]) anySatisfy: [:each | each beginsWith: aString]