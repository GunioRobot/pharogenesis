recreateCache
"
	self recreateCache.
"
	self allSubInstances do: [:inst | inst recreateCache].
	Smalltalk garbageCollect.
