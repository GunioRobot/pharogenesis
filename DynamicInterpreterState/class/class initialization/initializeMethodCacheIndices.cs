initializeMethodCacheIndices	
	"DynamicInterpreter initializeMethodCacheIndices"

	CacheProbeMax _ 3.
	MethodCacheEntries _ 1024.

	MethodCacheSelectorCol		_ 0 * MethodCacheEntries.	"selector oop"
	MethodCacheClassCol			_ 1 * MethodCacheEntries.	"class oop"
	MethodCacheMethodCol		_ 2 * MethodCacheEntries.	"CompiledMethod oop"
	MethodCachePrimIndexCol	_ 3 * MethodCacheEntries.	"raw primitive index"
	MethodCacheTMethodCol		_ 4 * MethodCacheEntries.	"TranslatedMethod oop"
	MethodCacheDelayCol		_ 5 * MethodCacheEntries.	"raw inline cache link delay"
	MethodCacheColumns		_ 6.

	MethodCacheMask _ MethodCacheEntries - 1.
	(MethodCacheEntries bitAnd: MethodCacheMask) = 0
		ifFalse: [ self error: 'MethodCacheEntries must be a power of two' ].

	MethodCacheSize _ MethodCacheEntries * MethodCacheColumns.

