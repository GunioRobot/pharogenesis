saveLatestScriptLoaderToHome
	"self new saveLatestScriptLoaderToHome"

	| man r |
	man := MCWorkingCopy allManagers.
	r := man select: [:each | 'ScriptLoader*' match: each  package name].
	self repository storeVersion: r first newVersion.