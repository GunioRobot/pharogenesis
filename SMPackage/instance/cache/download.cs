download
	"Force download into cache."

	self isReleased ifFalse: [self error: 'There is no release for this package to download.'].
	^self lastRelease download