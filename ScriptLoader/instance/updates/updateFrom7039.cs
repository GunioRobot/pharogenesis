updateFrom7039
	"self new updateFrom7039"
	
	self loadTogether: #('Kernel-sd.133.mcz' 'Traits-al.221.mcz') merge: true.
	
	Smalltalk allClassesAndTraits do: [:t | 
		(t methodDict keys select: [:s | t includesLocalSelector: s]) do: [:s | 
		t notifyUsersOfChangedSelectors: {s}].
	(t classSide methodDict keys select: [:s | t classSide includesLocalSelector: s]) do: [:s |
          t classSide notifyUsersOfChangedSelectors: {s}]].	
	
	"Initialization required for tests: strange why this is not a teardwon method"
	SendCaches initializeAllInstances.

	self flushCaches.
	MCDefinition clearInstances.
	