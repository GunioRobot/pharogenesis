endHeader: level
	boldLevel _ boldLevel - 1. "self decreaseBold"
	self ensureNewlines: 2.
	self endFont: nil.