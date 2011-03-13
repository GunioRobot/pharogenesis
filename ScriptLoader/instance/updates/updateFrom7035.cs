updateFrom7035
	"self new updateFrom7035"
	
	"Pragrams fixes lr
	PackageInfo al
	System al
	Kernel Tests lr"
	
	self
		loadOneAfterTheOther: #('System-sd.87.mcz' 'Monticello-al.305.mcz' 'PackageInfo-al.6.mcz')
		merge: true.
		
	self script67.
	
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.

	self flushCaches.
	MCDefinition clearInstances.
	