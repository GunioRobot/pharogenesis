currentPage
	(submorphs includes: currentPage) ifFalse: [currentPage _ nil].
	^ currentPage