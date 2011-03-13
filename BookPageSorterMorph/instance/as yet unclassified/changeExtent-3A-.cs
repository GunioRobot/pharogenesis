changeExtent: aPoint

	self extent: aPoint.
	pageHolder extent: self extent - borderWidth.

