shuffleSubmorphs
	"Randomly shuffle the order of my submorphs.  Don't call this method lightly!"

	self invalidRect: self fullBounds.
	submorphs := submorphs shuffled.
	self layoutChanged