toggleResizeToFit
	resizeToFit _ self resizeToFit not.
	self fixLayout.
	self layoutChanged