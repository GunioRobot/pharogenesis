saveGZipContents
	"Save the contents of a gzipped file"
	| zipped buffer unzipped newName |
	newName _ fileName copyUpToLast: FileDirectory extensionDelimiter.
	unzipped _ directory newFileNamed: newName.
	zipped _ GZipReadStream on: (directory readOnlyFileNamed: self fullName).
	buffer _ String new: 50000.
	'Extracting ' , self fullName
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: zipped sourceStream size
		during: 
			[:bar | 
			[zipped atEnd]
				whileFalse: 
					[bar value: zipped sourceStream position.
					unzipped nextPutAll: (zipped nextInto: buffer)].
			zipped close.
			unzipped close].
	self updateFileList.
	^ newName