changed
	"Recompute bounds as a result of change"
	| oldCenter newBounds delta |
	submorphs isEmpty ifFalse:
		[oldCenter _ self center.
		self firstSubmorph position: 0@0.
		newBounds _ Rectangle encompassing:
			(self firstSubmorph bounds corners
				collect: [:p | transform invert: p]).
		delta _ oldCenter - newBounds center.
		bounds _ newBounds translateBy: delta.
		self layoutChanged.
		transform _ transform withOffset: (self offset - delta) - self innerBounds topLeft].
	super changed