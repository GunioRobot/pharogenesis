nextPage

	currentPage == nil ifTrue: [^ self goToPage: 1].
	self goToPage: (self pageNumberOf: currentPage) + 1.
