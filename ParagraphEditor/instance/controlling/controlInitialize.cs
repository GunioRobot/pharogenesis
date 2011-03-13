controlInitialize

	super controlInitialize.
	self recomputeInterval.
	self initializeSelection.
	beginTypeInBlock _ nil