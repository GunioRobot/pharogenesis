copyDataWithCRCTo: aStream
	"Copy my data to aStream. Also set the CRC-32.
	Only used when compressionMethod = desiredCompressionMethod = CompressionStored"

	uncompressedSize _ compressedSize _ readDataRemaining.

	crc32 _ 16rFFFFFFFF.

	[ readDataRemaining > 0 ] whileTrue: [ | data |
		data _ self readRawChunk: (4096 min: readDataRemaining).
		aStream nextPutAll: data.
		crc32 _ ZipWriteStream updateCrc: crc32 from: 1 to: data size in: data.
		readDataRemaining _ readDataRemaining - data size.
	].

	crc32 _ crc32 bitXor: 16rFFFFFFFF.
