noteInstalled: aPackageRelease
	"The package release was just successfully installed using SM.
	This is the method being called by SM upon a successful installation.

	We record this in our Dictionary of installed package releases
	and log a 'do it' to mark this in the changelog.
	The map used is the default map."

	^self noteInstalledPackageWithId: aPackageRelease package id asString
		autoVersion: aPackageRelease automaticVersion
		name: aPackageRelease package name