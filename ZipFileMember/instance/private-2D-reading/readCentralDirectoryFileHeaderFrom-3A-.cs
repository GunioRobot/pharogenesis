readCentralDirectoryFileHeaderFrom: aStream
	"Assumes aStream positioned after signature"

	| fileNameLength extraFieldLength fileCommentLength |

	versionMadeBy _ aStream nextLittleEndianNumber: 1.
	fileAttributeFormat _ aStream nextLittleEndianNumber: 1.

	versionNeededToExtract _ aStream nextLittleEndianNumber: 2.
	bitFlag _ aStream nextLittleEndianNumber: 2.
	compressionMethod _ aStream nextLittleEndianNumber: 2.

	lastModFileDateTime _ aStream nextLittleEndianNumber: 4.
	crc32 _ aStream nextLittleEndianNumber: 4.
	compressedSize _ aStream nextLittleEndianNumber: 4.
	uncompressedSize _ aStream nextLittleEndianNumber: 4.

	fileNameLength _ aStream nextLittleEndianNumber: 2.
	extraFieldLength _ aStream nextLittleEndianNumber: 2.
	fileCommentLength _ aStream nextLittleEndianNumber: 2.
	aStream nextLittleEndianNumber: 2. 	"disk number start"
	internalFileAttributes _ aStream nextLittleEndianNumber: 2.

	externalFileAttributes _ aStream nextLittleEndianNumber: 4.
	localHeaderRelativeOffset _ aStream nextLittleEndianNumber: 4.

	fileName _ (aStream next: fileNameLength) asString asSqueakPathName.
	cdExtraField _ (aStream next: extraFieldLength) asByteArray asString.
	fileComment _ (aStream next: fileCommentLength) asString convertFromSystemString.

	self desiredCompressionMethod: compressionMethod