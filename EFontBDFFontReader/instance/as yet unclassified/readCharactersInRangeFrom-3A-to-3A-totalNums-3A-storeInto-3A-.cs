readCharactersInRangeFrom: start to: stop totalNums: upToNum storeInto: chars

	| array form code |
	1 to: upToNum do: [:i |
		array := self readOneCharacter.
		code := array at: 2.
		code > stop ifTrue: [^ self].
		(code between: start and: stop) ifTrue: [
			form := array at: 1.
			form ifNotNil: [
				chars add: array.
			].
		].
	].
