mouseDown: event
	"Relay a mouseDown event to my model."

	mouseDownSelector ifNotNil:
		[mouseDownSelector numArgs = 0
			ifTrue: [^ model perform: mouseDownSelector].
		mouseDownSelector numArgs = 1
			ifTrue: [^ model perform: mouseDownSelector with: event].
		mouseDownSelector numArgs = 2
			ifTrue: [^ model perform: mouseDownSelector with: true with: event].
		^ self error: 'mouseDownselector must take 0, 1, or 2 arguments']