controlInitialize

	super controlInitialize.
	self recomputeInterval.
	self initializeSelection.
	beginTypeInBlock := nil