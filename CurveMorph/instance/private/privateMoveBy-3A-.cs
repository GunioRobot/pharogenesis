privateMoveBy: delta
	super privateMoveBy: delta.
	coefficients _ nil.  "Force recomputation"
