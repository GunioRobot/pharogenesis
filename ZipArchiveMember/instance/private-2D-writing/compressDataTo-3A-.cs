compressDataTo: aStream
	"Copy my deflated data to the given stream."
	| encoder startPos endPos |

	encoder _ ZipWriteStream on: aStream.
	startPos _ aStream position.

	[ readDataRemaining > 0 ] whileTrue: [ | data |
		data _ self readRawChunk: (4096 min: readDataRemaining).
		encoder nextPutAll: data asByteArray.
		readDataRemaining _ readDataRemaining - data size.
	].
	encoder finish. "not close!"
	endPos _ aStream position.
	compressedSize _ endPos - startPos.
	crc32 _ encoder crc.
