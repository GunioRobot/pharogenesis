showChangeSetNamed: aName

	aName ifNil: [^ self showChangeSet: nil].
	self showChangeSet: 
		(AllChangeSets detect: [:each | each name = aName]) 