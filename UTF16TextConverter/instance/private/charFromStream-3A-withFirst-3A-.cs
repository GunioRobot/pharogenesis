charFromStream: aStream withFirst: firstValue

	| character1 character2 tmp n secondValue |
	(16rD800 <= firstValue and: [firstValue <= 16rDBFF]) ifTrue: [
		character1 := aStream basicNext.
		character1 isNil ifTrue: [^ nil].
		character2 := aStream basicNext.
		character2 isNil ifTrue: [^ nil].
		self useLittleEndian ifTrue: [
			tmp := character1.
			character1 := character2.
			character2 := tmp
		].
		secondValue := (character1 charCode << 8) + (character2 charCode).
		n := (firstValue - 16rD800) * 16r400 + (secondValue - 16rDC00) + 16r10000.
		^ Unicode value: n
	].

	^ Unicode value: firstValue
