versionLabel
	"Return a label indicating installed and available version as:
		'1.0'      = 1.0 is installed and no new published version for this version of Squeak is available
		'1.0->1.1' = 1.0 is installed and 1.1 is published for this version of Squeak
		'->1.1'    = No version is installed and 1.1 is published for this version of Squeak
		'->(1.1)	 = No version is installed and there is only a non published version available for this version of Squeak

	The version showed is the one that #smartVersion returns.
	If a version name is in parenthesis it is not published."

	| installedVersion r r2 |
	r _ self installedRelease.
	r ifNotNil: [
		installedVersion _ r smartVersion.
		r2 _ self lastPublishedReleaseForCurrentSystemVersionNewerThan: r]
	ifNil: [
		installedVersion _ ''.
		r2 _ self lastPublishedReleaseForCurrentSystemVersion ].
	^r2 ifNil: [installedVersion ] ifNotNil: [installedVersion, '->', r2 smartVersion].