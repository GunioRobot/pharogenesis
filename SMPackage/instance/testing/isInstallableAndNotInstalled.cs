isInstallableAndNotInstalled
	"Answer if there is any installer that
	can install me and I am not yet installed."

	^self isInstallable and: [self isInstalled not]