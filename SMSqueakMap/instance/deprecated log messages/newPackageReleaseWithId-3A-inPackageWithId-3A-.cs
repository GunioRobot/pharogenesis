newPackageReleaseWithId: anIdString inPackageWithId: packageIdString
	"Create a package release and add it to the correct package."

	| release |
	release _ SMPackageRelease newIn: self withId: anIdString.
	(self packageWithId: packageIdString) addRelease: release.
	^self newObject: release