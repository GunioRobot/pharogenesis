markAndTraceMethodCache
	"Mark from the translated methods in the method cache.  This is necessary since the method
	cache might be the only place that still has a reference to a given translated method.
	It is also necessary to support selective flush because a class definition change may #become:
	the class in the hierarchy, leaving an obsolete class referenced only from the cache."
	self inline: false.

	1 to: MethodCacheEntries do: [:i | self markAndTraceMethodCacheLine: i].
"
	1 to: MethodCacheEntries do: [:i |
		(methodCache at: i) = 0 ifFalse:
			[self markAndTrace: (methodCache at: i + (MethodCacheEntries * 4))]].
"