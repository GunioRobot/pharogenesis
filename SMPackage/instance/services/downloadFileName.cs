downloadFileName
	"Cut out the filename from the url."
	self isReleased ifFalse: [self error: 'There is no release for this package to download.'].
	^self lastRelease downloadFileName