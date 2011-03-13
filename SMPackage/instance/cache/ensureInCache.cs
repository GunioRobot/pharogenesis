ensureInCache
	"Makes sure all release files are in the cache."

	self releases do: [:rel | rel ensureInCache ]