newChangesFromStream: aStream named: aName
	"File in the code from the stream into a new change set whose name is derived from aName.  Leave the 'current change set' unchanged.   Returns the new change set;  Returns nil on failure."

	|  newName aNewChangeSet existingChanges |

	existingChanges _ Smalltalk changes.
	newName _ aName sansPeriodSuffix.
	(self changeSetNamed: newName) ~~ nil
		ifTrue:
			[self inform: 'Sorry -- "', newName, '" is already used as a change-set name'.
			aStream close.
			^ nil].

	aNewChangeSet _ ChangeSet new initialize.
	aNewChangeSet name: newName.
	AllChangeSets add: aNewChangeSet.
	Smalltalk newChanges: aNewChangeSet.
	aStream fileInAnnouncing: 'Loading ', newName, '...'.
	Transcript cr; show: 'File ', aName, ' successfully filed in to change set ', newName.
	Smalltalk newChanges: existingChanges.
	^ aNewChangeSet