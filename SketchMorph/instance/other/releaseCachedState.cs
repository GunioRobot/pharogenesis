releaseCachedState
	"Clear cache of rotated, scaled Form."

	super releaseCachedState.
	rotatedForm _ nil.
	originalForm hibernate