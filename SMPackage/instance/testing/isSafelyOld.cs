isSafelyOld
	"Answer if I am installed and there also is a
	newer published version for this version of Squeak available."

	| installed |
	installed := self installedRelease.
	^installed ifNil: [false] ifNotNil: [
		^(self lastPublishedReleaseForCurrentSystemVersionNewerThan: installed) notNil]