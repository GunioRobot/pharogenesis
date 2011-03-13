rewriteMethodCacheSel: selector class: class primIndex: localPrimIndex 
	"Rewrite an existing entry in the method cache with a new primitive   
	index."
	| probe hash |
	self inline: false.
	hash _ selector bitXor: class.
	0 to: CacheProbeMax - 1 do: 
		[:p | 
		probe _ hash >> p bitAnd: MethodCacheMask.
		((methodCache at: probe + MethodCacheSelector)
			= selector and: [(methodCache at: probe + MethodCacheClass)
				= class])
			ifTrue: 
				[methodCache at: probe + MethodCachePrim put: localPrimIndex.
				^ nil]]