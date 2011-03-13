mouseUp: event
	"Relay a mouseUp event to my model."

	mouseUpSelector ifNotNil:
		[mouseUpSelector numArgs = 0
			ifTrue: [^ model perform: mouseUpSelector].
		mouseUpSelector numArgs = 1
			ifTrue: [^ model perform: mouseUpSelector with: event].
		^ self error: 'mouseUpselector must take 0, or 1 argument'].
	mouseDownSelector ifNotNil:
		["Or send mouseDown: false..."
		mouseDownSelector numArgs = 2
			ifTrue: [^ model perform: mouseDownSelector with: false with: event].
		^ self error: 'mouseDownselector must take 2 arguments']