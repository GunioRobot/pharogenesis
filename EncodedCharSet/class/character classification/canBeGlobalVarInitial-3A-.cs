canBeGlobalVarInitial: char

	| leadingChar |
	leadingChar _ char leadingChar.

	leadingChar = 0 ifTrue: [^ self isUppercase: char].
	^ self isLetter: char.
