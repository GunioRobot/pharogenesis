flushMethodCacheSelective: sel
	"Flush all entries of the method cache that refer to the given selector.

	Note: we first invalidate all translated methods, and then reinstate those that are reachable through the method cache by bringing them forward into the new translation cycle.  This is not perfect (monomorphic send sites [the happiest clients of the inline cache] never refill themselves from the method cache, so they are hit worst by this scheme) -- but it's better than the 'correct' solution of scanning the whole of object memory."

	| probe |
	self inline: false.

	self flushInlineCache.
	1 to: MethodCacheEntries do: [:i |
		probe _ methodCache at: i + MethodCacheSelectorCol.
		probe = 0 ifFalse:
			[probe = sel
				ifTrue: [self flushMethodCacheLine: i]
				ifFalse: [self preserveMethodCacheLine: i]]]