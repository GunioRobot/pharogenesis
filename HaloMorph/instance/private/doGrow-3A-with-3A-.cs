doGrow: evt with: growHandle

	| newExtent |
	newExtent _ (evt cursorPoint - positionOffset) - target topLeft.
	target extent: (newExtent max: minExtent).
	growHandle position: evt cursorPoint - (growHandle extent // 2).
	self layoutChanged.
