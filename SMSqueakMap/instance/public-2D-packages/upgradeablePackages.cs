upgradeablePackages
	"Answer all packages that has an installer that can upgrade them.
	Note that this doesn't mean they are old, see #upgradeableAndOldPackages."

	^self packages select: [:package | package isUpgradeable]