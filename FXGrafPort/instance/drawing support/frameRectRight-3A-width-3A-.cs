frameRectRight: rect width: w

	width _ 1.
	height _ rect height - 1.
	destX _ rect right - 1.
	destY _ rect top + 1.
	1 to: w do: [:i |
		self copyBits.
		destX _ destX - 1.
		destY _ destY + 1.
		height _ height - 2].
