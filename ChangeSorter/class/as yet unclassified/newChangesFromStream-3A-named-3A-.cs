newChangesFromStream: aFileStream named: aFileName
	"File in the code from the file, into a new change set whose name is derived from the filename.  Leave the 'current change set' unchanged.   Returns the new change set;  Returns nil on failure.  7/12/96 sw  Allow any kind of stream.  tk 9/11/97"

	|  newName aNewChangeSet existingChanges |

	existingChanges _ Smalltalk changes.
	newName _ aFileName sansPeriodSuffix.
	(self changeSetNamed: newName) ~~ nil
		ifTrue:
			[self inform: 'Sorry -- "', newName, '" is already used as a change-set name'.
			aFileStream close.
			^ nil].

	aNewChangeSet _ ChangeSet new initialize.
	aNewChangeSet name: newName.
	AllChangeSets add: aNewChangeSet.
	self makeCurrent: aNewChangeSet.
	aFileStream fileIn.
	Transcript cr; show: 'File ', aFileName, ' successfully filed in to change set ', newName.
	self makeCurrent: existingChanges.
	^ aNewChangeSet