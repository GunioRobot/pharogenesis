from: aFileName
	| entry |
	compressionMethod _ CompressionStored.
	"Now get the size, attributes, and timestamps, and see if the file exists"
	stream _ StandardFileStream readOnlyFileNamed: aFileName.
	self localFileName: (externalFileName _ stream name).
	entry _ stream directoryEntry.
	compressedSize _ uncompressedSize _ entry fileSize.
	desiredCompressionMethod _ compressedSize > 0 ifTrue: [ CompressionDeflated ] ifFalse: [ CompressionStored ].
	self setLastModFileDateTimeFrom: entry modificationTime
