isUpgradeable: aPackageRelease
	"Detect if any subclass can handle the release.
	Currently we assume that upgrade is the same as install."

	^self isInstallable: aPackageRelease