fileIntoNewChangeSet
	"File all of my contents into a new change set." 

	self readOnly.
	ChangesOrganizer newChangesFromStream: self named: (self localName)
