initialize: n
	valueDictionary := WeakIdentityKeyDictionary new: n.
	accessLock := Semaphore forMutualExclusion.