updateFrom7046
	"self new updateFrom7046"
	
	self script77.
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.
	
	self flushCaches.
	MCDefinition clearInstances.
	"uncomment for the final version"
	Utilities emptyScrapsBook.
	"self prepareReleaseImage."