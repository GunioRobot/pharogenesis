upgrade
	"Upgrade this package release if there is a new release available."

	| newRelease |
	newRelease _ package lastPublishedReleaseForCurrentSystemVersionNewerThan: self.
	newRelease ifNotNil: [(SMInstaller forPackageRelease: newRelease) upgrade]