fullBounds

	| result oldBounds |
	(fullBounds == nil and: [self autoLineLayout]) ifTrue:
		[oldBounds _ bounds.
		self fixLayout.
		self resizeToFit ifTrue:
			[result _ self boundingBoxOfSubmorphs.
			bounds _ bounds withBottom: result bottom].
		fullBounds _ bounds.
		self invalidRect: oldBounds.
		self changed.
		^ bounds].  "compute fullBounds before calling changed to avoid infinite recursion!"

	^ fullBounds _ bounds
