asCharacter

	^ self isOctetCharacter
		ifTrue: [Character value: self asciiValue]
		ifFalse: [self]