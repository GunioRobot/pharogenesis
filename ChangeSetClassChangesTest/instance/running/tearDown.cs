tearDown

	(Smalltalk classNamed: #JunkClass) ifNotNil: [:c | c removeFromSystem: true].
	SystemOrganization removeCategory: #'DeleteMe-1'.
	SystemOrganization removeCategory: #'DeleteMe-2'.
	ChangeSet current removeClassChanges: 'JunkClass'

