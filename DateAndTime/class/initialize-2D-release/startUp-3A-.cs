startUp: resuming 

	resuming ifFalse: [^ self].
	
	[ self initializeOffsets ] fork.
	
