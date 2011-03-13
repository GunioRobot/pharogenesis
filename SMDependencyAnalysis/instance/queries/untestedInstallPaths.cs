untestedInstallPaths
	"We take the paths with conflicts and remove the older releases."

	^self installPathsWithConflicts collect: [:p |
		 self removeOlderReleasesIn: p] 