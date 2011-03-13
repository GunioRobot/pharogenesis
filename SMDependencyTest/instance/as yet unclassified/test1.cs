test1
	"Test three different scenarios, a trivial, a simple
	and one with conflicting solutions."

	| task bestPath |
	engine := SMDependencyEngine map: map.
	task := engine installPackages: map installedPackages.
	self assert: (task calculate).
	self assert: (task analysis alreadyInstalled allSatisfy: [:r | r isInstalled]).
	self assert: (task analysis trivialToInstall isEmpty).
	self assert: (task analysis alreadyInstallable isEmpty).
	self assert: (task analysis trickyReleases isEmpty).
	self assert: (task allInstallPaths first isEmpty).
	self assert: (task allInstallPaths size = 1).

	"Test to install a trivial one, and an already installable one."
	engine := SMDependencyEngine map: map.
	task := engine installPackages: {map packageWithName: 'TrivialToInstall1'. map packageWithName: 'AlreadyInstallable1'}.
	self assert: (task calculate).
	self assert: (task analysis alreadyInstalled isEmpty).
	self assert: (task analysis trivialToInstall size = 1).
	self assert: (task analysis alreadyInstallable size = 1).
	self assert: (task analysis trickyReleases isEmpty).
	self assert: (task allInstallPaths size = 1).
	self assert: (task allInstallPaths first size = 2).
	
	"Test to install two packages, there are two solutions without conflicts."
	engine := SMDependencyEngine map: map.
	task := engine installPackages: {map packageWithName: 'Tricky1'. map packageWithName: 'Tricky2'}.
	self assert: (task calculate ).
	self assert: (task analysis alreadyInstalled isEmpty).
	self assert: (task analysis trivialToInstall isEmpty).
	self assert: (task analysis alreadyInstallable isEmpty).
	self assert: (task analysis trickyReleases size = 2).
	self assert: (task allInstallPaths size = 4).
	self assert: (task analysis allNormalizedInstallPaths size = 2).
	"Make sure the 4 different install paths are computed correctly. Since the algorithm uses Sets
	the actual installs can vary, that is why we sort etc to check it."
	self assert: ((task allInstallPaths collect: [:oc |
		(oc collect: [:r | r packageNameWithVersion ]) asSortedCollection asString]) asSortedCollection asString =  'a SortedCollection(''a SortedCollection(''''Tricky1 1'''' ''''Tricky2 1'''' ''''Tricky3 1'''' ''''Tricky3 2'''' ''''TrivialToInstall1 1'''')'' ''a SortedCollection(''''Tricky1 1'''' ''''Tricky2 1'''' ''''Tricky3 1'''' ''''Tricky3 2'''' ''''TrivialToInstall1 1'''')'' ''a SortedCollection(''''Tricky1 1'''' ''''Tricky2 1'''' ''''Tricky3 1'''' ''''TrivialToInstall1 1'''')'' ''a SortedCollection(''''Tricky1 1'''' ''''Tricky2 1'''' ''''Tricky3 2'''' ''''TrivialToInstall1 1'''')'')').
	self assert: (task analysis installPathsWithoutConflicts size = 2).
	bestPath := task analysis bestInstallPath.
	self assert: (bestPath size = 4).
	self assert: (bestPath anySatisfy: [:r | r packageNameWithVersion = 'Tricky3 2']).
	