compressFileNamed: aFileName in: aDirectory
	"Compress the currently selected file"
	| zipped buffer unzipped zipFileName |
	unzipped _ aDirectory readOnlyFileNamed: (aDirectory fullNameFor: aFileName).
	unzipped binary.
	zipFileName _ aFileName copyUpToLast: $. .
	zipped _ aDirectory newFileNamed: (zipFileName, FileDirectory dot, ImageSegment compressedFileExtension).
	zipped binary.
	zipped _ GZipWriteStream on: zipped.
	buffer _ ByteArray new: 50000.
	'Compressing ', zipFileName displayProgressAt: Sensor cursorPoint
		from: 0 to: unzipped size
		during:[:bar|
			[unzipped atEnd] whileFalse:[
				bar value: unzipped position.
				zipped nextPutAll: (unzipped nextInto: buffer)].
			zipped close.
			unzipped close].
