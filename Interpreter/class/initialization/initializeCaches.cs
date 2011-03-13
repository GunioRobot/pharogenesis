initializeCaches
	| atCacheEntrySize |
	MethodCacheEntries _ 512. 
	MethodCacheSelector _ 1.
	MethodCacheClass _ 2.
	MethodCacheMethod _ 3.
	MethodCachePrim _ 4.
	MethodCacheNative _ 5.
	MethodCacheEntrySize _ 8.  "Must be power of two for masking scheme."
	MethodCacheMask _ (MethodCacheEntries - 1) * MethodCacheEntrySize.
	MethodCacheSize _ MethodCacheEntries * MethodCacheEntrySize.
	CacheProbeMax _ 3.

	AtCacheEntries _ 8.  "Must be power of two"
	AtCacheOop _ 1.
	AtCacheSize _ 2.
	AtCacheFmt _ 3.
	AtCacheFixedFields _ 4.
	atCacheEntrySize _ 4.  "Must be power of two for masking scheme."
	AtCacheMask _ (AtCacheEntries-1) * atCacheEntrySize.
	AtPutBase _ AtCacheEntries * atCacheEntrySize.
	AtCacheTotalSize _ AtCacheEntries * atCacheEntrySize * 2.
