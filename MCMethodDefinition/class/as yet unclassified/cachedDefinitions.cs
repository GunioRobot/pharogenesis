cachedDefinitions
	Definitions ifNil: [Definitions := WeakIdentityKeyDictionary new.  WeakArray addWeakDependent: Definitions].
	^ Definitions