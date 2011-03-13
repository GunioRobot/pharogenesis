mouseLeave: event
	"Relay a mouseLeave event to my model."

	mouseLeaveSelector ifNotNil:
		[mouseLeaveSelector numArgs = 0
			ifTrue: [^ model perform: mouseLeaveSelector].
		mouseLeaveSelector numArgs = 1
			ifTrue: [^ model perform: mouseLeaveSelector with: event].
		^ self error: 'mouseLeaveSelector must take 0, or 1 argument'].

	mouseEnterSelector ifNotNil:
		["Or send mouseEnter: false..."
		mouseEnterSelector numArgs = 2
			ifTrue: [^ model perform: mouseEnterSelector with: false with: event].
		^ self error: 'mouseEnterSelector must take 2 arguments']