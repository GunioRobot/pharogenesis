nextFromStream: aStream

	| character1 value1 character2 value2 unicode character3 value3 character4 value4 |
	aStream isBinary ifTrue: [^ aStream basicNext].
	character1 _ aStream basicNext.
	character1 isNil ifTrue: [^ nil].
	value1 _ character1 asciiValue.
	value1 <= 127 ifTrue: [
		"1-byte character"
		currentCharSize _ 1.
		^ character1
	].

	(value1 bitAnd: 16rE0) = 192 ifTrue: [
		"2-byte character"
		character2 _ aStream basicNext.
		character2 = nil ifTrue: [^ nil "self errorMalformedInput"].
		value2 _ character2 asciiValue.
		currentCharSize _ 2.
		^ Unicode value: ((value1 bitAnd: 31) bitShift: 6) + (value2 bitAnd: 63).
	].

	(value1 bitAnd: 16rF0) = 224 ifTrue: [
		"3-byte character"
		character2 _ aStream basicNext.
		character2 = nil ifTrue: [^ nil "self errorMalformedInput"].
		value2 _ character2 asciiValue.
		character3 _ aStream basicNext.
		character3 = nil ifTrue: [^ nil "self errorMalformedInput"].
		value3 _ character3 asciiValue.
		unicode _ ((value1 bitAnd: 15) bitShift: 12) + ((value2 bitAnd: 63) bitShift: 6)
				+ (value3 bitAnd: 63).
		currentCharSize _ 3.
	].

	(value1 bitAnd: 16rF8) = 240 ifTrue: [
		"4-byte character"
		character2 _ aStream basicNext.
		character2 = nil ifTrue: [^ nil " self errorMalformedInput"].
		value2 _ character2 asciiValue.
		character3 _ aStream basicNext.
		character3 = nil ifTrue: [^ nil "self errorMalformedInput"].
		value3 _ character3 asciiValue.
		character4 _ aStream basicNext.
		character4 = nil ifTrue: [^ nil "self errorMalformedInput"].
		value4 _ character4 asciiValue.
		currentCharSize _ 4.
		unicode _ ((value1 bitAnd: 16r7) bitShift: 18) +
					((value2 bitAnd: 63) bitShift: 12) + 
					((value3 bitAnd: 63) bitShift: 6) +
					(value4 bitAnd: 63).
	].

	unicode isNil ifTrue: [^ nil].
	unicode > 16r10FFFD ifTrue: [^ nil].
	
	unicode = 16rFEFF ifTrue: [^ self nextFromStream: aStream].
	^ Unicode value: unicode.
