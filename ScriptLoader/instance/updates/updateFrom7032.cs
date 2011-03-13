updateFrom7032

	"self new updateFrom7032"
	"
	Networks fixes provided by the network IO team
	"
	
	self script65.
	
	
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.

	self flushCaches.
	MCDefinition clearInstances.
	