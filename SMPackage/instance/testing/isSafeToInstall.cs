isSafeToInstall
	"Answer if I am NOT installed and there also is a
	published version for this version of Squeak available."

	^self isInstalled not and: [
		self lastPublishedReleaseForCurrentSystemVersion notNil]