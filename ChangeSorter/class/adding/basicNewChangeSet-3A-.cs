basicNewChangeSet: newName
	| newSet |
	newName ifNil: [^ nil].
	(self changeSetNamed: newName) ifNotNil:
		[self inform: 'Sorry that name is already used'.
		^ nil].
	newSet _ ChangeSet basicNewNamed: newName.
	AllChangeSets add: newSet.
	^ newSet