flushMethodCacheFrom: memStart to: memEnd 
	"Flush entries in the method cache only if the oop address is within the given memory range. 
	This reduces overagressive cache clearing. Note the AtCache is fully flushed, 70% of the time 
	cache entries live in newspace, new objects die young"
	| probe |
	probe _ 0.
	1 to: MethodCacheEntries do: [:i | 
			(methodCache at: probe + MethodCacheSelector) = 0
				ifFalse: [(((((methodCache at: probe + MethodCacheSelector) >= memStart
										and: [(methodCache at: probe + MethodCacheSelector) < memEnd])
									or: [(methodCache at: probe + MethodCacheClass) >= memStart
											and: [(methodCache at: probe + MethodCacheClass) < memEnd]])
								or: [(methodCache at: probe + MethodCacheMethod) >= memStart
										and: [(methodCache at: probe + MethodCacheMethod) < memEnd]])
							or: [(methodCache at: probe + MethodCacheNative) >= memStart
									and: [(methodCache at: probe + MethodCacheNative) < memEnd]])
						ifTrue: [methodCache at: probe + MethodCacheSelector put: 0]].
			probe _ probe + MethodCacheEntrySize].
	1 to: AtCacheTotalSize do: [:i | atCache at: i put: 0]