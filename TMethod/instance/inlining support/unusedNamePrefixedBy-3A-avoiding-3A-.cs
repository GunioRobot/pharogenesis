unusedNamePrefixedBy: aString avoiding: usedNames
	"Choose a unique variable or label name with the given string as a prefix, avoiding the names in the given collection. The selected name is added to usedNames."

	| n newVarName |
	n _ 1.
	newVarName _ aString, n printString.
	[usedNames includes: newVarName] whileTrue: [
		n _ n + 1.
		newVarName _ aString, n printString.
	].
	usedNames add: newVarName.
	^ newVarName