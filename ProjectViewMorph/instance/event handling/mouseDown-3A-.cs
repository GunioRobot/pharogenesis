mouseDown: evt

	evt hand newMouseFocus: self.
	self removeProperty: #wasOpenedAsSubproject.
	self showMouseState: 2.