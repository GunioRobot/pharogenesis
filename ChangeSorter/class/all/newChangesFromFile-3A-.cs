newChangesFromFile: aFileName
	"File in the code from the file of the given name, into a new change set whose name is derived from that of the filename.  Leave the 'current change set' unchanged.   Returns the new change set; Returns nil on failure.  5/30/96 sw"

	^ self newChangesFromStream: (FileStream oldFileNamed: aFileName) 
		named: aFileName.