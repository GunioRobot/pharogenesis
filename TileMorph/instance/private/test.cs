test
	| pos hh |
	"Set the position of all my submorphs.  Compute my bounds.  Caller must call layoutChanged or set fullBounds to nil."

	fullBounds ifNil: [
		pos _ self topLeft.
		self submorphsDo: [:sub | 
			hh _ (self class defaultH - sub height) // 2.	"center in Y"
			sub privateBounds: (pos + (2@hh) extent: sub extent).
			pos x: (sub right min: 1200)].	"2 pixels spacing on left"
		bounds _ bounds topLeft corner: pos + (2 @ self class defaultH).
		fullBounds _ bounds.
		].
	owner class == TilePadMorph ifTrue: [owner bounds: bounds].
	^ fullBounds