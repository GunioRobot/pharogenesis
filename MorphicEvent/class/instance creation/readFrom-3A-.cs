readFrom: aStream
	"Read a MorphicEvent from the given stream."

	| s type x y buttons keyValue |
	s _ WriteStream on: ''.
	[aStream peek isLetter] whileTrue: [s nextPut: aStream next].
	type _ s contents asSymbol.
	aStream skip: 1.

	x _ Integer readFrom: aStream.
	aStream skip: 1.
	y _ Integer readFrom: aStream.
	aStream skip: 1.

	buttons _ Integer readFrom: aStream.
	aStream skip: 1.

	keyValue _ Integer readFrom: aStream.

	^ self basicNew setType: type
		cursorPoint: x@y
		buttons: buttons
		keyValue: keyValue
