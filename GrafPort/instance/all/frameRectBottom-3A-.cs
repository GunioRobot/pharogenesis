frameRectBottom: rect

	| w h |
	w _ width.
	h _ height.
	sourceForm _ nil.
	destX _ rect left + 1.
	destY _ rect bottom - 1.
	width _ rect width - 2.
	height _ 1.
	1 to: h do: [:i |
		self copyBits.
		destX _ destX + 1.
		destY _ destY - 1.
		width _ width - 2].
	width _ w.
	height _ h.
