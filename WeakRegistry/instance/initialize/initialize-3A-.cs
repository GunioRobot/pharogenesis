initialize: n
	valueDictionary := WeakKeyDictionary new: n.
	accessLock := Semaphore forMutualExclusion.