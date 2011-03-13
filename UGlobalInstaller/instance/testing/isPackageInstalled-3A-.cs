isPackageInstalled: aPackage
	^ self installedPackageVersions anySatisfy: [:packageVersion | packageVersion name =  aPackage]