isUpgradeable
	"Answer if there is any installer that can upgrade me."

	^self isReleased and: [self lastRelease isUpgradeable]