sortPages

	currentPage ifNotNil: [currentPage updateCachedThumbnail].
	^ super sortPages