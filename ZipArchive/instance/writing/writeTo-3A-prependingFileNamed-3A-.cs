writeTo: stream prependingFileNamed: aFileName
	| prepended buffer |
	stream binary.
	prepended _ StandardFileStream readOnlyFileNamed: aFileName.
	prepended binary.
	buffer _ ByteArray new: (prepended size min: 32768).
	[ prepended atEnd ] whileFalse: [ | bytesRead |
		bytesRead _ prepended readInto: buffer startingAt: 1 count: buffer size.
		stream next: bytesRead putAll: buffer startingAt: 1
	].
	members do: [ :member |
		member writeTo: stream.
		member endRead.
	].
	writeCentralDirectoryOffset _ stream position.
	self writeCentralDirectoryTo: stream.
	