contents: aString
	contents _ aString.
	compressedSize _ uncompressedSize _ aString size.
	"set the file date to now"
	self setLastModFileDateTimeFrom: Time totalSeconds