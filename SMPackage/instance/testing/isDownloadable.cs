isDownloadable
	"Answer if I can be downloaded."

	^self isReleased and: [self lastRelease isDownloadable]