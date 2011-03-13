setFrame: aRectangle in: widget
	| frame |
	aRectangle ifNil:[^nil].
	frame := self asFrame: aRectangle.
	widget layoutFrame: frame.
	widget hResizing: #spaceFill; vResizing: #spaceFill.
	(parent isSystemWindow) ifTrue:[
		widget borderWidth: 2; borderColor: #inset.
	].