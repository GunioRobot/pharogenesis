upgradeableAndOldOrInstallableAndNotInstalledPackages
	"This would give you all packages that are available now
	for automatic install or automatic upgrade."

	^self upgradeableAndOldPackages union: self installableAndNotInstalledPackages