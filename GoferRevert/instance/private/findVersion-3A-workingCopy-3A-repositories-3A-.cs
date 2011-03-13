findVersion: aReference workingCopy: aWorkingCopy repositories: anArray
	^ (MCRepositoryGroup withAll: anArray) versionWithInfo: aWorkingCopy ancestors first