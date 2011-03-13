toggleAutoLineLayout
	autoLineLayout _ self autoLineLayout not.
	self fixLayout.
	self layoutChanged