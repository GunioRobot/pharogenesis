initialize
	super initialize.
	lastModFileDateTime _ 0.
	fileAttributeFormat _ FaUnix.
	versionMadeBy _ 20.
	versionNeededToExtract _ 20.
	bitFlag _ 0.
	compressionMethod _ CompressionStored.
	desiredCompressionMethod _ CompressionDeflated.
	desiredCompressionLevel _ CompressionLevelDefault.
	internalFileAttributes _ 0.
	externalFileAttributes _ 0.
	fileName _ ''.
	cdExtraField _ ''.
	localExtraField _ ''.
	fileComment _ ''.
	crc32 _ 0.
	compressedSize _ 0.
	uncompressedSize _ 0.
	self unixFileAttributes: DefaultFilePermissions.