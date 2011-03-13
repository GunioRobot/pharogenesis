isFontAvailable
	| encoding |
	encoding := self leadingChar + 1.
	TextStyle defaultFont fontArray
		at: encoding
		ifAbsent: [^ false].
	^ true