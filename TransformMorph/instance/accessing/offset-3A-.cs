offset: newOffset

	transform _ transform withOffset: newOffset - self innerBounds topLeft.
	self changed