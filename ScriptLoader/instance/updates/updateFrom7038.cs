updateFrom7038
	"self new updateFrom7038"
	
	self script70.
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.

	self flushCaches.
	MCDefinition clearInstances.
	