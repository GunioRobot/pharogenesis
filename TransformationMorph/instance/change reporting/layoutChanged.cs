layoutChanged
	"Recompute bounds as a result of change"
	self hasSubmorphs ifTrue:
		[bounds _ Rectangle merging:
			(self submorphs collect:
				[:m | transform invertRect: m fullBounds])].
	super layoutChanged