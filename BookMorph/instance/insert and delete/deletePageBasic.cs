deletePageBasic
	| thisPage |
	thisPage _ self pageNumberOf: currentPage.
	pages remove: currentPage.
	currentPage delete.
	currentPage _ nil.
	pages isEmpty ifTrue: [^ self insertPage].
	self goToPage: (thisPage min: pages size)
