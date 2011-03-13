initializeFlapVersionFor: aPlayer
	scriptedPlayer _ aPlayer.
	self listDirection: #topToBottom;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		borderWidth: 1.
	self color: self standardViewerColor.
	self addHeaderMorphWithBarHeight: 0 includeDismissButton: false.

	self addCategoryViewer.    "#1"
	self addCategoryViewer.    "#2"