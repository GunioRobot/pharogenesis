computeBounds
	submorphs isEmpty ifTrue:
		[self extent: 50@40.
		fullBounds _ nil.
		^ self].
	self changed.
	bounds _ (submorphs first bounds) copy.
	fullBounds _ nil.
	bounds _ self fullBounds translateBy: shadowOffset.
	self changed