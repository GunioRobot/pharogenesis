widthOf: aCharacter

	| encoding |
	encoding _ aCharacter leadingChar.
	^ (fontArray at: encoding + 1) widthOf: aCharacter.
