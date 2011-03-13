computeBounds
	self hasSubmorphs ifTrue:
		[bounds _ (transform localBoundsToGlobal:
					(Rectangle merging:
						(self submorphs collect: [:m | m fullBounds]))) truncated
				expandBy: 1].
	fullBounds _ bounds.