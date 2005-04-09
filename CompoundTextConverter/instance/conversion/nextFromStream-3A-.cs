nextFromStream: aStream 

	| character character2 size leadingChar offset result |
	aStream isBinary ifTrue: [^ aStream basicNext].

	character _ aStream basicNext.
	character ifNil: [^ nil].
	character == Character escape ifTrue: [
		self parseShiftSeqFromStream: aStream.
		character _ aStream basicNext.
		character ifNil: [^ nil]].
	character asciiValue < 128 ifTrue: [
		size _ state g0Size.
		leadingChar _ state g0Leading.
		offset _ 16r21.
	] ifFalse: [
		size _state g1Size.
		leadingChar _ state g1Leading.
		offset _ 16rA1.
	].
	size = 1 ifTrue: [
		leadingChar = 0
			ifTrue: [^ character]
			ifFalse: [^ Character leadingChar: leadingChar code: character asciiValue]
	].
	size = 2 ifTrue: [
		character2 _ aStream basicNext.
		character2 ifNil: [^ nil. "self errorMalformedInput"].
		character _ character asciiValue - offset.
		character2 _ character2 asciiValue - offset.
		result _ Character leadingChar: leadingChar code: character * 94 + character2.
		^ result asUnicodeChar.
		"^ self toUnicode: result"
	].
	self error: 'unsupported encoding'.
