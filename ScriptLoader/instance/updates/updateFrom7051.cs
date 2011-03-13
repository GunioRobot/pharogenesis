updateFrom7051

	"self new updateFrom7051"
	self script82.
	
	Preferences disable: #maintainHalos.
	SMSqueakMap default loadFull.
	self flushCaches.
	ChangeSet removeEmptyUnnamedChangeSets.
	ChangeSet newChanges: (ChangeSorter basicNewChangeSet: 'Unnamed').
	ChangeSet current name: 'Unnamed'.