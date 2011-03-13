tearDown

	super tearDown.
	self removeGeneratedTestClasses.
	ChangeSet newChanges: previousChangeSet.
	ChangesOrganizer removeChangeSet: testsChangeSet.
	previousChangeSet := nil.
	testsChangeSet := nil.
