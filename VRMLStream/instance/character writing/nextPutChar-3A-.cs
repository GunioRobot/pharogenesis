nextPutChar: aChar
	| firstChar lastChar |
	aChar asciiValue < 128 ifTrue:[^theStream nextPut: aChar].
	firstChar := 2r11000000 + (aChar asciiValue bitShift: -6).
	lastChar := 2r10000000 + (aChar asciiValue bitAnd: 2r00111111).
	theStream nextPut: firstChar asCharacter; nextPut: lastChar asCharacter.
	^aChar