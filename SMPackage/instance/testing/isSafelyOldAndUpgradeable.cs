isSafelyOldAndUpgradeable
	"Answer if I am installed and there also is a
	newer published version for this version of Squeak available
	that can be upgraded to (installer support)."

	| installed newRelease |
	installed _ self installedRelease.
	^installed ifNil: [false] ifNotNil: [
		newRelease _ self lastPublishedReleaseForCurrentSystemVersionNewerThan: installed.
		^newRelease ifNil: [false] ifNotNil: [newRelease isUpgradeable]]