cachedCopyFilename
	"Download the package to a local cache, if it is not already in the cache.  Return the filename of the file in the cache.  If the package has no URL, download nothing and return nil."
	| filename doc file downloadDir |
	self url ifNil: [ ^nil ].
	
	downloadDir _ FileDirectory default directoryNamed: 'universetmp'.
	downloadDir assureExistence.
	
	filename _ self url path last.
	(downloadDir isAFileNamed: filename)
	ifFalse: [
		"download the file"
		doc _ url retrieveContents.
		((doc contentType asString = 'text/plain') and: [
			doc content beginsWith: 'error']) ifTrue: [
			"HACK to see if the download failed; the real solution is to make retrieveContents report errors"
			^self error: 'download failed' ].
		file _ downloadDir newFileNamed: filename.
		file binary.
		file nextPutAll: doc content.
		file close. ].

	^ (downloadDir fullNameFor: filename).