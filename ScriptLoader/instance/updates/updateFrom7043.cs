updateFrom7043
	"self new updateFrom7043"
	
	self script74.
	ServiceRegistry rebuild.

	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.
	
	self flushCaches.
	MCDefinition clearInstances.
	