isUpgradeableAndOld
	"Answer if there is any installer that
	can upgrade me and I can be upgraded."

	^self isUpgradeable and: [self isOld]