download: aDownloadable 
	"Download the file for this SM object into the local file cache.
	If the file already exists, delete it.
	No unpacking or installation into the running image."

	| stream file fileName dir |
	[fileName _ aDownloadable downloadFileName.
	fileName
		ifNil: [self inform: 'No download url, can not download.'.
			^ false].
	fileName isEmpty
		ifTrue: [self inform: 'Download url lacks filename, can not download.'.
			^ false].
	dir _ aDownloadable cacheDirectory.
	[(dir fileExists: fileName)
		ifTrue: [dir deleteFileNamed: fileName].
	stream _ aDownloadable downloadUrl asUrl retrieveContents contentStream binary.
	file _ dir newFileNamed: fileName.
	file nextPutAll: stream contents]
		ensure: [file
				ifNotNil: [file close]]]
		on: Error
		do: [^ false].
	^ true