upgradeableAndOldPackages
	"Answer all packages that are installed and which have a
	newer published release for this Squeak version that also
	can be to by an installer."

	^self installedPackages select: [:package | package isSafelyOldAndUpgradeable]