readFrom: aStream
	"Read a MorphicEvent from the given stream."

	| type x y buttons keyValue typeString c |
	typeString _ String streamContents:
		[:s |   [(c _ aStream next) isLetter] whileTrue: [s nextPut: c]].
	typeString = 'mouseMove'
		ifTrue: [type _ #mouseMove  "fast treatment of common case"]
		ifFalse: [type _ typeString asSymbol].

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
