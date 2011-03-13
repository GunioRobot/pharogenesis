installPathsWithoutConflicts
	"Same as allInstallPaths, but we filter out paths
	with multiple releases of the same package."

	^ self allInstallPaths reject: [:path | self detectConflictingReleasesIn: path] 