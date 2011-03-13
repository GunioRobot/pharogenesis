updateFrom7044

	"self new updateFrom7044"
	self script75.
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.
	
	self flushCaches.
	MCDefinition clearInstances.