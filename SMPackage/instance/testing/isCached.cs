isCached
	"Is the last release corresponding to me in the local file cache?
	NOTE: This doesn't honour #published nor if the release is
	intended for the current Squeak version."

	^self isReleased and: [self lastRelease isCached]