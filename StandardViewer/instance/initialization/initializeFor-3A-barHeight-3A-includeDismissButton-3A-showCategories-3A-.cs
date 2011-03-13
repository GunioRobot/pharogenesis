initializeFor: aPlayer barHeight: anInteger includeDismissButton: aBoolean showCategories: cats
	scriptedPlayer _ aPlayer.
	self listDirection: #topToBottom;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		borderWidth: 1.
	self color: self standardViewerColor.
	self addHeaderMorphWithBarHeight: anInteger includeDismissButton: aBoolean.

	cats isEmptyOrNil
		ifFalse:
			[cats do:
				[:aCat | self addCategoryViewerFor: aCat]]
		ifTrue:
			[self addCategoryViewer.
			self addCategoryViewer].