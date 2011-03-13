insertPageMorphInCorrectSpot: aPageMorph

	self addMorph: (currentPage _ aPageMorph) behind: submorphs second.
	self changeTiltFactor: self getTiltFactor.
	self changeZoomFactor: self getZoomFactor.
	zoomController target: currentPage.

