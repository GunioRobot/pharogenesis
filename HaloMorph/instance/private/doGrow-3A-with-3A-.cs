doGrow: evt with: growHandle

	| newExtent |
	newExtent _ (target pointFromWorld: (evt cursorPoint - positionOffset)) - target topLeft.
	evt shiftPressed ifTrue: [newExtent _ (newExtent x max: newExtent y) asPoint].
	target renderedMorph extent: (newExtent max: minExtent).
	growHandle position: evt cursorPoint - (growHandle extent // 2).
	self layoutChanged.
