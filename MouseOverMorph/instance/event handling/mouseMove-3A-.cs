mouseMove: event
	"Relay a mouseMove event to my model."

	mouseMoveSelector ifNotNil:
		[mouseMoveSelector numArgs = 0
			ifTrue: [^ model perform: mouseMoveSelector].
		mouseMoveSelector numArgs = 1
			ifTrue: [^ model perform: mouseMoveSelector with: event cursorPoint].
		mouseMoveSelector numArgs = 2
			ifTrue: [^ model perform: mouseMoveSelector with: event cursorPoint with: event].
		^ self error: 'mouseMoveSelector must take 0, 1, or 2 arguments']