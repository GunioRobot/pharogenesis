installableAndNotInstalledPackages
	"Answer all installable but not installed packages."

	^self packages select: [:package | package isInstallableAndNotInstalled]