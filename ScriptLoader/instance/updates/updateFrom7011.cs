updateFrom7011
	"self new updateFrom7011"
	"
	Refactoring of Class|Trait>>category lookup. Improves category lookup by a factor of 10 and 	for example loading of a Monticello package by a factor of 2.
	"
	self script49.
	self flushCaches.
	MCDefinition clearInstances.