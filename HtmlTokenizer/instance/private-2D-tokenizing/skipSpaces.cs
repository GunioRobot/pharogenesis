skipSpaces
	"skip as many consecutive space characters as possible"
	pos _ text indexOfAnyOf: CSNonSeparators startingAt: pos ifAbsent: [ text size + 1 ].