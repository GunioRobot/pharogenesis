addCategoryViewerFor: aStartingCategory
	| aViewer |
	self addMorphBack: (aViewer _ CategoryViewer new initializeFor: scriptedPlayer categoryChoice: aStartingCategory).
	self world ifNotNil: [self world startSteppingSubmorphsOf: aViewer]