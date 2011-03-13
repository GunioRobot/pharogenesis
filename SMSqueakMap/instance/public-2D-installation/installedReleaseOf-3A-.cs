installedReleaseOf: aPackage
	"If the package is installed, return the release.
	Otherwise return nil. SM2 stores the version as
	an Association to be able to distinguish it."

	^self registry installedReleaseOf: aPackage