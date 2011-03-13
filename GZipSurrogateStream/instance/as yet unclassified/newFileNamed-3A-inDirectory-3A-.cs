newFileNamed: fName inDirectory: aDirectory

	positionThusFar _ 0.
	zippedFileStream _ aDirectory newFileNamed: fName.
	zippedFileStream binary; setFileTypeToObject.
		"Type and Creator not to be text, so can be enclosed in an email"
	gZipStream _ GZipWriteStream on: zippedFileStream.
