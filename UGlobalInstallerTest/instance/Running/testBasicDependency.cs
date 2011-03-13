testBasicDependency
	| installer neededPackages |
	installer := UGlobalInstaller universe: universe.
	neededPackages := installer 
				allPackagesNeededToInstall: (universe newestPackageNamed: 'A')
				orIfImpossible: [:ign | self error: 'dependency not found'].
	self should: [neededPackages size = 5].
	
	
	installer := UGlobalInstaller universe: universe.
	neededPackages := installer 
				allPackagesNeededToInstall: (universe newestPackageNamed: 'B')
				orIfImpossible: [:ign | self error: 'dependency not found'].
	self should: [neededPackages size = 4]