installPathsWithConflicts
	"Same as allInstallPaths, but we only return paths
	with multiple releases of the same package."

	^ self allInstallPaths select: [:path | self detectConflictingReleasesIn: path] 