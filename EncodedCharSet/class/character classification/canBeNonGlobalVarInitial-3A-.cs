canBeNonGlobalVarInitial: char

	| leadingChar |
	leadingChar _ char leadingChar.

	leadingChar = 0 ifTrue: [^ self isLowercase: char].
	^ self isLetter: char.
