addReference: aReference requiredCopy: aWorkingCopy repositories: anArray
	| source target patch |
	super addReference: aReference requiredCopy: aWorkingCopy repositories: anArray.
	source := aWorkingCopy package.
	target := aReference versionReference version.
	patch := source snapshot patchRelativeToBase: target snapshot.
	aWorkingCopy modified: patch isEmpty not.
	self model operations addAll: patch operations