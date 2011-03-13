mouseDown: event
	"Unshifted action is to move the pin (see mouseMove:)"
	event shiftPressed ifTrue: [self startWiring: event].
