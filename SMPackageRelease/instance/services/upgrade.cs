upgrade
	"Upgrade this package release if there is a new release available."

	| newRelease |
	newRelease := package lastPublishedReleaseForCurrentSystemVersionNewerThan: self.
	newRelease ifNotNil: [(SMInstaller forPackageRelease: newRelease) upgrade]