releaseCachedState
	"Release any state that could be recomputed"

	super releaseCachedState.
	handWithTile _ nil.
	self hibernate