asUnicode

	| table charset v |
	self leadingChar = 0 ifTrue: [^ value].
	charset _ EncodedCharSet charsetAt: self leadingChar.
	charset isCharset ifFalse: [^ self charCode].
	table _ charset ucsTable.
	table isNil ifTrue: [^ 16rFFFD].

	v _ table at: self charCode + 1.
	v = -1 ifTrue: [^ 16rFFFD].

	^ v.
