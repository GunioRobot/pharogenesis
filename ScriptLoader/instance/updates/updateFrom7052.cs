updateFrom7052
	"self new updateFrom7052"
	self unloadFFI.
	
	Preferences disable: #maintainHalos.
	SMSqueakMap default loadFull.
	self flushCaches.
	ChangeSet removeEmptyUnnamedChangeSets.
	ChangeSet newChanges: (ChangeSorter basicNewChangeSet: 'Unnamed').
	ChangeSet current name: 'Unnamed'.