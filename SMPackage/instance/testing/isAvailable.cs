isAvailable
	"Answer if I am old or not installed regardless of
	if there is installer support for me. It also does
	not care if the newer release is not published
	or no for this Squeak version."

	^self isOld or: [self isInstalled not]