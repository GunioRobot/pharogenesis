deselectPackageNamed: aPackageName
	self selectedPackageVersions 
		removeAllSuchThat: [:package | package name = aPackageName ]