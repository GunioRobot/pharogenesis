reverse
	self invalidRect: self fullBounds.
	submorphs _ submorphs reversed.
	self layoutChanged.