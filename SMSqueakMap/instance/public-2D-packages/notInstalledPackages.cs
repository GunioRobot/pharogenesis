notInstalledPackages
	"Answer all packages that are not installed."

	^self packages reject: [:package | package isInstalled]