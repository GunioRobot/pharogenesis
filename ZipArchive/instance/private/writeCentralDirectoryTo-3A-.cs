writeCentralDirectoryTo: aStream
	| offset |
	offset _ writeCentralDirectoryOffset.
	members do: [ :member |
		member writeCentralDirectoryFileHeaderTo: aStream.
		offset _ offset + member centralDirectoryHeaderSize.
	].
	writeEOCDOffset _ offset.
	self writeEndOfCentralDirectoryTo: aStream.

