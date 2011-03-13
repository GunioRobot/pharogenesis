flushCaches

	MCFileBasedRepository flushAllCaches.
	MCDefinition clearInstances.
	Smalltalk garbageCollect.
	
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.