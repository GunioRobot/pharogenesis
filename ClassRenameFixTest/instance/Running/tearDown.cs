tearDown

	self removeEverythingInSetFromSystem: testsChangeSet.
	ChangeSet newChanges: previousChangeSet.
	ChangesOrganizer removeChangeSet: testsChangeSet.
	previousChangeSet := nil.
	testsChangeSet := nil.
	SystemChangeNotifier uniqueInstance noMoreNotificationsFor: self.
	super tearDown.