addReference: aReference requiredCopy: aWorkingCopy repositories: anArray
	super addReference: aReference requiredCopy: aWorkingCopy repositories: anArray.
	latestVersions at: aWorkingCopy put: aReference versionReference version info.
