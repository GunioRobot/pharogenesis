compressFile: aFileStream
	"Shamelessly copied and modified from StandardFileStream>>compressFile."
	
	| zipped buffer |
	aFileStream binary.
	zipped := StandardFileStream newFileNamed: (self directory fullNameFor: (aFileStream name, 'gz')).
	zipped binary; setFileTypeToObject.
	"Type and Creator not to be text, so can be enclosed in an email"
	zipped := GZipWriteStream on: zipped.
	buffer := ByteArray new: 50000.
	[[aFileStream atEnd] whileFalse: [
		zipped nextPutAll: (aFileStream nextInto: buffer)]]
		ensure: [zipped close. aFileStream close].
	self directory deleteFileNamed: aFileStream name