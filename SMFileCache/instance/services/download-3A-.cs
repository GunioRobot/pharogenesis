download: aDownloadable 
	"Download the file for this SMObject into the local file cache.
	If the file already exists, delete it.
	No unpacking or installation into the running image."

	| stream file fileName dir |
	[fileName := aDownloadable downloadFileName.
	fileName
		ifNil: [self inform: 'No download url, can not download.'.
			^ false].
	fileName isEmpty
		ifTrue: [self inform: 'Download url lacks filename, can not download.'.
			^ false].
	dir := aDownloadable cacheDirectory.
	[stream := self getStream: aDownloadable.
	stream ifNil: [^ false].
	(dir fileExists: fileName)
		ifTrue: [dir deleteFileNamed: fileName].
	file := dir newFileNamed: fileName.
	file binary; nextPutAll: stream contents]
		ensure: [file ifNotNil: [file close]]]
		on: Error
		do: [^ false].
	^ true