isSafelyAvailable
	"Answer if I am old or not installed regardless of
	if there is installer support for me. The
	newer release should be published
	and meant for this Squeak version."

	^self isSafeToInstall or: [self isSafelyOld]