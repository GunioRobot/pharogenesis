isPackageSelected: aPackageName
	^ self selectedPackageVersions
		anySatisfy: [:packageVersion | packageVersion name = aPackageName ]