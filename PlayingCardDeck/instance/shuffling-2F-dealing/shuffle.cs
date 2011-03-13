shuffle
	self invalidRect: self fullBounds.
	submorphs _ submorphs shuffledBy: (Random new seed: seed).
	self layoutChanged.