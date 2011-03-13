mouseMove: evt
	"See if arrows are being pressed and call arrowAction:..."

	upArrow ifNotNil:
		[(upArrow containsPoint: evt cursorPoint) ifTrue:
			[self readyForAnotherTick ifTrue: [^ self arrowAction: 1]].
		(downArrow containsPoint: evt cursorPoint) ifTrue:
			[self readyForAnotherTick ifTrue: [^ self arrowAction: -1]]].

	super mouseMove: evt.
