indexOfAnyOf: aCharacterSet  startingAt: start
	"returns the index of the first character in the given set, starting from start.  Returns 0 if none are found"
	^self indexOfAnyOf: aCharacterSet  startingAt: start  ifAbsent: [ 0 ]