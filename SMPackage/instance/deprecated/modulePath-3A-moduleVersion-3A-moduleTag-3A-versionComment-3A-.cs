modulePath: p moduleVersion: v moduleTag: t versionComment: vc
	"Deprecated. Only kept for migration from SM 1.0x.
	Method used when recreating from storeOn: format."

	self isReleased ifTrue: [self lastRelease note: vc]