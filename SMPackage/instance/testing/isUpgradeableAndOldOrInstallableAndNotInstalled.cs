isUpgradeableAndOldOrInstallableAndNotInstalled
	"Well, duh. Isn't it obvious? :-)
	Is the package available now for automatic install or automatic upgrade?"

	^self isUpgradeableAndOld and: [self isInstallableAndNotInstalled]