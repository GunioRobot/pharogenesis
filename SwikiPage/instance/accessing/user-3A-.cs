user: aString

	aString class == String 
		ifFalse: [user _ aString printString]
		ifTrue: [user _ aString]