updateFrom7033
	"self new updateFrom7033"
	
	"Some MC fixes"
	
	self script66.
	
	
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.

	self flushCaches.
	MCDefinition clearInstances.
	