upgradeOldPackages
	"Upgrade all upgradeable old packages without confirmation on each."

	^self upgradeOldPackagesConfirmBlock: [:package | true ]