skipSeparators
	pos _ text indexOfAnyOf: CSNonSeparators  startingAt: pos  ifAbsent: [ text size + 1 ].