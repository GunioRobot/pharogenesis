saveLatestScriptLoaderToWaitingFolder
	"self new saveLatestScriptLoaderToWaitingFolder"

	| man r |
	man := MCWorkingCopy allManagers.
	r := man select: [:each | 'ScriptLoader*' match: each  package name].
	self
		saveInToReloadCachePackage: r first
		with: self commentForCurrentUpdate