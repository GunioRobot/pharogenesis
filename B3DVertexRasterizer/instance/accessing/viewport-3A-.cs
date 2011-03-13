viewport: aRectangle
	| r |
	r _ aRectangle.
	offset ifNotNil:[r _ r translateBy: offset].
	viewport _ B3DViewport origin: r origin truncated corner: r corner truncated.
	viewport toggleYScale.