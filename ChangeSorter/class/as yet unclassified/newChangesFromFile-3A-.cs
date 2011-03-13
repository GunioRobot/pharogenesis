newChangesFromFile: aFileName
	"File in the code from the file of the given name, into a new change set whose name is derived from that of the filename.  Leave the 'current change set' unchanged.   Returns the new change set; Returns nil on failure.  5/30/96 sw"

	|  newName aNewChangeSet existingChanges |

	existingChanges _ Smalltalk changes.
	newName _ aFileName sansPeriodSuffix.
	(self changeSetNamed: newName) ~~ nil
		ifTrue:
			[self inform: 'Sorry -- "', newName, '" is already used as a change-set name'.
			^ nil].

	aNewChangeSet _ ChangeSet new initialize.
	aNewChangeSet name: newName.
	AllChangeSets add: aNewChangeSet.
	self makeCurrent: aNewChangeSet.
	(FileStream oldFileNamed: aFileName) fileIn.
	Transcript cr; show: 'File ', aFileName, ' successfully filed in to change set ', newName.
	self makeCurrent: existingChanges.
	^ aNewChangeSet