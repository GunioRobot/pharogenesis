newChangesFromStream: aStream named: aName
	"File in the code from the stream into a new change set whose
	name is derived from aName. Leave the 'current change set'
	unchanged. Return the new change set or nil on failure."

	| oldChanges newName newSet |
	oldChanges _ Smalltalk changes.
	newName _ aName sansPeriodSuffix.
	newSet _ self basicNewChangeSet: newName.
	newSet ifNotNil:
		[Smalltalk newChanges: newSet.
		aStream fileInAnnouncing: 'Loading ', newName, '...'.
		Transcript cr; show: 'File ', aName, ' successfully filed in to change set ', newName].
	aStream close.
	Smalltalk newChanges: oldChanges.
	^ newSet