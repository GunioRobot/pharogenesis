isInstalled
	"Answer if any version of me is installed."

	^(map installedReleaseOf: self) notNil