okayActiveProcessStack

	| cntxt |
	cntxt _ activeContext.	
	[cntxt = nilObj] whileFalse: [
		self okayFields: cntxt.
		cntxt _ (self fetchPointer: SenderIndex ofObject: cntxt).
	].