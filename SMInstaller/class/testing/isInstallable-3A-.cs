isInstallable: aPackageRelease
	"Detect if any subclass can handle the package release."

	aPackageRelease ifNil: [^false].
	^(self classForPackageRelease: aPackageRelease) notNil