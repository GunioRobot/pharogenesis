ensureInCache
	"Makes sure the file is in the cache."
	self isReleased ifFalse: [self error: 'There is no release for this package to download.'].
	^self lastRelease ensureInCache 