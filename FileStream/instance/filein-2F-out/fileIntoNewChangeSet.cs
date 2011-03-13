fileIntoNewChangeSet
	"File all of my contents into a new change set." 

	self readOnly.
	ChangeSorter newChangesFromStream: self named: (self localName)
