installPackageRelease: aPackageRelease
	"Install the given package release, no checks made."

	(SMInstaller forPackageRelease: aPackageRelease) install