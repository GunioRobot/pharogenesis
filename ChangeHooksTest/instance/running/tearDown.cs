tearDown

	super tearDown.
	self removeGeneratedTestClasses.
	ChangeSet newChanges: previousChangeSet.
	ChangeSorter removeChangeSet: testsChangeSet.
	previousChangeSet := nil.
	testsChangeSet := nil.
