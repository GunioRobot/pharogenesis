initializeFor: aPlayer barHeight: anInteger includeDismissButton: aBoolean
	scriptedPlayer _ aPlayer.
	self orientation: #vertical;
		hResizing: #spaceFill;
		vResizing: #shrinkWrap;
		borderWidth: 1.
	self color: self standardViewerColor.
	self addHeaderMorphWithBarHeight: anInteger includeDismissButton: aBoolean.

	self addCategoryViewer.    "#1"
	self addCategoryViewer.    "#2"