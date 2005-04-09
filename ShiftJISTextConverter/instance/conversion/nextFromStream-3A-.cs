nextFromStream: aStream 
	| character1 character2 value1 value2 char1Value result |
	aStream isBinary ifTrue: [^ aStream basicNext].
	character1 _ aStream basicNext.
	character1 isNil ifTrue: [^ nil].
	char1Value _ character1 asciiValue.
	(char1Value < 16r81) ifTrue: [^ character1].
	(char1Value > 16rA0 and: [char1Value < 16rE0]) ifTrue: [^ self katakanaValue: char1Value].

	character2 _ aStream basicNext.
	character2 = nil ifTrue: [^ nil "self errorMalformedInput"].
	value1 _ character1 asciiValue.
	character1 asciiValue >= 224 ifTrue: [value1 _ value1 - 64].
	value1 _ value1 - 129 bitShift: 1.
	value2 _ character2 asciiValue.
	character2 asciiValue >= 128 ifTrue: [value2 _ value2 - 1].
	character2 asciiValue >= 158 ifTrue: [
		value1 _ value1 + 1.
		value2 _ value2 - 158
	] ifFalse: [value2 _ value2 - 64].
	result _ Character leadingChar: self leadingChar code: value1 * 94 + value2.
	^ self toUnicode: result
