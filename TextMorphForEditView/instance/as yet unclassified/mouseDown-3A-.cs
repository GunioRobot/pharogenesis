mouseDown: event

	event yellowButtonPressed ifTrue: [^ editView yellowButtonActivity: event shiftPressed].
	^ super mouseDown: event
