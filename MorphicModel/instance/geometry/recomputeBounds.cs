recomputeBounds

	| bnds |
	bnds _ submorphs first bounds.
	bounds _ bnds origin corner: bnds corner. "copy it!"
	fullBounds _ nil.
	bounds _ self fullBounds.
