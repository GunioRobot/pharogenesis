processDefineFontInfo: data
	| id nameLength fontName flags charMap |
	id := data nextWord.
	nameLength := data nextByte.
	fontName := (data nextBytes: nameLength) asString.
	flags := data nextByte.
	charMap := data upToEnd.
	self recordFont: id name: fontName charMap: charMap wide: (flags anyMask: 1).
	^true