controlTerminate

	self closeTypeIn.  "Must call to establish UndoInterval"
	super controlTerminate.
	self deselect