updateFrom7041
	"self new updateFrom7041"
	
	self script72.
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.

	self flushCaches.
	MCDefinition clearInstances.
	