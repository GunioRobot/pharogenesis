computeBounds
	submorphs isEmpty ifTrue:
		[self extent: 50@40.
		fullBounds _ nil.
		^ self].
	self changed.
	bounds _ (submorphs first fullBounds) copy.
	bounds _ fullBounds _ (bounds translateBy: shadowOffset) merge: bounds.
	self changed