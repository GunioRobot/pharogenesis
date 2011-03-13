mouseMove: event
	"Relay a mouseMove event to my model."

	mouseMoveSelector ifNotNil:
		[mouseMoveSelector argumentCount = 0
			ifTrue: [^ model perform: mouseMoveSelector].
		mouseMoveSelector argumentCount = 1
			ifTrue: [^ model perform: mouseMoveSelector with: event cursorPoint].
		mouseMoveSelector argumentCount = 2
			ifTrue: [^ model perform: mouseMoveSelector with: event cursorPoint with: event].
		^ self error: 'mouseMoveSelector must take 0, 1, or 2 arguments']