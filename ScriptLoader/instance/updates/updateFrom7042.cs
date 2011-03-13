updateFrom7042
	"self new updateFrom7042"
	
	self script73.
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.
	
	Preferences disable: #higherPerformance.
	self flushCaches.
	MCDefinition clearInstances.
	