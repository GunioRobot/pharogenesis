processDefineFontInfo: data
	| id nameLength fontName flags charMap |
	id _ data nextWord.
	nameLength _ data nextByte.
	fontName _ (data nextBytes: nameLength) asString.
	flags _ data nextByte.
	charMap _ data upToEnd.
	self recordFont: id name: fontName charMap: charMap wide: (flags anyMask: 1).
	^true