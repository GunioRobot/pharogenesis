fileIntoNewChangeSet
	"FileIn all of the contents from the external file, into a new change set.  7/12/96 sw"

	ChangeSorter newChangesFromFileStream: (FileStream oldFileNamed: self fullName)