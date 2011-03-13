test3
	"Test simplest conflict."

	| task |
	"Test to install two packages, there is one solution with one conflict."
	engine := SMDependencyEngine map: map.
	task := engine installPackages: {map packageWithName: 'Seaside'. map packageWithName: 'HttpView'}.
	self assert: (task calculate).
	self assert: (task allInstallPaths size = 1).
	self assert: (task analysis installPathsWithoutConflicts size = 0).
	self assert: (task analysis allNormalizedInstallPaths size = 1).
	self assert: (task analysis bestInstallPath = nil).
	self assert: (task analysis untestedInstallPaths size = 1).
	self assert: (task proposals size = 1).
	self assert: (task proposals first hasDeviations)