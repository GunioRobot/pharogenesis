uncompressDataTo: aStream

	| decoder buffer chunkSize crcErrorMessage |
	decoder _ ZipReadStream on: stream.
	decoder expectedCrc: self crc32.
	buffer _ ByteArray new: (32768 min: readDataRemaining).
	crcErrorMessage _ nil.

	[[ readDataRemaining > 0 ] whileTrue: [
		chunkSize _ 32768 min: readDataRemaining.
		buffer _ decoder next: chunkSize into: buffer startingAt: 1.
		aStream next: chunkSize putAll: buffer startingAt: 1.
		readDataRemaining _ readDataRemaining - chunkSize.
	]] on: CRCError do: [ :ex | crcErrorMessage _ ex messageText. ex proceed ].

	crcErrorMessage ifNotNil: [ self isCorrupt: true. CRCError signal: crcErrorMessage ]

