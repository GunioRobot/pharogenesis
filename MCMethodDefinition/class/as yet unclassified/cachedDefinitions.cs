cachedDefinitions
	Definitions ifNil: [Definitions _ WeakIdentityKeyDictionary new.  WeakArray addWeakDependent: Definitions].
	^ Definitions