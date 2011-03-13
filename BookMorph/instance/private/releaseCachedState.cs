releaseCachedState
	"Release the cached state of all my pages."

	super releaseCachedState.
	pages do: [:page | page allMorphsDo: [:m | m releaseCachedState]].
