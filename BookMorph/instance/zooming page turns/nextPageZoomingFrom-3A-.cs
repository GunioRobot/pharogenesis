nextPageZoomingFrom: aMorph

	| i |
	i _ (pages indexOf: currentPage ifAbsent: [0]) + 1.
	self goToPage: i zoomingFrom: aMorph.
