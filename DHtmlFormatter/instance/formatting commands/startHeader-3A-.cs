startHeader: level
	self ensureNewlines: 3.
	boldLevel _ boldLevel + 1. "self increaseBold"
	self startFont: (self headerFont: level).