controlInitialize

	model acceptOnCR ifFalse: [^ super controlInitialize].
	self setMark: self markBlock stringIndex.
	self setPoint: self pointBlock stringIndex.
	self initializeSelection.
	beginTypeInBlock _ nil.
