readFromObsolete: aStream
	"Read one of those old and now obsolete events from the stream"
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

	typeString = 'mouseMove' ifTrue:[
		^MouseMoveEvent new
			setType: #mouseMove 
			startPoint: x@y 
			endPoint: x@y 
			trail: #() 
			buttons: buttons 
			hand: nil 
			stamp: nil].
	(typeString = 'mouseDown') | (typeString = 'mouseUp') ifTrue:[
			^MouseButtonEvent new
				setType: type
				position: x@y
				which: 0
				buttons: buttons
				hand: nil
				stamp: nil].
	(typeString = 'keystroke') | (typeString = 'keyDown') | (typeString = 'keyUp') ifTrue:[
		^KeyboardEvent new
			setType: type
			buttons: buttons
			position: x@y
			keyValue: keyValue
			hand: nil
			stamp: nil].

	^nil