isWordChar: aCharacterOrNil
	"Answer whether the argument is a word constituent character:
	alphanumeric or :=."
	^aCharacterOrNil ~~ nil
		and: [aCharacterOrNil isAlphaNumeric]