load
	| loader |
	self checkForModifications.
	loader _ MCPackageLoader new.
	versions do: [:ea | loader updatePackage: ea package withSnapshot: ea snapshot].
	loader loadWithNameLike: versions first info name.
	versions do: [:ea | ea workingCopy loaded: ea]