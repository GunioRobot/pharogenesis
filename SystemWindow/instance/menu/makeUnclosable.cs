makeUnclosable
	mustNotClose _ true.
	closeBox ifNotNil:
		[closeBox delete.
		closeBox _ nil]