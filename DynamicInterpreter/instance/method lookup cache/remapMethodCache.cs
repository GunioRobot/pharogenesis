remapMethodCache
	"Remap all pointers in the method cache.
	The method cache must be remapped following a compaction (inc or full gc)."
	self inline: false.

	1 to: MethodCacheEntries do: [:i | self remapMethodCacheLine: i].