toggleIndicateCursor
	indicateCursor _ self indicateCursor not.
	self fixLayout.
	self layoutChanged