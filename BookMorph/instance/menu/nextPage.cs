nextPage

	| i |
	currentPage == nil ifTrue: [^ self goToPage: 1].
	i _ (pages indexOf: currentPage ifAbsent: [0]) + 1.
	self goToPage: i.
