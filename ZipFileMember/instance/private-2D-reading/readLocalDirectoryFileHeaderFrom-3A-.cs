readLocalDirectoryFileHeaderFrom: aStream 
	"Positions stream as necessary. Will return stream to its original position"

	| fileNameLength extraFieldLength xcrc32 xcompressedSize xuncompressedSize sig oldPos |

	oldPos _ aStream position.

	aStream position: localHeaderRelativeOffset.

	sig _ aStream next: 4.
	sig = LocalFileHeaderSignature asByteArray
		ifFalse: [ aStream position: oldPos.
				^self error: 'bad LH signature at ', localHeaderRelativeOffset hex ].

	versionNeededToExtract _ aStream nextLittleEndianNumber: 2.
	bitFlag _ aStream nextLittleEndianNumber: 2.
	compressionMethod _ aStream nextLittleEndianNumber: 2.

	lastModFileDateTime _ aStream nextLittleEndianNumber: 4.
	xcrc32 _ aStream nextLittleEndianNumber: 4.
	xcompressedSize _ aStream nextLittleEndianNumber: 4.
	xuncompressedSize _ aStream nextLittleEndianNumber: 4.

	fileNameLength _ aStream nextLittleEndianNumber: 2.
	extraFieldLength _ aStream nextLittleEndianNumber: 2.

	fileName _ (aStream next: fileNameLength) asString asSqueakPathName.
	localExtraField _ (aStream next: extraFieldLength) asByteArray.

	dataOffset _ aStream position.

	"Don't trash these fields if we already got them from the central directory"
	self hasDataDescriptor ifFalse: [
		crc32 _ xcrc32.
		compressedSize _ xcompressedSize.
		uncompressedSize _ xuncompressedSize.
	].

	aStream position: oldPos.