installedPackageReleases
	"Answer all package releases that we know are installed.
	Lazily initialize. The Dictionary contains the installed packages
	using their UUIDs as keys and the version string as the value."

	^self installedPackages collect: [:p | self installedReleaseOf: p]