asUnicodeChar

	| table charset v |
	self leadingChar = 0 ifTrue: [^ value].
	charset _ EncodedCharSet charsetAt: self leadingChar.
	charset isCharset ifFalse: [^ self].
	table _ charset ucsTable.
	table isNil ifTrue: [^ Character value: 16rFFFD].

	v _ table at: self charCode + 1.
	v = -1 ifTrue: [^ Character value: 16rFFFD].

	^ MultiCharacter leadingChar: charset unicodeLeadingChar code: v.
