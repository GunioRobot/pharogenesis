oldPackages
	"Answer all packages that are installed with a
	newer published version for this Squeak version available."

	^self installedPackages select: [:package | package isSafelyOld]