nextIntegerFrom: aStream
	" Returns the next Integer present in aStream. "

	| sign result |
	sign := (self is: $- in: aStream) ifTrue: [-1] ifFalse: [1].
	result := 0.
	self skipBlanks: aStream.
	[aStream peek isDigit] whileTrue: [
		result := aStream next asciiValue - $0 asciiValue + (result * 10)
	].
	^result * sign