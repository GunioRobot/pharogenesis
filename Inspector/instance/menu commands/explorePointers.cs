explorePointers
	self selectionIndex = 0 ifTrue: [^ self changed: #flash].
	PointerExplorer new openExplorerFor: self selection