updateFrom7040
	"self new updateFrom7040"
	
	self script71.
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.

	self flushCaches.
	MCDefinition clearInstances.
	