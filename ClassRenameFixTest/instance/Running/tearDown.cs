tearDown

	self removeEverythingInSetFromSystem: testsChangeSet.
	ChangeSet newChanges: previousChangeSet.
	ChangeSorter removeChangeSet: testsChangeSet.
	previousChangeSet := nil.
	testsChangeSet := nil.
	super tearDown.