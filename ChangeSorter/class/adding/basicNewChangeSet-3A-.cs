basicNewChangeSet: newName
	| newSet |
	(self changeSetNamed: newName) ifNotNil:
		[self inform: 'Sorry that name is already used'.
		^ nil].
	newSet _ ChangeSet new initialize name: newName.
	AllChangeSets add: newSet.
	^ newSet