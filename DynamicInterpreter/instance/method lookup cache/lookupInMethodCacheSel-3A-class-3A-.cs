lookupInMethodCacheSel: selector class: class
	"This method implements a simple method lookup cache. If an entry for the given selector and class is found in the cache, set the values of 'newMethod' and 'primitiveIndex' and return true. Otherwise, return false."
	"About the re-probe scheme: The hash is the low bits of the XOR of two large addresses, minus their useless lowest two bits. If a probe doesn't get a hit, the hash is shifted right one bit to compute the next probe, introducing a new randomish bit. The cache is probed CacheProbeMax times before giving up."
	"WARNING: The method cache must either be compeltely flushed, or all pointers must be remapped following a compaction (ie, incremental or full GC)."

	| hash probe oldDelay |
	self inline: true.
	UseMethodCacheHashBits
		ifTrue: [hash _ self hashForCacheWithSelector: selector class: class]
		ifFalse: [hash _ (selector bitXor: class) >> 2].  "drop two low-order zeros from addresses"
	probe _ (hash bitAnd: MethodCacheMask) + 1.  "initial probe"

	1 to: CacheProbeMax do: [ :p |
		(((methodCache at: probe + MethodCacheSelectorCol) = selector) and:
		 [(methodCache at: probe + MethodCacheClassCol) = class]) ifTrue:
			[newMethod _ methodCache at: probe + MethodCacheMethodCol.
			primitiveIndex _ methodCache at: probe + MethodCachePrimIndexCol.
			newTranslatedMethod _ methodCache at: probe + MethodCacheTMethodCol.
			statMethodCacheHits _ statMethodCacheHits + 1.
			UseInlineCacheDelay ifTrue: [
				oldDelay _ methodCache at: probe + MethodCacheDelayCol.
				oldDelay > 0 ifTrue: [methodCache at: probe + MethodCacheDelayCol put: oldDelay - 1].
				newInlineCacheDelay _ oldDelay.
			].
			^ true	"found entry in cache; done"
		].
		probe _ ((hash >> p) bitAnd: MethodCacheMask) + 1
	].
	^ false
