initializeCache: cacheAddress
	"Initialize cache-related Interpreter state before starting execution of a new image."
	"Note:	The caches initially contain garbage, which is fine since the interpreter is
			expected to be *precise* in the initialisation and subsequent use of them
			(including marking and remapping during GC and become operations)."

	self inline: false.

	"Make sure we have at least two cached contexts to play with"
	(contextCacheEntries < 2) ifTrue: [self error: 'context cache too small (minimum 2 entries)'].
	contextCache _ cacheAddress.
	lastCachedContext _ contextCache + ((contextCacheEntries - 1) * CacheEntrySize).
	activeCachedContext _ 0.
	lowestCachedContext _ 0.

	"Make sure we have at least contextCacheEntries stack cache entries"
	(stackCacheEntries < contextCacheEntries) ifTrue: [self error: 'stack cache too small for context cache size'].
	stackCache _ self contextCacheLimit.
	stackCacheFence _ stackCache + ((stackCacheEntries - 1) * StackEntrySize).

	stackOverflow _ false.