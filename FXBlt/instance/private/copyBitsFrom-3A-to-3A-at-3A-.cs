copyBitsFrom: x0 to: x1 at: y
	destX _ x0.
	destY _ y.
	sourceX _ x0.
	width _ (x1 - x0).
	self copyBits.