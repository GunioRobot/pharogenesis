packageVersionsForPackage: aPackageName
	^ (universe packages
		select: [:package | package name = aPackageName])
		asSortedCollection: [:p1 :p2 | p1 version < p2 version].
	