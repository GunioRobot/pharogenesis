initialize
	"DynamicContextCache initialize"
	super initialize.

	self initializeCacheIndices.
	self initializePseudoContextIndices.

	ContextCacheEntries		_ 16.
	CacheEntrySize			_ CachedContextSize * 4.

	StackCacheEntries		_ 16.
	StackEntrySize			_ 32 * 4
