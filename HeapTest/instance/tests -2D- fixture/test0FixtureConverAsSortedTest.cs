test0FixtureConverAsSortedTest

	self shouldnt: [self collectionWithSortableElements ] raise: Error.
	self deny: self collectionWithSortableElements isEmpty .