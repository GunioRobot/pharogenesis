handleMouseMove: evt
	"Dispatch a mouseMove event."

	clickState ~~ #idle ifTrue: [self checkForDoubleClick: evt].

	mouseDownMorph ifNotNil:
		[mouseDownMorph mouseMove: (self transformEvent: evt)].

	self handleMouseOver: evt.
