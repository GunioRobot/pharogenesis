writeImageFile: imageBytes

	| headerStart headerSize f bytesWritten |
	self var: #f declareC: 'sqImageFile f'.

	"local constants"
	headerStart _ 0.  "change to 512 to leave room for a Unix exec string"
	headerSize _ 64.  "header size in bytes; do not change!"

	f _ self cCode: 'sqImageFileOpen(imageName, "wb")'.
	f = nil ifTrue: [
		"could not open the image file for writing"
		self success: false.
		^ nil].

	self cCode: '/* Note: on Unix systems one could put an exec command here, padded to 512 bytes */'.
	"position file to start of header"
	self sqImageFile: f Seek: headerStart.

	self putLong: (self imageFormatVersion) toFile: f.
	self putLong: headerSize toFile: f.
	self putLong: imageBytes toFile: f.
	self putLong: (self startOfMemory) toFile: f.
	self putLong: specialObjectsOop toFile: f.
	self putLong: lastHash toFile: f.
	self putLong: (self ioScreenSize) toFile: f.
	1 to: 9 do: [:i | self putLong: 0 toFile: f].  "fill remaining header words with zeros"
	successFlag ifFalse: [
		"file write or seek failure"
		self cCode: 'sqImageFileClose(f)'.
		^ nil].

	"position file after the header"
	self sqImageFile: f Seek: headerStart + headerSize.

	"write the image data"
	bytesWritten _ self cCode: 'sqImageFileWrite(memory, sizeof(unsigned char), imageBytes, f)'.
	self success: bytesWritten = imageBytes.
	self cCode: 'sqImageFileClose(f)'.

	"set Mac file type and creator; this is a noop on other platforms"
	self cCode: 'dir_SetMacFileTypeAndCreator(imageName, strlen(imageName), "STim", "FAST")'.
