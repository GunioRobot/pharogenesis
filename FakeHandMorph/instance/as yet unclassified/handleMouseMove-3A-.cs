handleMouseMove: evt
	"Dispatch a mouseMove event."
	mouseDownMorph ifNotNil:
		[mouseDownMorph mouseMove: (self transformEvent: evt)].
