fullBounds

	fullBounds ifNil: [
		fullBounds _ self bounds.
		self submorphsDo: [:m | fullBounds _ fullBounds quickMerge: m fullBounds]].
	^ fullBounds