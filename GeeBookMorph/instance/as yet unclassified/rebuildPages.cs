rebuildPages

	pages _ self geePageRectangles collect: [ :each |
		GeeBookPageMorph new 
			disableDragNDrop;
			geeMail: geeMail geeMailRectangle: each.
	].
	currentPage delete.
	currentPage _ nil.
	pages isEmpty ifTrue: [^ self insertPage].
	self goToPage: 1.

