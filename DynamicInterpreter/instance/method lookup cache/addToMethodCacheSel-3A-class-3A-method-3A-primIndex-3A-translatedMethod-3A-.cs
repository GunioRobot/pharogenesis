addToMethodCacheSel: selector class: class method: meth primIndex: primIndex translatedMethod: tMeth
	"Add the given entry to the method cache."

	| probe |
	self inline: false.

	"select one of the CacheProbeMax possible entries for replacement..."
	mcProbe _ (mcProbe + 1) \\ CacheProbeMax.  "in range 0..CacheProbeMax-1"
	UseMethodCacheHashBits
		ifTrue: [probe _ (((self hashForCacheWithSelector: selector class: class) >> mcProbe)
							bitAnd: MethodCacheMask) + 1]
		ifFalse: [probe _ (((selector bitXor: class) >> (mcProbe + 2))
							bitAnd: MethodCacheMask) + 1].
	"...and replace the entry at that probe addresses"
	self assertIsCompiledMethod: meth.
	self assertIsTranslatedMethod: tMeth.
	(methodCache at: probe + MethodCacheSelectorCol) = 0
		ifFalse: [self ejectMethodCacheLine: probe].
	methodCache at: probe + MethodCacheSelectorCol		put: selector.
	methodCache at: probe + MethodCacheClassCol			put: class.
	methodCache at: probe + MethodCacheMethodCol		put: meth.
	methodCache at: probe + MethodCachePrimIndexCol	put: primIndex.
	methodCache at: probe + MethodCacheTMethodCol		put: tMeth.
	UseInlineCacheDelay ifTrue:
		[methodCache at: probe + MethodCacheDelayCol put: inlineCacheDelay.
		 newInlineCacheDelay _ inlineCacheDelay].