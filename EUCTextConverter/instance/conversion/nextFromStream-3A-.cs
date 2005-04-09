nextFromStream: aStream

	| character1 character2 offset value1 value2 nonUnicodeChar |
	aStream isBinary ifTrue: [^ aStream basicNext].
	character1 _ aStream basicNext.
	character1 isNil ifTrue: [^ nil].
	character1 asciiValue <= 127 ifTrue: [^ character1].
	character2 _ aStream basicNext.
	character2 = nil ifTrue: [^ nil].
	offset _ 16rA1.
	value1 _ character1 asciiValue - offset.
	value2 _ character2 asciiValue - offset.
	(value1 < 0 or: [value1 > 93]) ifTrue: [^ nil].
	(value2 < 0 or: [value2 > 93]) ifTrue: [^ nil].

	nonUnicodeChar _ Character leadingChar: self leadingChar code: value1 * 94 + value2.
	^ Character leadingChar: self languageEnvironment leadingChar code: nonUnicodeChar asUnicode.
