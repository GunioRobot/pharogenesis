previousPageZoomingFrom: aMorph

	| i |
	i _ (pages indexOf: currentPage ifAbsent: [2]) - 1.
	self goToPage: i zoomingFrom: aMorph.
