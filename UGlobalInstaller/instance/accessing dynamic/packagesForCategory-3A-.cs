packagesForCategory: aCategory
	^ (universe packages
		select: [:package | package category = aCategory]
		thenCollect: [:package | package name])
		asSortedCollection 