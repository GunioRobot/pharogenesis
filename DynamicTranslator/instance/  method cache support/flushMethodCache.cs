flushMethodCache
	"Flush the method cache. The method cache is flushed on every programming change.  It must also be flushed following a compaction, unless the hashing scheme is invariant, in which case remapping will suffice."

	1 to: MethodCacheEntries do: [ :i | self flushMethodCacheLine: i].
	mcProbe _ 0.