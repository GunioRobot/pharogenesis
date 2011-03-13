testBrokenDependency
	| installer neededPackages |
	installer := UGlobalInstaller universe: universe.
	neededPackages _ installer allPackagesNeededToInstall: (universe newestPackageNamed: 'Broken')  orIfImpossible: [ :ign | nil ].
	self should: [ neededPackages isNil ].

	