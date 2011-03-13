installedPackageVersions
	^ configuration installedPackages 
		asSortedCollection: [:p1 :p2 | p1 name < p2 name].