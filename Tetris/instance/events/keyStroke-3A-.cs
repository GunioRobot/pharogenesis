keyStroke: evt

	| charValue |
	charValue _ evt keyCharacter asciiValue.
	charValue = 28 ifTrue: [board moveLeft].
	charValue = 29 ifTrue: [board moveRight].
	charValue = 30 ifTrue: [board rotateClockWise].
	charValue = 31 ifTrue: [board rotateAntiClockWise].
	charValue = 32 ifTrue: [board dropAllTheWay].
