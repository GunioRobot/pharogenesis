isInstalled
	"Answer if this release is installed."

	^(map installedReleaseOf: package) == self