skipLocalDirectoryFileHeaderFrom: aStream 
	"Assumes that stream is positioned after signature."

	|  extraFieldLength fileNameLength |
	aStream next: 22.
	fileNameLength _ aStream nextLittleEndianNumber: 2.
	extraFieldLength _ aStream nextLittleEndianNumber: 2.
	aStream next: fileNameLength.
	aStream next: extraFieldLength.
	dataOffset _ aStream position.
