tearDown

	self removeEverythingInSetFromSystem: testsChangeSet.
	ChangeSet newChanges: previousChangeSet.
	ChangeSorter removeChangeSet: testsChangeSet.
	previousChangeSet := nil.
	testsChangeSet := nil.
	SystemChangeNotifier uniqueInstance noMoreNotificationsFor: self.
	super tearDown.