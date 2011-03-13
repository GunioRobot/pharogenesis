installedReleaseOf: aPackage
	"If the package is installed, return the release.
	Otherwise return nil. SM2 stores the version as
	an Association to be able to distinguish it."

	| autoVersionOrOld |
	installedPackages ifNil: [^nil].
	autoVersionOrOld := (installedPackages at: aPackage id ifAbsent: [^nil]) last first.
	(autoVersionOrOld isKindOf: Association)
		ifTrue: [
			^aPackage releaseWithAutomaticVersion: autoVersionOrOld value]
		ifFalse: [
			^aPackage releaseWithVersion: autoVersionOrOld]