scale: newScale

	self changed.
	transform _ transform withScale: newScale.
	self layoutChanged.
	self changed.
