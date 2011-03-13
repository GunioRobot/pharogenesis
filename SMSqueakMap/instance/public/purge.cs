purge
	"Clear out the map from memory. Use this to reclaim space,
	no information is lost because it does not remove information
	about what packages are installed, and the map itself is checkpointed
	to disk. Use #reload to get it back from the latest checkpoint on disk."

	objects := accounts := users := packages := categories := nil.
	checkpointNumber := 0.