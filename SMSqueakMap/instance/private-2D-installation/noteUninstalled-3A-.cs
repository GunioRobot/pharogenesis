noteUninstalled: aPackageRelease
	"The package release was just successfully uninstalled using SM.
	This is the method being called by SM upon a successful uninstallation.

	We record this in our Dictionary of installed package releases
	and log a 'do it' to mark this in the changelog.
	The map used is the default map."

	^self noteUninstalledPackageWithId: aPackageRelease package id asString
		autoVersion: aPackageRelease automaticVersion
		name: aPackageRelease package name