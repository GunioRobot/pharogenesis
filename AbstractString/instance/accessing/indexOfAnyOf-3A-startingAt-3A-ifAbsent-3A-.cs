indexOfAnyOf: aCharacterSet  startingAt: start ifAbsent: aBlock
	"returns the index of the first character in the given set, starting from start"

	| ans |
	ans _ String findFirstInString: self  inSet: aCharacterSet byteArrayMap startingAt: start.

	ans = 0 
		ifTrue: [ ^aBlock value ]
		ifFalse: [ ^ans ]