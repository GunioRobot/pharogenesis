setOrigin: aPoint clipRect: aRectangle

	origin _ aPoint.
	clipRect _ aRectangle.
	port clipRect: aRectangle.
