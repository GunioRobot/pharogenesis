addToMethodCacheSel: selector class: class method: meth primIndex: primIndex
	"Add the given entry to the method cache."

	| probe |
	self inline: false.

	"select one of the CacheProbeMax possible entries for replacement..."
	mcProbe _ (mcProbe + 1) \\ CacheProbeMax.  "in range 0..CacheProbeMax-1"
	probe _ (((selector bitXor: class) >> (mcProbe + 2)) bitAnd: MethodCacheMask) + 1.

	"...and replace the entry at that probe addresses"
	methodCache at: probe put: selector.
	methodCache at: probe + MethodCacheEntries put: class.
	methodCache at: probe + (MethodCacheEntries * 2) put: meth.
	methodCache at: probe + (MethodCacheEntries * 3) put: primIndex.
