asciiOfCharacter: characterObj  "Returns an integer object"

	self inline: false.
	self successIfClassOf: characterObj is: (self splObj: ClassCharacter).
	successFlag
		ifTrue: [^ self fetchPointer: CharacterValueIndex ofObject: characterObj]
		ifFalse: [^ ConstZero]  "in case some code needs an int"