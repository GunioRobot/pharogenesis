fitContents

	| newBounds boundsChanged |
	newBounds _ self measureContents.
	boundsChanged _ bounds extent ~= newBounds.
	self extent: newBounds.		"default short-circuits if bounds not changed"
	boundsChanged ifFalse: [self changed]