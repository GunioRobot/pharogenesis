privateFullMoveBy: delta
	"Private! Relocate me, but not my subMorphs."

	self privateMoveBy: delta.
	self offset: self offset - delta.
