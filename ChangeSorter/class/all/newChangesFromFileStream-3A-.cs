newChangesFromFileStream: aFileStream
	"File in the code from the file, into a new change set whose name is derived from the filename.  Leave the 'current change set' unchanged.   Returns the new change set;  Returns nil on failure.  7/12/96 sw"

	^ self newChangesFromStream: aFileStream 
		named: aFileStream localName