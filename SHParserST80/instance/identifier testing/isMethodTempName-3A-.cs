isMethodTempName: aString 
	"Answer true if aString is the name of a method temporary, false otherwise.
    Does not check whether aString is also a block temporary
    or argument"

	((arguments at: 0 ifAbsent: [#()]) includes: aString) ifTrue: [^false].
	^(temporaries at: 0 ifAbsent: [#()]) includes: aString