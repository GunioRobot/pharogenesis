add: aDownloadable 
	"Conditionally download the downloadable object into the cache.
	Return true on success, otherwise false."

	^(self includes: aDownloadable)
		ifTrue: [true]
		ifFalse: [self download: aDownloadable]