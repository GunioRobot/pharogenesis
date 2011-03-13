mouseEnter: event
	"Relay a mouseEnter event to my model."

	mouseEnterSelector ifNotNil:
		[mouseEnterSelector numArgs = 0
			ifTrue: [^ model perform: mouseEnterSelector].
		mouseEnterSelector numArgs = 1
			ifTrue: [^ model perform: mouseEnterSelector with: event].
		mouseEnterSelector numArgs = 2
			ifTrue: [^ model perform: mouseEnterSelector with: true with: event].
		^ self error: 'mouseEnterselector must take 0, 1, or 2 arguments']