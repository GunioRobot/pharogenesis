handleBoundsChange: aBlock
	| oldBounds newBounds |
	oldBounds _ bounds.
	aBlock value.
	newBounds _ bounds.
	self boundsChangedFrom: oldBounds to: newBounds.