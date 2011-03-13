addReference: aPackage requiredCopy: aWorkingCopy repositories: anArray
	super addReference: aPackage requiredCopy: aWorkingCopy repositories: anArray.
	repositories at: aWorkingCopy put: anArray