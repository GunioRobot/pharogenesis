layoutChanged
	"Recompute bounds as a result of change"
	self hasSubmorphs ifTrue:
		[bounds _ (transform localBoundsToGlobal:
					(Rectangle merging:
						(self submorphs collect: [:m | m fullBounds]))) truncated
				expandBy: 1].
	super layoutChanged