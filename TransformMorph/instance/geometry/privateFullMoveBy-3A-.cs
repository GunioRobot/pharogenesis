privateFullMoveBy: delta
	"Private! Relocate me, but not my subMorphs."

	self privateMoveBy: delta.
	transform _ transform withOffset: (transform offset - delta).
