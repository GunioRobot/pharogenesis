at: aCharOrInteger

	| char |
	char _ aCharOrInteger asCharacter.
	^ glyphs at: (char charCode) + 1.
